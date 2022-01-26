/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/17/2021
*******************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GoofyGhosts
{
    public class AbilityAvailableUI : MonoBehaviour
    {
        /// <summary>
        /// Action invoked when the cooldown begins.
        /// </summary>
        private UnityAction<float> StartCooldown;

        [SerializeField] private Image iconImage;
        private Color availableColor;
        [SerializeField] private Color unavailableColor;

        [Tooltip("The Image that will display the cooldown time.")]
        [SerializeField] private Animator iconAnimator;

        [Tooltip("Channel used to handle an ability's cooldown.")]
        [SerializeField] private FloatChannelSO abilityCooldownChannel;

        private void Awake()
        {
            StartCooldown = time =>
            {
                StopAllCoroutines();
                StartCoroutine(AnimateIcon(time));
            };

            availableColor = iconImage.color;
        }

        #region -- // Event subbing / unsubbing // --
        private void OnEnable()
        {
            abilityCooldownChannel.OnEventRaised += StartCooldown;
        }

        private void OnDisable()
        {
            abilityCooldownChannel.OnEventRaised -= StartCooldown;
        }
        #endregion

        /// <summary>
        /// Animates the ability icon after the cooldown is completed.
        /// </summary>
        /// <param name="cooldownTime">The ability's cooldown time.</param>
        private IEnumerator AnimateIcon(float cooldownTime)
        {
            iconImage.color = unavailableColor;
            yield return new WaitForSeconds(cooldownTime);
            iconAnimator.SetTrigger("Pop");
            iconImage.color = availableColor;
        }
    }
}