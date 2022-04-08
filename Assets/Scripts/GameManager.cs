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

    int playerHp = 10;
    int enemyHp = 10;

    private void Start()
    {
        playerHpText.text = "HP: " + playerHp.ToString();
        enemyHpText.text = "ENMY HP: " + enemyHp.ToString();
    }

    public void initiatePlayerAttack()
    {
        foreach (Slot s in playerSlots.Where(s => s.containedCard))
        {
            enemyHp -= s.containedCard.atk;
        }
        enemyHpText.text = "ENMY HP: " + enemyHp.ToString();
    }
}
