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
    ë��,
    ����,
    ����,
    ���¾�,
    ����,
    ������
}

public enum ItemType
{
    ����,
    ����,
    �鼮,
    ��װ,
    ��Ʒ,
    ����,
    ��Ʒ,
    ��Ʒ,
    �ӻ�,
    ҩ��,
    ��ҩ,
    ����
}
public class ItemUI : MonoBehaviour, IIcon, IPointerClickHandler
{
    public ItemName ItemName;
    public Image icon;
    public Text amount;
    public TagExchangeUI tagExchangeUI;

    public Image Icon => icon;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            PlayerCharactersInventory playerCharactersInventory = Resources.Load<PlayerCharactersInventory>("CharacterInvUI/ChraInvUI");
            PlayerCharactersInventory current = Instantiate(playerCharactersInventory, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
            GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().InUseItem = ItemName;
            foreach (CharacterUI characterUI in current.characterUIList)
            {
                characterUI.newTag = Use();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //TODO: destroyed Mother Object
        } 

    }

    public void SetUp(ItemName item, int amount)
    {
        this.ItemName = item;
        string SpritePath = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        icon.sprite = Resources.Load<Sprite>(SpritePath);
        this.amount.text = amount.ToString();
    }

    public Tag Use()
    {
        return SOItem.ItemMap[this.ItemName];
    }

}
