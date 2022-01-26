/******************************************************************
*    Author: Kyle Grenier
*    Contributors: 
*    Date Created: 12/4/2021
*******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoofyGhosts.Kyle
{
    [CreateAssetMenu(menuName = "SceneLoaderSO")]
    public class SceneLoader : ScriptableObject
    {
        [SerializeField] private VoidChannelSO pauseGameChannel;

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void TogglePause()
        {
            pauseGameChannel.RaiseEvent();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}