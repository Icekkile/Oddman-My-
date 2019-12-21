using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMatchMakerScript : MonoBehaviour
{
    void Start()
    {
        MatchMaker.ins = new MatchMaker();
        MatchMaker.ins.StartThis();
    }
}
