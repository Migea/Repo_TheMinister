using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using static PixelCrushers.QuestMachine.QuestNumber;

public static class ItemStatPrinter
{
    private static Dictionary<Tag, List<int>> TagInfDict => Player.TagInfDict;
    private static Dictionary<ItemName, Tag> ItemToTag => Player.ItemToTag;
    public static string PrintAllStats(Tag tag)
    {
        string output = string.Empty;
        int count = 0;
        foreach (CharacterValueType valueType in Enum.GetValues(typeof(CharacterValueType)))
        {
            var newLine = PrintStat(tag, valueType);
            if (newLine == string.Empty) continue;
            if (count == 3) output += "\n";
            output += newLine;
            output += " ";
            count++;
        }
        if (count == 0)
        {
            LocalizedString uselessString = new LocalizedString
            {
                TableReference = "itemdescribe",
                TableEntryReference = $"无用"
            };
            return uselessString.GetLocalizedString();
        }
        
        return output;
    }
    public static string PrintAllStats(ItemName item)
    {
        return PrintAllStats(ItemToTag[item]);
    }
    public static string PrintStat(Tag tag, CharacterValueType valueType)
    {
        int value = 0;
        switch (valueType)
        {
            case CharacterValueType.智:
                value = TagInfDict[tag][0];
                break;
            case CharacterValueType.才:
                value = TagInfDict[tag][1];
                break;
            case CharacterValueType.谋:
                value = TagInfDict[tag][2];
                break;
            case CharacterValueType.武:
                value = TagInfDict[tag][3];
                break;
            case CharacterValueType.刺:
                value = TagInfDict[tag][4];
                break;
            case CharacterValueType.守:
                value = TagInfDict[tag][5];
                break;
            default: break;
        }
        string sign = value > 0 ? "+" : string.Empty;
        LocalizedString valueTypeString = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = $"设置_{valueType.ToString()}"
        };
        string output = value != 0 ? $" {valueTypeString.GetLocalizedString()}{sign}{value}" : string.Empty;
        return output;
    }
    public static string PrintStat(ItemName item, CharacterValueType valueType)
    {
        return PrintStat(ItemToTag[item], valueType);
    }
}
