/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/14/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Represents an enemy's state.
    /// </summary>
    [RequireComponent(typeof(EnemyStateManager))]
    public abstract class IEnemyState : MonoBehaviour
    {
        /// <summary>
        /// Reference to the EnemyCharacterController component.
        /// </summary>
        protected EnemyStateManager manager;
        /// <summary>
        /// Attacks a target.
        /// </summary>
        public abstract void Attack();
        /// <summary>
        /// Seeks the player target.
        /// </summary>
        public abstract void SeekTarget();
        /// <summary>
        /// Invoked when this state is swapped from.
        /// </summary>
        public virtual void OnUnSwap() { }
        /// <summary>
        /// Invoked when the enemy is attacked.
        /// </summary>
        /// <param name="damage">The amount of damage received.</param>
        public virtual void OnAttacked(float damage) { }
        /// <summary>
        /// Invoked when the enemy is attacked from behind.
        /// </summary>
        /// <param name="damage"></param>
        public virtual void OnCritical(float damage) { }

        protected virtual void Awake()
        {
            manager = GetComponent<EnemyStateManager>();
        }
    }
}