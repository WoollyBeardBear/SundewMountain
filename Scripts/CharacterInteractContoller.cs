using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteractContoller : MonoBehaviour
{
    CharacterController2d characterController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;
    InputAction _interact;
    [SerializeReference] HighlighterController highlighterController;

    private void Start()
    {
        //_interact = InputSystem.actions.FindAction("Interact");
        _interact = new InputAction("Interact", InputActionType.Button, binding: "<Keyboard>/e");
        _interact.Enable();
    }



    private void Awake()
    {
        characterController = GetComponent<CharacterController2d>();
        rgbd2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
        
        
    }

    private void Update()
    {
        Check();
        
    }
    
    private void FixedUpdate()
    {
        if (_interact.IsPressed())
        {
            Debug.Log("Interact Pressed");
            Interact();
        }
    }

    private void Check()
    {
        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highlighterController.Highlight(hit.gameObject);
                return;
            }
        }
        highlighterController.Hide();
    } 

    private void Interact()
    {
        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
    

}
