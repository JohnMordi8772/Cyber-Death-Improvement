/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace GoofyGhosts
{
    [RequireComponent(typeof(Slider))]
    public class VolumeSlider : MonoBehaviour
    {
        private Slider slider;
        [SerializeField] private AudioMixerGroup masterMixer;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Start()
        {
            slider.maxValue = 20f;
            slider.minValue = -80f;

            float currentVolume;

            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                currentVolume = PlayerPrefs.GetFloat("MasterVolume");
                masterMixer.audioMixer.SetFloat("MasterVolume", currentVolume);
            }
            else
            {
                masterMixer.audioMixer.GetFloat("MasterVolume", out currentVolume);
            }

            slider.value = currentVolume;
        }

        public void OnValueChanged(float value)
        {
            masterMixer.audioMixer.SetFloat("MasterVolume", value);
            PlayerPrefs.SetFloat("MasterVolume", value);
        }
    }
}