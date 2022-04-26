/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/13/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GoofyGhosts
{
    /// <summary>
    /// Manages spawning waves of enemies.
    /// </summary>
    public class WaveManager : MonoBehaviour
    {
        /// <summary>
        /// The current wave number.
        /// </summary>
        public int waveNumber;
        /// <summary>
        /// The total enemy count for the current wave.
        /// </summary>
        public int totalEnemyCount;
        /// <summary>
        /// The number of enemies killed on the current wave.
        /// </summary>
        public int enemyKillCount;

        [Header("The wave to begin on.")]
        [Min(1)] [SerializeField] private int startingWave;

        [Header("Enemy Health Data")]
        [SerializeField] HealthData baseEnemyData;
        [SerializeField] HealthData fastEnemyData;
        [SerializeField] HealthData rangedEnemyData;
        [SerializeField] HealthData tankEnemyData;

        [Header("Enemy Weapon Data")]
        [SerializeField] WeaponData baseFist;
        [SerializeField] WeaponData fastFist;
        [SerializeField] WeaponData rangedWeapon;
        [SerializeField] WeaponData tankFist;

        [Header("Channels")]
        [Tooltip("Channel used to signal when a new wave starts.")]
        [SerializeField] private IntChannelSO waveChannel;
        [Tooltip("Channel used to signal a change in the required enemy count.")]
        [SerializeField] private IntChannelSO enemiesRemainingChannel;
        [Tooltip("Channel used to handle increasing enemy kill count.")]
        [SerializeField] private VoidChannelSO enemyDeathChannel;
        [Tooltip("Channel used to handle requests to progress to the next wave.")]
        [SerializeField] private VoidChannelSO progressWaveChannel;
        [Header("Audio")]
        [SerializeField] private AudioClipChannelSO audioClipChannel;
        [SerializeField] private AudioClipSO waveEndSFX;
        [SerializeField] private AudioClipSO waveEnd2SFX;
        [SerializeField] private AudioClipSO waveStartSFX;

        public bool playerDead;

        /// <summary>
        /// Initialization.
        /// </summary>
        private void Awake()
        {
            waveNumber = 0;
            playerDead = false;

            baseEnemyData.Init();
            fastEnemyData.Init();
            //rangedEnemyData.Init();
            tankEnemyData.Init();

            baseFist.Hydrate();
            fastFist.Hydrate();
            rangedWeapon.Hydrate();
            tankFist.Hydrate();
        }

        #region -- // Event Subbing / UnSubbing // --
        private void OnEnable()
        {
            enemyDeathChannel.OnEventRaised += OnEnemyDeath;
            progressWaveChannel.OnEventRaised += ProgressWave;
        }

        private void OnDisable()
        {
            enemyDeathChannel.OnEventRaised -= OnEnemyDeath;
            progressWaveChannel.OnEventRaised -= ProgressWave;
        }
        #endregion

        /// <summary>
        /// Progresses to the first wave.
        /// </summary>
        void Start()
        {
            waveNumber = startingWave - 1;
        }

        /// <summary>
        /// Progresses the wave to the next wave.
        /// </summary>
        public void ProgressWave()
        {
            audioClipChannel.RaiseEvent(waveStartSFX);

            enemyKillCount = 0;

            ++waveNumber;
            totalEnemyCount = GetNumEnemiesForWave(waveNumber);
            ScrapCounter.scrapPerPile = GetScrapPerPile(waveNumber);
            waveChannel.RaiseEvent(waveNumber);
            enemiesRemainingChannel.RaiseEvent(totalEnemyCount);
        }

        /// <summary>
        /// Returns the scrap per pile the player will receive.
        /// </summary>
        /// <param name="waveNumber">The wave number.</param>
        /// <returns>The scrap per pile the player will receive.</returns>
        private int GetScrapPerPile(int waveNumber)
        {
            //// Taken from Anthony's Wave Distribution Chart on Google Drive.
            //if (waveNumber < 5)
                  return 1;
            //else if (waveNumber < 7)
            //    return 5;
            //else if (waveNumber < 10)
            //    return 6;
            //else if (waveNumber < 11)
            //    return 7;
            //else if (waveNumber < 12)
            //    return 8;
            //else if (waveNumber < 13)
            //    return 9;
            //else if (waveNumber < 14)
            //    return 10;
            //else if (waveNumber < 15)
            //    return 11;
            //else if (waveNumber < 16)
            //    return 13;
            //else if (waveNumber < 17)
            //    return 15;
            //else if (waveNumber < 18)
            //    return 17;
            //else if (waveNumber < 19)
            //    return 19;
            //else if (waveNumber < 20)
            //    return 21;
            //else
            //    return 23;
        }

        /// <summary>
        /// Returns the number of enemies to spawn for the given wave.
        /// </summary>
        /// <param name="waveNum">The wave number.</param>
        /// <returns>The number of enemies to spawn.</returns>
        public static int GetNumEnemiesForWave(int waveNum)
        {
            int num = Mathf.FloorToInt(
                Mathf.Pow(1.3f, waveNum) + 5);

            return num;
        }

        /// <summary>
        /// Invoked when an enemy dies.
        /// </summary>
        private void OnEnemyDeath()
        {
            ++enemyKillCount;
            SpawnPoint.spawnCount--;
            enemiesRemainingChannel.RaiseEvent(totalEnemyCount - enemyKillCount);

            // If all enemies have been killed, signal
            // all spawn points to stop spawning.
            if (enemyKillCount >= totalEnemyCount)
            {
                OnWaveComplete();
            }
        }

        /// <summary>
        /// Invoked when the wave is over. Raises the wave channel's event with
        /// a value of -1 to signify any observers that the wave is over.
        /// </summary>
        private void OnWaveComplete()
        {
            waveChannel.RaiseEvent(-1);
            audioClipChannel.RaiseEvent(waveEndSFX);
            audioClipChannel.RaiseEvent(waveEnd2SFX);

            if ( ((waveNumber + 1) % 5 )== 0)
            {
                float increment;

                baseEnemyData.maxHealth = new StatUpgrade(baseEnemyData.maxHealth, increment = baseEnemyData.maxHealth.GetStat() * 0.1f);
                baseEnemyData.currentHealth += increment;
                baseFist.attackDamage = new StatUpgrade(baseFist.attackDamage, 1);

                fastEnemyData.maxHealth = new StatUpgrade(fastEnemyData.maxHealth, increment = fastEnemyData.maxHealth.GetStat() * 0.1f);
                fastEnemyData.currentHealth += increment;
                fastFist.attackDamage = new StatUpgrade(fastFist.attackDamage, 1);

                //rangedEnemyData.maxHealth = new StatUpgrade(rangedEnemyData.maxHealth, increment = rangedEnemyData.maxHealth.GetStat() * 0.05f);
                //rangedEnemyData.currentHealth += increment;
                rangedWeapon.attackDamage = new StatUpgrade(rangedWeapon.attackDamage, 1);

                tankEnemyData.maxHealth = new StatUpgrade(tankEnemyData.maxHealth, increment = tankEnemyData.maxHealth.GetStat() * 0.1f);
                tankEnemyData.currentHealth += increment;
                tankFist.attackDamage = new StatUpgrade(tankFist.attackDamage, 1);
            }

        }

        public void PlayerDeath()
        {
            playerDead = true;
            waveChannel.RaiseEvent(-1);
        }

        public IntChannelSO GetWaveChannel()
        {
            return waveChannel;
        }
    }
}