using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophiesSaver : MonoBehaviour, ISaver<int>
{
    public int param { get; set; }

    public void LoadParam()
    {
        param = PlayerPrefs.GetInt("Trophies");
    }

    public void SaveParam()
    {
        PlayerPrefs.SetInt("Trophies", param);
    }
}
