using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController ins;

    [SerializeField]
    private Canvas canvas;

    private void Start()
    {
        ins = this;
    }

    public void SetActive(bool Active)
    {
        canvas.gameObject.SetActive(Active);
    }
}
