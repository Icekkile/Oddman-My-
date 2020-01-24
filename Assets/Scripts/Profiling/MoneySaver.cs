using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySaver : MonoBehaviour, ISaver<int>
{
    public int param { get; set; }

    public void LoadParam()
    {
        param = PlayerPrefs.GetInt("Money");
    }

    public void SaveParam()
    {
        PlayerPrefs.SetInt("Money", param);
    }
}
