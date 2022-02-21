/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/21/2021
*******************************************************************/

namespace GoofyGhosts
{
    /// <summary>
    /// A shop module that upgrades the player's speed.
    /// </summary>
    public class PlayerSpeedModule : PlayerModule
    {
        public override void OnPurchased()
        {
            motorData.movementSpeed = new StatUpgrade(motorData.movementSpeed, (rank * ModuleUpgrades.MOVE_SPEED_UPGRADE) + 1.5f);
        }
    }
}
