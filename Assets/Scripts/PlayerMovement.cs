using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxForceDistance;
    public float Speed;

    private float force;

    private void Start()
    {

    }

    public void DetermineForce (Vector2 pointToMove)
    {
        if (Hypotenuse(pointToMove, rb.transform.position) >= maxForceDistance)
            force = maxForceDistance * Speed;
        else
            force = Hypotenuse(pointToMove, rb.transform.position) * Speed;
    }

    public float Move(Vector2 pointToMove)
    {
        //distance from this point to the point we need. Indicator.
        float temp = Hypotenuse(rb.transform.position, pointToMove);
        //
        Debug.Log(temp);
        //if dash is all
        if (temp <= 0)
        {
            rb.velocity = Vector2.zero;
            Debug.Log(rb.velocity);
            return temp;
        }
        //

        //moving
        DetermineForce(pointToMove);// - method that ditermines value of force from point we need.
        rb.velocity = pointToMove.normalized * force * Time.deltaTime;
        //

        return temp;
    }

    float Hypotenuse (Vector2 point_1, Vector2 point_2)
    {
        float result = 0;
        float x = Mathf.Abs(point_1.x - point_2.x);
        float y = Mathf.Abs(point_1.y - point_2.y);
        return result = Mathf.Sqrt(x * x + y * y);
    }
}
