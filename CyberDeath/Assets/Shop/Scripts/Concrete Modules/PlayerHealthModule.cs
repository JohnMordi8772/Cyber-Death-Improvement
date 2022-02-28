/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/22/2021
*******************************************************************/
using UnityEngine;

namespace GoofyGhosts
{
    /// <summary>
    /// Module to upgrade player health.
    /// </summary>
    public class PlayerHealthModule : Module
    {
        [SerializeField] private HealthData playerHealthData;
        [SerializeField] private HealthDataChannelSO playerHealthChannel;

        public override void OnPurchased()
        {
            Stat healthStat = playerHealthData.maxHealth;

            playerHealthData.maxHealth = new StatUpgrade(healthStat, ModuleUpgrades.HEALTH_UPGRADE);
            playerHealthChannel.RaiseEvent(playerHealthData);
        }
    }
}