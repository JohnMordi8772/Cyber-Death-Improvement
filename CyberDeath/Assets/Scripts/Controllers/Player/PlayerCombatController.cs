/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Handles obtaining input for the player using weapons.
    /// </summary>
    [RequireComponent(typeof(WeaponUser))]
    public class PlayerCombatController : MonoBehaviour
    {
        private PlayerControls controls;
        private PlayerWeaponUser weaponUser;

        [SerializeField] private GameObject scytheTrail;
        [SerializeField] private BoolChannelSO controlsToggleChannel;

        private void Awake()
        {
            controls = new PlayerControls();
            weaponUser = GetComponent<PlayerWeaponUser>();
        }

        private void OnEnable()
        {
            controls.WeaponsHandling.Fire.started += _ => weaponUser.PlayerFire();
            controls.WeaponsHandling.Fire.canceled += _ => weaponUser.PlayerReleaseFire();

            controls.WeaponsHandling.Enable();

            controlsToggleChannel.OnEventRaised += ToggleControls;
        }

        private void OnDisable()
        {
            controls.WeaponsHandling.Disable();
            controlsToggleChannel.OnEventRaised -= ToggleControls;
        }


        public void EnableScytheTrail()
        {
            scytheTrail.SetActive(true);
        }

        public void DisableScytheTrail()
        {
            scytheTrail.SetActive(false);
        }

        private void ToggleControls(bool toggle)
        {
            if (toggle)
            {
                controls.WeaponsHandling.Enable();
            }
            else
            {
                controls.WeaponsHandling.Disable();
            }
        }
    }
}