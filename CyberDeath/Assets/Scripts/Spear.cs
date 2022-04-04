
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace GoofyGhosts
{
    /// <summary>
    /// The player's main weapon. Slashes through hordes of enemies.
    /// </summary>
    public class Spear : IWeapon
    {
        //public List<GameObject> weaponList = new List<GameObject> { };

        private Collider spearCollider;
        int i;
        PlayerControls controls;
        //[SerializeField] WeaponData[] weaponReference;//scythereference, swordReference;
        //[SerializeField] TextMeshProUGUI weaponText;
        //[SerializeField] public List<RuntimeAnimatorController> weaponAnimList = new List<RuntimeAnimatorController> { };

        //public Animator playAnim;

        #region -- // Init // --
        protected override void Awake()
        {
            base.Awake();
            i = 0;
            controls = new PlayerControls();
            spearCollider = GetComponent<Collider>();
            //playAnim = GameObject.Find("Player_Updated").GetComponent<Animator>();
        }

        //private void OnEnable()
        //{
        //    //controls.WeaponsHandling.SwapWeapon.performed += _ => SwapWeapon();
        //    //controls.WeaponsHandling.Enable();
        //}
        /*
        void SwapWeapon()
        {
            if (i < weaponReference.Length - 1)
            {
                weaponList[i].SetActive(false);
                data = weaponReference[++i];
                weaponList[i].SetActive(true);
                weaponText.text = "Current Weapon: " + weaponReference[i].weaponName;
                playAnim.runtimeAnimatorController = weaponAnimList[i];
            }
            else
            {
                weaponList[i].SetActive(false);
                i = 0;
                data = weaponReference[i];
                weaponList[i].SetActive(true);
                weaponText.text = "Current Weapon: " + weaponReference[i].weaponName;
                playAnim.runtimeAnimatorController = weaponAnimList[i];
            }
        }
        */
        private void Start()
        {
            spearCollider.enabled = false;
        }
        #endregion

        protected override void FireWeapon()
        {
            // Scythe weapon behaviour.
        }

        public override void EnableCollider()
        {
            spearCollider.enabled = true;
        }

        public override void DisableCollider()
        {
            spearCollider.enabled = false;
        }

        /// <summary>
        /// Attack any IDamageables that got hit by the scythe.
        /// TODO: Maybe slow the game down on hit? Or on combo?
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if(other.gameObject.tag != "Player")
                damageable?.TakeDamage(WeaponDamage);
        }
    }
}