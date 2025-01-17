using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;
    public bool moving;
    private Vector3 lastPosition, newPosition, deltaPosition;
    private Vector2 playerPositionVec2;
    public Vector2 lastMotionVector;
    public bool hasInteracted = false;
    private float distance;
    private float stopDistance = 1f;
  


    private Animator _animator;

    void Start()
    {
        player = GameManager.instance.player.transform;
        _animator = GetComponent<Animator>();
    }
    

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (hasInteracted && distance >= stopDistance)
        {
            // if close enough then chase, but dont keep chasing if close
            lastPosition = transform.position;
            newPosition= Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            deltaPosition = lastPosition - newPosition;
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
}
