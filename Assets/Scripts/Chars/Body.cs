using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardContainer), typeof(Controller))]
public class Body : MonoBehaviour
{
    public GameObject this_Gm { get; private set; }

    public Controller controller;
    public BodyConfig config;
    public CharacterMovement pm;

    private float CoolDown;
    private float _coolDown;

    public CardContainer card;

    public bool actioned { get; private set; }

    private void OnEnable()
    {
        DetermineRequirements();

        card.Add("Body");
    }

    public void DetermineRequirements()
    {
        this_Gm = gameObject;
        controller = GetComponent<Controller>();
        card = GetComponent<CardContainer>();
        pm = GetComponent<CharacterMovement>();
        CoolDown = config.CoolDown;
    }

    public void Update()
    {
        if (_coolDown > 0)
            _coolDown -= Time.deltaTime;
        actioned = _coolDown > 0;
    }

    public void Move(Vector2 TargetPoint)
    {
        pm.OrderToMove(TargetPoint);
        _coolDown = CoolDown;
    }

    public void OnDeath()
    {
        card.RemoveFromCardSystem();
        Death.ins.EInvoke(this);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gm = collision.collider.gameObject;
        CardContainer cc = gm.GetComponent<CardContainer>();

        if(cc == null || !cc.Contains("Killer"))
            return;

        OnDeath();
    }
}
