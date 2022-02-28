/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/14/2021
*******************************************************************/
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Handles controlling the states of enemy characters.
    /// </summary>
    public class FastEnemyStateManager : MonoBehaviour
    {
        /// <summary>
        /// The enemy's current state.
        /// </summary>
        private IEnemyState currentState;

        private List<IEnemyState> states;

        /// <summary>
        /// Init member variables.
        /// </summary>
        private void Awake()
        {
            states = new List<IEnemyState>(GetComponents<IEnemyState>());

            currentState = GetComponent<EnemyWakeupState>();
        }
        /*
        public void Attack()
        {
            currentState.Attack();
        }
        */
        public void SeekTarget()
        {
            currentState.SeekTarget();
        }

        public void OnAttacked(float damage)
        {
            currentState.OnAttacked(damage);
        }

        public void SwapState<T>() where T : IEnemyState
        {
            IEnemyState state = states.Find(t => t.GetType() == typeof(T));
            if (state != null && state != currentState)
            {
                currentState.OnUnSwap();
                currentState = state;
            }
            //else
            //{
            //    Debug.LogWarning("State not found or already active: " + typeof(T));
            //}
        }
    }
}