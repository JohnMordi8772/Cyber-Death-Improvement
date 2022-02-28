/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/12/2021
*******************************************************************/
using UnityEngine;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    /// <summary>
    /// Holds data related to the health of an entity.
    /// </summary>
    [CreateAssetMenu(menuName = "HealthData", fileName = "New HealthData")]
    public class HealthData : ScriptableObject
    {
        [Tooltip("True if the data is base data.")]
        [SerializeField] private bool isBaseData;
        [HideIf("isBaseData")]
        [SerializeField] private HealthData baseData;

        public Stat maxHealth;
        public float currentHealth;

        public void Init()
        {
            this.maxHealth = baseData.maxHealth;
            this.currentHealth = maxHealth.GetStat();
        }

        public void Init(HealthData baseData)
        {
            this.maxHealth = baseData.maxHealth;
            this.currentHealth = maxHealth.GetStat();
        }
    }
}