using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Card : MonoBehaviour
{
    [SerializeField] TextMesh nameText;
    [SerializeField] TextMesh hpText;
    [SerializeField] TextMesh atkText;
    public int hp;
    public int atk;
    bool dragging = false;
    Slot inSlot;
    Vector3 initialPos;
    Vector3 raisedPos;
    [SerializeField] LayerMask slotLayer;

    void Start()
    {
        hp = Random.Range(1, 6);
        atk = Random.Range(0, 3);
        name = string.Join("", new char[5].Select(i => 'A' + Random.Range(0, 27)));
        hpText.text = hp.ToString();
        atkText.text = atk.ToString();
        nameText.text = name.ToString();
        initialPos = transform.position;
        raisedPos = transform.position + new Vector3(0,.1f,0);
    }

    private void OnMouseDown()
    {
        if (!inSlot)
        {
            dragging = true;
            transform.position = raisedPos;
        }
    }

    private void OnMouseUp()
    {
        if (dragging)
        {
            dragging = false;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, slotLayer))
            {
                Transform hitTrans = hit.transform;
                transform.position = hitTrans.position;
                Slot hitSlot = hitTrans.GetComponent<Slot>();
                hitSlot.containedCard = this;
                inSlot = hitSlot;
            }
            else
            {
                transform.position = initialPos;
            }
        }
    }
}
