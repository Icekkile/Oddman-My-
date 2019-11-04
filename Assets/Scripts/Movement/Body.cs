using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Body : MonoBehaviour
{
    public GameObject this_Gm { get; private set; }

    public CharacterMovement pm;

    public float CoolDown;
    private float _coolDown;

    public bool actioned { get; private set; }

    private void Awake()
    {
        this_Gm = gameObject;
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

    public void OnDeath(GameObject killer)
    {
        Death.instance.EInvoke(gameObject, killer);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != "Char_Killer")
            return;

        OnDeath(collision.collider.gameObject);
    }
}
