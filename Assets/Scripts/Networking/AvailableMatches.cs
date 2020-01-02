using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.Networking;

public class AvailableMatches : MonoBehaviour
{
    private static List<MatchInfoSnapshot> availableMatches;
    private float refreshTime;

    private void Start()
    {
        availableMatches = new List<MatchInfoSnapshot>();
    }

    private void Update()
    {
        if (Time.time >= refreshTime)
        {
            RefreshMatches();
        }
    }

    public static List<MatchInfoSnapshot> GetAvailableMatches ()
    {
        return availableMatches;
    }

    private void RefreshMatches ()
    {
        refreshTime = Time.time + 1f;

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

    public void ListMatchesReturn (bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        availableMatches = matches;
        Debug.Log(availableMatches.Count);
    }
}
