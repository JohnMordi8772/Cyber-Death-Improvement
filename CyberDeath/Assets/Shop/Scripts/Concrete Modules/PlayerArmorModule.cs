/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/28/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class PlayerArmorModule : Module
    {
        [SerializeField] private Armor playerArmor;

        public override void OnPurchased()
        {
            playerArmor.CurrentArmor = new StatUpgrade(playerArmor.CurrentArmor, rank * ModuleUpgrades.ARMOR_UPGRADE);
        }
    }
}