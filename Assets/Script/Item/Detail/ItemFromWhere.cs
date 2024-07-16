using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ItemFromWhere : MonoBehaviour
{
    public ItemName itemName;
    public Text Where;
    public Text Information;
    public Color NColor = Color.white;
    public Color RColor = Color.white;
    public Color SRColor = Color.white;
    public Color SSRColor = Color.white;
    public Color URColor = Color.white;
    public Dictionary<ItemName, List<ItemName>> MergeItemDict => SOItem.MergeItemDict;
    public Dictionary<BuildingType, List<ItemName>> BuildingCraftDict => SOItem.BuildingCraftDict;
    public void Setup(ItemName itemName)
    {
        this.itemName = itemName;
        if (!MergeItemDict.Keys.Contains(itemName)) { gameObject.SetActive(false); return; }
        else
        {
            gameObject.SetActive(true);
        }
        var requireList = MergeItemDict[itemName];
        string outputText = string.Empty;
        if (requireList == null) { gameObject.SetActive(false); return; }
        else
        {
            foreach (var item in requireList)
            {
                if (outputText != string.Empty) outputText += "°¢";
                Color rareColor = NColor;
                var Rarity = Player.AllTagRareDict[Use(item)] != Rarerity.B ? Player.AllTagRareDict[Use(item)] : Rarerity.N;
                if (Rarity == Rarerity.R) rareColor = RColor;
                else if (Rarity == Rarerity.SR) rareColor = SRColor;
                else if (Rarity == Rarerity.SSR) rareColor = SSRColor;
                else if (Rarity == Rarerity.UR) rareColor = URColor;
                string line = $"<color=#{ColorUtility.ToHtmlStringRGBA(rareColor)}>{item.ToString()}</color>";
                outputText += line;
            }
        }
        Where.text = FindWhere(itemName);
        Information.text = outputText;
    }
    public string FindWhere(ItemName itemName)
    {
        string locations = string.Empty;
        foreach (var item in BuildingCraftDict)
        {
            if (item.Value.Contains(itemName))
            {
                if (locations != string.Empty) locations += "°¢";
                LocalizedString locationsString = new LocalizedString
                {
                    TableReference = "UI",
                    TableEntryReference = $"…Ë÷√_{item.Key.ToString()}"
                };
                locations += locationsString.GetLocalizedString();
            }
        }
        return locations;
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
