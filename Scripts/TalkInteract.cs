using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable
{
    [SerializeField] private DialogueContainer dialogue;
    [SerializeField] private GameObject talkBubble;
    public override void Interact(Character character)
    {
        GameManager.instance.dialogueSystem.Initialize(dialogue);
        talkBubble.SetActive(false);

        NPCFollow npcFollow = GetComponent<NPCFollow>();
        if (npcFollow != null)
        {
            npcFollow.hasInteracted = true;
        }

    }

}
