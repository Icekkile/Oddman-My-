using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SumoController : MonoBehaviour, IController
{
    public Body body { get; set; }

    private void Start()
    {
        DetermineBody();
        body.card.Add("Enemy");
    }

    public void DetermineBody()
    {
        body = gameObject.GetComponent<Body>();
    }

    private void Update()
    {
        if (body.actioned) return;
        SayToBody(FindBody().transform.position);
    }

    public void SayToBody(Vector2 destination)
    {
        body.SetTargetPoint(destination);
    }

    public GameObject FindBody ()
    {
        List<GameObject> gms = CardSystem.ins.FindManyByCard("Player");
        gms.Remove(gameObject);
        GameObject nearest = gms[0];
        float dist = Vector2.Distance(body.this_Gm.transform.position, nearest.transform.position);
        foreach (GameObject gm in gms)
        {
            float temp = Vector2.Distance(body.this_Gm.transform.position, gm.transform.position);
            if (temp < dist)
            {
                dist = temp;
                nearest = gm;
            }

        }
        return nearest;
    }

    
}
