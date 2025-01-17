using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChaseEnemy : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 attackSize = Vector2.one;
    [SerializeField] private float attackSizeFloat = 0.99f;
    [SerializeField] private float chaseArea = 5f;
    [SerializeField] private int damage = 5;
    [SerializeField] private float timeToAttack = 2f;
    private float attackTimer;
    public bool moving;
    private Vector3 lastPosition, newPosition, deltaPosition;
    private Vector2 playerPositionVec2;
    private float distance;
    public Vector2 lastMotionVector;
    public LayerMask attackLayerMask;

    private Animator _animator;

    void Start()
    {
        player = GameManager.instance.player.transform;
        attackTimer = Random.Range(0, 1);
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        if (distance <= attackSizeFloat)
        {
            Attack();
            moving = false;

        }
        else if (distance < chaseArea)
        {
            // if close enough then chase, but dont keep chasing if in range to attack
            lastPosition = transform.position;
            newPosition= Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            deltaPosition = lastPosition - newPosition;
            // Debug.Log("np: " + newPosition.ToString() + " lp: " + lastPosition.ToString() + " dp: " + deltaPosition.ToString());
            float horizontal = deltaPosition.x;
            float vertical = deltaPosition.y;
            _animator.SetFloat("horizontal", horizontal);
            _animator.SetFloat("vertical", vertical);
            transform.position = newPosition;
            moving = horizontal != 0 || vertical != 0;
            _animator.SetBool("moving", moving);
            
            if (horizontal != 0 || vertical != 0)
            {
                lastMotionVector = new Vector2 (horizontal, vertical).normalized;

                _animator.SetFloat("lastHorizontal", horizontal);
                _animator.SetFloat("lastVertical", vertical );
            }
            
            
            
        }
        else 
        {
            
            moving = false;
        }

        
    }

    private void Attack()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer > 0f) { return; }

        attackTimer = timeToAttack;
        _animator.SetTrigger("swing");
        
        Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, attackSize, 0f, attackLayerMask);

        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].gameObject == gameObject) continue;
            
            Damageable character = targets[i].GetComponent<Damageable>();
            if (character != null)
            {
                character.TakeDamage(damage);
            }
        }
    }
}
