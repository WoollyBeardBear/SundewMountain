using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float offSetDistance = 1.2f;
    [SerializeField] private Vector2 attackAreaSize = new Vector2(1f, 1f);
    public LayerMask attackLayerMask;

    private Rigidbody2D rgbd2d;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }
    public void Attack(int damage, Vector2 lastMotionVector)
    {
        Vector2 position = rgbd2d.position + lastMotionVector * offSetDistance;

        Collider2D[] targets = Physics2D.OverlapBoxAll(position, attackAreaSize, 0f, attackLayerMask);

        foreach (Collider2D c in targets)
        {
            
            Damageable damageable = c.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage); 
            }
        }
    }
}
