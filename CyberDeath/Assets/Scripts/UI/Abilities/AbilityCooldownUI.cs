/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    /// <summary>
    /// Displays an abilties cooldown time via a UI image.
    /// </summary>
    public class AbilityCooldownUI : MonoBehaviour
    {
        [Tooltip("The slider that will display the cooldown time.")]
        [SerializeField] private Slider slider;

        [Tooltip("Channel used to handle an ability's cooldown.")]
        [SerializeField] private FloatChannelSO abilityCooldownChannel;


        #region -- // Event subbing / unsubbing // --
        private void OnEnable()
        {
            abilityCooldownChannel.OnEventRaised += UpdateSlider;
        }

        private void OnDisable()
        {
            abilityCooldownChannel.OnEventRaised -= UpdateSlider;
        }
        #endregion

        /// <summary>
        /// Updates the slider according to the cooldown time.
        /// </summary>
        /// <param name="cooldownTime">The ability's cooldown time.</param>
        private void UpdateSlider(float cooldownTime)
        {
            StopAllCoroutines();
            StartCoroutine(DisplayCooldown(cooldownTime));
        }

        /// <summary>
        /// Displays the ability's cooldown.
        /// </summary>
        /// <param name="cooldownTime">The ability's cooldown time.</param>
        private IEnumerator DisplayCooldown(float cooldownTime)
        {
            float currentTime = 0f;
            const float RESET_TIME = 0.2f;

            while(currentTime < (cooldownTime - RESET_TIME))
            {
                currentTime += Time.deltaTime;
                slider.value = Mathf.Lerp(1f, 0f, currentTime / (cooldownTime - RESET_TIME));
                yield return null;
            }

            currentTime = 0f;
            while (currentTime < RESET_TIME)
            {
                currentTime += Time.deltaTime;
                slider.value = Mathf.Lerp(0f, 1f, currentTime / RESET_TIME);
                yield return null;
            }
        }
    }
}