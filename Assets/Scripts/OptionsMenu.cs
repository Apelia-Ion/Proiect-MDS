using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void BackButton()
    {
       SceneManager.LoadScene("MainMenu");
    }

    public void GoToResolution()
    {
        SceneManager.LoadScene("ResolutionMenu");
    }
}

