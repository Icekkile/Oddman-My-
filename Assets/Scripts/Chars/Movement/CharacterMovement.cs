using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float MaxMagnitude;

    public float Speed;
    public float DashTime;
    public float punchParam;
    public float massBonus;

    public Vector2 moveVector;
    private float dashTime;

    private bool dashing;

    private float afterDashSpeedParam = 2;

    public void OrderToMove (Vector2 targetPoint)
    {
        FindMoveVector(targetPoint);
        dashTime = DashTime;
        dashing = true;
    }

    private void FindMoveVector(Vector2 targetPoint)
    {
        moveVector = targetPoint - (Vector2)rb.transform.position;
        
        if (moveVector.magnitude > MaxMagnitude)
        {
            float temp = MaxMagnitude / moveVector.magnitude;
            moveVector *= temp;
        }

        float speed = Speed / DashTime / massBonus;

        moveVector = moveVector * speed;
    }

    private void Update()
    {
        if (!dashing)
            return;

        if (dashTime <= 0)
        {
            dashing = false;
            rb.velocity /= afterDashSpeedParam;
            return;
        }

        dashTime -= Time.deltaTime;
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
