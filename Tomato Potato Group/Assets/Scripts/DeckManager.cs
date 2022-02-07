using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public List<Card> container = new List<Card>();

    public GameObject deckCard1;
    public GameObject deckCard2;
    public GameObject deckCard3;
    public GameObject deckCard4;

    //public GameObject drawnCard;
    public GameObject playerArea;

    //public Card drawnCardInfo;

    //void Awake()
    //{
        
    //}

    void Start()
    {
        //Shuffle();
        //CardDraw(4);
    }

    void Update()
    {
        deck = GetComponent<PlayerManager>().deck;

        if (deck.Count < 30)
        {
            deckCard1.SetActive(false);
        }
        if(deck.Count < 20)
        {
            deckCard2.SetActive(false);
        }
        if(deck.Count < 10)
        {
            deckCard3.SetActive(false);
        }
        if(deck.Count == 0)
        {
            deckCard4.SetActive(false);
        }
    }
    //public void CardDraw(int cardsDrawn)
    //{
    //    for (int i = 0; i < cardsDrawn; i++)
    //    {

    //        GameObject instantiatedCard = Instantiate(drawnCard, playerArea.transform.position, Quaternion.identity);

    //        CardBack.cardBack = false;
    //        drawnCard.GetComponent<CardBack>().CardBackActive();

    //        playerArea = GameObject.Find("Player Area");
    //        instantiatedCard.transform.SetParent(playerArea.transform);
    //        instantiatedCard.transform.localScale = Vector3.one;

    //        drawnCardInfo = deck[0];
    //        instantiatedCard.GetComponent<CardDisplay>().card = drawnCardInfo;
    //        deck.RemoveAt(0);

    //    }
    //}
    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            container[0] = deck[i];
            int randomindex = Random.Range(i, deck.Count);
            deck[i] = deck[randomindex];
            deck[randomindex] = container[0];
        }
    }

}
