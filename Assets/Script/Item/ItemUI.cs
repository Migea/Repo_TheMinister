using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemName
{
    Null,
    ������,
    �����滨��,
    �������,
    ��ʤ��,
    ����ǹ,
    ��Դ��,
    �˻�����,
    ������,
    �ƽ��,
    ��ʯ,
    ����,
    ��֮ӥ,
    ����컯��,
    ����������,
    ɽ����,
    ���زо�,
    ����������,
    �����,
    ŷұ�ӵĴ�,
    �Ƶ��ھ�,
    ���ݸ�Ŀ,
    ��󡹦�ؼ�,
    ������,
    ��˪����,
    ����,
    ����ʵ�,
    ����ʵ�,
    ����,
    ī�ӷǹ�,
    ī�Ӽ氮,
    �����ӡ,
    ����,
    Ψ����,
    ����ƿ,
    ���,
    ��ֳ�д�,
    ŷұ�ӵ�С��,
    �˺��Ӳ���,
    �Ĺ�״,
    ���״,
    ���ֵ�����,
    �����,
    �Ӽ�,
    ���ӵ�,
    ����,
    ϴԩ¼,
    ����,
    ����,
    Т����,
    ��,
    ë��,
    ����,
    ����,
    ��,
    ҩ�Ĵ�ȫ,
    ��Ʒ,
    ��,
    ��,
    ǹ,
    ��,
    �,
    ��Ա����������,
    ��ͷ���

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
            LeftClickAction();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //TODO: destroyed Mother Object
        } 

    }

    protected virtual void LeftClickAction()
    {
        PlayerCharactersInventory playerCharactersInventory = Resources.Load<PlayerCharactersInventory>("CharacterInvUI/ChraInvUI");
        PlayerCharactersInventory current = Instantiate(playerCharactersInventory, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().InUseItem = ItemName;
        foreach (CharacterUI characterUI in current.characterUIList)
        {
            characterUI.newTag = Use();
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
