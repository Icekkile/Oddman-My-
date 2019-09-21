using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public PlayerMovement pm;

    private void Update()
    {
        float temp = 0;
        if (Input.GetMouseButtonDown(0) || temp > 0)
        {
            pm.rb.gravityScale = 0;
            Vector2 pointToMove = ControllerInput();
            temp = pm.Move(pointToMove);
            return;
        }
        pm.rb.gravityScale = 1;
    }

    Vector2 ControllerInput ()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
