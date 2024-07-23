using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.Localization.Tables;
using UnityEngine.Localization;

public class ShopItemUI : ItemUI
{
    public Text Price;
    public GameObject BoughtSign;
    private bool setdone = false;
    private bool Bought => BoughtSign.gameObject.activeSelf;
    private void Awake()
    {
        if (!setdone)
        {
            gameObject.SetActive(false);
            return;
        }
    }
    private void Start()
    {
        BoughtSign.SetActive(false);
    }
    protected override void LeftClickAction()
    {

    }
    public override void SetupInUseItem()
    {
        if (Bought)
        {
            return;
        }
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currencyInv.Money < int.Parse(Price.text))
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            LocalizedString localizedString = new LocalizedString
            {
                TableReference = "UI",
                TableEntryReference = "提示_你需要更多银两"
            };
            alert.text = localizedString.ToString();
            return;
        }
        else
        {
            BuyItem();
        }
        //string message = "是否花费" + Price.text + "银两购买" + ItemName + "?";
        //StartCoroutine(Confirmation.CreateNewComfirmation(BuyItem, message).Confirm());
    }
    public void BuyItem()
    {
        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
        LocalizedString localizedString = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = "商店购买_获得了"
        };
        LocalizedString localizedItem = new LocalizedString
        {
            TableReference = "Item",
            TableEntryReference = ItemName.ToString()
        };
        alert.text = localizedString.GetLocalizedString() + " " + localizedItem.GetLocalizedString();
        CurrencyInvAnimationManager.Instance.MoneyChange(-int.Parse(Price.text));
        BoughtSign.SetActive(true);
        FindObjectOfType<ItemInventory>().AddItem(ItemName);
    }
    public void SetupShopItem(ItemName item, int price = 0)
    {
        Setup(item, 0);
        Price.text = price.ToString();
        setdone = true;
        gameObject.SetActive(true);
        amount.gameObject.SetActive(false);
    }
}
