/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Abilities/Slam Data")]
    public class SlamAbilityData : IAbilityData
    {
        [SerializeField] private Stat slamForce;
        public Stat DashForce
        {
            get
            {
                return slamForce;
            }
        }
        [SerializeField] private float slamDuration;
        public float SlamDuration
        {
            get
            {
                return slamDuration;
            }
        }

        [SerializeField] private float slamDamage;
        public float DashDamage
        {
            get
            {
                return slamDamage;
            }
        }

        [SerializeField] private float enemyKnockback = 0f;
        public float EnemyKnockBack
        {
            get
            {
                return enemyKnockback;
            }
        }

        [SerializeField] private float knockbackRange = 20f;
        public float KnockbackRange
        {
            get
            {
                return knockbackRange;
            }
        }
    }
}