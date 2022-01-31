using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    public GameObject drawnCard;
    public GameObject playerArea;
    private Card drawnCardInfo;
    private List<Card> deck;
    
    // Start is called before the first frame update
    void Start()
    {
        deck = GetComponent<DeckManager>().deck;
        drawnCardInfo = drawnCard.GetComponent<CardDisplay>().card;
        CardDraw(4);
    }

    public void CardDraw(int cardsDrawn)
    {
        for(int i = 0; i < cardsDrawn; i++)
        {
            Instantiate(drawnCard, playerArea.transform.position, Quaternion.identity);
            CardBack.cardBack = false;
            drawnCard.GetComponent<CardBack>().CardBackActive();

            playerArea = GameObject.Find("Player Area");
            drawnCard.transform.SetParent(playerArea.transform);
            drawnCard.transform.localScale = Vector3.one;

            drawnCardInfo = deck[0];
            deck.RemoveAt(0);

        }
    }
}
