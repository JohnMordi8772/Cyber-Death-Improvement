/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 12/1/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class AudioClipInvoker : MonoBehaviour
    {
        [SerializeField] private AudioClipChannelSO sfxChannel;

        public void PlaySFX(AudioClipSO clip)
        {
            sfxChannel.RaiseEvent(clip);
        }
    }
}
