using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour, IController
{
    public Body controller;

    private void Update()
    {
        if (!isLocalPlayer) return;
        if (controller.actioned) return;

        CmdSayToBody();
    }

    [Command]
    public void CmdSayToBody ()
    {
        RpcSayToBody();
    }

    [ClientRpc]
    public void RpcSayToBody ()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 pointToMove = ControllerInput();
            controller.SetTargetPoint(pointToMove);
        }
    }

    public Vector2 ControllerInput()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
