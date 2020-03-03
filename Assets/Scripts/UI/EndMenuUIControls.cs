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

    [SerializeField]
    private float MenuTime;
    private float menuTime;
    public bool canContiune { get; private set; }

    private void OnEnable()
    {
        SetBattleResult(BattleData.ins.matchResult);
        SetMoneyBonus();
        SetTrophiesBonus();
        SetMenuTime();
        canContiune = false;
    }

    private void Update()
    {
        CountTime(); //region: Time
    }

    #region Time
    private void CountTime()
    {
        if (menuTime > 0)
            menuTime -= Time.deltaTime;
        else if (menuTime <= 0)
            canContiune = true;
    }

    private void SetMenuTime ()
    {
        menuTime = MenuTime;
    }
    #endregion

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
