using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardContainer), typeof(Controller))]
public class Body : MonoBehaviour
{
    public GameObject this_Gm { get; private set; }

    public BodyConfig config;
    public CharacterMovement pm;

    private float CoolDown;
    private float _coolDown;

    public CardContainer card;

    public bool actioned { get; private set; }

    private void Start()
    {
        DetermineRequirements();

        card.Add("Body");
    }

    public void DetermineRequirements()
    {
        this_Gm = gameObject;
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

    public void SetTargetPoint(Vector2 TargetPoint)
    {
        pm.SetTargetPoint(TargetPoint);
        _coolDown = CoolDown;
    }

    public void OnDeath()
    {
        card.RemoveFromCardSystem();
        Death.ins.EInvoke(this);
        gameObject.SetActive(false);
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
