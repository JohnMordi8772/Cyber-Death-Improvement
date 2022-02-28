/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Abilities/Dash Data")]
    public class DashAbilityData : IAbilityData
    {
        [SerializeField] private Stat dashForce;
        public Stat DashForce
        {
            get
            {
                return dashForce;
            }
        }
        [SerializeField] private float dashDuration;
        public float DashDuration
        {
            get
            {
                return dashDuration;
            }
        }

        [SerializeField] private float dashDamage;
        public float DashDamage
        {
            get
            {
                return dashDamage;
            }
        }

        [SerializeField] private float enemyKnockback = 10f;
        public float EnemyKnockBack
        {
            get
            {
                return enemyKnockback;
            }
        }

        [SerializeField] private float knockbackRange = 10f;
        public float KnockbackRange
        {
            get
            {
                return knockbackRange;
            }
        }
    }
}