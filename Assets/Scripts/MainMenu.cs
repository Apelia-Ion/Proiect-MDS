using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed!!");
    }

    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    
    public void GoToSettings()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
