using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MaterialUI : MonoBehaviour, IPointerClickHandler
{
    public Text ItemName;
    public Text NeedAmount;
    public Text HaveAmount;

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO: show item info
    }

    public void SetUp(ItemName item, int haveAmount)
    {
        ItemName.text = item.ToString();
        NeedAmount.text = "/"+1.ToString();
        HaveAmount.text = haveAmount.ToString();
    }
}
