using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    public static CardSystem ins;
    [SerializeField]
    private List<CardContainer> allCardConts;

    public void RemoveFromList (CardContainer cc)
    {
        allCardConts.Remove(cc);
    }

    public void AddToList (CardContainer cc)
    {
        allCardConts.Add(cc);
    }

    
    public GameObject FindByCard (string card)
    {
        foreach (CardContainer c in ins.allCardConts)
        {
            if (c.Contains(card))
                return c.gameObject;
        }

        return null;
    }

    public List<GameObject> FindManyByCard(string card)
    {
        List<GameObject> result = null;

        foreach (CardContainer c in ins.allCardConts)
        {
            if (c.Contains(card))
                result.Add(c.gameObject);
        }

        return result;
    }

    #region init
    private void Awake()
    {
        ins = this;
        ins.allCardConts = new List<CardContainer>();
    }
    #endregion
}
