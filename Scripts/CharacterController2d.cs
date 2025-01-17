using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2d : MonoBehaviour
{
   Rigidbody2D rigidbody2D;
   [SerializeField] float speed = 2f;
   Vector2 motionVector;
   public Vector2 lastMotionVector;
   Animator animator;
   public bool moving;
   public bool slash;
   public InputAction attack;
   public static CharacterController2d instance;

   
    // Start is called before the first frame update
    private void Start()
    {
        attack.Enable();
    }

    private void OnEnable()
    {
        attack.Enable();
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attack = InputSystem.actions.FindAction("Attack");
        attack = new InputAction("Attack", binding: "<Mouse>/leftButton");
        instance = this;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        motionVector = new Vector2(horizontal, vertical);
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        
        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);
        
        if (attack.triggered)
        {
            animator.SetTrigger("slash1");
        }
        
        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2 (horizontal, vertical).normalized;

            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical );
        }
        //slash animation

        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2D.velocity = motionVector * speed;
    }

    public void Respawn(Vector2 respawnPosition)
    {
        rigidbody2D.position = respawnPosition;
    }
    
    private void OnDisable()
    {
        // Clean up input action
        attack.Disable();
        rigidbody2D.velocity = Vector2.zero;
        animator.SetBool("moving", false);
    }
}

