using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoofyGhosts
{
    public class ShopPlayerStatDisplay : MonoBehaviour
    {
        public Text attackStat;
        public Text armorStat;
        public Text healthStat;
        public Text aSpeedStat;
        public Text mSpeedStat;

        [SerializeField] private PlayerAttackModule playerAttack;
        [SerializeField] private Armor playerArmor;
        [SerializeField] private PlayerHealthModule playerHealth;
        [SerializeField] private PlayerSwingModule playerSwing;
        [SerializeField] private PlayerSpeedModule playerMove;

        // Start is called before the first frame update
        void Start()
        {
            attackStat.text = "Attack: +0%";
            armorStat.text =  "Defense: +0%";
            healthStat.text = "Health: +0";
            aSpeedStat.text = "Attack Speed: +0%";
            mSpeedStat.text = "Move Speed: +0%";
        }

        // Update is called once per frame
        void Update()
        {
            attackStat.text = "Attack: +" + (playerAttack.modifier * 10) + "%";
            armorStat.text = "Defense: +" + (playerArmor.armorMod * 5) + "%";
            healthStat.text = "Health: +" + (playerHealth.modifier * 10);
            aSpeedStat.text = "Attack Speed: +" + (playerSwing.modifier * 10) + "%";
            mSpeedStat.text = "Move Speed: +" + (playerMove.modifier * 10) + "%";
        }
    }
}
