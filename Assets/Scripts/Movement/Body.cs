using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject this_Gm { get; private set; }

    public CharacterMovement pm;

    public float CoolDown;
    private float _coolDown;

    public CardContainer card;

    public bool actioned { get; private set; }

    private void Awake()
    {
        this_Gm = gameObject;
        card = GetComponent<CardContainer>();
        pm = GetComponent<CharacterMovement>();
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
