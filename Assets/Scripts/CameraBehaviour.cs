using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform FBorder;
    public Transform SBorder;

    public float camScaleByPlParam;

    private Camera camera;
    private Vector2 plPos;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        plPos = BattleData.instance.Player.transform.position;
        CameraMove();
        CameraScaleByPlayer(IsPlayerOutOfBorder());
    }

    void CameraScaleByPlayer (bool isPlayerOut)
    {
        if (!isPlayerOut) return;
        camera.orthographicSize = plPos.magnitude * camScaleByPlParam;
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


        camera.transform.position = pointToMove;
    }
}
