using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class ButtonHandlers : MonoBehaviour
{
    private AvailableMatches availableMatches;

    private void OnEnable()
    {
        availableMatches = new AvailableMatches();
    }

    public void PlayBattleButtonHandler ()
    {
        List<MatchInfoSnapshot> matches = availableMatches.GetAvailableMatches();

        if (matches.Count != 0)
            MatchMaker.ins.ConnectInternetMatch();

        else if (matches.Count == 0)
            MatchMaker.ins.CreateInternetMatch();

        else
            Debug.Log("Can`t connect.");
    }
}
