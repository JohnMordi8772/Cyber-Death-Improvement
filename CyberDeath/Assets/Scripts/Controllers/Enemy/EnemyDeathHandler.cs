/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/15/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(Health))]
    public class EnemyDeathHandler : MonoBehaviour
    {
        private Health health;

        [Tooltip("Channel used to handle wave change events.")]
        [SerializeField] private IntChannelSO waveChannel;
        [Tooltip("Prefab holding the gibs for this enemy.")]
        [SerializeField] private Transform gibPrefab;
        [Tooltip("Scrap prefab so player can collect it for currency.")]
        [SerializeField] private GameObject scrapPrefab;
        [SerializeField] GameObject enemyPartPrefab;
        [SerializeField] private AudioClipChannelSO sfxChannel;
        [SerializeField] private AudioClipSO deathSFX;

        private Transform gibClone;
        
        /// <summary>
        /// Member variable initialization.
        /// </summary>
        private void Awake()
        {
            health = GetComponent<Health>();
        }

        private void Start()
        {
            gibClone = Instantiate(gibPrefab);
            gibClone.gameObject.SetActive(false);
        }

        #region -- // Event Subbing/UnSubbing // --
        private void OnEnable()
        {
            health.OnDeath += SpawnGibsWithScrap;
            waveChannel.OnEventRaised += OnWaveChange;
        }

        private void OnDisable()
        {
            health.OnDeath -= SpawnGibsWithScrap;
            waveChannel.OnEventRaised -= OnWaveChange;
        }
        #endregion

        /// <summary>
        /// Spawns in the gibs with scrap.
        /// </summary>
        private void SpawnGibsWithScrap()
        {
            Instantiate(scrapPrefab, transform.position, Quaternion.identity);
            if(Random.Range(0,100) < 10)
                Instantiate(enemyPartPrefab, transform.position, Quaternion.identity);
            SpawnGibs();
        }

        /// <summary>
        /// Spawns in gibs.
        /// </summary>
        private void SpawnGibs()
        {
            sfxChannel.RaiseEvent(deathSFX);
            gibClone.position = transform.position;
            gibClone.rotation = transform.rotation;

            gibClone.gameObject.SetActive(true);

            foreach (Transform child in gibClone)
            {
                if (child.TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(200f, transform.position, 10f);
                }
            }
        }

        /// <summary>
        /// Invoked when the wave number changes.
        /// </summary>
        /// <param name="waveNum">The wave number.</param>
        private void OnWaveChange(int waveNum)
        {
            // If the wave ends, spawn gibs and destroy the game object.
            if (waveNum == -1)
            {
                SpawnGibs();
                Destroy(gameObject);
            }
        }
    }
}
