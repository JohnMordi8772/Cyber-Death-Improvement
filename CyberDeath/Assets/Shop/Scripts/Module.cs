using System.Collections;
using UnityEngine;

namespace GoofyGhosts
{
    public abstract class Module : MonoBehaviour
    {
        // Name of module (Ex. "Speed", "Power", "Reach")
        public string name;

        // How much the module costs (at rank 1)
        public int price;

        // Value shown in the shop
        public int displayPrice;

        // Rank of the module, starts at 1 by default
        // Cannot be edited in inspector
        [System.NonSerialized]
        public int rank = 1;

        
        void Awake()
        {
            displayPrice = price;
        }

        // Promotes the module to the next rank and
        // updates its price
        // Called whenever the module is bought in the store
        public void Promote()
        { 
            if (rank <= ShopInterface.shopPrices.numberOfRanks)
            {
                rank++;

                float tempPrice = price;
                float newPrice = tempPrice * ShopInterface.shopPrices.priceIncrementRate;

                price = (int)newPrice; 
                displayPrice = price;
            }
            else
            {
                rank = ShopInterface.shopPrices.numberOfRanks;
            }

        }

        // Used for setting a module's rank remotely
        // Should only be used for testing purposes
        public void SetRank(int x)
        {
            if (x > ShopInterface.shopPrices.numberOfRanks || x <= 0)
                //Error state, invalid rank #
                rank = 1;
            else
                rank = x;
        }

        // Gets the name of the module that is shown in the shop
        // Combines name and rank information
        public string GetDisplayName()
        {
            return (name + " Module: Mk. " + rank);
        }

        // Gets the display price of the item
        public int GetPrice()
        {
            return (price);
        }

        /// <summary>
        /// Invoked when the module is purchased.
        /// Performs the stat upgrade.
        /// </summary>
        public abstract void OnPurchased();
    }
}