/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/28/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    [CreateAssetMenu]
    public class Armor : ScriptableObject
    {
        [SerializeField] private Stat baseStat;
        [SerializeField] private Stat currentArmor;
        private float armorLevel;

        public Stat CurrentArmor
        {
            get
            {
                return currentArmor;
            }

            set
            {
                currentArmor = value;
                armorLevel = currentArmor.GetStat();
            }
        }
        
        public void Init()
        {
            armorLevel = baseStat.GetStat();
        }

        public float GetArmorLevel()
        {
            return armorLevel;
        }
    }
}
