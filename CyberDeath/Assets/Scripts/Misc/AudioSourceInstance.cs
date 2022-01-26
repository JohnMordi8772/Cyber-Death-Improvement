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
    public class AudioSourceInstance
    {
        private AudioSource source;
        private AudioClipSO lastClip;

        public AudioSourceInstance(AudioClipSO clip, GameObject gameObject)
        {
            bool hasAudioSource = gameObject.TryGetComponent(out source);

            if (!hasAudioSource)
            {
                source = gameObject.AddComponent<AudioSource>();
            }

            Update(clip);
        }

        public void UpdateFromLast()
        {
            Update(lastClip);
        }

        public void Update(AudioClipSO clip)
        {
            if (clip == null)
            {
                Debug.LogWarning("[AudioSourceInstance]: Cannot update clip because the provided clip is null.");
                return;
            }

            source.clip = clip.AudioClip;
            source.volume = clip.Volume;
            source.outputAudioMixerGroup = clip.MixerGroup;
            source.pitch = clip.Pitch;

            lastClip = clip;
        }

        public void Play()
        {
            if (lastClip == null)
            {
                Debug.LogWarning("[AudioSourceInstance]: Cannot call Play because the provided clip is null.");
                return;
            }
            else
            {
                source.Play();
            }
        }
    }
}
