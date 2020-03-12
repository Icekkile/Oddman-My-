using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardContainer), typeof(Controller))]
public class Body : MonoBehaviour
{
    public GameObject this_Gm { get; private set; }

    public BodyConfig config;
    public Controller controller;
    public CharacterMovement movement;
    public CardContainer card;
    public Weapon weapon;
    public ConfigDisplay configDisplay;

    private float CoolDown;
    private float _coolDown;

    public bool actioned { get; private set; }

    private void OnEnable()
    {
        DetermineRequirements();

        card.Add("Body");
    }

    public void DetermineRequirements()
    {
        this_Gm = gameObject;

        if (controller == null)
            controller = GetComponent<Controller>();

        if (card == null)
            card = GetComponent<CardContainer>();

        if (movement == null)
            movement = GetComponent<CharacterMovement>();

        if (weapon == null)
            weapon = GetComponent<Weapon>();

        if (configDisplay == null)
            configDisplay = GetComponent<ConfigDisplay>();

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
        movement.OrderToMove(TargetPoint);
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
