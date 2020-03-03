using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    public EndMenuUIControls endControls;

    public GameObject MenuCanvas;
    public GameObject BattleCanvas;
    public GameObject EndCanvas;

    public GameObject playerStaminaSlider;

    public void ShowMenu ()
    {
        if (!endControls.canContiune)
            return;

        MenuCanvas.SetActive(true);
        BattleCanvas.SetActive(false);
        EndCanvas.SetActive(false);
    }

    public void ShowBattle ()
    {
        MenuCanvas.SetActive(false);
        BattleCanvas.SetActive(true);
        EndCanvas.SetActive(false);
    }

    public void ShowEnd ()
    {
        MenuCanvas.SetActive(false);
        BattleCanvas.SetActive(false);
        EndCanvas.SetActive(true);
    }
} 
