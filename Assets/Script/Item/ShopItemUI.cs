using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class ShopItemUI : ItemUI
{
    public Text Price;
    public GameObject BoughtSign;
    private bool bought = false;
    private void Start()
    {
        BoughtSign.SetActive(false);
    }
    protected override void LeftClickAction()
    {
        if (bought)
        {
            return;
        }
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currencyInv.Money < int.Parse(Price.text))
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            alert.text = "����Ҫ��������";
            return;
        }
        string message = "�Ƿ񻨷�" + Price.text + "��������" + ItemName + "?";
        Confirmation.CreateNewComfirmation(BuyItem, message);
    }
    public void BuyItem()
    {
        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
        alert.text = "����� " + ItemName;
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        currencyInv.Money -= int.Parse(Price.text);
        BoughtSign.SetActive(true);
        FindObjectOfType<ItemInventory>().AddItem(ItemName);
    }
    public void SetupShopItem(ItemName item, int price = 0)
    {
        Price.text = price.ToString();
        amount.gameObject.SetActive(false);
    }
}
