using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

namespace GoofyGhosts
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI displayText;
        public string[] lines;
        public Queue dialogue = new Queue();
        public float textDelay;
        public bool returnToFirst, returnToBuy, hideShop, leaveShop;

        int index;
        int charCount;
        bool canAdvance;

        public GameObject continueButton, shopKeep;
        public Animator anim, bAnim;
        private Animator sAnim;
        public AudioSource select, scroll, scroll2;

        private GameObject cm;
        private ChoiceManager choice;

        private GameObject sm;
        private ShopInterface shop;

        private GameObject scm;
        private SceneLoader scene;

        public int talkRandom;

        private PlayerControls controls;
        private bool progressAttempt;

        [SerializeField] private BoolChannelSO controlsToggle;
        [SerializeField] private VoidChannelSO toggleSettingsChannel;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        #region -- // Event Handling // --
        private void OnEnable()
        {
            controls.UI.Progress.started += _ => progressAttempt = true;
            controls.UI.Progress.canceled += _ => progressAttempt = false;
            controls.UI.Progress.Enable();
        }

        private void OnDisable()
        {
            controls.UI.Progress.Disable();
        }
        #endregion

        void Start()
        {
            toggleSettingsChannel.RaiseEvent();

            Random.seed = System.DateTime.Now.Millisecond;
            talkRandom = Random.Range(1, 4);

            Random.seed = System.DateTime.Now.Millisecond;
            int random = Random.Range(1, 5);

            if (random == 1)
            {
                QueueDialogue(1);

            }
            else if (random == 2)
            {
                QueueDialogue(26);
            }
            else if (random == 3)
            {
                QueueDialogue(27);
            }
            else
            {
                QueueDialogue(28);
            }

            bAnim = continueButton.GetComponent<Animator>();
            sAnim = shopKeep.GetComponent<Animator>();

            cm = GameObject.Find("ChoiceManager");
            choice = cm.GetComponent<ChoiceManager>();

            sm = GameObject.Find("ShopManager");
            shop = sm.GetComponent<ShopInterface>();

            scm = GameObject.Find("SceneManager");
            scene = scm.GetComponent<SceneLoader>();

            //choiceNext = true;
            returnToFirst = true;
            StartCoroutine(Print());

            controlsToggle.RaiseEvent(false);
        }

        void Update()
        {
            /*
            if(displayText.text == lines[index])
            {
                continueButton.SetActive(true);
                canAdvance = true;
            } */

            if (dialogue.Count > 0)
            {
                if (displayText.text == dialogue.Peek().ToString())
                {
                    sAnim.SetBool("isTalking", false);
                    if (shop.shopActive == false)
                    {                       
                        continueButton.SetActive(true);
                        canAdvance = true;

                    }
                    else
                    {                        
                        canAdvance = false;
                    }
                }
            }

            if (progressAttempt
                && canAdvance)
            {
                progressAttempt = false;
                NextLine();
            }
        }

        IEnumerator Print()
        {
            sAnim.SetBool("isTalking", true);
            foreach (char letter in (dialogue.Peek().ToString()).ToCharArray())
            {
                ++charCount;
                int random = Random.Range(0, 2);

                if (charCount % 2 == 0)
                {
                    if (random == 0)
                        scroll.Play();
                    else
                        scroll2.Play();
                }

                displayText.text += letter;
                yield return new WaitForSeconds(textDelay / 100f);
            }
            /*
            foreach (char letter in lines[index].ToCharArray())
            {
                ++charCount;
                int random = Random.Range(0, 2);

                if(charCount % 2 == 0)
                {
                    if (random == 0)
                        scroll.Play();
                    else
                        scroll2.Play();
                }

                displayText.text += letter;
                yield return new WaitForSeconds(textDelay / 100f);

            } */
        }

        public void NextLine()
        {
            select.Play();
            anim.SetTrigger("Change");
            bAnim.SetTrigger("Change");
            continueButton.SetActive(false);
            canAdvance = false;

            bool toChoice = false;

            if (returnToFirst == true && dialogue.Count == 1)
            {
                toChoice = true;
                choice.ToggleChoice(3);
                returnToFirst = false;                
            }

            /*
            if (hideShop == true)
            {
                shop.ToggleInterface();
            } */

            if (leaveShop == true)
            {
                controlsToggle.RaiseEvent(true);
                toggleSettingsChannel.RaiseEvent();
                scene.LoadGameScene();
                leaveShop = false;
            }

            /*
            if(choiceNext == true)
            {
                choice.ToggleChoice(3);
                choiceNext = false;
            } */

            /*
            if (index < lines.Length - 1)
            {
                index++;
                displayText.text = "";
                StartCoroutine(Print());
            }
            else
            {
                displayText.text = "";
                continueButton.SetActive(false);
                canAdvance = false;
            } */

            if (dialogue.Count > 0 && toChoice == true)
            {
                dialogue.Dequeue();
                displayText.text = "";
            }
            else if (dialogue.Count > 0)
            {
                dialogue.Dequeue();
                displayText.text = "";
                StartCoroutine(Print());
            }
            else
            {
                displayText.text = "";
                continueButton.SetActive(false);
                canAdvance = false;
            }
        }

        // Used by other scripts to push a string into the queue
        // to then be printed as dialogue
        public void QueueDialogue(int x)
        {
            dialogue.Enqueue(lines[x]);
        }

        public void DequeueDialogue()
        {
            dialogue.Dequeue();
        }

        public int GetQueueCount()
        {
            print(dialogue.Count);
            return dialogue.Count;
        }

        public void PrintQueue()
        {
            foreach (string line in dialogue)
            {
                print(dialogue.Peek());
            }
        }

        public void ClearQueue()
        {
            dialogue.Clear();
        }

        public void Choice(int x)
        {
            //GUIDE:
            // 0 = BUY dialogue
            // 1 = TALK dialogue
            // 2 = LEAVE dialogue
            // 3 = BUY ITEM dialogue
            // 4 = REFUSE BUY ITEM dialogue
            switch (x)
            {
                case 0:
                    Random.seed = System.DateTime.Now.Millisecond;
                    int random = Random.Range(1, 4);
                    if (random == 1 && ScrapCounter.scrapCount > 100)
                        QueueDialogue(9);
                    else if (random == 2)
                        QueueDialogue(15);
                    else
                        QueueDialogue(2);
                    //anim.SetTrigger("Change");
                    returnToFirst = true;
                    shop.ToggleInterface();
                    break;

                case 1:
                    //anim.SetTrigger("Change");

                    if (talkRandom == 1)
                    {
                        talkRandom = 2;
                        QueueDialogue(10);
                        QueueDialogue(11);
                        QueueDialogue(12);
                    }
                    else if (talkRandom == 2)
                    {
                        talkRandom = 3;
                        QueueDialogue(3);
                        QueueDialogue(4);
                        QueueDialogue(5);
                    }
                    else
                    {
                        talkRandom = 1;
                        QueueDialogue(16);
                        QueueDialogue(17);
                        QueueDialogue(18);
                    }

                    returnToFirst = true;
                    //anim.SetTrigger("Change");              
                    break;

                case 2:
                    Random.seed = System.DateTime.Now.Millisecond;
                    int random2 = Random.Range(1, 5);

                    if (random2 == 1)
                    {
                        QueueDialogue(6);
                    }
                    else if (random2 == 2)
                    {
                        QueueDialogue(19);
                    }
                    else if (random2 == 3)
                    {
                        QueueDialogue(20);
                    }
                    else
                    {
                        QueueDialogue(21);
                    }

                    leaveShop = true;
                    break;

                case 3:
                    QueueDialogue(7);
                    break;

                case 4:
                    QueueDialogue(8);
                    break;

                default:
                    QueueDialogue(0);
                    break;
            }

            StartCoroutine(Print());
        }
    }
}