using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SumoController : MonoBehaviour, IController
{
    public Body controller;

    private void Update()
    {
        if (controller.actioned) return;
        SayToBody(FindBody().transform.position);
    }

    public void SayToBody(Vector2 destination)
    {
        controller.SetTargetPoint(destination);
    }

    public GameObject FindBody ()
    {
        List<GameObject> gms = CardSystem.ins.FindManyByCard("Body");
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
