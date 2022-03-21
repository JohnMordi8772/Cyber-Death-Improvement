/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/8/2021
*******************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GoofyGhosts
{
    /// <summary>
    /// An abstract class representing the base functionality for all abilities.
    /// </summary>
    [RequireComponent(typeof(AbilityManager))]
    public abstract class IAbility : MonoBehaviour
    {
        /// <summary>
        /// True if the ability is cooling down.
        /// </summary>
        public bool coolingDown;
        public float i;

        [Tooltip("Channel used to signal the ability's cooldown has begun.")]
        [SerializeField] private FloatChannelSO cooldownBeginChannel;

        [Tooltip("The ability's data container.")]
        [SerializeField] protected IAbilityData data;

        public UnityAction OnCooldownComplete;

        private void Start()
        {
            i = data.CooldownTime.GetStat();
        }

        /// <summary>
        /// Invoked when the ability is swapped to.
        /// </summary>
        public virtual void OnSwapped()
        {
        }

        /// <summary>
        /// Invoked when abiltiy is unswapped from.
        /// </summary>
        public virtual void OnUnswapped()
        {
        }

        /// <summary>
        /// Activates the ability's unique functionality if 
        /// not cooling down.
        /// </summary>
        public bool Activate()
        {
            if (coolingDown)
                return false;

            ActivateAbility();
            Cooldown();
            return true;
        }

        /// <summary>
        /// Activates the ability's unique functionality.
        /// </summary>
        protected abstract void ActivateAbility();
        
        /// <summary>
        /// Initiates the ability's cooldown.
        /// During this period the ability cannot be used.
        /// </summary>
        protected virtual void Cooldown()
        {
            coolingDown = true;
            cooldownBeginChannel.RaiseEvent(data.CooldownTime.GetStat());

            StartCoroutine(PerformCooldown());

            IEnumerator PerformCooldown()
            {
                for (i = data.CooldownTime.GetStat(); i > 0 ; i--)
                {
                    yield return new WaitForSeconds(1);
                }
                coolingDown = false;
                OnCooldownComplete?.Invoke();
                i = data.CooldownTime.GetStat();
            }
        }

        /// <summary>
        /// Returns the ability's name.
        /// </summary>
        /// <returns>The ability's name.</returns>
        public string GetName()
        {
            return data.AbilityName;
        }
    }
}