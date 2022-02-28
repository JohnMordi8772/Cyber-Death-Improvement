using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Global", fileName = "ShopPrices")]
public class GlobalModule: ScriptableObject
{
    // How much the price of every module is multiplied by for every rank
    // (Note: Could potentially be different for certain modules?)
    public float priceIncrementRate;

    // How many upgradable ranks there are for each module (default: 10?)
    public int numberOfRanks;

}
