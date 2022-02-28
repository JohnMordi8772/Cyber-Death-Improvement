/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Controls player ability usage.
    /// </summary>
    [RequireComponent(typeof(AbilityManager))]
    public class PlayerAbilityController : MonoBehaviour
    {
        private PlayerControls controls;
        private AbilityManager manager;

        [SerializeField] private BoolChannelSO controlsToggleChannel;

        /// <summary>
        /// Initializes member variables.
        /// </summary>
        private void Awake()
        {
            controls = new PlayerControls();
            manager = GetComponent<AbilityManager>();
        }

        /// <summary>
        /// Subscribes to events.
        /// </summary>
        private void OnEnable()
        {
            controls.Abilities.ActivateAbility.performed += _ => manager.Activate();
            controls.Abilities.SwapAbility.performed += _ => manager.SwapAbilities<NanobotsAbility>();

            controls.Abilities.Enable();

            controlsToggleChannel.OnEventRaised += ToggleControls;
        }

        /// <summary>
        /// Unsubs from events.
        /// </summary>
        private void OnDisable()
        {
            controls.Abilities.Disable();
            controlsToggleChannel.OnEventRaised -= ToggleControls;
        }

        private void ToggleControls(bool toggle)
        {
            if (toggle)
            {
                controls.Abilities.Enable();
            }
            else
            {
                controls.Abilities.Disable();
            }
        }
    }
}