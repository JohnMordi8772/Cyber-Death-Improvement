/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// An abstract ScriptableObject that holds an ability's data.
    /// </summary>
    public abstract class IAbilityData : ScriptableObject
    {
        [SerializeField] private string abilityName;
        public string AbilityName
        {
            get
            {
                return abilityName;
            }
        }

        [Tooltip("Time in seconds this ability coolsdown for.")]
        [SerializeField] private Stat cooldownTime;
        public Stat CooldownTime
        {
            get
            {
                return cooldownTime;
            }
        }
    }
}
