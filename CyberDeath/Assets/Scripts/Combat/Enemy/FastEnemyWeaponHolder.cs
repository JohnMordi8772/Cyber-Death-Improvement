/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public sealed class FastEnemyWeaponHolder : WeaponUser
    {
        /// <summary>
        /// Starts the attack animation.
        /// </summary>
        /// <returns>True if the weapon animation began.</returns>
        public override void Fire()
        {
            // Since everything is controlled via animation events, we don't need
            // to worry aboout checking for cooldowns.
            if (currentWeapon != null)
            {
                currentWeapon.Fire();

                if (anim != null && anim.GetInteger("Fire0") == 0)
                {
                    anim.SetFloat("FireMultiplier", currentWeapon.AttackSpeed);
                    anim.SetInteger("Fire0", 1);
                }
            }
        }

        /// <summary>
        /// Invoked when the weapon should stop firing.
        /// </summary>
        public override void ReleaseFire()
        {
            base.ReleaseFire();
            // print("Calling enemy release fire");
            anim.SetInteger("Fire0", 0);
        }
    }
}
