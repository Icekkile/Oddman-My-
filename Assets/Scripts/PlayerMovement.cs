using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;

    public float MinTargetSpeed, MaxTargetSpeed;

    private Vector2? _targetPoint;
    public Vector2? targetPoint
    {
        get => _targetPoint;
        private set
        {
            _targetPoint = value;

            if(value != null)
            {
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = 1;
                rb.velocity = Vector2.zero;
            }
        }
    }

    private float force;
    private float tolerance = 0.01f;

    public void DetermineForce (Vector2 pointToMove)
    {
        float distanceToPoint = Vector2.Distance(pointToMove, (Vector2)rb.transform.position);

        force = Mathf.Clamp(distanceToPoint * Speed, MinTargetSpeed, MaxTargetSpeed);
    }

    public void SetTargetPoint (Vector2 targetPointParam)
    {
        targetPoint = targetPointParam;
    }

    private void Update()
    {
        if (targetPoint != null)
        {
            GoToPointProcess();
        }
    }

    private void GoToPointProcess()
    {
        if ((targetPoint.Value - (Vector2)rb.transform.position).magnitude > rb.velocity.magnitude * 0.02f)
        {
            Move();
        }
        else
        {
            targetPoint = null;
        }
    }

    public void Move()
    {
        Vector2 currentTargetPoint = targetPoint.Value;

        //moving
        DetermineForce(currentTargetPoint);// - method that ditermines value of force from point we need.
        rb.velocity = (currentTargetPoint - (Vector2)rb.transform.position).normalized * force;
    }
}
