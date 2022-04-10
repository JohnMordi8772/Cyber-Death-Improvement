using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    public class WeaponChoice : MonoBehaviour
    {
        public IWeapon weapon;
        public WeaponUser weaponUser;
        public GameObject weaponStats;
        public GameObject weaponModel;
        public GameObject playerWeapon;
        IntChannelSO manager;
        bool interactive, within;
        PlayerControls controls;
        // Start is called before the first frame update
        void Awake()
        {
            interactive = false;
            within = false;
            controls = new PlayerControls();
            manager = FindObjectOfType<WaveManager>().GetWaveChannel();
            manager.OnEventRaised += _ => EndChoices();
            controls.Interaction.Interact.started += _ => ChooseWeapon();

        }

        private void OnEnable()
        {
            controls.Interaction.Interact.Enable();
        }

        private void OnDisable()
        {
            controls.Interaction.Interact.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                interactive = true;
                weaponStats.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player")
            {
                interactive = false;
                weaponStats.SetActive(false);
                within = false;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" && !within)
            {
                within = true;
                interactive = true;
                weaponStats.SetActive(true);
            }
        }

        void EndChoices()
        {
            Destroy(weaponModel);//weaponModel.SetActive(false);
        }

        void ChooseWeapon()
        {
            if (interactive)
            {
                weaponUser.SwapWeapon(weapon);
                playerWeapon.SetActive(true);
            }
        }
    }
}
