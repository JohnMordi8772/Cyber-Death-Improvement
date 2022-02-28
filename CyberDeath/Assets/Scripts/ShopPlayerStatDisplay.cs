using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    public class ShopPlayerStatDisplay : MonoBehaviour
    {
        public Text armorStat;
        [SerializeField] private Armor playerArmor;

        // Start is called before the first frame update
        void Start()
        {
            armorStat.text = "Player Defense: 0";
        }

        // Update is called once per frame
        void Update()
        {
            armorStat.text = "Player Defense: " + playerArmor.GetArmorLevel();
        }
    }
}
