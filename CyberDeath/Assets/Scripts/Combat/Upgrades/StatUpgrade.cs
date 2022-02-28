/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/15/2021
*******************************************************************/

namespace GoofyGhosts
{
    /// <summary>
    /// Represents an upgradeable stat.
    /// </summary>
    public class StatUpgrade : Stat
    {
        /// <summary>
        /// The stat this upgrade is tied to.
        /// </summary>
        private Stat baseStat;
        /// <summary>
        /// The increase in the base state.
        /// </summary>
        private float increase;

        /// <summary>
        /// Constructs a new stat upgrade.
        /// </summary>
        /// <param name="baseStat">The stat to upgrade.</param>
        /// <param name="increase">The increase in the base state.</param>
        public StatUpgrade(Stat baseStat, float increase)
        {
            this.baseStat = baseStat;
            this.increase = increase;
        }

        /// <summary>
        /// Returns the stat and all upgrades.
        /// </summary>
        /// <returns>The stat and all upgrades.</returns>
        public override float GetStat()
        {
            return increase + baseStat.GetStat();
        }

        /// <summary>
        /// Returns the stat name and all upgrades.
        /// </summary>
        /// <returns>The stat name and all upgrades.</returns>
        public override string GetName()
        {
            return baseStat.GetName() + ", +" + increase;
        }
    }
}