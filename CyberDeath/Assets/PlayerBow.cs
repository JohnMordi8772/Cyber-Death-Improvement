using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class PlayerBow : IWeapon
    {
        //public List<GameObject> weaponList = new List<GameObject> { };

        private Collider bowCollider;
        int i;
        PlayerControls controls;
        public RuntimeAnimatorController bowAnimator;
        public GameObject arrow;
        GameObject player;
        //[SerializeField] WeaponData[] weaponReference;//scythereference, swordReference;
        //[SerializeField] TextMeshProUGUI weaponText;
        //[SerializeField] public List<RuntimeAnimatorController> weaponAnimList = new List<RuntimeAnimatorController> { };

        public Animator playAnim;

        #region -- // Init // --
        protected override void Awake()
        {
            base.Awake();
            i = 0;
            controls = new PlayerControls();
            bowCollider = GetComponent<Collider>();
            playAnim = GameObject.Find("Player_Updated").GetComponent<Animator>();
            playAnim.runtimeAnimatorController = bowAnimator;
            GameObject.FindGameObjectWithTag("Player");
        }

        private void OnEnable()
        {
            playAnim.runtimeAnimatorController = bowAnimator;
            //controls.WeaponsHandling.SwapWeapon.performed += _ => SwapWeapon();
            //controls.WeaponsHandling.Enable();
        }
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
            bowCollider.enabled = false;
        }
        #endregion

        protected override void FireWeapon()
        {
            Instantiate(arrow, player.transform.position, player.transform.rotation);
        }

        public override void EnableCollider()
        {
            bowCollider.enabled = true;
        }

        public override void DisableCollider()
        {
            bowCollider.enabled = false;
        }

        /// <summary>
        /// Attack any IDamageables that got hit by the scythe.
        /// TODO: Maybe slow the game down on hit? Or on combo?
        /// </summary>
        /// <param name="other">The Collider that entered the trigger.</param>
        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (other.gameObject.tag != "Player")
                damageable?.TakeDamage(WeaponDamage);
        }
    }
}
