using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        public TextMeshProUGUI moneyText;

        public Button[] buttons;

        public void Start()
        {
            for (int i = 0; i < 12; i++)
            {
                buttons[i].image.color = Color.gray;
            }
        }

        public void AttackBuff1()
        {
            if (aCounter1 == 0 && GetScrapCount() >= 10)
            {
                playerAttack.OnPurchased(5, 1);
                playerSwing.OnPurchased(0.05f, 1);
                aCounter1++;
                ScrapCounter.scrapCount -= 10;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[0].image.color = Color.white;
                buttons[12].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void AttackBuff2()
        {
            if (aCounter1 == 1 && GetScrapCount() >= 15)
            {
                playerAttack.OnPurchased(5, 1);
                playerSwing.OnPurchased(0.05f, 1);
                aCounter1++;
                ScrapCounter.scrapCount -= 15;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[1].image.color = Color.white;
                buttons[3].image.color = Color.white;
                buttons[0].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void AttackPowerUp1()
        {
            if (aCounter1 == 2 && aCounter2 == 0 && GetScrapCount() >= 40)
            {
                playerAttack.OnPurchased(10, 2);
                aCounter2++;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[2].image.color = Color.white;
                buttons[1].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void AttackPowerUp2()
        {
            if (aCounter2 == 1 && GetScrapCount() >= 50)
            {
                playerAttack.OnPurchased(20, 4);
                aCounter2++;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[2].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void AttackSpeedUp1()
        {
            if (aCounter1 == 2 && aCounter3 == 0 && GetScrapCount() >= 40)
            {
                playerSwing.OnPurchased(0.10f, 2);
                aCounter3++;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[4].image.color = Color.white;
                buttons[3].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void AttackSpeedUp2()
        {
            if (aCounter3 == 1 && GetScrapCount() >= 50)
            {
                playerSwing.OnPurchased(0.20f, 4);
                aCounter3++;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[4].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void DefenseBuff1()
        {
            if (dCounter1 == 0 && GetScrapCount() >= 10)
            {
                playerHealth.OnPurchased(5, 1);
                playerArmor.OnPurchased(5, 1);
                playerMove.OnPurchased(0.5f, 1);
                dCounter1++;
                ScrapCounter.scrapCount -= 10;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[5].image.color = Color.white;
                buttons[13].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void DefenseBuff2()
        {
            if (dCounter1 == 1 && GetScrapCount() >= 15)
            {
                playerHealth.OnPurchased(5, 1);
                playerArmor.OnPurchased(5, 1);
                playerMove.OnPurchased(0.5f, 1);
                dCounter1++;
                ScrapCounter.scrapCount -= 15;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[6].image.color = Color.white;
                buttons[8].image.color = Color.white;
                buttons[10].image.color = Color.white;
                buttons[5].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void HealthUp1()
        {
            if (dCounter1 == 2 && dCounter2 == 0 && GetScrapCount() >= 40) 
            { 
                playerHealth.OnPurchased(10, 2);
                dCounter2++;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[7].image.color = Color.white;
                buttons[6].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void HealthUp2()
        {
            if (dCounter2 == 1 && GetScrapCount() >= 50)
            {
                playerHealth.OnPurchased(10, 2);
                dCounter2++;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[7].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void ArmorUp1()
        {
            if (dCounter1 == 2 && dCounter3 == 0 && GetScrapCount() >= 40)
            {
                playerArmor.OnPurchased(10, 2);
                dCounter3++;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[9].image.color = Color.white;
                buttons[8].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void ArmorUp2()
        {
            if (dCounter3 == 1 && GetScrapCount() >= 50)
            {
                playerArmor.OnPurchased(10, 2);
                dCounter3++;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[9].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void MoveSpeedUp1()
        {
            if (dCounter1 == 2 && dCounter4 == 0 && GetScrapCount() >= 40)
            {
                playerMove.OnPurchased(1, 2);
                dCounter4++;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[11].image.color = Color.white;
                buttons[10].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void MoveSpeedUp2()
        {
            if (dCounter4 == 1 && GetScrapCount() >= 50)
            {
                playerMove.OnPurchased(1, 2);
                dCounter4++;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[11].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        int GetScrapCount()
        {
            return ScrapCounter.scrapCount;
        }

        void UpdateMoneyText()
        {
            moneyText.text = "Scrap: " + GetScrapCount();
        }
    }
}
