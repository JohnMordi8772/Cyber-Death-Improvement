/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/13/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Holds spawn information requied to spawn an enemy.
    /// </summary>
    [CreateAssetMenu(menuName = "Wave Management/Enemy Spawn Info", fileName = "New Enemy Spawn Info")]
    public class EnemySpawnInfo : ScriptableObject
    {
        [Tooltip("The enemy prefab.")]
        [SerializeField] private GameObject prefab;
        /// <summary>
        /// The enemy prefab.
        /// </summary>
        public GameObject Prefab
        {
            get
            {
                return prefab;
            }
        }

        [Tooltip("The wave number at which this enemy will be able to be spawned in.")]
        [SerializeField] private int waveNumber;
        /// <summary>
        /// The wave number at which this enemy will be able to be spawned in.
        /// </summary>
        public int WaveNumber
        {
            get
            {
                return waveNumber;
            }
        }

        [Tooltip("The chance this enemy will spawn.")]
        [Range(0,1)][SerializeField] private float spawnChance;
        /// <summary>
        /// The chance this enemy will spawn.
        /// </summary>
        public float SpawnChance
        {
            get
            {
                return spawnChance;
            }
        }
    }
}