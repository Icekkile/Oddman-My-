using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuUIControls : MonoBehaviour
{
    [SerializeField]
    UIControls uiControls;

    public Text BattleResult;
    public Text MoneyBonus;
    public Text TrophiesBonus;

    public Profile profile;

    private void OnEnable()
    {
        SetBattleResult(BattleData.ins.matchResult);
        SetMoneyBonus();
        SetTrophiesBonus();
    }

    private void SetBattleResult (MatchResults result)
    {
        if (result == MatchResults.Win)
            BattleResult.text = "You Win!";
        else if (result == MatchResults.Lose)
            BattleResult.text = "You Lose!";
        else if (result == MatchResults.Draw)
            BattleResult.text = "Draw!";
    }

    private void SetMoneyBonus ()
    {
        MoneyBonus.text = $"Money Bonus: {BattleData.ins.MoneyBonus}";
        profile.BonusMoney(BattleData.ins.MoneyBonus);
    }

    private void SetTrophiesBonus ()
    {
        TrophiesBonus.text = $"Trophies Bonus: {BattleData.ins.TrophiesBonus}";
        profile.BonusTrophies(BattleData.ins.TrophiesBonus);
    }
}
