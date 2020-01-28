using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandlers : MonoBehaviour
{
    public UIControls uiControls;

    public void PlayBattleButtonHandler ()
    {
        BattleData.ins.PlayBattle();
    }

    public void ContinueButtonHandler()
    {
        uiControls.ShowMenu();
    }
}
