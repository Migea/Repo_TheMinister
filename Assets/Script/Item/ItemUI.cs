using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemName
{
    Null,
    ��������ҩ,
    ʮȫ����,
    �����,
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
    Ȯ,
    ����,
    ��,
    ɽ����,
    ���زо�,
    ����������,
    �����,
    ŷұ�ӵĴ�,
    �Ƶ��ھ�,
    ���ݸ�Ŀ,
    ��ʯ�ҷ繭,
    �һ�ն�Ƶ�,
    ��ľ�׵�ǹ,
    ��ʮ���ı���,
    ���ξ�,
    ��ζ��,
    ��֮��,
    ��Է����,
    ��Ԫ��,
    �����ײ�,
    ������ݥ,
    �Ļ�ɳĮ,
    �˱�ҰѼ,
    ���ֽ��,
    ������,
    ��������ɢ,
    ҽʥ��ҩ��,
    ��Ѫ��,
    ľ����,
    ���̱�ʯ,
    ˺�������,
    ���ư�����,
    ���ƻ�,
    ������,
    �컧��,
    ������,
    ����װ,
    ��Ǯ��,
    ����,
    Ѫ����,
    ��֥,
    ľ������,
    ��˷���,
    ��������,
    �峴����,
    ��޷����,
    ľ����,
    ����ɢ,
    ������,
    ϴ�赤,
    ��󡹦�ؼ�,
    ������,
    ��˪����,
    �ƽ�,
    ����ǹ,
    �󿳵�,
    ��Ƭ�,
    �����澭,
    �����澭,
    ����,
    ����ʵ�,
    ����ʵ�,
    ˿��,
    ����,
    ���ľ�,
    Ƥ��,
    ����,
    ����,
    �˲�,
    ����,
    ����,
    ˮ�̻�,
    ����,
    �ع�,
    ����,
    �챦ʯ,
    ��ˮ��,
    ����ʯ,
    ��ĸ��,
    ī�ӷǹ�,
    ī�Ӽ氮,
    �����ӡ,
    ����,
    Ψ����,
    ����ƿ,
    ���,
    ��Ҷ��,
    �ſ���,
    Ů����,
    ���廪��,
    ��ֳ�д�,
    ŷұ�ӵ�С��,
    �˺��Ӳ���,
    �����,
    ��Ŀ���,
    ����,
    �ϻ�,
    ��,
    ����,
    �廨��,
    ��ɰ֬,
    �̵�,
    ������,
    �ɹ���,
    ������,
    ��ü��,
    ���,
    С��,
    ����,
    �Ĺ�״,
    ���״,
    ���,
    �ƾ�,
    ���,
    «��,
    ���ʾ�,
    ������,
    ����ı�ʯ,
    ȱ�ڵı�ʯ,
    ������Ļƽ�,
    ���ֵ�����,
    ����,
    ��ѿ,
    ��Ƥ,
    ����,
    �컨,
    �����,
    �Ӽ�,
    ���ӵ�,
    ����,
    ϴԩ¼,
    ����,
    ����,
    ������,
    ��β��,
    Т����,
    ��,
    ë��,
    ����,
    ����,
    ��,
    ҩ�Ĵ�ȫ,
    ��,
    ��,
    ǹ,
    ��,
    �,
    ��Ա����������,
    ��ͷ���,
    �ɻ�ʯ,
    ��Ҷ,
    ������,
    ��ҩ,
    ��,
    ֹѪ��,
    ���������,
    �峴��ѿ,
    �Ļƹ�,
    ������,
    �������ܲ�,
    ����,
    ͭ��,
    ����,
    ��ƥ,
    ľͷ,
    Ƥ��,
    í��,
    Ӳľ,
    ��ֽ,
    ��֬,
    ��,
    ����,
    ����,
    ��,
    ��,
    ������,
    ����,
    �˽���,
    ����,
    �޺���,
    Ѫ����,
    �ƾ�,
    �׻������,
    ˮ��,
    ����,
    ��ȱ�ڵ�����,
    ���·�,
    ����,
    ����,
    ���,
    ����,
    ��ɽ��,
    �ǳ���



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
        current.SetupMode(CardMode.ItemSelectMode);
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
