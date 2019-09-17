using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxForceMagitude;
    public float forceParam;
    private float force;

    public void DetermineForce (Vector2 pointToMove)
    {
        if (pointToMove.magnitude >= maxForceMagitude)
            force = maxForceMagitude * forceParam;
        else
            force = pointToMove.magnitude * forceParam;
    }

    public void Move(Vector2 pointToMove)
    {
        rb.velocity = pointToMove.normalized * force;
        //rb.AddForce(pointToMove.normalized * force);
    }
}
