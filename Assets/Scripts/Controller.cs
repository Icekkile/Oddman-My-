using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour , IController
{
    public PlayerMovement pm;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 pointToMove = ControllerInput();
            SetTargetPoint(pointToMove);
        }


    }

    public void SetTargetPoint(Vector2 TargetPoint)
    {
        pm.SetTargetPoint(TargetPoint);
    }

    Vector2 ControllerInput ()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
