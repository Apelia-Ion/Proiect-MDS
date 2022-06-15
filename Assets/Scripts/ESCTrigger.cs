using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ESCTrigger : MonoBehaviour
{
    [SerializeField] private RectTransform backgroundBox;
    private static bool isActive = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isActive == false)
        {
            isActive = true;
            backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isActive == true)
        {
            isActive = false;
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            Debug.Log(isActive);
            ReturnToMainMenu();
        }

    }

    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
