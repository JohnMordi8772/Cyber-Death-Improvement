/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/14/2021
*******************************************************************/
using System.Collections;
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(WeaponUser))]
    [RequireComponent(typeof(EnemyCharacterController))]
    public class EnemyAttackState : IEnemyState
    {
        private WeaponUser weaponUser;
        private bool attacking;
        private EnemyCharacterController controller;

        private Transform target;

        protected override void Awake()
        {
            base.Awake();
            weaponUser = GetComponent<WeaponUser>();
            controller = GetComponent<EnemyCharacterController>();
        }

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }


        public override void Attack()
        {
            //Debug.Log("EnemyAttackState: Attack");
            if (!attacking)
            {
                attacking = true;
                StartCoroutine(RotateTowardsTarget());

                // We only call this once to start the animation.
                // After that, it is called repeatedly via an AnimationEvent.
                weaponUser.Fire();
            }
        }

        private void Update()
        {
            if (!controller.IsInRangeOfTarget() && attacking)
            {
                StopAllCoroutines();
                weaponUser.ReleaseFire();
                SeekTarget();
            }
        }

        private IEnumerator RotateTowardsTarget()
        {
            while(attacking && target != null)
            {
                Vector3 dir = (target.position - transform.position);
                dir.y = 0;

                transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
                yield return null;
            }
        }

        public override void OnUnSwap()
        {
            attacking = false;
        }

        public override void SeekTarget()
        {
            //Debug.Log("EnemyAttackState: SeekTarget");
            manager.SwapState<EnemySeekState>();
            manager.SeekTarget();
        }
    }
}
