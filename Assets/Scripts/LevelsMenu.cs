using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public void BackButton()
    {
       SceneManager.LoadScene("MainMenu");
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
