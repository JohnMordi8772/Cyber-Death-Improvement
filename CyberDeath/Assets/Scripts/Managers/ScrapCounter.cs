/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/21/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Holds the player's scrap count.
    /// </summary>
    public class ScrapCounter : MonoBehaviour
    {
        [SerializeField] private AudioClipChannelSO sfxChannel;
        [SerializeField] private AudioClipSO scrapCollectSFX;
        [SerializeField] private VoidChannelSO scrapCollectedChannel;

        private static AudioClipChannelSO _sfxChannel;
        private static AudioClipSO _scrapCollectSFX;
        private static VoidChannelSO _scrapCollectedChannel;

        private void Awake()
        {
            _sfxChannel = sfxChannel;
            _scrapCollectSFX = scrapCollectSFX;
            _scrapCollectedChannel = scrapCollectedChannel;
        }

        /// <summary>
        /// The player's scrap count.
        /// </summary>
        public static int scrapCount { get; set; }

        /// <summary>
        /// How much scrap is rewarded per pile.
        /// </summary>
        public static int scrapPerPile { get; set; }

        /// <summary>
        /// Adds scrap to the player's pile.
        /// </summary>
        public static void AddScrap()
        {
            scrapCount += scrapPerPile;
            _sfxChannel.RaiseEvent(_scrapCollectSFX);
            _scrapCollectedChannel.RaiseEvent();
        }

        public static void OnScrapCountChange()
        {
            _scrapCollectedChannel.RaiseEvent();
        }
    }
}