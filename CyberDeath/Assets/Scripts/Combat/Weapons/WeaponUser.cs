/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace GoofyGhosts
{
    /// <summary>
    /// An entity that is able to use weapons.
    /// </summary>
    [DisallowMultipleComponent]
    public class WeaponUser : MonoBehaviour
    {
        [SerializeField] private Transform weaponHolder;
        [SerializeField] protected Animator anim;

        protected IWeapon currentWeapon;

        private bool firing;

        private UnityAction SetFireToFalse;

        /// <summary>
        /// Member variable initialization.
        /// </summary>
        private void Awake()
        {
            IWeapon weapon = weaponHolder.GetComponentInChildren<IWeapon>();
            SetFireToFalse = () => anim.SetBool("Fire", false);


            SwapWeapon(weapon);
        }

        #region -- // Event Handling // --
        private void OnEnable()
        {
            PlayerAttackStateAnimBehaviour.OnStateEnterAction += SetFireToFalse;
        }

        private void OnDisable()
        {
            PlayerAttackStateAnimBehaviour.OnStateEnterAction -= SetFireToFalse;
        }
        #endregion

        public void SwapWeapon(IWeapon weapon)
        {
            currentWeapon = weapon;
            Physics.IgnoreCollision(currentWeapon.GetComponent<Collider>(), GetComponent<Collider>());
        }

        /// <summary>
        /// Fires / uses the weapon.
        /// </summary>
        public virtual void Fire()
        {
            if (anim.GetBool("Fire") == false)
            {
                anim.SetFloat("FireMultiplier", currentWeapon.AttackSpeed);
                anim.SetBool("Fire", true);
            }
        }

        /// <summary>
        /// Rapidly fires the weapon.
        /// </summary>
        private IEnumerator RapidFire()
        {
            while (firing)
            {
                bool fired = currentWeapon.Fire();

                if (anim != null && fired)
                {
                    anim.SetFloat("FireMultiplier", currentWeapon.AttackSpeed);
                    anim.SetBool("Fire", true);
                }

                yield return null;
            }

            anim.SetBool("Fire", false);
        }

        /// <summary>
        /// Invoked when the weapon should stop firing.
        /// </summary>
        public virtual void ReleaseFire()
        {
            //anim.SetBool("Fire", false);
            firing = false;
        }

        /// <summary>
        /// Completes the weapon's cooldown.
        /// </summary>
        public void CompleteCooldown()
        {
            currentWeapon.CompleteCooldown();
        }

        public void EnableWeaponCollider()
        {
            currentWeapon.EnableCollider();
        }

        public void DisableWeaponCollider()
        {
            currentWeapon.DisableCollider();
        }
    }
}