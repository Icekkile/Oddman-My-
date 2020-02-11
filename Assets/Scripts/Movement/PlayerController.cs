using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController
{
    [SerializeField]
    public Body body { get; set; }

    private void Start()
    {
        DetermineBody();
        body.card.Add("Player");

        BattleData.ins.Player = body;
    }

    public void DetermineBody()
    {
        body = gameObject.GetComponent<Body>();
    }

    private void Update()
    {
        if (body.actioned) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 temp = ControllerInput();
            SayToBody(temp);
        }
    }

    public void SayToBody (Vector2 destination)
    {
        body.SetTargetPoint(destination);
    }

    public Vector2 ControllerInput()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    
}
