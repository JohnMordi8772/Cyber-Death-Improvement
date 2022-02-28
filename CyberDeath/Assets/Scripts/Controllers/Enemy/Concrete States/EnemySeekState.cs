/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/14/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GoofyGhosts
{
    /// <summary>
    /// Controls the enemy's navigation.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyCharacterController))]
    [RequireComponent(typeof(CharacterMotor))]
    public class EnemySeekState : IEnemyState
    {
        /// <summary>
        /// Reference to the NavMeshAgent component.
        /// </summary>
        private NavMeshAgent agent;
        /// <summary>
        /// The target to seek.
        /// </summary>
        private Transform target;
        private EnemyCharacterController controller;
        private Animator anim;

        private CharacterMotor motor;

        [Tooltip("Time in seconds a new path is calculated.")]
        [SerializeField] private float updatePathTime = 0.3f;

        /// <summary>
        /// True if the enemy is actively seeking a target.
        /// </summary>
        private bool seeking;



        #region -- // Init // --
        protected override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
            controller = GetComponent<EnemyCharacterController>();
            anim = GetComponent<Animator>();
            motor = GetComponent<CharacterMotor>();
        }

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                agent.updatePosition = false;
                agent.updateRotation = false;

                target = player.transform;
            }
        }
        #endregion


        public override void Attack()
        {
            seeking = false;
            manager.SwapState<EnemyAttackState>();
            manager.Attack();
        }

        /// <summary>
        /// Begins navigating towards the provided target.
        /// </summary>
        public override void SeekTarget()
        {
            if(!seeking)
            {
                seeking = true;
                //agent.isStopped = false;
                StartCoroutine(UpdatePath());
            }
        }

        private void Update()
        {
            if (seeking)
            {
                agent.nextPosition = transform.position;

                Vector3 vel = agent.desiredVelocity;
                vel.y = 0;
                vel.Normalize();

                motor.MoveCharacter(vel);
                motor.Rotate(vel);

                if (controller.IsInRangeOfTarget())
                {
                    
                    Attack();
                }
            }
        }

        private IEnumerator UpdatePath()
        {
            while(seeking)
            {
                if (target == null)
                {
                    yield break;
                }

                // Make sure the enemy stops firing.
                if(anim.GetBool("Fire"))
                {
                    anim.SetBool("Fire", false);
                }

                agent.destination = target.position;
                yield return new WaitForSeconds(updatePathTime);
            }
        }

        public override void OnUnSwap()
        {
            seeking = false;
        }
    }
}