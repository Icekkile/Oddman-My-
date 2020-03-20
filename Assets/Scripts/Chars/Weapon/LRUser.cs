using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRUser : IWeaponUser
{
    private GameObject m_GM;
    private float Damage;

    public LRUser (GameObject thisGM, float damage)
    {
        m_GM = thisGM;
        Damage = damage;
    }

    private Body FindNearest ()
    {
        List<Body> bodies = new List<Body>(BattleData.ins.Enemies);
        Body nearest = bodies[0];
        float dist = Vector2.Distance(m_GM.transform.position, nearest.gameObject.transform.position);

        foreach (Body body in bodies)
        {
            float newdist = Vector2.Distance(m_GM.transform.position, body.gameObject.transform.position);
            if (newdist > dist)
                continue;

            nearest = body;
            dist = newdist;
        }
        return nearest;
    } 

    public void UseIt()
    {
        Body nearest = FindNearest();

        nearest.controller.Stamina -= Damage;
    }
}
