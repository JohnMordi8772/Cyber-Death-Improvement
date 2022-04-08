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
    [RequireComponent(typeof(Animator))]
    public class HUDCanvas : MonoBehaviour
    {
        [SerializeField] private IntChannelSO waveChannel;
        [SerializeField] private bool playOnWaveEnd;
        private Animator anim;
        public WaveManager waveManager;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        #region -- // Event Handler // --
        private void OnEnable()
        {
            waveChannel.OnEventRaised += OnWaveChange;
        }

        private void OnDisable()
        {
            waveChannel.OnEventRaised -= OnWaveChange;
        }
        #endregion


        private void OnWaveChange(int waveNum)
        {
            if (waveNum == -1 && playOnWaveEnd && !waveManager.playerDead)
            {
                anim.SetTrigger("OnWaveChange");
            }
            else if (waveNum != -1 && !playOnWaveEnd)
            {
                anim.SetTrigger("OnWaveChange");
            }
        }
    }
}