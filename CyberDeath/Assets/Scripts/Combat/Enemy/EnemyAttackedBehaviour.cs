/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/14/2021
*******************************************************************/
using UnityEngine;
using UnityEngine.AI;

namespace GoofyGhosts
{
    /// <summary>
    /// Handles behaviour that invokes when the enemy is attacked.
    /// </summary>
    [RequireComponent(typeof(EnemyStateManager))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAttackedBehaviour : MonoBehaviour, IDamageable
    {
        private EnemyStateManager manager;
        private NavMeshAgent agent;
        public Transform playerWeapon;

        private void Awake()
        {
            manager = GetComponent<EnemyStateManager>();
            agent = GetComponent<NavMeshAgent>();
        }

        public void TakeDamage(float amnt)
        {
           // agent.isStopped = true;
            manager.SwapState<EnemyAttackedState>();
            manager.OnAttacked(amnt);
        }

        public void TakeCritical(float amnt)
        {
            // agent.isStopped = true;
            if (Physics.Linecast(transform.position, playerWeapon.position))
            {
                manager.SwapState<EnemyAttackedState>();
                manager.OnAttacked(amnt * 1.5f);
                Debug.Log("Critical Hit");
            }
        }
    }
}
