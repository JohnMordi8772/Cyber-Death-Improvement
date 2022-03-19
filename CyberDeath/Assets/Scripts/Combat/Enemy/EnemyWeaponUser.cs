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
    public sealed class EnemyWeaponUser : WeaponUser
    {
        /// <summary>
        /// Starts the attack animation.
        /// </summary>
        /// <returns>True if the weapon animation began.</returns>
        public override void Fire()
        {
            //Debug.Log("EnemyWeaponUser: Fire");
            // Since everything is controlled via animation events, we don't need
            // to worry aboout checking for cooldowns.
            if (currentWeapon != null)
            {
                currentWeapon.Fire();

                if (anim != null && anim.GetBool("Fire") == false)
                {
                    anim.SetFloat("FireMultiplier", currentWeapon.AttackSpeed);
                    anim.SetBool("Fire", true);
                }
            }
        }

        /// <summary>
        /// Invoked when the weapon should stop firing.
        /// </summary>
        public override void ReleaseFire()
        {
            //Debug.Log("EnemyWeaponUser: ReleaseFire");
            base.ReleaseFire();
            // print("Calling enemy release fire");
            anim.SetBool("Fire", false);
        }
    }
}
