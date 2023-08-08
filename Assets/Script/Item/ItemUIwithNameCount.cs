using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIwithNameCount : ItemUI
{
    public Text Name;

    private void Tool(ItemName item, int amount)
    {
        string SpritePath = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        Icon.sprite = Resources.Load<Sprite>(SpritePath);
        this.amount.text = amount.ToString();
        this.ItemName = item;
        var framRarity = Player.AllTagRareDict[Use()] != Rarerity.B ? Player.AllTagRareDict[Use()] : Rarerity.N;
        string FramePath = $"Art/BuildingUI/�ӻ���/���������/��Ʒ��/��Ʒ��-{framRarity}";
        Frame.sprite = Resources.Load<Sprite>(FramePath);
        Name.text = item.ToString();
    }
    public override void Setup(ItemName item, int count = 0)
    {
        Tool(item, count);
        Frame.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        Frame.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }
}
