using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class ButtonHandlers : MonoBehaviour
{
    public UIControls uiControls;

    public void PlayBattleButtonHandler ()
    {
        uiControls.ShowBattle();
    }

    public void ContinueButtonHandler()
    {
        uiControls.ShowMenu();
    }
}
