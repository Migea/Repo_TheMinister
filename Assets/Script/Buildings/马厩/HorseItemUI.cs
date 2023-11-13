using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        BuyPrice.text = SOItem.ItempriceTag[buildingType][ItemType.����][(int)framRarity / 2 - 1].ToString();
        RentPrice.text = SOItem.ItemRentPrice[(int)framRarity / 2 - 1].ToString();
        HorseName.text = ItemName.ToString();
        if (itemImage != null)
            itemImage.gameObject.SetActive(true);
    }
    public void Rent()
    {
        var map = FindObjectOfType<Map>();
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currencyInv.Money < int.Parse(BuyPrice.text))
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            alert.text = "����Ҫ��������";
            return;
        }
        buff = (int)framRarity / 2 + 1;
        string message = "�Ƿ񻨷�" + BuyPrice.text + "��������" + ItemName + $"�����{buff}���ƶ��ӳ�?";
        StartCoroutine(Confirmation.CreateNewComfirmation(RentItem, message).Confirm());
    }
    public void RentItem()
    {
        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
        alert.text = "����� " + buff + "�����ټӳ�";
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        currencyInv.Money -= int.Parse(BuyPrice.text);
        FindObjectOfType<Map>().HorseMovementBuff = buff;
        Destroy(this.gameObject);
    }
    public void Buy()
    {
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currencyInv.Money < int.Parse(BuyPrice.text))
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            alert.text = "����Ҫ��������";
            return;
        }
        string message = "�Ƿ񻨷�" + BuyPrice.text + "��������" + ItemName + "?";
        StartCoroutine(Confirmation.CreateNewComfirmation(BuyItem, message).Confirm());
    }
    public void BuyItem()
    {
        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
        alert.text = "����� " + ItemName + "\n(�������ƥֻ��װ������ɫ)";
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        currencyInv.Money -= int.Parse(BuyPrice.text);
        BoughtSign.SetActive(true);
        FindObjectOfType<ItemInventory>().AddItem(ItemName);
        Destroy(this.gameObject);
    }
}
