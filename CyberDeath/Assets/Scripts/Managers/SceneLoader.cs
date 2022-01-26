using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.UnloadScene("Shop");
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
} 
