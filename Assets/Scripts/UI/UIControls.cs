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
        MenuCanvas.SetActive(false);
        EndCanvas.SetActive(false);

    }

    public void ShowEnd ()
    {
        MenuCanvas.SetActive(false);
        EndCanvas.SetActive(true);
    }
} 
