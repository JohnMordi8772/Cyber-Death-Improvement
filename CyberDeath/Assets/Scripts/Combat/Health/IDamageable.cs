/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/

namespace GoofyGhosts
{
    /// <summary>
    /// Interface all damageable entities must implement.
    /// </summary>
    public interface IDamageable
    {
        void TakeDamage(float amnt);
    }
}
