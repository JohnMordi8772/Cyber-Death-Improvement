/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GoofyGhosts
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private TextMeshProUGUI enemiesRemainingText;
        [SerializeField] private TextMeshProUGUI scrapText;
        [SerializeField] private TextMeshProUGUI wireText;
        [SerializeField] private TextMeshProUGUI fanText;
        [SerializeField] private TextMeshProUGUI coilText;
        [SerializeField] private TextMeshProUGUI armorText;

        [Header("Channels")]
        [SerializeField] private IntChannelSO waveChannel;
        [SerializeField] private IntChannelSO enemiesRemainingChannel;
        [SerializeField] private VoidChannelSO scrapCollectedChannel;

        private void OnEnable()
        {
            waveChannel.OnEventRaised += OnWaveChange;
            enemiesRemainingChannel.OnEventRaised += OnEnemyCountChange;
            scrapCollectedChannel.OnEventRaised += OnScrapCollected;
        }

        private void OnDisable()
        {
            waveChannel.OnEventRaised -= OnWaveChange;
            enemiesRemainingChannel.OnEventRaised -= OnEnemyCountChange;
            scrapCollectedChannel.OnEventRaised -= OnScrapCollected;
        }

        /// <summary>
        /// Invoked when the wave number changes.
        /// </summary>
        /// <param name="waveNum">The current wave number.</param>
        private void OnWaveChange(int waveNum)
        {
            if (waveNum != -1)
            {
                waveText.text = "ROUND " + waveNum;
            }
        }

        /// <summary>
        /// Invoked when the remaining enemies count changes.
        /// </summary>
        /// <param name="enemiesRemaining">The number of enemies remaining.</param>
        private void OnEnemyCountChange(int enemiesRemaining)
        {
            if (enemiesRemaining <= 0)
            {
                enemiesRemainingText.text = "";
            }
            else
            {
                enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining;
            }
        }

        /// <summary>
        /// Invoked when the player collects scrap.
        /// </summary>
        private void OnScrapCollected()
        {
            scrapText.text = "x " + ScrapCounter.scrapCount.ToString().PadLeft(3, '0');
            wireText.text = "x " + ScrapCounter.wireCount.ToString().PadLeft(3, '0');
            fanText.text = "x " + ScrapCounter.fanCount.ToString().PadLeft(3, '0');
            coilText.text = "x " + ScrapCounter.coilCount.ToString().PadLeft(3, '0');
            armorText.text = "x " + ScrapCounter.armorCount.ToString().PadLeft(3, '0');
        }
    }
}