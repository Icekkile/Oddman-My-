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
        GameObject foundBody = FindBody();
        if (foundBody == null)
            return;
        SayToBody(foundBody.transform.position);
    }

    public void SayToBody(Vector2 destination)
    {
        body.SetTargetPoint(destination);
    }

    public GameObject FindBody ()
    {
        GameObject go = CardSystem.ins.FindByCard("Player");
        return go;
    }
}
