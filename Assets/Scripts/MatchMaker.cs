using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class MatchMaker : NetworkManager
{
    public static MatchMaker ins;

    public int MaxPosiblePlayers;

    void Start()
    {
        ins = this;
        StartMatchMaker();
    }



    //call this method to request a match to be created on the server
    public void CreateInternetMatch()
    {
        matchMaker.CreateMatch("", 4, true, "", "", "", 0, 0, OnInternetMatchCreate);
    }

    //this method is called when your request for creating a match is returned
    private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            MatchInfo hostInfo = matchInfo;
            NetworkServer.Listen(hostInfo, 9000);

            UIController.ins.SetActive(false);
            
            StartHost(hostInfo);
        }
    }

    public List<MatchInfoSnapshot> GetAvailableMatches ()
    {
        List<MatchInfoSnapshot> matches = new List<MatchInfoSnapshot>();
        matchMaker.ListMatches
            (
            0,
            20,
            "",
            true,
            0,
            0,
                (
                bool success,
                string extendedInfo,
                List<MatchInfoSnapshot> found
                ) 
                => matches = found
            );
        return matches;
    }



    //this method is called when a list of matches is returned
    public void ConnectInternetMatch()
    {
        List<MatchInfoSnapshot> matches = GetAvailableMatches();

        if (matches.Count != 0)
        {
            MatchInfoSnapshot connectMatch = matches[Random.Range(0, matches.Count)];
            matchMaker.JoinMatch(connectMatch.networkId, "", "", "", 0, 0, OnJoinInternetMatch);
        }

    }

    //this method is called when your request to join a match is returned
    private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            MatchInfo hostInfo = matchInfo;
            UIController.ins.SetActive(false);


            StartClient(hostInfo);
        }
    }
}
