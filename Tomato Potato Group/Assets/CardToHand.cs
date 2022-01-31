using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject playerArea;
    public GameObject handCard;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CardBack.cardBack = false;
        handCard.GetComponent<CardBack>().CardBackActive();
        playerArea = GameObject.Find("Player Area");
        handCard.transform.SetParent(playerArea.transform);
        handCard.transform.localScale = Vector3.one;

    }
}
