/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace GoofyGhosts
{
    /// <summary>
    /// An abstract class all concrete weapons must inherit from.
    /// </summary>
    public abstract class IWeapon : MonoBehaviour
    {
        /// <summary>
        /// True if the weapon is cooling down.
        /// </summary>
        private bool coolingDown;
        public bool CoolingDown
        {
            get
            {
                return coolingDown;
            }
        }

        [Tooltip("The weapon's data.")]
        [FormerlySerializedAs("weaponData")]
        [SerializeField] public WeaponData data;

        /// <summary>
        /// Invoked when the ability's cooldown begins.
        /// </summary>
        [HideInInspector] public UnityAction<float> OnCooldownBegin;

        /// <summary>
        /// The weapon's attack damage.
        /// </summary>
        protected float WeaponDamage
        {
            get
            {
                return data.attackDamage.GetStat();
            }
        }
        /// <summary>
        /// The speed the weapon's animation plays at.
        /// </summary>
        public float AttackSpeed
        {
            get
            {
                return data.attackSpeed.GetStat();
            }
        }

        /// <summary>
        /// Hydrates the WeaponData; resets it to default values.
        /// </summary>
        protected virtual void Awake()
        {
            data.Hydrate();
        }

        /// <summary>
        /// Fires / uses the weapon.
        /// </summary>
        /// <returns>True if the weapon fired successfully.</returns>
        public bool Fire()
        {
            // TODO: Have cooldown adjusted via animation events,
            // or have animation speed determined by cooldown time.
            // Probs the former.
            FireWeapon();
            return true;
        }

        /// <summary>
        /// Activates the weapon's usage mechanic.
        /// </summary>
        protected abstract void FireWeapon();

        /// <summary>
        /// Invoked via an AnimationEvent when the cooldown is complete.
        /// </summary>
        public virtual void CompleteCooldown()
        {
            coolingDown = false;
        }

        /// <summary>
        /// Enables the weapon's collider.
        /// </summary>
        public virtual void EnableCollider()
        {
        }

        /// <summary>
        /// Disables the weaoon's collider.
        /// </summary>
        public virtual void DisableCollider()
        {
        }
    }
}