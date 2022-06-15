using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private RectTransform backgroundBox;
    private int npcId;

    private DialogueTrigger trigger;

    string[] currentMessage;
    int activeMessage = 0;
    private static bool isActive = false;
    private int numMeeting;

    [SerializeField] AudioSource dialogueSoundEffect;
    public void OpenDialogue(string[] messages, int id)
    {
        trigger = GameObject.Find("Ciupercuta").GetComponent<DialogueTrigger>();
        npcId = id;
        currentMessage = messages;
        activeMessage = 0;
        isActive = true;
        numMeeting = trigger.getNumById(npcId) + 1;
        trigger.setNumById(npcId, numMeeting);

        Debug.Log("A inceput conversatia");
        Debug.Log(numMeeting);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo(); 
    }

    private void DisplayMessage()
    {
        dialogueSoundEffect.Play();
        if (numMeeting < 2)
        {
            string messageToDisplay = currentMessage[activeMessage];
            messageText.text = messageToDisplay;
        }
        else
        {
            int n;
            n = currentMessage.Length - 1;
            string messageToDisplay = currentMessage[n];
            messageText.text = messageToDisplay;
        }
    }

    private void NextMessage()
    {
        if (numMeeting < 2)
        {
            activeMessage++;
            if (activeMessage < currentMessage.Length - 1)
            {
                DisplayMessage();
            }
            else
            {
                isActive = false;
                backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                Debug.Log("Gata conversatia!");
            }
        }
        else
        {
            DisplayMessage();
        }
    }

    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive && numMeeting < 2)
        {
            NextMessage();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isActive && numMeeting > 1)
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }

    }

    public bool getActivity()
    {
        return isActive;
    }
}
