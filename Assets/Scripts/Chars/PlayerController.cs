using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public override void Init()
    {
        base.Init();
        BattleData.ins.Player = body;
    }

    private void Update()
    {
        if (body.actioned) return;
        if (Input.GetMouseButton(0))
        {
            Vector2 temp = ControllerInput();
            SayToBody(temp);
        }

        StaminaRegen(0);
    }

    public Vector2 ControllerInput()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
