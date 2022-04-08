using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject Card;
    List<GameObject> cards;
    
    void Start()
    {
        cards = new List<GameObject>();
        for (int i = 0; i < 5; ++i)
        {
            cards.Add(GameObject.Instantiate(Card, transform.position - new Vector3(-.32f + .16f * i, 0, 0),Quaternion.identity,transform));
        }
    }
}