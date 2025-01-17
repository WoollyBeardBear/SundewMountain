using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControls : MonoBehaviour
{
    CharacterController2d _characterController;
    ToolsCharacterController _toolsCharacter;
    InventoryContoller _inventoryContoller;
    
    void Awake()
    {
        _characterController = GetComponent<CharacterController2d>();
        _toolsCharacter = GetComponent<ToolsCharacterController>();
        _inventoryContoller = GetComponent<InventoryContoller>();
    }

    public void DisableControl()
    {
        _characterController.enabled = false;
        _toolsCharacter.enabled = false;
        _inventoryContoller.enabled = false;
    }

    public void EnableControl()
    {
        _characterController.enabled = true;
        _toolsCharacter.enabled = true;
        _inventoryContoller.enabled = true;
    }
}
