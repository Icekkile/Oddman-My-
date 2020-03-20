using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SumoController : Controller
{
    public override void Init()
    {
        base.Init();
    }

    private void Update()
    {
        if (body.actioned) return;
        GameObject foundBody = FindBody();
        if (foundBody == null)
            return;
        SayToBody(foundBody.transform.position);

        StaminaRegen(0);
    }

    public GameObject FindBody ()
    {
        GameObject go = BattleData.ins.Player.gameObject;
        return go;
    }
}
