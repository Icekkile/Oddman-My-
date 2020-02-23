using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SumoController : Controller
{
    public override void Init()
    {
        base.Init();
        body.card.Add("Enemy");
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
        GameObject go = CardSystem.ins.FindByCard("Player");
        return go;
    }
}
