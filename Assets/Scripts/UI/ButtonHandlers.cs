using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class ButtonHandlers : MonoBehaviour
{
    public void PlayBattleButtonHandler ()
    {
        MatchMaker.ins.PlayInternetMatch();
    }
}
