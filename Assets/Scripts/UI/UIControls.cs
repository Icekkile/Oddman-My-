using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject EndCanvas;

    public void ShowMenu ()
    {
        
    }

    public void ShowBattle ()
    {
        BattleData.ins.StartNew();
        MenuCanvas.SetActive(false);
        EndCanvas.SetActive(false);

        MatchMaker.ins.PlayInternetMatch();
    }

    public void ShowEnd ()
    {
        
    }
} 
