using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBuilder : MonoBehaviour
{
    public ArenaConfig arenaPref;
    public Transform ArenaAnchor;
    public Transform SpawnPointAnchor;

    public List<GameObject> bodySPs { get; private set; }

    public void Build ()
    {
        bodySPs = new List<GameObject>();
        BuildArena(arenaPref.Arena);
        BuildSP(arenaPref.SpawnPoints);
    }

    private void BuildArena (List<GameObject> prefs)
    {
        foreach (GameObject go in prefs)
        {
            Instantiate(go, go.transform.position, Quaternion.identity, ArenaAnchor);
        }
    }

    private void BuildSP (List<GameObject> SPs)
    {
        foreach (GameObject go in SPs)
        {
            bodySPs.Add(Instantiate(go, go.transform.position, Quaternion.identity, SpawnPointAnchor));
        }
    }
}
