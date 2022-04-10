using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoofyGhosts
{
    public class ChoiceManager : MonoBehaviour
    {
        // Whether or not the interface is expecting the player
        // to make a choice or not
        public bool isInChoice;

        // How many choices there are
        public int numberOfChoices;

        // Current value being selected
        public int index;

        public GameObject choice2, choice3, pointer;
        //public GameObject text1, text2, text3;

        public AudioSource choose, select;

        private GameObject dm;
        private Dialogue dialogue;

        private Animator anim3, anim2, pAnim;

        private PlayerControls controls;
        private bool navLeft;
        private bool navRight;
        private bool progressClick;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.UI.Left.performed += _ => navLeft = true;
            controls.UI.Right.performed += _ => navRight = true;
            controls.UI.Progress.performed += _ => progressClick = true;
            controls.UI.Enable();
        }

        private void OnDisable()
        {
            controls.UI.Disable();
        }

        void Start()
        {
            //pointerPos = pointer.GetComponent<Transform>();
            dm = GameObject.Find("DialogueManager");
            dialogue = dm.GetComponent<Dialogue>();
            anim3 = choice3.GetComponent<Animator>();
            anim2 = choice3.GetComponent<Animator>();
            pAnim = pointer.GetComponent<Animator>();
        }

        void Update()
        {
            if (isInChoice == true)
            {
                if (navLeft
                    && index > 0)
                {
                    DecrementIndex();
                    ManagePointer();
                    //print(index);
                }

                if (navRight
                    && index < numberOfChoices - 1)
                {
                    IncrementIndex();
                    ManagePointer();
                    //print(index);
                }

                if (progressClick)
                {
                    Choose();
                }
            }
            /*
            if(index < 0)
            {
                index = numberOfChoices - 1;
            }

            if(index > numberOfChoices - 1)
            {
                index = 0;
            }   */

            navLeft = false;
            navRight = false;
            progressClick = false;
        }

        void DecrementIndex()
        {
            choose.Play();
            if (index < 0)
                index = 0;
            else
                --index;
        }

        void IncrementIndex()
        {
            choose.Play();
            if (index > numberOfChoices - 1)
                index = numberOfChoices - 1;
            else
                ++index;
        }

        public void Choose()
        {
            select.Play();
            if (numberOfChoices == 2)
                dialogue.Choice(index + 3);
            else
                dialogue.Choice(index);

            ToggleChoice(0);
        }

        public void Choose(int button)
        {
            select.Play();
            if (numberOfChoices == 2)
                dialogue.Choice(button + 3);
            else
                dialogue.Choice(button);

            ToggleChoice(0);
        }



        void ManagePointer()
        {
            if (numberOfChoices == 2)
            {
                /*
                if (index == 1)
                    pointerPos.position = new Vector3(pPos2, 
                        pointerPos.position.y, -1);
                else
                    pointerPos.position = new Vector3(pPos1, 
                        pointerPos.position.y, -1); */
            }
            else
            {
                if (index == 1)
                {
                    pAnim.SetBool("pos2", true);
                    pAnim.SetBool("pos1", false);
                    pAnim.SetBool("pos3", false);

                    anim3.SetTrigger("text2");

                }
                else if (index == 2)
                {
                    pAnim.SetBool("pos3", true);
                    pAnim.SetBool("pos1", false);
                    pAnim.SetBool("pos2", false);

                    anim3.SetTrigger("text3");
                }
                else
                {
                    pAnim.SetBool("pos1", true);
                    pAnim.SetBool("pos2", false);
                    pAnim.SetBool("pos3", false);

                    anim3.SetTrigger("text1");
                }

                /*
                if (index == 1)
                    pointerPos.position = new Vector3(pPos2,
                        pointerPos.position.y, -1);
                else if (index == 2)
                    pointerPos.position = new Vector3(pPos3, 
                        pointerPos.position.y, -1);
                else
                    pointerPos.position = new Vector3(pPos1,
                        pointerPos.position.y, -1); */
            }
        }

        // Called by other functions to indicate that
        // a choice is being made.
        public void ToggleChoice(int x)
        {
            isInChoice = !isInChoice;

            if (isInChoice == true)
            {
                dialogue.ClearQueue();
                dialogue.displayText.text = "";

                //index = 0;
                numberOfChoices = x;

                if (x == 3)
                {
                    choice3.SetActive(true);
                }
                else
                {
                    choice2.SetActive(true);
                }

                ManagePointer();
                pointer.SetActive(true);

            }

            if (isInChoice == false)
            {
                choice2.SetActive(false);
                choice3.SetActive(false);
                pointer.SetActive(false);
            }
        }
    }
}