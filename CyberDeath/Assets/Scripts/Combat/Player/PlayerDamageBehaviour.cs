/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*    Brief Description: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(PlayerFlash))]
    public class PlayerDamageBehaviour : MonoBehaviour, IDamageable
    {
        private Health health;
        [SerializeField] private IntChannelSO waveChannel;

        [SerializeField] private float stunDuration;
        private bool stunned;

        [SerializeField] private int maxHits = 3;
        private int currentHits;
        private bool resettingHitCount;

        private Animator anim;

        private PlayerFlash flashComponent;


        void Awake()
        {
            health = GetComponent<Health>();
            anim = GetComponent<Animator>();
            flashComponent = GetComponent<PlayerFlash>();
        }

        public void TakeDamage(float amnt)
        {
            if (stunned)
                return;

            ++currentHits;

            if (currentHits >= maxHits)
            {
                stunned = true;
                anim.SetTrigger("Stunned");
                flashComponent.StartFlash();
                StartCoroutine(ResetStun());
            }
            else if (!resettingHitCount)
            {
                resettingHitCount = true;
                StartCoroutine(ResetHitCount());
            }

            health.TakeDamage(amnt);
        }

        private IEnumerator ResetStun()
        {
            yield return new WaitForSeconds(stunDuration);
            stunned = false;
            flashComponent.EndFlash();
        }

        private IEnumerator ResetHitCount()
        {
            yield return new WaitForSeconds(0.5f);
            currentHits = 0;
            resettingHitCount = false;
        }
    }
}