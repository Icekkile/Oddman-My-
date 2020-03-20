using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    Player,
    Enemy
}

[RequireComponent(typeof(Controller))]
public class Body : MonoBehaviour
{
    public BodyType? bodyType { get; private set; }

    public BodyConfig config;
    public Controller controller;
    public CharacterMovement movement;
    public Weapon weapon;
    public ConfigDisplay configDisplay;

    private float CoolDown;
    private float _coolDown;

    public bool actioned { get; private set; }

    private void OnEnable()
    {
        SetClasses();
        configDisplay.SetConfigs(this);
        SetParams();
    }

    private void SetParams ()
    {
        if (bodyType == null)
        {
            if (gameObject.tag == "Player")
                bodyType = BodyType.Player;
            else if (gameObject.tag == "Enemy")
                bodyType = BodyType.Enemy;
        }

        CoolDown = config.CoolDown;
    }

    public void SetClasses()
    {
        weapon = new Weapon(this);

        if (controller == null)
            controller = GetComponent<Controller>();

        if (movement == null)
            movement = GetComponent<CharacterMovement>();

        if (configDisplay == null)
            configDisplay = GetComponent<ConfigDisplay>();
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
        Death.ins.EInvoke(this);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gm = collision.collider.gameObject;

        if(gm.tag != "Killer")
            return;

        OnDeath();
    }
}
