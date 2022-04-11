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

        private AbilityManager am;

        public void Start()
        {
            pm = GameObject.Find("PurchaseManager").GetComponent<PurchaseManager>();
            am = GameObject.Find("Player_Updated").GetComponent<AbilityManager>();

            for (int i = 0; i < 17; i++)
            {
                buttons[i].image.color = Color.gray;
            }

            if (pm.purchase1)
            {
                buttons[17].interactable = false;
                buttons[0].image.color = Color.white;
                aCounter1 = 1;
            }
            if (pm.purchase17)
            {
                buttons[0].interactable = false;
                buttons[14].image.color = Color.white;
                aCounter1 = 2;
            }
            if (pm.purchase18)
            {
                buttons[15].interactable = false;
            }
            if (pm.purchase2)
            {
                buttons[14].interactable = false;
                buttons[1].image.color = Color.white;
                buttons[3].image.color = Color.white;
                buttons[12].image.color = Color.white;
                buttons[15].image.color = Color.white;
                aCounter1 = 3;
            }
            if (pm.purchase3)
            {
                buttons[1].interactable = false;
                buttons[2].image.color = Color.white;
                aCounter2 = 1;
            }
            if (pm.purchase4)
            {
                buttons[2].interactable = false;
                aCounter2 = 2;
            }
            if (pm.purchase5)
            {
                buttons[3].interactable = false;
                buttons[4].image.color = Color.white;
                aCounter3 = 1;
            }
            if (pm.purchase6)
            {
                buttons[4].interactable = false;
                aCounter3 = 2;
            }
            if (pm.purchase7)
            {
                buttons[12].interactable = false;
                buttons[13].image.color = Color.white;
                aCounter4 = 1;
            }
            if (pm.purchase8)
            {
                buttons[13].interactable = false;
                aCounter4 = 2;
            }
            if (pm.purchase9)
            {
                buttons[18].interactable = false;
                buttons[5].image.color = Color.white;
                dCounter1 = 1;
            }
            if (pm.purchase19)
            {
                buttons[5].interactable = false;
                buttons[16].image.color = Color.white;
                dCounter1 = 2;
            }
            if (pm.purchase10)
            {
                buttons[16].interactable = false;
                buttons[6].image.color = Color.white;
                buttons[8].image.color = Color.white;
                buttons[10].image.color = Color.white;
                buttons[15].image.color = Color.white;
                dCounter1 = 3;
            }
            if (pm.purchase11)
            {
                buttons[6].interactable = false;
                buttons[7].image.color = Color.white;
                dCounter2 = 1;
            }
            if (pm.purchase12)
            {
                buttons[7].interactable = false;
                dCounter2 = 2;
            }
            if (pm.purchase13)
            {
                buttons[8].interactable = false;
                buttons[9].image.color = Color.white;
                dCounter3 = 1;
            }
            if (pm.purchase14)
            {
                buttons[9].interactable = false;
                dCounter3 = 2;
            }
            if (pm.purchase15)
            {
                buttons[10].interactable = false;
                buttons[11].image.color = Color.white;
                dCounter4 = 1;
            }
            if (pm.purchase16)
            {
                buttons[11].interactable = false;
                dCounter4 = 2;
            }
        }

        public void AttackBuff1()
        {
            if (aCounter1 == 0 && GetScrapCount() >= 10 && !pm.purchase1)
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
                buttons[17].interactable = false;
                buttons[17].Select();
            }
        }

        public void AttackBuff2()
        {
            if (aCounter1 == 1 && GetScrapCount() >= 15 && !pm.purchase17)
            {
                playerAttack.OnPurchased(5, 1);
                playerSwing.OnPurchased(0.05f, 1);
                GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance += 5;
                aCounter1++;
                pm.purchase17 = true;
                ScrapCounter.scrapCount -= 15;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[14].image.color = Color.white;
                buttons[0].interactable = false;
                buttons[0].Select();
            }
        }

        public void GroundSlam()
        {
            if (aCounter1 == 2 && GetScrapCount() >= 25 && !pm.purchase2)
            {
                am.slamPurchased = true;
                aCounter1++;
                pm.purchase2 = true;
                ScrapCounter.scrapCount -= 25;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[1].image.color = Color.white;
                buttons[3].image.color = Color.white;
                buttons[12].image.color = Color.white;
                buttons[15].image.color = Color.white;
                buttons[14].interactable = false;
                buttons[14].Select();
            }
        }

        public void EMP()
        {
            if ((aCounter1 == 3 || dCounter1 == 3) && GetScrapCount() >= 25 && !pm.purchase18)
            {
                am.empPurchased = true;
                pm.purchase18 = true;
                ScrapCounter.scrapCount -= 25;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[15].interactable = false;
                buttons[15].Select();
            }
        }

        public void AttackPowerUp1()
        {
            if (aCounter1 == 3 && aCounter2 == 0 && GetScrapCount() >= 40 && !pm.purchase3)
            {
                playerAttack.OnPurchased(10, 2);
                aCounter2++;
                pm.purchase3 = true;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[2].image.color = Color.white;
                buttons[1].interactable = false;
                buttons[1].Select();
            }
        }

        public void AttackPowerUp2()
        {
            if (aCounter2 == 1 && GetScrapCount() >= 50 && !pm.purchase4)
            {
                playerAttack.OnPurchased(20, 4);
                aCounter2++;
                pm.purchase4 = true;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[2].interactable = false;
                buttons[2].Select();
            }
        }

        public void AttackSpeedUp1()
        {
            if (aCounter1 == 3 && aCounter3 == 0 && GetScrapCount() >= 40 && !pm.purchase5)
            {
                playerSwing.OnPurchased(0.10f, 2);
                aCounter3++;
                pm.purchase5 = true;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[4].image.color = Color.white;
                buttons[3].interactable = false;
                buttons[3].Select();
            }
        }

        public void AttackSpeedUp2()
        {
            if (aCounter3 == 1 && GetScrapCount() >= 50 && !pm.purchase6)
            {
                playerSwing.OnPurchased(0.20f, 4);
                aCounter3++;
                pm.purchase6 = true;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[4].interactable = false;
                buttons[4].Select();
            }
        }

        public void CritChanceUp1()
        {
            if (aCounter1 == 3 && aCounter4 == 0 && GetScrapCount() >= 40 && !pm.purchase7)
            {
                GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance += 10;
                aCounter4++;
                pm.purchase7 = true;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[13].image.color = Color.white;
                buttons[12].interactable = false;
                buttons[12].Select();
            }
        }

        public void CritChanceUp2()
        {
            if (aCounter4 == 1 && GetScrapCount() >= 50 && !pm.purchase8)
            {
                GameObject.Find("CritChanceStorage").GetComponent<CritChanceStorage>().critChance += 15;
                aCounter4++;
                pm.purchase8 = true;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[13].interactable = false;
                buttons[13].Select();
            }
        }

        public void DefenseBuff1()
        {
            if (dCounter1 == 0 && GetScrapCount() >= 10 && !pm.purchase9)
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
                buttons[18].interactable = false;
                buttons[18].Select();
            }
        }

        public void DefenseBuff2()
        {
            if (dCounter1 == 1 && GetScrapCount() >= 15 && !pm.purchase19)
            {
                playerHealth.OnPurchased(5, 1);
                playerArmor.OnPurchased(5, 1);
                playerMove.OnPurchased(0.5f, 1);
                dCounter1++;
                pm.purchase19 = true;
                ScrapCounter.scrapCount -= 15;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[16].image.color = Color.white;
                buttons[5].interactable = false;
                buttons[5].Select();
            }
        }

        public void TaniumSkin()
        {
            if (dCounter1 == 2 && GetScrapCount() >= 25 && !pm.purchase10)
            {
                am.taniumPurchased = true;
                dCounter1++;
                pm.purchase10 = true;
                ScrapCounter.scrapCount -= 25;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[6].image.color = Color.white;
                buttons[8].image.color = Color.white;
                buttons[10].image.color = Color.white;
                buttons[15].image.color = Color.white;
                buttons[16].interactable = false;
                buttons[16].Select();
            }
        }

        public void HealthUp1()
        {
            if (dCounter1 == 3 && dCounter2 == 0 && GetScrapCount() >= 40 && !pm.purchase11) 
            { 
                playerHealth.OnPurchased(10, 2);
                dCounter2++;
                pm.purchase11 = true;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[7].image.color = Color.white;
                buttons[6].interactable = false;
                buttons[6].Select();
            }
        }

        public void HealthUp2()
        {
            if (dCounter2 == 1 && GetScrapCount() >= 50 && !pm.purchase12)
            {
                playerHealth.OnPurchased(10, 2);
                dCounter2++;
                pm.purchase12 = true;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[7].interactable = false;
                buttons[7].Select();
            }
        }

        public void ArmorUp1()
        {
            if (dCounter1 == 3 && dCounter3 == 0 && GetScrapCount() >= 40 && !pm.purchase13)
            {
                playerArmor.OnPurchased(10, 2);
                dCounter3++;
                pm.purchase13 = true;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[9].image.color = Color.white;
                buttons[8].interactable = false;
                buttons[8].Select();
            }
        }

        public void ArmorUp2()
        {
            if (dCounter3 == 1 && GetScrapCount() >= 50 && !pm.purchase14)
            {
                playerArmor.OnPurchased(10, 2);
                dCounter3++;
                pm.purchase14 = true;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[9].interactable = false;
                buttons[9].Select();
            }
        }

        public void MoveSpeedUp1()
        {
            if (dCounter1 == 3 && dCounter4 == 0 && GetScrapCount() >= 40 && !pm.purchase15)
            {
                playerMove.OnPurchased(1, 2);
                dCounter4++;
                pm.purchase15 = true;
                ScrapCounter.scrapCount -= 40;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[11].image.color = Color.white;
                buttons[10].interactable = false;
                buttons[10].Select();
            }
        }

        public void MoveSpeedUp2()
        {
            if (dCounter4 == 1 && GetScrapCount() >= 50 && !pm.purchase16)
            {
                playerMove.OnPurchased(1, 2);
                dCounter4++;
                pm.purchase16 = true;
                ScrapCounter.scrapCount -= 50;
                ScrapCounter.OnScrapCountChange();
                UpdateMoneyText();
                buttons[11].interactable = false;
                buttons[11].Select();
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
