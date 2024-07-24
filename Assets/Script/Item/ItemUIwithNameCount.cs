using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Tables;
using UnityEngine.Localization;
using UnityEngine.UI;
using PixelCrushers.QuestMachine;

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
        string FramePath = $"Art/BuildingUI/杂货铺/初级五金铺/物品框/物品框-{framRarity}";
        Frame.sprite = Resources.Load<Sprite>(FramePath);
        LocalizedString itemString = new LocalizedString
        {
            TableReference = "ItemShortName",
            TableEntryReference = item.ToString()
        };
        Name.text = itemString.GetLocalizedString();
        Name.gameObject.AddComponent<FontUpdater>();
        Name.lineSpacing = 0.4f;
    }
    public override void Setup(ItemName item, int count = 0)
    {
        Tool(item, count);
        Frame.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        Frame.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }
}
