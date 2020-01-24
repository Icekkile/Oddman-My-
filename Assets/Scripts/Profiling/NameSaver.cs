using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSaver : MonoBehaviour, ISaver<string>
{
    public string param { get; set; }

    public void SaveParam()
    {
        PlayerPrefs.SetString("Name", param);
    }

    public void LoadParam()
    {
        param = PlayerPrefs.GetString("Name");
    }
}
