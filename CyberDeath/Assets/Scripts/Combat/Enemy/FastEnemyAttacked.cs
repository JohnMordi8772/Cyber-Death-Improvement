
using UnityEngine;
using UnityEngine.AI;

namespace GoofyGhosts
{
    /// <summary>
    /// Handles behaviour that invokes when the enemy is attacked.
    /// </summary>
    [RequireComponent(typeof(EnemyStateManager))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class FastEnemyAttacked : MonoBehaviour, IDamageable
    {
        private FastEnemyStateManager manager;
        private NavMeshAgent agent;

        private void Awake()
        {
            manager = GetComponent<FastEnemyStateManager>();
            agent = GetComponent<NavMeshAgent>();
        }

        public void TakeDamage(float amnt)
        {
            // agent.isStopped = true;
            manager.SwapState<FastEnemyAttackedState>();
            manager.OnAttacked(amnt);
        }
    }
}
