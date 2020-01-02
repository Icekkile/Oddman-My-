using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetSender : NetworkBehaviour
{
    public static NetSender ins;

    private void Start()
    {
        ins = this;
    }

    [Command]
    public void CmdSendDied()
    {
        RpcSendDied();
    }

    [ClientRpc]
    private void RpcSendDied()
    {
        if (NetworkServer.connections.Count == 1)
            MatchMaker.ins.WinMe();
    }
}
