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
    [CreateAssetMenu(menuName = "CompositeAudioClipSO")]
    public class CompositeAudioClipSO : AudioClipSO
    {
        [SerializeField] private AudioClip[] audioClips;

        /// <summary>
        /// Returns a random audio clip from the array.
        /// </summary>
        public override AudioClip AudioClip
        {
            get
            {
                return audioClips[Random.Range(0, audioClips.Length)];
            }
        }
    }
}