using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Card containedCard;
    public Slot opposingSlot;
    public bool isFriendly;
    
    public bool takeDamage(int dmgAmnt)
    {
        if (containedCard)
        {
            if ((containedCard.hp -= dmgAmnt) <= 0)
            {
                DestroyImmediate(containedCard.gameObject);
                containedCard = null;
            }
            else
            {
                containedCard.hpText.text = containedCard.hp.ToString();
            }
            return true;
        }
        return false;
    }
}
