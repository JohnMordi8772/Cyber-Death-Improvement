/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 11/15/2021
*******************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoofyGhosts
{
    public class GameManager : MonoBehaviour
    {
        private PlayerControls controls;
        private bool gamePaused;
        [SerializeField] private VoidChannelSO pauseGameChannel;
        [SerializeField] private VoidChannelSO toggleSettingsControlsChannel;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        #region -- // Event Subbing / Unsubbing // --
        private void OnEnable()
        {
            controls.Settings.Pause.started += _ => PauseGame();
            controls.Settings.Pause.Enable();

            pauseGameChannel.OnEventRaised += PauseGame;
            toggleSettingsControlsChannel.OnEventRaised += ToggleSettingsControls;
        }

        private void OnDisable()
        {
            controls.Settings.Pause.Disable();

            pauseGameChannel.OnEventRaised -= PauseGame;
            toggleSettingsControlsChannel.OnEventRaised -= ToggleSettingsControls;
        }
        #endregion

        private void PauseGame()
        {
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync("PauseMenu");
            }
        }

        private void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void ToggleSettingsControls()
        {
            bool enabled = !controls.Settings.enabled;

            if (enabled)
            {
                print("Enabling settings");
                controls.Settings.Enable();
            }
            else
            {
                print("Disabling Settings");
                controls.Settings.Disable();
            }
        }
    }
}