using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class MatchMaker : NetworkManager
{
    public static MatchMaker ins;

    public int MaxPosiblePlayers;
    public NetworkMatch _matchMaker;

    public GameObject MenuCanvas;

    private AvailableMatches _refAvailableMatches;

    void Start()
    {
        ins = this;
        singleton.StartMatchMaker();
        _matchMaker = singleton.matchMaker;
        _refAvailableMatches = new AvailableMatches();
    }

    //call this method to request a match to be created on the server
    public void CreateInternetMatch()
    {
        _matchMaker.CreateMatch("Knockouters", 4, true, "", "", "", 0, 0, OnInternetMatchCreate);
    }

    //this method is called when your request for creating a match is returned
    private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (!success)
            return;

        MatchInfo hostInfo = matchInfo;

        MenuCanvas.SetActive(false);
        singleton.StartHost(hostInfo);
    }

    //this method is called when a list of matches is returned
    public void ConnectInternetMatch()
    {
        List<MatchInfoSnapshot> matches = _refAvailableMatches.GetAvailableMatches();

        if (matches.Count == 0)
            return;
        
        MatchInfoSnapshot connectMatch = matches[Random.Range(0, matches.Count)];

        _matchMaker.JoinMatch(connectMatch.networkId, "", "", "", 0, 0, OnJoinInternetMatch);
        

    }

    //this method is called when your request to join a match is returned
    private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            MatchInfo hostInfo = matchInfo;
            MenuCanvas.SetActive(false);


            singleton.StartClient(hostInfo);
        }
    }
}
