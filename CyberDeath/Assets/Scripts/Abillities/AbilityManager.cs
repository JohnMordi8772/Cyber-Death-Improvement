/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/08/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System.Linq;

namespace GoofyGhosts
{
    /// <summary>
    /// Manages assigning/activating character abilities.
    /// </summary>
    public class AbilityManager : MonoBehaviour
    {
        /// <summary>
        /// The current ability.
        /// </summary>
        [ShowInInspector] [ReadOnly] private IAbility currentAbility;

        /// <summary>
        /// The list of the player's abilities.
        /// </summary>
        [ShowInInspector] [ReadOnly] private List<IAbility> abilities;

        [SerializeField] AbilityCooldownUI abilityCooldown;

        [SerializeField] AbilityAvailableUI availableUI;

        [SerializeField] Image icon;

        [SerializeField] Sprite[] spriteIcons;

        PlayerControls playerControls;

        private Animator anim;

        public bool slamPurchased = false;
        public bool empPurchased = false;
        public bool taniumPurchased = false;

        /// <summary>
        /// Initialize member variables.
        /// </summary>
        private void Awake()
        {
            InitializeAbilityList();
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            if (currentAbility != null)
            {
                currentAbility.OnCooldownComplete += () => anim.SetTrigger("AbilityDone");
            }
            abilityCooldown.SetCurrentAbility(currentAbility);
        }

        /// <summary>
        /// Initializes the ability list by searching the
        /// gameobject for all attached IAbility components.
        /// </summary>
        private void InitializeAbilityList()
        {
            IEnumerable<IAbility> attachedAbilities = GetComponents<IAbility>();
            abilities = new List<IAbility>(attachedAbilities);

            if (abilities.Count > 0)
                currentAbility = abilities[0];
        }

        /// <summary>
        /// Activates the current ability.
        /// </summary>
        public void Activate()
        {
            if (currentAbility != null && currentAbility.Activate())
            {
                anim.SetTrigger("Ability");
            }
        }

        /// <summary>
        /// Swaps to the ability of the given type if it is 
        /// in the list of usable abilities.
        /// </summary>
        /// <typeparam name="T">The IAbility type to swap to.</typeparam>
        public void SwapAbilities<T>() where T : IAbility
        {
            if (currentAbility is DashAbility)
            {
                currentAbility = GetComponent<NanobotsAbility>();
                icon.sprite = spriteIcons[1];
            }
            else if (currentAbility is NanobotsAbility)
            {
                if (empPurchased)
                {
                    currentAbility = GetComponent<ShockwaveAbility>();
                    icon.sprite = spriteIcons[2];
                }
                else if (taniumPurchased)
                {
                    currentAbility = GetComponent<Titanium>();
                    icon.sprite = spriteIcons[3];
                }
                else if (slamPurchased)
                {
                    currentAbility = GetComponent<GrandSlamAbility>();
                    icon.sprite = spriteIcons[4];
                }
                else
                {
                    currentAbility = GetComponent<DashAbility>();
                    icon.sprite = spriteIcons[0];
                }
            }
            else if (currentAbility is ShockwaveAbility)
            {
                if (taniumPurchased)
                {
                    currentAbility = GetComponent<Titanium>();
                    icon.sprite = spriteIcons[3];
                }
                else if (slamPurchased)
                {
                    currentAbility = GetComponent<GrandSlamAbility>();
                    icon.sprite = spriteIcons[4];
                }
                else
                {
                    currentAbility = GetComponent<DashAbility>();
                    icon.sprite = spriteIcons[0];
                }
            }
            else if (currentAbility is Titanium)
            {
                if (slamPurchased)
                {
                    currentAbility = GetComponent<GrandSlamAbility>();
                    icon.sprite = spriteIcons[4];
                }
                else
                {
                    currentAbility = GetComponent<DashAbility>();
                    icon.sprite = spriteIcons[0];
                }
            }
            else
            {
                currentAbility = GetComponent<DashAbility>();
                icon.sprite = spriteIcons[0];
            }
            abilityCooldown.SetCurrentAbility(currentAbility);
            if(currentAbility.coolingDown)
            {
                abilityCooldown.UpdateSlider(currentAbility.i);
                icon.color = availableUI.unavailableColor;
            }
            else
            {
                abilityCooldown.UpdateSlider(-1);
                icon.color = availableUI.availableColor;
            }
            //bool abilityExists = AbilityListContains<T>(out IAbility ability);

            //if (!abilityExists)
            //{
            //    Debug.LogWarning("[AbilityManager]: Cannot swap to ability - type not present in the list" +
            //        "of usable abilities.");
            //}
            //else
            //{
            //    currentAbility?.OnUnswapped();
            //    currentAbility = ability;
            //    currentAbility.OnSwapped();
            //}
        }

        /// <summary>
        /// Adds an ability to the list of usable abilities.
        /// </summary>
        /// <typeparam name="T">The type of ability to add.</typeparam>
        public void AddAbility<T>() where T : IAbility
        {
            if (!AbilityListContains<T>())
            {
                abilities.Add(gameObject.AddComponent<T>());
            }
            else
            {
                Debug.Log("[AbilityManager]: Cannot add ability - type already exists in the list.");
            }
        }

        #region -- // Helper Methods // --
        /// <summary>
        /// Returns true if the list of active abilities contains the provided IAbility type.
        /// </summary>
        /// <typeparam name="T">The type of the ability to search for.</typeparam>
        /// <param name="ability">The found ability. Null if it does not exist.</param>
        /// <returns>True if the list of active abilities contains the provided IAbility type.</returns>
        private bool AbilityListContains<T>(out IAbility ability) where T : IAbility
        {
            IAbility existingAbility = abilities.Find(t => t.GetType() == typeof(T));

            if (existingAbility != null)
            {
                ability = existingAbility;
                return true;
            }
            else
            {
                ability = null;
                return false;
            }
        }

        /// <summary>
        /// Returns true if the list of active abilities contains the provided IAbility type.
        /// </summary>
        /// <typeparam name="T">The type of the ability to search for.</typeparam>
        /// <returns>True if the list of active abilities contains the provided IAbility type.</returns>
        private bool AbilityListContains<T>() where T : IAbility
        {
            IAbility existingAbility = abilities.Find(t => t.GetType() == typeof(T));
            return existingAbility != null;
        }
        #endregion
    }
}