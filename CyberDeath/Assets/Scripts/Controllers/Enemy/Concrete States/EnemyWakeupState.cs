/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class EnemyWakeupState : IEnemyState
    {
        [SerializeField] private float wakeupTime;
        private CharacterController characterController;

        protected override void Awake()
        {
            base.Awake();
            characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            // Disable the character controller to prevent getting hit.
            characterController.enabled = false;

            StartCoroutine(Wakeup());
        }

        /// <summary>
        /// Wakes up the enemy; any "on spawn" animation should be performed
        /// in this state.
        /// </summary>
        private IEnumerator Wakeup()
        {
            // Yield until anim is done playing. For now, it's a wakeup time.
            // Might have a check to see if this enemy is using a wakeup anim.
            yield return new WaitForSeconds(wakeupTime);
            characterController.enabled = true;
            SeekTarget();
        }

        public override void Attack()
        {
            // Cannot attack in this state.
        }

        public override void SeekTarget()
        {
            manager.SwapState<EnemySeekState>();
            manager.SeekTarget();
        }

        public override void OnUnSwap()
        {
            // Do Nothing
        }
    }
}
