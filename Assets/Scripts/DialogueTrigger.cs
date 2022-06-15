using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] int npcId;
    [SerializeField] private string[] messages;
    private static int[] numMeetingsNpcs = {0,0,0};

    private void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, npcId);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            StartDialogue();
    }
    
    public int getNumById(int id)
    {
        return numMeetingsNpcs[id];
    }

    public void setNumById(int id, int nr)
    {
        numMeetingsNpcs[id] = nr;
    }    
}
