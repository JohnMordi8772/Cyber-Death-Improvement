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
<<<<<<< HEAD
            controls.WeaponsHandling.Fire.started += _ => weaponUser.Fire();
            controls.WeaponsHandling.Fire.canceled += _ => weaponUser.ReleaseFire();
            controls.WeaponsHandling.Charge.started += _ => weaponUser.Charge();
            controls.WeaponsHandling.Charge.canceled += _ => weaponUser.ReleaseFire();
=======
            controls.WeaponsHandling.Fire.started += _ => weaponUser.PlayerFire();
            controls.WeaponsHandling.Fire.canceled += _ => weaponUser.PlayerReleaseFire();

>>>>>>> main
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