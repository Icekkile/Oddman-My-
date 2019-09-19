using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public PlayerMovement pm;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || pm.dashTime > 0)
        {
            Vector2 pointToMove = ControllerInput();
            pm.Move(pointToMove);
        }
    }

    Vector2 ControllerInput ()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
