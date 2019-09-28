using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PunchManager : MonoBehaviour
{
    public float punchParam;

    List<Rigidbody2D> punchRBs;

    public static PunchManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        punchRBs = new List<Rigidbody2D>();
    }

    public void SetNewPunchVector (Rigidbody2D punchRB)
    {
        punchRBs.Add(punchRB);
        Punch();
    }

    void Punch ()
    {
        foreach (Rigidbody2D rb in punchRBs)
        {
            foreach (Rigidbody2D temp in punchRBs)
            {
                if (temp == rb) continue;
                rb.velocity -= temp.velocity;
            }
            rb.velocity *= punchParam;
        }
    }
}
