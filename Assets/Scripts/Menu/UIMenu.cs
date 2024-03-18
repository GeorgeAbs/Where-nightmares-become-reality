using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public static Scene Inventory;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
    public void ContinueGame()
    {

    }
    public void OpenSettings()
    {

    }
    public void OpenCreators()
    {

    }
    public void BackToGame()
    {
        
    }
    public void BackToMenu()
    {

    }
}
