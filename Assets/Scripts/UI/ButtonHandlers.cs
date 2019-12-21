using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class ButtonHandlers : MonoBehaviour
{
    public void PlayBattleButtonHandler ()
    {
        SceneManager.LoadScene("Battle");
    }
}
