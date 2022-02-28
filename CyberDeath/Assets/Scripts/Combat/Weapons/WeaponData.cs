/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/11/2021
*******************************************************************/
using UnityEngine;
using Sirenix.OdinInspector;

namespace GoofyGhosts
{
    [CreateAssetMenu(menuName = "Weapons/Weapon Data", fileName = "New Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [InfoBox("You should not be modifying this! Modify the base data instead!", visibleIfMemberName: "IsNotBaseData", infoMessageType: InfoMessageType.Warning)]
        [SerializeField] private bool isBaseData = false;
        private bool IsNotBaseData()
        {
            return !isBaseData;
        }

        [HideIf("isBaseData")]
        [Tooltip("The data that this WeaponData is hydrated from.")]
        [SerializeField] private WeaponData baseData;

        /// <summary>
        /// The name of the weapon.
        /// </summary>
        public string weaponName;

        /// <summary>
        /// The damage the weapon inflicts.
        /// </summary>
        public Stat attackDamage;

        /// <summary>
        /// The speed at which this weapon's animation plays.
        /// </summary>
        public Stat attackSpeed;

        public void Hydrate()
        {
            this.weaponName = baseData.weaponName;

            this.attackDamage = new Stat(baseData.attackDamage);
            this.attackSpeed = new Stat(baseData.attackSpeed);
        }
    }
}