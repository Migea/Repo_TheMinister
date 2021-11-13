using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemName
{
    Null,
    ɽ����,
    ���زо�,
    ����������,
    ��󡹦�ؼ�,
    ������,
    ��˪����,
    ����,
    ����ʵ�,
    ����ʵ�,
    �Ӽ�,
    ����,
    ���ӵ�,
    ����,
    ��,
    ����,
    ����,
    ���¾�,
    ������
}

public enum ItemType
{
    Null
}
public class ItemUI : MonoBehaviour, IIcon, IPointerClickHandler
{
    public ItemName ItemName;
    public SOItem sOItem;
    private Image icon;
    public Text amount;
    

    public Image Icon => icon;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //TODO: destroyed Mother Object
        } 

    }

    public void SetUp(ItemName item, int amount)
    {
        string SpritePath = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        icon.sprite = Resources.Load<Sprite>(SpritePath);
        this.amount.text = amount.ToString();
    }

    public Tag Use()
    {
        return sOItem.ItemMap[ItemName];
    }

}
