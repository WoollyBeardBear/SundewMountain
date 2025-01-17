using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolsCharacterController : MonoBehaviour
{
    
    CharacterController2d _character;
    Rigidbody2D _rgbd2d;
    private ToolBarController _toolBarController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.1f;
    InputAction _chop;
    InputAction _attack;
    private InputAction _usePotion;
    private AttackController _attackController;
    private PotionController _potionController;
    public Item item;
    
    

    
    // Start is called before the first frame update
    private void Awake()
    {
        _character = GetComponent<CharacterController2d>();
        _rgbd2d = GetComponent<Rigidbody2D>();
        _attack = InputSystem.actions.FindAction("Attack");
        _chop = InputSystem.actions.FindAction("Chop");
        _usePotion = InputSystem.actions.FindAction("UsePotion");
        _attackController = GetComponent<AttackController>();
        _toolBarController = GetComponent<ToolBarController>();
        _potionController = GetComponent<PotionController>();
    }

    private void Start()
    {
        _attack.Enable();
        _chop.Enable();
        _usePotion.Enable();
    }

    private void OnEnable()
    {
        _attack.Enable();
        _chop.Enable();
        _usePotion.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_chop.triggered) 
        {
            UseTool();
        }
        
        if (_attack.triggered)
        {
            WeaponAction();
        }

        if (_usePotion.triggered)
        {
            UsePotion();
        }
        
        
    }

    private void UsePotion()
    {
        Item item = _toolBarController.GetItem;
        if (item == null) { return; }
        if (item.isPotion == false) { return; }
        _potionController.FullHeal();
        _toolBarController.potionChange();


    }

    private void WeaponAction()
    {
        
        Item item = _toolBarController.GetItem;
        if (item == null) { return; }
        if (item.isWeapon == false) { return; }
        Vector2 postition = _rgbd2d.position + _character.lastMotionVector * offsetDistance;
        _attackController.Attack(item.damage, _character.lastMotionVector);
        

    }
    private void UseTool()
    {
        Item item = _toolBarController.GetItem;
        if (item == null) { return; }
        if (item.isTool == false) { return; }
        
        Vector2 position = _rgbd2d.position + _character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }    
    
    private void OnDisable()
    {
        // Clean up input action
        _attack.Disable();
        _chop.Disable();
    }
}
