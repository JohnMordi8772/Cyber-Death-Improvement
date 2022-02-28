using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GoofyGhosts
{
    public class ShopInterface : MonoBehaviour
    {
        [Tooltip("Items available for sale, drag them here!")]
        // Note: String values for now, can eventually be an array of
        // module Gameobjects, which can then be given to the player
        // and swapped out for the next rank gameObject when they
        // are bought
        //public string[] inventory;
        public GameObject[] inventory;
        public Sprite[] moduleSprites;

        public static GlobalModule shopPrices;
        public GlobalModule basePrices;

        // Current value being selected in the inventory
        private int index;

        public TextMeshProUGUI moduleText, moneyText, priceText;

        public bool shopActive, canBuy, firstPurchase;

        public Animator anim, sAnim;

        public GameObject cancelButton, arrows, shopArrows;
        public AudioSource buy, choose;

        public GameObject moduleObject;
        public Image moduleImage;

        private GameObject cm;
        private ChoiceManager choice;

        private GameObject dm;
        private Dialogue dialogue;

        private PlayerControls controls;
        private bool navLeft;
        private bool navRight;
        private bool progressClick;
        private bool escapeKey;
        private bool printInfoKey;
        private bool promoteKey;

        private void Awake()
        {
            controls = new PlayerControls();

            moduleImage = moduleObject.GetComponent<Image>();
        }

        #region -- // Event Handling // --
        private void OnEnable()
        {
            controls.UI.Left.started += _ => navLeft = true;
            controls.UI.Right.started += _ => navRight = true;
            controls.UI.Progress.started += _ => progressClick = true;

            controls.UI.Progress.started += _ => { if (shopActive) ClickButton(); };

            controls.UI.PrintInfo.started += _ => printInfoKey = true;
            controls.UI.Escape.started += _ => escapeKey = true;
            controls.UI.Promote.started += _ => promoteKey = true;

            controls.UI.Enable();
        }

        private void OnDisable()
        {
            controls.UI.Disable();
        }
        #endregion

        void Start()
        {
            //moduleText.text = inventory[0];
            shopPrices = ScriptableObject.CreateInstance<GlobalModule>();
            HydrateGlobalModule();
            anim = moduleText.GetComponent<Animator>();
            sAnim = shopArrows.GetComponent<Animator>();
            index = 0;

            cm = GameObject.Find("ChoiceManager");
            choice = cm.GetComponent<ChoiceManager>();

            dm = GameObject.Find("DialogueManager");
            dialogue = dm.GetComponent<Dialogue>();

            UpdateMoneyText();
            UpdatePriceText();

            //Time.timeScale = 0;
        }

        private void HydrateGlobalModule()
        {
            shopPrices.numberOfRanks = basePrices.numberOfRanks;
            shopPrices.priceIncrementRate = basePrices.priceIncrementRate;
        }

        void Update()
        {
            if (shopActive == true)
            {
                if (navLeft)
                {
                    sAnim.SetTrigger("Left");
                    choose.Play();
                    DecrementIndex();
                    UpdateModuleText();
                    UpdatePriceText();
                    ShowModuleInfo();
                    UpdateModuleImage();
                }

                if (navRight)
                {
                    sAnim.SetTrigger("Right");
                    choose.Play();
                    IncrementIndex();
                    UpdateModuleText();
                    UpdatePriceText();
                    ShowModuleInfo();
                    UpdateModuleImage();
                }

                if (escapeKey)
                {
                    EscapeKey();
                }

                /*
                if (Input.GetKeyDown("space") && canBuy == true)
                {
                    ClickButton();
                } */

                /*
                // PROMOTE KEY (DEBUG ONLY)
                if (promoteKey)
                {
                    /*
                    GameObject temp = inventory[index];
                    Module m = temp.GetComponent<Module>();
                    print("promoted!");
                    m.Promote(); 
                }

                // PRINT INFO (DEBUG ONLY)
                if (printInfoKey)
                {
                    
                    GameObject temp = inventory[index];
                    Module m = temp.GetComponent<Module>();
                    print("Rank: " + m.rank);
                    //print(m.price); 
                } */
            }

            navRight = false;
            navLeft = false;
            progressClick = false;
            escapeKey = false;
            promoteKey = false;
            printInfoKey = false;
        }

        void DecrementIndex()
        {
            if (index <= 0)
                index = inventory.Length - 1;
            else
                --index;

            //print(index);
        }

        void IncrementIndex()
        {
            if (index >= inventory.Length - 1)
                index = 0;
            else
                ++index;

            //print(index);
        }

        void UpdateModuleText()
        {
            moduleText.text = GetModuleName(index);
        }

        void UpdateModuleImage()
        {
            moduleImage.sprite = moduleSprites[index];
        }

        void UpdatePriceText()
        {
            priceText.text = "Price: " + (GetModulePrice(index)).ToString();
        }

        int GetScrapCount()
        {
            return ScrapCounter.scrapCount;
        }

        void UpdateMoneyText()
        {
            moneyText.text = "Scrap: " + GetScrapCount();
        }

        string GetModuleName(int x)
        {
            GameObject temp = inventory[x];
            Module m = temp.GetComponent<Module>();
            string a = m.GetDisplayName();
            return a;
        }

        int GetModulePrice(int x)
        {
            GameObject temp = inventory[x];
            Module m = temp.GetComponent<Module>();
            int a = m.GetPrice();
            return a;
        }

        void DecreasePrice()
        {
            ScrapCounter.scrapCount -= GetModulePrice(index);
            ScrapCounter.OnScrapCountChange();
            UpdateMoneyText();
        }

        void ShowModuleInfo()
        {

            GameObject temp = inventory[index];
            Module m = temp.GetComponent<Module>();
            string a = m.name;

            if (a == "Speed")
            {
                dialogue.displayText.text = "Increase movement speed by 25%.";
            }
            else if (a == "Swing")
            {
                dialogue.displayText.text = "Increase attack speed by 10%.";
            }
            else if (a == "Attack")
            {
                dialogue.displayText.text = "Increase damage by a small amount.";
            }
            else if (a == "Endurance")
            {
                dialogue.displayText.text = "Increase your health by 10 hitpoints.";
            }
            else if (a == "Armor")
            {
                dialogue.displayText.text = "Take 5% less damage.";
            }

            //dialogue.NextLine();
        }

        public void EscapeKey()
        { 
            //if( dialogue.displayText.text == dialogue.dialogue.Peek().ToString())
            //{
                ToggleInterface();
                dialogue.returnToFirst = true;
                dialogue.NextLine();
            //}
        }

        public void ToggleInterface()
        {
            shopActive = !shopActive;

            if (shopActive == true)
            {
                canBuy = true;
                anim.SetTrigger("Change");
                cancelButton.SetActive(true);
                arrows.SetActive(true);
                moduleText.text = GetModuleName(index);
            }
            else
            {
                canBuy = false;
                cancelButton.SetActive(false);
                arrows.SetActive(false);
                moduleText.text = "";
            }
        }

        public void ClickButton()
        {
            // Checks if dialogue is done printing
            if (dialogue.displayText.text == dialogue.dialogue.Peek().ToString())
            {
                //If player doesn't have enough money, deny purchase
                if (GetModulePrice(index) > GetScrapCount())
                {
                    //dialogue.ClearQueue();
                    //dialogue.displayText.text = "";

                    Random.seed = System.DateTime.Now.Millisecond;
                    int random1 = Random.Range(1, 4);

                    if (random1 == 1)
                    {
                        dialogue.QueueDialogue(14);
                    }
                    else if (random1 == 2)
                    {
                        dialogue.QueueDialogue(22);
                    }
                    else
                    {
                        dialogue.QueueDialogue(23);
                    }

                    dialogue.NextLine();
                }

                else
                {
                    buy.Play();
                    Random.seed = System.DateTime.Now.Millisecond;
                    int random2 = Random.Range(1, 4);

                    if (random2 == 1)
                    {
                        dialogue.QueueDialogue(13);
                    }
                    else if (random2 == 2)
                    {
                        dialogue.QueueDialogue(24);
                    }
                    else
                    {
                        dialogue.QueueDialogue(25);
                    }

                    dialogue.NextLine();
                    ConfirmPurchase();
                }
            }          
        }

        GameObject ConfirmPurchase()
        {
            // CHECK IF PLAYER CAN BUY HERE

            GameObject temp = inventory[index];
            Module m = temp.GetComponent<Module>();
            string a = m.GetDisplayName();
            print("Returned: " + a);
            
            DecreasePrice();
            m.OnPurchased();
            m.Promote();

            UpdatePriceText();
            UpdateModuleText();

            // GAME OBJECT MODULE IS RETURNED TO PLAYER HERE,
            // This line returns the current module being viewed
            // in the shop indicated by the index
            // Each module has a name, value, etc. that can be used
            // by the player scrips to determine what values to raise.
            // For more info, check the Module.cs script
            return inventory[index];
        }
    }
}