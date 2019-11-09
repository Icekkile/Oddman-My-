using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    public List<string> m_Cards;

    public void Add (string card)
    {
        m_Cards.Add(card);
    }

    public bool Contains (string card)
    {
        return m_Cards.Contains(card);
    }

    public void Remove(string card)
    {
        m_Cards.Remove(card);
    }



    private void Awake()
    {
        m_Cards = new List<string>();
    }

    private void Start()
    {
        CardSystem.ins.AddToList(this);
    }
}
