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
        private int aCounter4 = 0;
        private int dCounter1 = 0;
        private int dCounter2 = 0;
        private int dCounter3 = 0;
        private int dCounter4 = 0;

        public TextMeshProUGUI moneyText;

        public Button[] buttons;

        private PurchaseManager pm;

        public void Start()
        {
            pm = GameObject.Find("PurchaseManager").GetComponent<PurchaseManager>();

            for (int i = 0; i < 14; i++)
            {
                buttons[i].image.color = Color.gray;
            }

            if (pm.purchase1)
            {
                buttons[14].GetComponentInChildren<Text>().text = "Purchased";
                buttons[0].image.color = Color.white;
                aCounter1 = 1;
            }
            if (pm.purchase2)
            {
                buttons[0].GetComponentInChildren<Text>().text = "Purchased";
                buttons[1].image.color = Color.white;
                buttons[3].image.color = Color.white;
                buttons[12].image.color = Color.white;
                aCounter1 = 2;
            }
            if (pm.purchase3)
            {
                buttons[1].GetComponentInChildren<Text>().text = "Purchased";
                buttons[2].image.color = Color.white;
                aCounter2 = 1;
            }
            if (pm.purchase4)
            {
                buttons[2].GetComponentInChildren<Text>().text = "Purchased";
                aCounter2 = 2;
            }
            if (pm.purchase5)
            {
                buttons[3].GetComponentInChildren<Text>().text = "Purchased";
                buttons[4].image.color = Color.white;
                aCounter3 = 1;
            }
            if (pm.purchase6)
            {
                buttons[4].GetComponentInChildren<Text>().text = "Purchased";
                aCounter3 = 2;
            }
            if (pm.purchase7)
            {
                buttons[12].GetComponentInChildren<Text>().text = "Purchased";
                buttons[13].image.color = Color.white;
                aCounter4 = 1;
            }
            if (pm.purchase8)
            {
                buttons[13].GetComponentInChildren<Text>().text = "Purchased";
                aCounter4 = 2;
            }
            if (pm.purchase9)
            {
                buttons[15].GetComponentInChildren<Text>().text = "Purchased";
                buttons[5].image.color = Color.white;
                dCounter1 = 1;
            }
            if (pm.purchase10)
            {
                buttons[5].GetComponentInChildren<Text>().text = "Purchased";
                buttons[6].image.color = Color.white;
                buttons[8].image.color = Color.white;
                buttons[10].image.color = Color.white;
                dCounter1 = 2;
            }
            if (pm.purchase11)
            {
                buttons[6].GetComponentInChildren<Text>().text = "Purchased";
                buttons[7].image.color = Color.white;
                dCounter2 = 1;
            }
            if (pm.purchase12)
            {
                buttons[7].GetComponentInChildren<Text>().text = "Purchased";
                dCounter2 = 2;
            }
            if (pm.purchase13)
            {
                buttons[8].GetComponentInChildren<Text>().text = "Purchased";
                buttons[9].image.color = Color.white;
                dCounter3 = 1;
            }
            if (pm.purchase14)
            {
                buttons[9].GetComponentInChildren<Text>().text = "Purchased";
                dCounter3 = 2;
            }
            if (pm.purchase15)
            {
                buttons[10].GetComponentInChildren<Text>().text = "Purchased";
                buttons[11].image.color = Color.white;
                dCounter4 = 1;
            }
            if (pm.purchase16)
            {
                buttons[11].GetComponentInChildren<Text>().text = "Purchased";
                dCounter4 = 2;
            }
        }

        public void AttackBuff1()
        {
            if (aCounter1 == 0 && GetScrapCount() >= 10)
            {
                playerAttack.OnPurchased(5, 1);
                playerSwing.OnPurchased(0.05f, 1);
                GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance += 5;
                aCounter1++;
                pm.purchase1 = true;
                ScrapCounter.scrapCount -= 10;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[0].image.color = Color.white;
                buttons[14].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void AttackBuff2()
        {
            if (aCounter1 == 1 && GetScrapCount() >= 15)
            {
                playerAttack.OnPurchased(5, 1);
                playerSwing.OnPurchased(0.05f, 1);
                GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance += 5;
                aCounter1++;
                pm.purchase2 = true;
                ScrapCounter.scrapCount -= 15;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[1].image.color = Color.white;
                buttons[3].image.color = Color.white;
                buttons[12].image.color = Color.white;
                buttons[0].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void AttackPowerUp1()
        {
            if (aCounter1 == 2 && aCounter2 == 0 && GetScrapCount() >= 40)
            {
                playerAttack.OnPurchased(10, 2);
                aCounter2++;
                pm.purchase3 = true;
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
                pm.purchase4 = true;
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
                pm.purchase5 = true;
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
                pm.purchase6 = true;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[4].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void CritChanceUp1()
        {
            if (aCounter1 == 2 && aCounter4 == 0 && GetScrapCount() >= 40)
            {
                GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance += 10;
                aCounter4++;
                pm.purchase7 = true;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[13].image.color = Color.white;
                buttons[12].GetComponentInChildren<Text>().text = "Purchased";
            }
        }

        public void CritChanceUp2()
        {
            if (aCounter4 == 1 && GetScrapCount() >= 50)
            {
                GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance += 15;
                aCounter4++;
                pm.purchase8 = true;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[13].GetComponentInChildren<Text>().text = "Purchased";
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
                pm.purchase9 = true;
                ScrapCounter.scrapCount -= 10;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[5].image.color = Color.white;
                buttons[15].GetComponentInChildren<Text>().text = "Purchased";
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
                pm.purchase10 = true;
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
                pm.purchase11 = true;
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
                pm.purchase12 = true;
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
                pm.purchase13 = true;
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
                pm.purchase14 = true;
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
                pm.purchase15 = true;
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
                pm.purchase16 = true;
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
