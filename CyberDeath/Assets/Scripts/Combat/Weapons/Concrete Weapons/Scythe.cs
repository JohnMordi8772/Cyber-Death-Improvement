/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace GoofyGhosts
{
    /// <summary>
    /// The player's main weapon. Slashes through hordes of enemies.
    /// </summary>
    public class Scythe : IWeapon
    {
        public List<GameObject> weaponList = new List<GameObject> { };

        private Collider scytheCollider;
        int i;
        PlayerControls controls;
        [SerializeField] WeaponData[] weaponReference;//scythereference, swordReference;
        [SerializeField] TextMeshProUGUI weaponText;
        [SerializeField] public List<RuntimeAnimatorController> weaponAnimList = new List<RuntimeAnimatorController> { };
        //[SerializeField] public List<GameObject> weaponUI = new List<GameObject> { };
        public Animator playAnim;

        public bool onBow;
        bool shooting;

        [SerializeField] GameObject arrow;
        [SerializeField] Transform player;

        #region -- // Init // --
        protected override void Awake()
        {
            base.Awake();
            i = 0;
            controls = new PlayerControls();
            scytheCollider = GetComponent<Collider>();
            playAnim = GameObject.Find("Player_Updated").GetComponent<Animator>();
            scytheCollider.enabled = false;
        }

        private void OnEnable()
        {
            //controls.WeaponsHandling.SwapWeapon.performed += _ => SwapWeapon();
            //controls.WeaponsHandling.Enable();
        }

        public void SwapWeapon(int j)
        {
            weaponList[0].SetActive(false);
            weaponList[j].SetActive(true);
            playAnim.runtimeAnimatorController = weaponAnimList[j];
            
            //if (i < weaponReference.Length - 1)
            //{
            //    scytheCollider.enabled = false;
            //    weaponList[i].SetActive(false);
            //    //weaponUI[i].SetActive(false);
            //    data = weaponReference[++i];
            //    weaponList[i].SetActive(true);
            //    scytheCollider = weaponList[i].GetComponent<Collider>();
            //    //weaponUI[i].SetActive(true);
            //    weaponText.text = "Current Weapon: " + weaponReference[i].weaponName;
            //    playAnim.runtimeAnimatorController = weaponAnimList[i];
            //    //if(weaponAnimList[i].name == "PlayerBow")
            //    //{
            //    //    onBow = true;
            //    //}
            //    //else
            //    //{
            //    //    onBow = false;
            //    //}
            //}
            //else
            //{
            //    weaponList[i].SetActive(false);
            //    //weaponUI[i].SetActive(false);
            //    i = 0;
            //    data = weaponReference[i];
            //    weaponList[i].SetActive(true);
            //    scytheCollider = weaponList[i].GetComponent<Collider>();
            //    //weaponUI[i].SetActive(true);
            //    weaponText.text = "Current Weapon: " + weaponReference[i].weaponName;
            //    playAnim.runtimeAnimatorController = weaponAnimList[i];
            //}
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
            if(other.gameObject.tag != "Player")
                damageable?.TakeDamage(WeaponDamage);
        }

        private void Update()
        {
            //if (onBow == true && playAnim.GetBool("Fire") == true)
            //{
            //    Invoke("SpawnArrows", 0.6f);
            //    //shooting = true;
            //    //SpawnArrows();
            //}
            //if(onBow == true && playAnim.GetBool("Fire") == false)
            //{
            //    //shooting = false;
            //    CancelInvoke("SpawnArrows");
            //}
        }

        //void SpawnArrows()
        //{
        //    //Plane playerPlane = new Plane(Vector3.up, player.position);
        //    //Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //    //float hitDist = 0.0f;
        //    //if(playerPlane.Raycast(ray, out hitDist))
        //    //{
        //    //    Vector3 targetPoint = ray.GetPoint(hitDist);
        //    //    Quaternion targetRotation = Quaternion.LookRotation(targetPoint - player.position);
        //    //    targetRotation.x = 0;
        //    //    targetRotation.z = 0;
        //    //    Instantiate(arrow, player.position + new Vector3(0, 2, 0), targetRotation);
        //    //}
        //    Instantiate(arrow, player.position + new Vector3(0, 2, 0), player.rotation);
            
        //}
    }
}