using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Finish2 : MonoBehaviour
{
    private AudioSource finishSound;
    private ItemCollector itemCollect;

    private bool levelCompleted = false;

    [SerializeField] GameObject ob;
    [SerializeField] private RectTransform backgroundBox;
    [SerializeField] private Text fruitsText;
    private int fruits = 0;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        itemCollect = ob.GetComponent<ItemCollector>();

        backgroundBox.transform.localScale = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            fruits = itemCollect.GetFruits();


            finishSound.Play();
            levelCompleted = true;
            backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
            fruitsText.text = " Fruits collected: " + fruits + " / 16";
            Invoke("CompleteLevel", 5f);

        }
    }

    private void CompleteLevel()
    {
        backgroundBox.transform.localScale = Vector3.zero;
        SceneManager.LoadScene("Levels");
    }
}

   
