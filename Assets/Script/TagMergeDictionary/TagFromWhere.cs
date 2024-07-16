using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class TagFromWhere : MonoBehaviour
{
    public Tag tag;
    public Text TagName;
    public Text Where;
    public Color NColor = Color.white;
    public Color RColor = Color.white;
    public Color SRColor = Color.white;
    public Color SSRColor = Color.white;
    public Color URColor = Color.white;
    public Dictionary<Rarerity, List<Tag>> GivenableTagRareDict => Player.GivenableTagRareDict;
    public Dictionary<Rarerity, List<Tag>> MergeableTagRareDict => Player.MergeableTagRareDict;
    public Dictionary<Rarerity, List<Tag>> ItemgiveTagRareDict => Player.ItemgiveTagRareDict;
    public Dictionary<ItemName, Tag> ItemToTag => Player.ItemToTag;
    public void Setup(Tag tag)
    {
        this.tag = tag;
        LocalizedString tagString = new LocalizedString
        {
            TableReference = "Tag",
            TableEntryReference = $"设置_{tag.ToString()}"
        };
        tagString.GetLocalizedString();
        this.TagName.text = $"<{tagString.GetLocalizedString()}>";
        string output = string.Empty;
        if (TryGiven())
        {
            LocalizedString localizedString = new LocalizedString
            {
                TableReference = "Tag",
                TableEntryReference = $"出生获得"
            };
            output += $"{localizedString.ToString()}\n";
        }
        if (TryItem())
        {
            LocalizedString localizedString = new LocalizedString
            {
                TableReference = "Tag",
                TableEntryReference = $"使用道具获得"
            };
            output += $"{localizedString}：\n";
            Color rareColor = NColor;
            var Rarity = Player.AllTagRareDict[tag] != Rarerity.B ? Player.AllTagRareDict[tag] : Rarerity.N;
            if (Rarity == Rarerity.R) rareColor = RColor;
            else if (Rarity == Rarerity.SR) rareColor = SRColor;
            else if (Rarity == Rarerity.SSR) rareColor = SSRColor;
            else if (Rarity == Rarerity.UR) rareColor = URColor;
            LocalizedString ItemString = new LocalizedString
            {
                TableReference = "Item",
                TableEntryReference = $"{WhatItem(tag).ToString()}"
            };
            output += $"<color=#{ColorUtility.ToHtmlStringRGBA(rareColor)}>{ItemString.GetLocalizedString()}</color>\n";
        }
        if (TryMerge())
        {
            LocalizedString localizedString = new LocalizedString
            {
                TableReference = "Tag",
                TableEntryReference = $"词条合成获得"
            };
            output += $"{localizedString.GetLocalizedString()}\n";
        }
        Where.text = output;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    public bool TryMerge()
    {
        foreach (var list in MergeableTagRareDict.Values)
        {
            if (list.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }
    public bool TryGiven()
    {
        foreach (var list in GivenableTagRareDict.Values)
        {
            if (list.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }
    public bool TryItem()
    {
        foreach (var list in ItemgiveTagRareDict.Values)
        {
            if (list.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }
    public ItemName WhatItem(Tag tag)
    {
        foreach (var item in ItemToTag)
        {
            if (item.Value.Equals(tag)) return item.Key;
        }
        return ItemName.Null;
    }
}
