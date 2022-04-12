using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMesh playerHpText;
    [SerializeField] TextMesh enemyHpText;
    [SerializeField] List<Slot> playerSlots;
    [SerializeField] List<Slot> enemySlots;
    [SerializeField] GameObject Card;

    int playerHp = 10;
    int enemyHp = 10;

    private void Start()
    {
        playerHpText.text = "PLYR HP: " + playerHp.ToString();
        enemyHpText.text = "ENMY HP: " + enemyHp.ToString();
        foreach (Slot s in enemySlots)
        {
            GameObject.Instantiate(Card).GetComponent<Card>().setIsFriendly(false).tryEnterSlot(s);
        }
    }

    public void initAttackPhase(bool isFriendly)
    {
        foreach (Slot s in (isFriendly ? playerSlots : enemySlots).Where(s => s.containedCard))
        {
            if (!s.opposingSlot.takeDamage(s.containedCard.atk))
            {
                if (isFriendly)
                {
                    enemyHp -= s.containedCard.atk;
                }
                else
                {
                    playerHp -= s.containedCard.atk;
                }
            }
        }
        playerHpText.text = "PLYR HP: " + playerHp.ToString();
        enemyHpText.text = "ENMY HP: " + enemyHp.ToString();
    }
}
