/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/21/2021
*******************************************************************/

namespace GoofyGhosts
{
    public class PlayerAttackModule : WeaponModule
    {
        public override void OnPurchased()
        {
            weaponData.attackDamage = new StatUpgrade(weaponData.attackDamage, rank * 1.5f);
        }
    }
}