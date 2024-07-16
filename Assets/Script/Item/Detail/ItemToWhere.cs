using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ItemToWhere : MonoBehaviour
{
    public ItemName itemName;
    public Text Where;
    public Color NColor = Color.white;
    public Color RColor = Color.white;
    public Color SRColor = Color.white;
    public Color SSRColor = Color.white;
    public Color URColor = Color.white;
    public Dictionary<ItemName, List<ItemName>> MergeItemDict => SOItem.MergeItemDict;
    public void Setup(ItemName itemName)
    {
        this.itemName = itemName;
        var ToList = new List<ItemName>();
        foreach (var item in MergeItemDict)
        {
            if (item.Value.Contains(itemName))
            {
                ToList.Add(item.Key);
            }
        }
        if (ToList.Count < 1) { gameObject.SetActive(false); return; }
        else
        {
            gameObject.SetActive(true);
        }
        string output = string.Empty;
        foreach (var item in ToList)
        {
            if (output != string.Empty) output += "\n";
            Color rareColor = NColor;
            var Rarity = Player.AllTagRareDict[Use(item)] != Rarerity.B ? Player.AllTagRareDict[Use(item)] : Rarerity.N;
            if (Rarity == Rarerity.R) rareColor = RColor;
            else if (Rarity == Rarerity.SR) rareColor = SRColor;
            else if (Rarity == Rarerity.SSR) rareColor = SSRColor;
            else if (Rarity == Rarerity.UR) rareColor = URColor;
            LocalizedString itemString = new LocalizedString
            {
                TableReference = "Item",
                TableEntryReference = $"{item.ToString()}"
            };
            output += $"<color=#{ColorUtility.ToHtmlStringRGBA(rareColor)}>{itemString.GetLocalizedString()}</color>";
        }
        Where.text = output;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }


    public Tag Use(ItemName itemName)
    {
        Tag output = Tag.Null;
        if (SOItem.ItemMap.ContainsKey(itemName))
        {
            output = SOItem.ItemMap[itemName];
            return output;
        }
        else
        {
            Debug.LogError(itemName);
            return output;
        }
    }
}
