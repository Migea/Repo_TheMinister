using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class HorseItemUI : ItemUI
{
    public GameObject BoughtSign;
    public Text RentPrice;
    public Text BuyPrice;
    public Text HorseName;
    public Text HorseDescription;
    public Button BuyButton;
    public Button RentButton;
    private int buff;
    public GameObject itemImage;
    private IEnumerator Start()
    {
        var map = FindObjectOfType<Map>();
        yield return new WaitUntil(() => map.HorseMovementBuff > 1);
        RentButton.gameObject.SetActive(false);
        RentPrice.gameObject.SetActive(false);
    }
    public override void SetupInUseItem()
    {
        return;
    }
    protected override void LeftClickAction()
    {
        return;
    }
    public void SetupHorseItem(ItemName item, BuildingType buildingType)
    {
        Setup(item, 0);
        amount.gameObject.SetActive(false);
        BoughtSign.SetActive(false);
        BuyPrice.text = SOItem.ItempriceTag[buildingType][ItemType.坐骑][(int)framRarity / 2 - 1].ToString();
        RentPrice.text = SOItem.ItemRentPrice[(int)framRarity / 2 - 1].ToString();
        LocalizedString HorseString = new LocalizedString
        {
            TableReference = "Item",
            TableEntryReference = $"{ItemName}"
        };
        HorseName.text = HorseString.GetLocalizedString();
        if (itemImage != null)
            itemImage.gameObject.SetActive(true);
    }
    public void Rent()
    {
        var map = FindObjectOfType<Map>();
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currencyInv.Money < int.Parse(RentPrice.text))
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            LocalizedString alertString = new LocalizedString
            {
                TableReference = "UI",
                TableEntryReference = $"提示_你需要更多银两"
            };
            alert.text = alertString.GetLocalizedString();
            return;
        }
        else
        {
            buff = (int)framRarity / 2 + 1;
            RentItem();
        }
    }
    public void RentItem()
    {
        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
        LocalizedString message_1_String = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = $"商店购买_获得了"
        };
        LocalizedString message_2_String = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = $"倍移速加成"
        };
        alert.text = message_1_String.GetLocalizedString() + buff + message_2_String.GetLocalizedString();
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        currencyInv.Money -= int.Parse(RentPrice.text);
        FindObjectOfType<Map>().HorseMovementBuff = buff;
        Destroy(this.gameObject);
    }
    public void Buy()
    {
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currencyInv.Money < int.Parse(BuyPrice.text))
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            LocalizedString alertString = new LocalizedString
            {
                TableReference = "UI",
                TableEntryReference = $"提示_你需要更多银两"
            };
            alert.text = alertString.GetLocalizedString();
            return;
        }
        else
        {
            BuyItem();
        }
    }
    public void BuyItem()
    {
        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
        LocalizedString message_one_String = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = $"商店购买_获得了"
        };
        LocalizedString message_two_String = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = $"商店购买_购买的马匹只能装备给角色"
        };
        alert.text = message_one_String.GetLocalizedString() + ItemName + "\n" + message_two_String.GetLocalizedString();
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        currencyInv.Money -= int.Parse(BuyPrice.text);
        BoughtSign.SetActive(true);
        FindObjectOfType<ItemInventory>().AddItem(ItemName);
        Destroy(this.gameObject);
    }
}
