using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PunchAction : MonoBehaviour
{
    public float punchParam;

    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Character") return;

        Vector2 normal = collision.GetContact(0).normal;
        float Impulse = collision.GetContact(0).normalImpulse;

        _rigidbody.AddForce(normal * Impulse * punchParam);

        //pm.SetNewPunchVector(_rigidbody);
    }
}
