﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

enum PlayerStatements
{
    NoMatch,
    Host,
    Client
}

public class MatchMaker : NetworkManager
{
    public static MatchMaker ins;

    public NetworkMatch _matchMaker;

    private MatchResults matchResult;
    private PlayerStatements playerStatements = PlayerStatements.NoMatch;
    public MatchInfo curMatch;


    public void Start()
    {
        ins = this;

        singleton.StartMatchMaker();
        _matchMaker = singleton.matchMaker;
        PlayInternetMatch();
    }

    private void Update()
    {
        if (NetworkServer.connections.Count != 1)
            return;
        matchResult = MatchResults.Win;

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
        
        singleton.StartHost(curMatch);
        playerStatements = PlayerStatements.Host;
    }
    #endregion

    #region Match Connect
    public void ConnectInternetMatch(List<MatchInfoSnapshot> matches)
    {
        MatchInfoSnapshot connectMatch = matches[Random.Range(0, matches.Count)];

        _matchMaker.JoinMatch(connectMatch.networkId, "", "", "", 0, 0, OnJoinInternetMatch);
    }

    private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (!success)
            return;

        curMatch = matchInfo;

        singleton.StartClient(curMatch);
        playerStatements = PlayerStatements.Client;
    }
    #endregion

    #region Match End
    public void StartFinishingMatch (MatchResults result, GameObject killed, GameObject killer)
    {
        matchResult = result;
        DisconnectInternetMatch();
    }

    public void DisconnectInternetMatch ()
    {
        if (playerStatements == PlayerStatements.Host)
            _matchMaker.DestroyMatch(curMatch.networkId, 0, EndMatch);
        else if (playerStatements == PlayerStatements.Client)
            _matchMaker.DropConnection(curMatch.networkId, curMatch.nodeId, 0, EndMatch);
    }

    public void EndMatch(bool success, string extendedInfo)
    {
        playerStatements = PlayerStatements.NoMatch;
        BattleData.ins.matchResult = matchResult;
        BattleData.ins.EndBattleClearing();
        SceneManager.LoadScene("EndMenu");
    }
    #endregion 
}