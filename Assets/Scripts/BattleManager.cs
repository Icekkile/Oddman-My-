using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BattleManager : NetworkBehaviour
{
    public static BattleManager ins;

<<<<<<< Updated upstream
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
=======
    public Body ClientPlayer;

    public List<GameObject> allGMs;
>>>>>>> Stashed changes

    #region init

    private void Awake()
    {
        ins = this;
    }

<<<<<<< Updated upstream
    private void Start()
    {
        ConnectedPlayers = new List<GameObject>();
    }

    #endregion

    public override void OnStartLocalPlayer()
    {
        if (ClientPlayer != null)
            ClientPlayer.tag = "Player";
=======
    #endregion

    public void OnStartMyLocalPlayer()
    {
        if (ClientPlayer != null)
            ClientPlayer.this_Gm.AddComponent<PlayerCard>();


        GameObject[] gms = FindObjectsOfType<GameObject>();

        foreach (GameObject gm in gms)
            ins.allGMs.Add(gm);
>>>>>>> Stashed changes
    }
}
