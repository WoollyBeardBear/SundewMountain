using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winCondition : MonoBehaviour
{
    [SerializeField] private GameObject questGiver;
    [SerializeField] private GameObject questPerson;

    [SerializeField] private DialogueContainer dialogue;
    private bool hasInteracted = false;

    private float distance;
    private float questSuccessDistance = 4f;
    private float gameEndTimer = 0;

    [SerializeField] private string winningScreenName;

   

    private void Update()
    {
        distance = Vector3.Distance(transform.position, questPerson.transform.position);
        if (distance <= questSuccessDistance)
        {
            Interact();
            hasInteracted = true;
            
        }

        if (hasInteracted)
        {
            gameEndTimer += Time.deltaTime;
        }

        if (gameEndTimer > 4f)
        {
            SceneManager.LoadScene(winningScreenName, LoadSceneMode.Single);
        }
        
    }
    
    private void Interact()
    {
        GameManager.instance.dialogueSystem.Initialize(dialogue);
        GameManager.instance.dialogueSystem.PushText();

    }
}
