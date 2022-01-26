/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/17/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(IInteractor))]
    public class PlayerInteractionController : MonoBehaviour
    {
        private IInteractor interactor;
        private PlayerControls controls;

        [SerializeField] private BoolChannelSO controlsToggleChannel;

        private void Awake()
        {
            interactor = GetComponent<IInteractor>();
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.Interaction.Interact.performed += _ => interactor.Interact();
            controls.Interaction.Enable();

            controlsToggleChannel.OnEventRaised += ToggleControls;
        }

        private void OnDisable()
        {
            controls.Interaction.Disable();
            controlsToggleChannel.OnEventRaised -= ToggleControls;
        }

        private void ToggleControls(bool toggle)
        {
            if (toggle)
            {
                controls.Interaction.Enable();
            }
            else
            {
                controls.Interaction.Disable();
            }
        }
    }
}