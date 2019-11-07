using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BattleManager : NetworkBehaviour
{
    public static BattleManager ins;

    public GameObject ClientPlayer;
    public List<GameObject> ConnectedPlayers;

    #region ConnPlayersChange
    [ClientRpc]
    public void RpcConnPlsChange (GameObject gm)
    {
        ConnectedPlayers.Add(gm);
    }

    [Command]
    public void CmdConnPlsChange (GameObject gm)
    {
        RpcConnPlsChange(gm);
    }
    #endregion

    #region init

    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        ConnectedPlayers = new List<GameObject>();
    }

    #endregion

    public override void OnStartLocalPlayer()
    {
        if (ClientPlayer != null)
            ClientPlayer.tag = "Player";
    }
}
