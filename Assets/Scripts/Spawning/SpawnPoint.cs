using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform point { get; private set; }

    private void OnEnable()
    {
        point = gameObject.transform;
    }
}
