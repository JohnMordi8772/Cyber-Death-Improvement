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

        private int aCounter1 = 0;
        private int aCounter2 = 0;
        private int aCounter3 = 0;
        private int dCounter1 = 0;
        private int dCounter2 = 0;
        private int dCounter3 = 0;
        private int dCounter4 = 0;

        public void AttackBuff1()
        {
            if (aCounter1 == 0)
            {
                playerAttack.OnPurchased(5, 1);
                playerSwing.OnPurchased(0.05f, 1);
                aCounter1++;
            }
        }

        public void AttackBuff2()
        {
            if (aCounter1 == 1)
            {
                playerAttack.OnPurchased(5, 1);
                playerSwing.OnPurchased(0.05f, 1);
                aCounter1++;
            }
        }

        public void AttackPowerUp1()
        {
            if (aCounter1 == 2 && aCounter2 == 0)
            {
                playerAttack.OnPurchased(10, 2);
                aCounter2++;
            }
        }

        public void AttackPowerUp2()
        {
            if (aCounter2 == 1)
            {
                playerAttack.OnPurchased(20, 4);
                aCounter2++;
            }
        }

        public void AttackSpeedUp1()
        {
            if (aCounter1 == 2 && aCounter3 == 0)
            {
                playerSwing.OnPurchased(0.10f, 2);
                aCounter3++;
            }
        }

        public void AttackSpeedUp2()
        {
            if (aCounter3 == 1)
            {
                playerSwing.OnPurchased(0.20f, 4);
                aCounter3++;
            }
        }

        public void DefenseBuff1()
        {
            if (dCounter1 == 0)
            {
                playerHealth.OnPurchased(5, 1);
                playerArmor.OnPurchased(5, 1);
                playerMove.OnPurchased(0.5f, 1);
                dCounter1++;
            }
        }

        public void DefenseBuff2()
        {
            if (dCounter1 == 1)
            {
                playerHealth.OnPurchased(5, 1);
                playerArmor.OnPurchased(5, 1);
                playerMove.OnPurchased(0.5f, 1);
                dCounter1++;
            }
        }

        public void HealthUp1()
        {
            if (dCounter1 == 2 && dCounter2 == 0) 
            { 
                playerHealth.OnPurchased(10, 2);
                dCounter2++;
            }
        }

        public void HealthUp2()
        {
            if (dCounter2 == 1)
            {
                playerHealth.OnPurchased(10, 2);
                dCounter2++;
            }
        }

        public void ArmorUp1()
        {
            if (dCounter1 == 2 && dCounter3 == 0)
            {
                playerArmor.OnPurchased(10, 2);
                dCounter3++;
            }
        }

        public void ArmorUp2()
        {
            if (dCounter3 == 1)
            {
                playerArmor.OnPurchased(10, 2);
                dCounter3++;
            }
        }

        public void MoveSpeedUp1()
        {
            if (dCounter1 == 2 && dCounter4 == 0)
            {
                playerMove.OnPurchased(1, 2);
                dCounter4++;
            }
        }

        public void MoveSpeedUp2()
        {
            if (dCounter4 == 1)
            {
                playerMove.OnPurchased(1, 2);
                dCounter4++;
            }
        }
    }
}
