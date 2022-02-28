/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/16/2021
*******************************************************************/
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace GoofyGhosts
{
    public class SliderHealthDisplay : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private HealthDataChannelSO healthChannel;
        [SerializeField] private TextMeshProUGUI hpText;

        private void Start()
        {
            slider.value = slider.maxValue;
        }

        private void OnEnable()
        {
            healthChannel.OnEventRaised += DisplayHealth;
        }

        private void OnDisable()
        {
            healthChannel.OnEventRaised -= DisplayHealth;
        }

        private void DisplayHealth(HealthData healthData)
        {
            slider.maxValue = healthData.maxHealth.GetStat();
            slider.value = healthData.currentHealth;
            hpText.text = "HP " + Math.Round(healthData.currentHealth,2) + " / " + Math.Round(healthData.maxHealth.GetStat(),2);
            print(hpText.text);
        }
    }
}