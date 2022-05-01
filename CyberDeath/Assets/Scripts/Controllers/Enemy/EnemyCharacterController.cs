/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/14/2021
*******************************************************************/
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.Events;

namespace GoofyGhosts
{
    [RequireComponent(typeof(EnemyStateManager))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyCharacterController : MonoBehaviour
    {
        private EnemyStateManager manager;
        private Transform target;
        private NavMeshAgent agent;

        [SerializeField] protected Animator anim;

        private bool inRangeOfTarget;

        [SerializeField] private float checkDistanceTime = 0.3f;

        private void Awake()
        {
            manager = GetComponent<EnemyStateManager>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
                StartCoroutine(CheckRangeToTarget());
            }
        }

        private IEnumerator CheckRangeToTarget()
        {
            while (target != null)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if (!manager.currentState.isShocked)
                {
                    if ((distance <= agent.stoppingDistance + 0.1f && !inRangeOfTarget) || (inRangeOfTarget && !anim.GetBool("Fire")))
                    {
                        Debug.Log("InRange");
                        inRangeOfTarget = true;
                        anim.SetBool("Fire", true);
                    }
                    else if (distance > agent.stoppingDistance && inRangeOfTarget)
                    {
                        Debug.Log("OutOfRange");
                        inRangeOfTarget = false;
                        anim.SetBool("Fire", false);
                    }
                }

                yield return new WaitForSeconds(checkDistanceTime);
            }
        }

        /// <summary>
        /// Returns true if the enemy is in range of the target.
        /// </summary>
        /// <returns>True if the enemy is in range of the target.</returns>
        public bool IsInRangeOfTarget()
        {
            return inRangeOfTarget;
        }
    }
}