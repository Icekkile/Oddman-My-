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

    public Vector2 moveVector;
    private float dashTime;

    private void OnEnable()
    {
        rb.mass += massBonus;
    }
    public void OrderToMove (Vector2 target)
    {
        FindMoveVector(target);
        dashTime = DashTime;
    }

    private void FindMoveVector (Vector2 vector)
    {
        moveVector = vector - (Vector2)rb.transform.position;
        moveVector = (moveVector / DashTime / rb.mass) * Speed;
    }

    private void Update()
    {
        if (dashTime <= 0)
        {
            rb.gravityScale = 1;
            return;
        }

        dashTime -= Time.deltaTime;
        rb.gravityScale = 0;

        Move();
    }

    private void Move ()
    {
        rb.velocity = moveVector;
    }


    //punch
    public void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        dashTime = 0;

        if (collision.gameObject.GetComponent<Body>() == null) return;

        Vector2 normal = collision.GetContact(0).normal;
        float Impulse = collision.GetContact(0).normalImpulse;

        rb.AddForce(normal * Impulse * punchParam / massBonus);
    }
}
