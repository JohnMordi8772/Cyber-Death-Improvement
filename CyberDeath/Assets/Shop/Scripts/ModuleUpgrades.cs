/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/28/2021
*******************************************************************/
namespace GoofyGhosts
{
    /// <summary>
    /// Holds all of the module upgrades.
    /// </summary>
    public class ModuleUpgrades
    {
        // NOTE: These upgrades are multiplied by the rank
        // of the module (i.e. 1,2,3,4,...) EXCEPT for health. With health the upgrade is added on (i.e. 10f each upgrade).
        // Example: A rank 2 armor upgrade would add 2*(1/3) = (2/3) health to the player.

        public const float HEALTH_UPGRADE = 10f;
        public const float ARMOR_UPGRADE = (1f); // NOTE: Armor works by dividing the upgrade (rank*upgrade) to the amnt of damage received.
                                                   //       That being said, this should be at a minimum of 1 if you choose to go that low. 
        public const float MOVE_SPEED_UPGRADE = 0.25f;
        public const float ATT_SPEED_UPGRADE = 0.1f;
    }
}