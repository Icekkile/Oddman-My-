using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public PlayerMovement pm;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Vector2 pointToMove = ControllerInput();
        pm.DetermineForce(pointToMove);
        pm.Move(pointToMove);
    }

    Vector2 ControllerInput ()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
