using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float Speed;
    public float DashTime;
    public float punchParam;
    public float massBonus;

    private Vector2 moveVector;
    private float dashTime;

    private void OnEnable()
    {
        if (massBonus < 0)
            massBonus = 1 / massBonus;
        if (massBonus == 0)
            massBonus = 1;
    }

    private void Update()
    {
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
        
    }

    public void Move (Vector2 target)
    {
        FindMoveVector(target);
        rb.AddForce(moveVector * Speed / massBonus, ForceMode2D.Impulse);
        dashTime = DashTime;
    }

    private void FindMoveVector (Vector2 vector)
    {
        moveVector = vector - (Vector2)rb.transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Body>() == null) return;

        Vector2 normal = collision.GetContact(0).normal;
        float Impulse = collision.GetContact(0).normalImpulse;

        rb.AddForce(normal * Impulse * punchParam);
    }
}
