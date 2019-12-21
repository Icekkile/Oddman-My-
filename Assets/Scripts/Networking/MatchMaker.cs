using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class MatchMaker : NetworkManager
{
    public static MatchMaker ins;

    public NetworkMatch _matchMaker;

    private int isHosting;
    public MatchInfo curMatch;

    public void StartThis()
    {
        singleton.StartMatchMaker();
        _matchMaker = singleton.matchMaker;
    }

    public void PlayInternetMatch ()
    {
        List<MatchInfoSnapshot> matches = AvailableMatches.GetAvailableMatches();

        if (matches.Count <= 0)
            CreateInternetMatch();
        else if (matches.Count > 0)
            ConnectInternetMatch(matches);
    }

    #region Match Create
    public void CreateInternetMatch()
    {
        _matchMaker.CreateMatch("Knockouters", 2, true, "", "", "", 0, 0, OnInternetMatchCreate);
    }

    private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (!success)
            return;

        curMatch = matchInfo;

        SceneManager.LoadScene("Battle");
        singleton.StartHost(curMatch);
        isHosting = 1;
    }
    #endregion

    #region Match Connect
    public void ConnectInternetMatch(List<MatchInfoSnapshot> matches)
    {
        if (matches.Count == 0)
            return;
        
        MatchInfoSnapshot connectMatch = matches[Random.Range(0, matches.Count)];

        _matchMaker.JoinMatch(connectMatch.networkId, "", "", "", 0, 0, OnJoinInternetMatch);
        

    }

    private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (!success)
            return;

        curMatch = matchInfo;

        SceneManager.LoadScene("Battle");
        singleton.StartClient(curMatch);
        isHosting = 2;
    }
    #endregion

    #region Match Disconnect

    public void DisconnectInternetMatch ()
    {
        if (isHosting == 1)
            _matchMaker.DestroyMatch(curMatch.networkId, 0, OnDisconnectedMatch);
        else if (isHosting == 2)
            _matchMaker.DropConnection(curMatch.networkId, curMatch.nodeId, 0, OnDisconnectedMatch);
    }

    private void OnDisconnectedMatch(bool success, string extendedInfo)
    {
        isHosting = 0;
        SceneManager.LoadScene("EndGame");
    }

    #endregion
}