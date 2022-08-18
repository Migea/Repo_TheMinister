using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CureTagUI : MonoBehaviour
{
    public Tag OriginTag;
    public Image tagImage;
    public Button tagButton;
    public int price = 100;

    public void Setup(Tag tag)
    {
        OriginTag = tag;
        tagImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnTagPath(tag));
        //tagButton.onClick.AddListener(() =>
        //{
        //});
    }
    public void TryCure()
    {
        string message = "";
        if(FindObjectOfType<CurrencyInventory>().Money< price)
        {
            message = "����Ҫ��������";
            var alert =Instantiate( Resources.Load<RiseUpTextAnimation>("Hiring/Message"),MainCanvas.FindMainCanvas());
            alert.GetComponent<Text>().text = message;
            return;
        }
        message = $"ȷ�ϻ���{price}�����������Ƴ���{OriginTag}��������\n�����ƺ󽫻���´��������˴��š���";
        var confirm = Confirmation.CreateNewComfirmation(Cure,message);
        StartCoroutine(confirm.Confirm());
    }
    public void Cure()
    {
        var character = FindObjectOfType<OnSwitchAssets>().character;
        character.ExchangeTag(Tag.���˴���, OriginTag);
        FindObjectOfType<CurrencyInventory>().MoneyAdd(-price);
        string message = $"����{character.CharacterName}�ɹ�";
        var alert = Instantiate(Resources.Load<RiseUpTextAnimation>("Hiring/Message"), MainCanvas.FindMainCanvas());
        alert.GetComponent<Text>().text = message;
        Destroy(gameObject);
    }
}
