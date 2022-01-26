using UnityEngine;
using System.Collections;

namespace GoofyGhosts
{
    public abstract class WeaponModule : Module
    {
        [SerializeField] protected WeaponData weaponData;
    }
}