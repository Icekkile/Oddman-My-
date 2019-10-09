using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject player;

    public Transform FBorder;
    public Transform SBorder;

    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        CameraMove();
    }

    private void CameraMove ()
    {
        Vector2 temp = player.transform.position;

        Vector3 pointToMove = new Vector3
            (
            Mathf.Clamp(temp.x, FBorder.position.x, SBorder.position.x), 
            Mathf.Clamp(temp.y, FBorder.position.y, SBorder.position.y),
            -10
            );


        camera.transform.position = pointToMove;
    }
}
