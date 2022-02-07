using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject card;
    public GameObject playerArea;
    public GameObject enemyArea;
    public GameObject playArea;

    public List<Card> deck = new List<Card>();
    public Card drawnCardInfo;

    public override void OnStartClient()
    {
        base.OnStartClient();

        playerArea = GameObject.Find("Player Area");
        enemyArea = GameObject.Find("Enemy Area");
        playArea = GameObject.Find("Play Area");

    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();

        foreach (Card data in Resources.LoadAll<Card>("Cards/"))
        {
            deck.Add(data);
        }
    }

    [Command]
    public void CmdCardDraw(int cardsDrawn)
    {
        for (int i = 0; i < cardsDrawn; i++)
        {

            GameObject instantiatedCard = Instantiate(card, playerArea.transform.position, Quaternion.identity);

            NetworkServer.Spawn(instantiatedCard, connectionToClient);

            CardBack.cardBack = false;
            card.GetComponent<CardBack>().CardBackActive();


            int cardDrawLocation = Random.Range(0, deck.Count);
            drawnCardInfo = deck[cardDrawLocation];
            instantiatedCard.GetComponent<CardDisplay>().card = drawnCardInfo;
            deck.RemoveAt(cardDrawLocation);
            RpcShowCard(instantiatedCard, "Dealt");
        }
    }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        if(type == "Dealt")
        {
            if(hasAuthority)
            {
                card.transform.SetParent(playerArea.transform, false);
            }
            else
            {
                card.transform.SetParent(enemyArea.transform, false);
            }
        }
        else if (type == "Dealt")
        {
            card.transform.SetParent(playArea.transform, false);
        }
    }

}
