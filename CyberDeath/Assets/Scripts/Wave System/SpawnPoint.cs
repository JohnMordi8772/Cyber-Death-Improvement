/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/13/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    /// <summary>
    /// Behaviour for an enemy spawnpoint.
    /// </summary>
    public class SpawnPoint : MonoBehaviour
    {
        public static int spawnCount;
        int maxSpawnCount = 20;

        WaveManager manager;

        [SerializeField] private SpawnTimeInfo timeInfo;

        [Tooltip("The wave number this spawn point activates at.")]
        [SerializeField] private int requiredWaveNum;

        [Tooltip("Channel to handle wave progression.")]
        [SerializeField] private IntChannelSO waveChannel;

        [Tooltip("The enemies which spawn at this spawn point.")]
        [SerializeField] private EnemySpawnInfo[] spawnables;

        private void Start()
        {
            manager = GameObject.FindObjectOfType<WaveManager>();
            spawnCount = 0;
        }

        #region -- // Event Subbing / UnSubbing // --
        private void OnEnable()
        {
            waveChannel.OnEventRaised += StartSpawning;
        }

        private void OnDisable()
        {
            waveChannel.OnEventRaised -= StartSpawning;
        }
        #endregion

        /// <summary>
        /// Begins spawning enemies.
        /// </summary>
        /// <param name="waveNum">The current wave number.</param>
        private void StartSpawning(int waveNum)
        {
            // A wave number of -1 means stop spawning.
            if (waveNum == -1)
            {
                StopAllCoroutines();
                return;
            }

            // Don't spawn if the wave number has not been reached.
            if (waveNum < requiredWaveNum)
                return;

            //Debug.Log($"Starting wave {waveNum}", gameObject);
            List<EnemySpawnInfo> spawnableEnemies = GetSpawnableEnemies(waveNum);

            // Start the spawning process.
            StartCoroutine(SpawnEnemies(spawnableEnemies));
        }

        /// <summary>
        /// Spawns the enemies into the world.
        /// </summary>
        /// <param name="spawnableEnemies">The list of spawnable enemies.</param>
        private IEnumerator SpawnEnemies(List<EnemySpawnInfo> spawnableEnemies)
        {
            var sortedEnemies = spawnableEnemies.OrderBy(t => t.SpawnChance);

            // TODO: Check while the wave is still in session.
            // The WaveManager will use Anthony's function to determine when the wave ends - the y-axis of the graph.
            while(true)
            {
                float time = Random.Range(timeInfo.minTime, timeInfo.maxTime);
                //Debug.Log($"Waiting {time} seconds until spawn...", gameObject);
                yield return new WaitForSeconds(time);
                
                float chance = Random.Range(0f, 1f);
                //Debug.Log($"Chance to spawn is {chance * 100f}%", gameObject);

                foreach (var enemy in sortedEnemies)
                {
                    // Spawn the enemy if the chance checks out.
                    if (chance <= enemy.SpawnChance && spawnCount < maxSpawnCount && spawnCount < manager.totalEnemyCount - manager.enemyKillCount)
                    {
                        //Debug.Log($"Spawned enemy {enemy.Prefab.name} with a chance of {enemy.SpawnChance * 100f}%", gameObject);
                        Debug.Log(spawnCount);
                        SpawnEnemy(enemy.Prefab);
                        spawnCount++;
                        break;
                    }
                }
            }
            
        }

        /// <summary>
        /// Instantiates the enemy into the game world.
        /// </summary>
        /// <param name="enemy">The enemy GameObject.</param>
        private void SpawnEnemy(GameObject enemy)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }

        /// <summary>
        /// Returns a list of enemies that can spawn.
        /// </summary>
        /// <returns>A list of enemies that can spawn.</returns>
        private List<EnemySpawnInfo> GetSpawnableEnemies(int waveNum)
        {
            return spawnables.Where(t => t.WaveNumber <= waveNum).ToList();
        }
    }

    /// <summary>
    /// Holds a min and max time.
    /// </summary>
    [System.Serializable]
    public struct SpawnTimeInfo
    {
        public float minTime;
        public float maxTime;
    }
}
