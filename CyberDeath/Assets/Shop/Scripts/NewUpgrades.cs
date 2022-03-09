using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class NewUpgrades : MonoBehaviour
    {
        [SerializeField] private PlayerAttackModule playerAttack;
        [SerializeField] private PlayerArmorModule playerArmor;
        [SerializeField] private PlayerHealthModule playerHealth;
        [SerializeField] private PlayerSwingModule playerSwing;
        [SerializeField] private PlayerSpeedModule playerMove;

        public void AttackBuff1_2()
        {
            playerAttack.OnPurchased(5, 1);
            playerSwing.OnPurchased(0.05f, 1);
        }

        public void AttackPowerUp1()
        {
            playerAttack.OnPurchased(10, 2);
        }

        public void AttackPowerUp2()
        {
            playerAttack.OnPurchased(20, 4);
        }

        public void AttackSpeedUp1()
        {
            playerSwing.OnPurchased(0.10f, 2);
        }

        public void AttackSpeedUp2()
        {
            playerSwing.OnPurchased(0.20f, 4);
        }

        public void DefenseBuff1_2()
        {
            playerHealth.OnPurchased(5, 1);
            playerArmor.OnPurchased(5, 1);
            playerMove.OnPurchased(0.5f, 1);
        }

        public void HealthUp1()
        {
            playerHealth.OnPurchased(10, 2);
        }

        public void HealthUp2()
        {
            playerHealth.OnPurchased(10, 2);
        }

        public void ArmorUp1()
        {
            playerArmor.OnPurchased(10, 2);
        }

        public void ArmorUp2()
        {
            playerArmor.OnPurchased(10, 2);
        }

        public void MoveSpeedUp1()
        {
            playerMove.OnPurchased(1, 2);
        }

        public void MoveSpeedUp2()
        {
            playerMove.OnPurchased(1, 2);
        }
    }
}
