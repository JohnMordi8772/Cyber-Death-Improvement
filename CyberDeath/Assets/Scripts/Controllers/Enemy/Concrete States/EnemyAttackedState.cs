/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/14/2021
*******************************************************************/
using System.Collections;
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(Health))]
    public class EnemyAttackedState : IEnemyState
    {
        private Health health;
        private bool stunned;
        private Animator anim;

        [SerializeField] private AudioClipSO hitSFX;
        private AudioSourceInstance audioSource;

        protected override void Awake()
        {
            base.Awake();
            health = GetComponent<Health>();
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            audioSource = new AudioSourceInstance(hitSFX, gameObject);
        }

        public override void Attack()
        {
            //Debug.Log("EnemyAttackedState: Attack");
            // Cannot attack while being attacked.
        }

        public override void SeekTarget()
        {
            //Debug.Log("EnemyAttackedState: SeekTarget");
            manager.SwapState<EnemySeekState>();
            manager.SeekTarget();
        }

        public override void OnAttacked(float damage)
        {
            //Debug.Log("EnemyAttackedState: OnAttacked");
            // If the enemy is not stunned, take damage, become stunned,
            // and wait for stun effect to wear off.
            if (!stunned)
            {
                anim.SetTrigger("Stunned");
                stunned = true;
                //StartCoroutine(Cooldown());
            }

            audioSource.Play();
            health.TakeDamage(damage);
        }

        /// <summary>
        /// Invoked via an AnimationEvent. Starts seeking target again.
        /// </summary>
        public void OnStunComplete()
        {
            //stunned = false;
            StartCoroutine(Cooldown());
            SeekTarget();
        }

        IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(2f);
            stunned = false;
        }

        public void NewStunComplete()
        {
            stunned = false;
        }
    }
}