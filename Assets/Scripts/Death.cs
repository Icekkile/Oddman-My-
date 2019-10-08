using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public delegate void DeathDeleg(GameObject diedGameObj);
    public event DeathDeleg DeathEvent;

    private void Awake()
    {
        DeathEvent += OnDeath;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != "Char_Killer") return;
        if (DeathEvent != null)
            DeathEvent(gameObject);
    }

    void OnDeath (GameObject diedGameObj)
    {
        Debug.Log(diedGameObj.tag);
    }
}
