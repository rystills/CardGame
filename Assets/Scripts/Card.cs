using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Card : MonoBehaviour
{
    [SerializeField] TextMesh nameText;
    public TextMesh hpText;
    [SerializeField] TextMesh atkText;
    public bool isFriendly;
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
        raisedPos = transform.position + new Vector3(0, .1f, 0);
    }

    private void OnMouseDown()
    {
        if (!inSlot)
        {
            dragging = true;
            transform.position = raisedPos;
        }
    }

    public bool tryEnterSlot(Slot slot)
    {
        if (slot && !slot.containedCard && isFriendly == slot.isFriendly)
        {
            transform.SetParent(slot.transform, true);
            transform.localPosition = Vector3.zero;
            slot.containedCard = this;
            inSlot = slot;
        }
        return slot;
    }

    public Card setIsFriendly(bool isFriendly)
    {
        this.isFriendly = isFriendly;
        return this;
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
                if (!tryEnterSlot(hit.transform.GetComponent<Slot>())) {
                    transform.position = initialPos;
                }
            }
        }
    }
}
