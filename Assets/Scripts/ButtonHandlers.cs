using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class ButtonHandlers : MonoBehaviour
{
    public void PlayBattleButtonHandler ()
    {
        List<MatchInfoSnapshot> matches = MatchMaker.ins.GetAvailableMatches();

        if (matches.Count != 0)
            MatchMaker.ins.ConnectInternetMatch();

        else if (matches.Count == 0)
            MatchMaker.ins.CreateInternetMatch();

        else
            Debug.Log("Can`t connect.");
    }
}
