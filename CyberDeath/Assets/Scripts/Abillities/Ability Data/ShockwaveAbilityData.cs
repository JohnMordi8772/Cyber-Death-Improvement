/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Abilities/Shockwave Data")]
    public class ShockwaveAbilityData : IAbilityData
    {
        [SerializeField] private Stat shockForce;
        public Stat ShockForce
        {
            get
            {
                return shockForce;
            }
        }
        [SerializeField] private float shockDuration;
        public float ShockDuration
        {
            get
            {
                return shockDuration;
            }
        }

        [SerializeField] private float shockDamage;
        public float ShockDamage
        {
            get
            {
                return shockDamage;
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