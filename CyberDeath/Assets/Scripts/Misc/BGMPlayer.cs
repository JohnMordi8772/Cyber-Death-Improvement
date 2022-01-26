using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class BGMPlayer : MonoBehaviour
    {
        [Header("BGM")]
        [SerializeField] private AudioSource bgm;
        [SerializeField] private IntChannelSO waveChannelSO;

        private void OnEnable()
        {
            waveChannelSO.OnEventRaised += num => { if (num == -1) StopBGM(); };
        }

        public bool musicPlaying;
        public void PlayBGM()
        {
            if(musicPlaying == false)
            {
                bgm.Play();
                musicPlaying = true;
            }
        }

        public void StopBGM()
        {
            if(musicPlaying == true)
            {
                AudioSource aud = GetComponent<AudioSource>();
                aud.Stop();
                musicPlaying = false;
            }
        }
    }
}
