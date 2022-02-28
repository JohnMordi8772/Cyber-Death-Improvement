/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/15/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField] private string statName;
        [SerializeField] private float baseStat;
        
        public Stat(Stat stat)
        {
            this.statName = stat.statName;
            this.baseStat = stat.baseStat;
        }

        public Stat()
        { }

        public Stat(string statName, float baseStat)
        {
            this.statName = statName;
            this.baseStat = baseStat;
        }

        public virtual string GetName()
        {
            return statName;
        }

        public virtual float GetStat()
        {
            return baseStat;
        }
    }
}