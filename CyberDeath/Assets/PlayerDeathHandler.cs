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
    [RequireComponent(typeof(Animator))]
    public class PlayerDeathHandler : MonoBehaviour
    {
        private Health health;
        private Animator anim;
        [SerializeField] private BoolChannelSO disableControlsChannel;
        [SerializeField] WaveManager waveManager;

        private void Awake()
        {
            health = GetComponent<Health>();
            anim = GetComponent<Animator>();
        }

        #region // -- Event Handling // --
        private void OnEnable()
        {
            health.OnDeath += HandleDeath;
        }

        private void OnDisable()
        {
            health.OnDeath -= HandleDeath;
        }
        #endregion

        private void HandleDeath()
        {
            ScrapCounter.scrapCount = 0;
            waveManager.PlayerDeath();
            disableControlsChannel.RaiseEvent(false);
            anim.SetTrigger("Death");
        }
    }
}