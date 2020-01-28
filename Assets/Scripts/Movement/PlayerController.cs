using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController
{
    public Body controller;

    private void Start()
    {
        controller.card.Add("Player");

        BattleData.ins.ClientPlayer = controller;
    }

    private void Update()
    {
        if (controller.actioned) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 temp = ControllerInput();
            SayToBody(temp);
        }
    }

    public void SayToBody (Vector2 destination)
    {
        controller.SetTargetPoint(destination);
    }

    public Vector2 ControllerInput()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
