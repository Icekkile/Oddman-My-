using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform FBorder;
    public Transform SBorder;

    public float camScaleByPlParam;

    private Camera m_camera;
    private Vector2 plPos;

    private void Start()
    {
        m_camera = Camera.main;
    }

    private void Update()
    {
        if (BattleData.ins.ClientPlayer == null) return;

        GameObject temp = BattleData.ins.ClientPlayer.this_Gm;

        plPos = temp.transform.position;
        CameraMove();
        CameraScaleByPlayer(IsPlayerOutOfBorder());
    }

    void CameraScaleByPlayer (bool isPlayerOut)
    {
        if (!isPlayerOut) return;
        m_camera.orthographicSize = plPos.magnitude * camScaleByPlParam;
    }

    bool IsPlayerOutOfBorder ()
    {
        if (plPos.magnitude < 7f) return false;
        return true;
    }

    //note: scaling by enemies

    private void CameraMove ()
    {
        Vector3 pointToMove = new Vector3
            (
            Mathf.Clamp(plPos.x, FBorder.position.x, SBorder.position.x), 
            Mathf.Clamp(plPos.y, FBorder.position.y, SBorder.position.y),
            -10
            );


        m_camera.transform.position = pointToMove;
    }
}
