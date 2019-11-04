using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Enemy_SumoController : NetworkBehaviour, IController
{
    public Body controller;

    private void Update()
    {
        if (controller.actioned) return;
        CmdSayToBody();
    }

    [Command]
    public void CmdSayToBody()
    {
        RpcSayToBody();
    }

    [ClientRpc]
    public void RpcSayToBody ()
    {
        controller.SetTargetPoint(FindBody().transform.position);
    }

    public GameObject FindBody ()
    {
        List<GameObject> gms = new List<GameObject>(GameObject.FindGameObjectsWithTag("Character"));
        gms.Remove(gameObject);
        GameObject nearest = gms[0];
        float dist = Vector2.Distance(controller.this_Gm.transform.position, nearest.transform.position);
        foreach (GameObject gm in gms)
        {
            float temp = Vector2.Distance(controller.this_Gm.transform.position, gm.transform.position);
            if (temp < dist)
            {
                dist = temp;
                nearest = gm;
            }

        }
        return nearest;
    }
}
