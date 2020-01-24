using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    ISaver<int> moneySaver = new MoneySaver();
    ISaver<int> trophiesSaver = new TrophiesSaver();
    ISaver<string> nameSaver = new NameSaver();

    #region Money Get-Set
    public void SetMoney (int money)
    {
        moneySaver.param = money;
        moneySaver.SaveParam();
    }

    public void BonusMoney (int money)
    {
        int temp = moneySaver.param + money;
        SetMoney(temp);
    }

    public int GetMoney ()
    {
        moneySaver.LoadParam();
        return moneySaver.param;
    }
    #endregion

    #region Trophies Get-Set
    public void SetTrophies(int trophies)
    {
        trophiesSaver.param = trophies;
        trophiesSaver.SaveParam();
    }

    public void BonusTrophies(int trophies)
    {
        int temp = trophiesSaver.param + trophies;
        SetTrophies(temp);
    }

    public int GetTrophies()
    {
        trophiesSaver.LoadParam();
        return trophiesSaver.param;
    }
    #endregion

    #region Name Get-Set
    public void SetName(string name)
    {
        nameSaver.param = name;
        nameSaver.SaveParam();
    }

    public string GetName()
    {
        nameSaver.LoadParam();
        return nameSaver.param;
    }
    #endregion

    public void SaveAll ()
    {
        moneySaver.SaveParam();
        trophiesSaver.SaveParam();
        nameSaver.SaveParam();
    }

    public void LoadAll ()
    {
        moneySaver.LoadParam();
        trophiesSaver.LoadParam();
        nameSaver.LoadParam();
    }
}
