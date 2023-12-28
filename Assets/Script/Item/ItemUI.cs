using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

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
    ���õĿ���,
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
    Т��,
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
    ���ҷ�,
    ��ɽ��,
    �ǳ���,
    ����,
    ������,
    ľ����,
    ��˿,
    Ƥë,
    �鲼,
    �ƺ�«,
    ��֯������,
    ��������,
    ��������,
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
    ����,
    ����
}
public class ItemUI : MonoBehaviour, IIcon, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDetailAble
{
    public ItemName ItemName;
    public Image icon;
    public Text amount;
    public TagExchangeUI tagExchangeUI;
    public Image Frame;
    public Rarerity framRarity;
    public bool CanClick = true;
    public Image Icon => icon;
    public bool InUse = true;


    public virtual void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Play("��ť");
        if (!InUse)
            return;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //LeftClickAction();
            SetupInUseItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //TODO: destroyed Mother Object
        }
    }
    public virtual void SetupInUseItem()
    {
        GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().InUseItem = ItemName;
        FindObjectOfType<FocusImage>().Setup(ItemName);
        var OSA = FindObjectOfType<OnSwitchAssets>();
        OSA.replacementTag = Use();
        OSA.replacementTagOrigin = Use();
        //Debug.Log(FindObjectOfType<OnSwitchAssets>().replacementTag);
        FindObjectOfType<OnSwitchAssets>().item = ItemName;

        bool edible = EdiblesItems.IsEdible(ItemName);
        var eatItem = FindObjectOfType<EatItem>(true);
        if (eatItem != null)
        {
            eatItem.gameObject.SetActive(edible);
            if (edible)
            {
                eatItem.Setup();
            }
        }
    }
    protected virtual void LeftClickAction()
    {
        PlayerCharactersInventory playerCharactersInventory
            = Resources.Load<PlayerCharactersInventory>("CharacterInvUI/ChraInvUI");

        PlayerCharactersInventory current
            = Instantiate(playerCharactersInventory,
            GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        current.SetupMode(CardMode.ItemSelectMode);

        GameObject.FindGameObjectWithTag("PlayerItemInventory")
            .GetComponent<ItemInventory>().InUseItem = ItemName;

        foreach (CharacterUI characterUI in current.characterUIList)
        {
            characterUI.newTag = Use();
        }
    }
    public virtual void Setup(ItemName item, int amount = 0)
    {
        this.ItemName = item;
        Frame.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        Frame.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        string SpritePath = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        icon.sprite = Resources.Load<Sprite>(SpritePath);
        if (amount == 0)
            this.amount.transform.parent.gameObject.SetActive(false);
        else
        {
            this.amount.text = amount.ToString();
        }
        framRarity = Player.AllTagRareDict[Use()] != Rarerity.B ? Player.AllTagRareDict[Use()] : Rarerity.N;
        string FramePath = $"Art/BuildingUI/�ӻ���/���������/��Ʒ��/��Ʒ��-{framRarity}";
        Frame.sprite = Resources.Load<Sprite>(FramePath);
        var spritSize = icon.GetComponent<RectTransform>().sizeDelta;
        Frame.rectTransform.anchorMin = new Vector2(0, 0);
        Frame.rectTransform.anchorMax = new Vector2(1, 1);
        Frame.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        Frame.GetComponent<RectTransform>().localScale = new Vector2(1.16f, 1.1f);
    }
    public Tag Use()
    {
        Tag output = Tag.Null;
        if (SOItem.ItemMap.ContainsKey(ItemName))
        {
            output = SOItem.ItemMap[ItemName];
            return output;
        }
        else
        {
            Debug.LogError(ItemName);
            return output;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetOffDetail();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOnDetail(ItemName.ToString());
    }

    public void SetOnDetail(string target)
    {
        ItemDetailUI.Show(ItemName.ToString());
    }

    public void SetOffDetail()
    {
        ItemDetailUI.Hide();
    }
}
