/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    /// <summary>
    /// The player's main weapon. Slashes through hordes of enemies.
    /// </summary>
    public class Scythe : IWeapon
    {
        private Collider scytheCollider;
        PlayerControls controls;
        [SerializeField] WeaponData scythereference, swordReference;
        [SerializeField] TextMeshProUGUI weaponText;

        #region -- // Init // --
        protected override void Awake()
        {
            base.Awake();
            controls = new PlayerControls();
            scytheCollider = GetComponent<Collider>();
        }

        private void OnEnable()
        {
            controls.WeaponsHandling.SwapWeapon.performed += _ => SwapWeapon();
            controls.WeaponsHandling.Enable();
        }

        void SwapWeapon()
        {
            if (data.weaponName == "Scythe")
            {
                data = swordReference;
                weaponText.text = "Current Weapon: Sword";
            }
            else
            {
                data = scythereference;
                weaponText.text = "Current Weapon: Scythe";
            }
        }

        private void Start()
        {
            scytheCollider.enabled = false;
        }
        #endregion

        protected override void FireWeapon()
        {
            // Scythe weapon behaviour.
        }

        public override void EnableCollider()
        {
            scytheCollider.enabled = true;
        }

        public override void DisableCollider()
        {
            scytheCollider.enabled = false;
        }

        /// <summary>
        /// Attack any IDamageables that got hit by the scythe.
        /// TODO: Maybe slow the game down on hit? Or on combo?
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable?.TakeDamage(WeaponDamage);
        }
    }
}