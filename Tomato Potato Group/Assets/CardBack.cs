using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    public static bool cardBack = true;

    public GameObject cardBackImage;

    public void CardBackActive()
    {
        if(cardBack == false)
        {
            cardBackImage.SetActive(false);
        }
        else
        {
            cardBackImage.SetActive(true);
        }
    }
}
