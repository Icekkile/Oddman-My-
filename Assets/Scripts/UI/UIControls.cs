using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject EndCanvas;

    public void ShowMenu ()
    {
        MenuCanvas.SetActive(true);
        EndCanvas.SetActive(false);
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
        //StopBattle();
        BattleData.ins.EndThis();
        MenuCanvas.SetActive(false);
        EndCanvas.SetActive(true);
    }
} 
