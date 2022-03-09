/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/21/2021
*******************************************************************/
namespace GoofyGhosts
{
    /// <summary>
    /// Upgrades the player's attack speed.
    /// </summary>
    public class PlayerSwingModule : WeaponModule
    {
        public int modifier = 0;

        public override void OnPurchased()
        {
            weaponData.attackSpeed = new StatUpgrade(weaponData.attackSpeed, rank * ModuleUpgrades.ATT_SPEED_UPGRADE);
            modifier++;
        }

        public void OnPurchased(float value, int mod)
        {
            weaponData.attackSpeed = new StatUpgrade(weaponData.attackSpeed, value);
            modifier += mod;
        }
    }
}