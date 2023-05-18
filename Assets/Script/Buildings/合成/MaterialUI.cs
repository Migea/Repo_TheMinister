using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MaterialUI : MonoBehaviour, IPointerClickHandler
{
    public Image ItemImage;
    public Image Frame;
    public Text NeedAmount;
    public Text HaveAmount;

    public int IntNeedAmount = 1;
    public int IntHaveAmount;

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO: show item info
    }

    public void SetUp(ItemName item, int haveAmount)
    {
        IntHaveAmount = haveAmount;
        ItemImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnItemPath(item)); 
        var framRarity = Player.AllTagRareDict[SOItem.ItemMap[item]] != Rarerity.B ? Player.AllTagRareDict[SOItem.ItemMap[item]] : Rarerity.N;
        string FramePath = $"Art/BuildingUI/�ӻ���/���������/��Ʒ��/��Ʒ��-{framRarity}";
        Frame.sprite = Resources.Load<Sprite>(FramePath);
        NeedAmount.text = 1.ToString();
        HaveAmount.text = haveAmount.ToString();
    }
}
