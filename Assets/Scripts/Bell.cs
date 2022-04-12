using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void OnMouseUp()
    {
        gameManager.initAttackPhase(true);
        gameManager.initAttackPhase(false);
    }
}
