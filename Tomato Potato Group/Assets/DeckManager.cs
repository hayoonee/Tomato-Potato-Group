using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public List<Card> container = new List<Card>();

    void Awake()
    {
        foreach(Card data in Resources.LoadAll<Card>("Assets/Cards/"))
        {
            deck.Add(data);
        }
    }

    void Start()
    {
        Shuffle();
    }

    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
    }
}
