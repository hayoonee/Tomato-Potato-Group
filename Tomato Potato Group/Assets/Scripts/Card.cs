using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public int cardNumber;
    public string color;

    public Sprite cardImage;

    public Card()
    {

    }

    public Card(int CardNumber, string Color)
    {
        cardNumber = CardNumber;
        color = Color;
    }
}
