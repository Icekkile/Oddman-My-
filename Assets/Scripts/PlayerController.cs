using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Controller controller;

    private void Update()
    {
        if (!controller.CountCoolDown()) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 pointToMove = ControllerInput();
            controller.SetTargetPoint(pointToMove);
            controller.Actioned();
        }
    }

    public Vector2 ControllerInput()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
