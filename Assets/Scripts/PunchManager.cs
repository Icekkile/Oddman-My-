using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PunchManager : MonoBehaviour
{
    public float punchParam;

    Vector2 punchVector;
    List<Rigidbody2D> punchRBs;

    public void SetNewPunchVector (Vector2 punch, Rigidbody2D punchRB)
    {
        punchVector += punch;
        punchRBs.Add(punchRB);
    }

    void Punch ()
    {
        foreach (Rigidbody2D rb in punchRBs)
        {

        }
    }
}
