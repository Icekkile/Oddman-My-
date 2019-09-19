using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxForceMagitude;
    public float Speed;
    public float startDashTime;

    public float dashTime;
    private float force;

    private void Start()
    {
        dashTime = startDashTime;
    }

    public void DetermineForce (Vector2 pointToMove)
    {
        if (pointToMove.magnitude >= maxForceMagitude)
            force = maxForceMagitude * Speed;
        else
            force = pointToMove.magnitude * Speed;
    }

    public void Move(Vector2 pointToMove)
    {
        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
            return;
        }
        DetermineForce(pointToMove);
        dashTime -= Time.deltaTime;
        rb.velocity = pointToMove.normalized * force * Time.deltaTime;
    }
}
