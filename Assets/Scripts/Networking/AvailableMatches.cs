using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.Networking;

public class AvailableMatches : MonoBehaviour
{
    private static List<MatchInfoSnapshot> availableMatches;

    private void OnEnable()
    {
        availableMatches = new List<MatchInfoSnapshot>();
    }

    public List<MatchInfoSnapshot> GetAvailableMatches ()
    {
        RefreshMatches();
        return availableMatches;
    }

    private void RefreshMatches ()
    {
        MatchMaker.ins._matchMaker.ListMatches
            (
            0,
            20,
            "Knockouters",
            true,
            0,
            0,
            ListMatchesReturn
            );
    }

    private void ListMatchesReturn (bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        availableMatches = matches;
    }
}
