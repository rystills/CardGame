using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Card : MonoBehaviour
{
    [SerializeField] TextMesh nameText;
    [SerializeField] TextMesh hpText;
    [SerializeField] TextMesh atkText;
    int hp;
    int atk;
    void Start()
    {
        hp = Random.Range(1, 6);
        atk = Random.Range(0, 3);
        name = string.Join("", new char[5].Select(i => 'A' + Random.Range(0, 27)));
        hpText.text = hp.ToString();
        atkText.text = atk.ToString();
        nameText.text = name.ToString();
    }

    void Update()
    {
        
    }
}
