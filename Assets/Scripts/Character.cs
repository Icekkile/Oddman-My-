using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public IController m_Controller;

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
