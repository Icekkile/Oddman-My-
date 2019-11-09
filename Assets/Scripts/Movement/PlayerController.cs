using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour, IController
{
    public Body controller;

    private void Start()
    {
        if (!isLocalPlayer) return;
        controller.card.Add("Player");

        BattleData.ins.ClientPlayer = controller;
    }

    private void Update()
    {
        if (!isLocalPlayer) return;
        if (controller.actioned) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 temp = ControllerInput();
            CmdSayToBody(temp);
        }
    }

    #region SayToBody

    [Command]
    public void CmdSayToBody (Vector2 destination)
    {
        RpcSayToBody(destination);
    }

    [ClientRpc]
    public void RpcSayToBody (Vector2 destination)
    {
        controller.SetTargetPoint(destination);
    }

    #endregion

    public Vector2 ControllerInput()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
