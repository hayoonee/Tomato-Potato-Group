using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Image image;

    private void Start()
    {
        //card = GetComponent<DeckManager>().deck[0];
    }

    void Update()
    {
        image.sprite = card.cardImage;
    }
}
