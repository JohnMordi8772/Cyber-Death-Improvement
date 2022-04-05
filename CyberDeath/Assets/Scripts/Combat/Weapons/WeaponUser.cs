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
        [SerializeField] public Animator anim;
        protected IWeapon currentWeapon;

        protected bool firing;

        private UnityAction SetFireToFalse;

        /// <summary>
        /// Member variable initialization.
        /// </summary>
        private void Awake()
        {
            //IWeapon weapon = weaponHolder.GetComponentInChildren<IWeapon>();
            SetFireToFalse = () => anim.SetBool("Fire", false);
            //anim.SetInteger("Fire0", 1);

            //SwapWeapon(weapon);
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
            currentWeapon.gameObject.SetActive(true);
            Physics.IgnoreCollision(currentWeapon.GetComponent<Collider>(), GetComponent<Collider>());
        }

        /// <summary>
        /// Fires / uses the weapon.
        /// </summary>
        public virtual void Fire()
        {
            //Debug.Log("WeaponUser: Fire");
            if (anim.GetBool("Fire") == false)
            {
                anim.SetFloat("FireMultiplier", currentWeapon.AttackSpeed);
                anim.SetBool("Fire", true);
            }
        }

        public virtual void PlayerFire()
        {
            //Debug.Log("WeaponUser: PlayerFire");
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
            //Debug.Log("WeaponUser: ReleaseFire");
            firing = false;
            if (anim.GetBool("Spin") == true)
            {
                print("released mouse. Spinning");
                anim.SetBool("Spin", false);
            }
        }

        public virtual void PlayerReleaseFire()
        {
            //anim.SetBool("Fire", false);
            //Debug.Log("WeaponUser: PlayerReleaseFire");
            firing = false;

            if(anim.GetBool("Spin") == true)
            {
                print("released mouse. Spinning");
                anim.SetBool("Spin", false);
            }
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

        public virtual void Charge()
        {
            print("charging. Spin is true");
                anim.SetBool("Spin", true);
            
        }
    }
}