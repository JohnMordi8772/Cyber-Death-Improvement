using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoofyGhosts
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject pointer;
        [SerializeField] private GameObject textObject;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject howToPlay;
        [SerializeField] private GameObject credits;

        [SerializeField] private AudioSource choose;
        [SerializeField] private AudioSource select;

        // Animators for text and pointer
        private Animator anim, pAnim;

        // Current value being selected
        private int index;

        // Edit in inspector, four by default
        public int numberOfChoices;

        private PlayerControls controls;
        private bool navUp;
        private bool navDown;
        private bool progressClick;

        void Awake()
        {
            // Access the animators
            anim = textObject.GetComponent<Animator>();
            pAnim = pointer.GetComponent<Animator>();
            controls = new PlayerControls();
        }

        private void Start()
        {
            Time.timeScale = 1;
            ShowMainMenu();
        }

        private void OnDisable()
        {
            controls.UI.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            if (navUp && index > 0)
            {
                DecrementIndex();
                ManagePointer();
            }

            if (navDown && index < numberOfChoices - 1)
            {
                IncrementIndex();
                ManagePointer();
            }

            if (progressClick)
            {
                Choose();
            }

            navUp = false;
            navDown = false;
            progressClick = false;
        }


        // Called when left input is detected
        void DecrementIndex()
        {
            choose.Play();
            if (index <= 0)
                index = numberOfChoices - 1;
            else
                --index;

        }

        // Called when right input detected
        void IncrementIndex()
        {
            choose.Play();
            if (index >= numberOfChoices - 1)
                index = 0;
            else
                ++index;
        }

        // Moves the pointer around
        void ManagePointer()
        {
            if (index == 1)
            { 
                anim.SetTrigger("Text2");
                pAnim.SetBool("pos2", true);
                pAnim.SetBool("pos1", false);
                pAnim.SetBool("pos3", false);
                pAnim.SetBool("pos4", false);
            }
            else if (index == 2)
            {
                anim.SetTrigger("Text3");
                pAnim.SetBool("pos3", true);
                pAnim.SetBool("pos1", false);
                pAnim.SetBool("pos2", false);
                pAnim.SetBool("pos4", false);
            }
            else if (index == 3)
            {
                anim.SetTrigger("Text4");
                pAnim.SetBool("pos4", true);
                pAnim.SetBool("pos1", false);
                pAnim.SetBool("pos2", false);
                pAnim.SetBool("pos3", false);
            }
            else
            {
                anim.SetTrigger("Text1");
                pAnim.SetBool("pos1", true);
                pAnim.SetBool("pos2", false);
                pAnim.SetBool("pos3", false);
                pAnim.SetBool("pos4", false);
            }
        }

        void ShowCredits()
        {
            controls.Dispose();
            controls = new PlayerControls();

            controls.UI.Progress.started += _ => ShowMainMenu();
            controls.UI.Escape.started += _ => ShowMainMenu();
            controls.UI.Enable();

            credits.SetActive(true);
            howToPlay.SetActive(false);
            mainMenu.SetActive(false);
        }

        void ShowHowToPlay()
        {
            controls.Dispose();
            controls = new PlayerControls();

            controls.UI.Progress.started += _ => ShowMainMenu();
            controls.UI.Escape.started += _ => ShowMainMenu();
            controls.UI.Enable();

            howToPlay.SetActive(true);
            credits.SetActive(false);
            mainMenu.SetActive(false);

        }

        void ShowMainMenu()
        {
            index = 0;

            controls.Dispose();
            controls = new PlayerControls();

            controls.UI.Up.started += _ => navUp = true;
            controls.UI.Down.started += _ => navDown = true;
            controls.UI.Progress.started += _ => progressClick = true;
            controls.UI.Enable();

            mainMenu.SetActive(true);
            credits.SetActive(false);
            howToPlay.SetActive(false);
        }

        void QuitGame()
        {
            Application.Quit();
        }

        void LoadGameScene()
        {
            SceneManager.LoadSceneAsync("Greybox2");
        }

        // Called when an option is selected
        void Choose()
        {
            select.Play();

            switch( index )
            {
                // How to Play
                case 1:
                    ShowHowToPlay();
                    break;

                // Credits
                case 2:
                    ShowCredits();
                    break;
                
                // Quit
                case 3:
                    QuitGame();
                    break;

                // Play
                default:
                    LoadGameScene();
                    break;
            }               
        }
    }
}
