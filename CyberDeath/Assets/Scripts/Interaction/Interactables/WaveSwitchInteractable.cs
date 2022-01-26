/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/17/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    public class WaveSwitchInteractable : MonoBehaviour, IInteractable
    {
        /// <summary>
        /// True if the switch is in the on state.
        /// </summary>
        private bool active
        {
            set
            {
                // Turn the switch on, disable interaction.
                if (value == true)
                {
                    bgm.PlayBGM();
                    offState.SetActive(false);
                    onState.SetActive(true);
                    waveCompleted = false;
                    trigger.enabled = false;
                    anim.SetTrigger("back");
                }
                // Turn the switch off, enable interaction.
                else
                {
                    offState.SetActive(true);
                    onState.SetActive(false);
                    waveCompleted = true;
                    trigger.enabled = true;
                }
            }
        }
        /// <summary>
        /// True if the wave has finished.
        /// </summary>
        private bool waveCompleted;

        /// <summary>
        /// Reference to the trigger.
        /// </summary>
        private Collider trigger;

        private Animator anim;

        private BGMPlayer bgm;

        [Header("Game Objects")]
        [SerializeField] private GameObject onState;
        [SerializeField] private GameObject offState;
        [SerializeField] private GameObject popup;
        [SerializeField] private GameObject bgmManager;

        [Header("Channels")]
        [SerializeField] private IntChannelSO waveChangeChannel;
        [SerializeField] private VoidChannelSO waveProgressChannel;


        /// <summary>
        /// Initialization.
        /// </summary>
        private void Awake()
        {
            trigger = GetComponent<Collider>();

            anim = popup.GetComponent<Animator>();

            bgm = bgmManager.GetComponent<BGMPlayer>();

            // The wave does not immediately start. Therefore, we'll
            // set this to false.
            waveCompleted = true;
        }

        /// <summary>
        /// Deactivate the switch.
        /// </summary>
        void Start()
        {
            active = false;
        }

        #region -- // Event Handling // --
        private void OnEnable()
        {
            waveChangeChannel.OnEventRaised += OnWaveChange;
        }

        private void OnDisable()
        {
            waveChangeChannel.OnEventRaised -= OnWaveChange;
        }
        #endregion


        /// <summary>
        /// Progresses to the next wave if the current wave has completed.
        /// </summary>
        /// <param name="interactor">The interactor handling this interactable.</param>
        public void Interact(IInteractor interactor)
        {
            if (waveCompleted)
            {
                interactor.UnassignInteractable(); // Unassign the interactable because the trigger gets turned off, and the
                                                   // interactor cannot unassign this itself.
                active = true;
                waveProgressChannel.RaiseEvent();
            }
        }

        public void OnAssigned(IInteractor interactor)
        {
            anim.SetTrigger("interact");
            // TODO: Display UI.
        }

        public void OnUnassigned(IInteractor interactor)
        {
            anim.SetTrigger("back");
            // TODO: Hide UI.
        }

        /// <summary>
        /// Turns the switch to the off state if the wave has ended.
        /// </summary>
        /// <param name="waveNum">The current wave number.</param>
        private void OnWaveChange(int waveNum)
        {
            if (waveNum == -1)
            {
                active = false;
            }
        }
    }
}