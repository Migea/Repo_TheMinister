using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum DebatePointCollector
{
    ����,
    ��ҹ���,
    ����,
    �����,
    �����о�,
    ��ͬ����,
    ��ѹ����,
    ��λ��Ȼ,
    ����ֱ�,
    Ȩ��,
    �ʲ��԰�,
    �Ҽ�,
    һ֦����,
    ����λ,
    ����,
    �����ٳ�,
    ����,
    ����ı��,
    ��Ļ,
    ����,
    �廨��ͷ,
    �Ӳ���,
    ���ڵй�,
    ��ʿ��˫,
    ���Ͻ߽�,
    ����֮��,
    ǿ����
}

public class TopicPointsCalculator : MonoBehaviour
{
    private delegate bool TopicPointsCalculatorDelegate(DebateTopic topic, Character[] playerCharacters, object value);
    static TopicPointsCalculatorDelegate isCharacterFemale = IsCharacterFemale;
    static TopicPointsCalculatorDelegate isWisdomAboveR = IsWisdomAboveR;
    static TopicPointsCalculatorDelegate isWisdomAboveSR = IsWisdomAboveSR;
    static TopicPointsCalculatorDelegate isWisdomAboveSSR = IsWisdomAboveSSR;
    static TopicPointsCalculatorDelegate isWisdomBelowN = IsWisdomBelowN;
    static TopicPointsCalculatorDelegate isGetRightTag = IsGetRightTag;
    static TopicPointsCalculatorDelegate isGetAllRightTags = IsGetAllRightTags;
    static TopicPointsCalculatorDelegate isRollingOthers = IsRollingOthers;
    static TopicPointsCalculatorDelegate isOnlyGoverner = IsOnlyGoverner;
    static TopicPointsCalculatorDelegate isStatHighest = IsStatHighest;
    static TopicPointsCalculatorDelegate isStatBelowN = IsStatBelowN;
    static TopicPointsCalculatorDelegate isCarryWeapon = IsCarryWeapon;
    static TopicPointsCalculatorDelegate isOtherCarryWeapon = IsOtherCarryWeapon;
    static TopicPointsCalculatorDelegate isSolo = IsSolo;
    static TopicPointsCalculatorDelegate isRarityFit = IsRarityFit;
    static TopicPointsCalculatorDelegate isAnyUR = IsAnyUR;
    static TopicPointsCalculatorDelegate isStrategyLowest = IsStrategyLowest;
    static TopicPointsCalculatorDelegate isStrategyLowerThanAny = IsStrategyLowerThanAny;
    static TopicPointsCalculatorDelegate isStrategyRequiredAndGotHighest = IsStrategyRequiredAndGotHighest;
    static TopicPointsCalculatorDelegate isStrategyNotRequiredAndGotHighest = IsStrategyNotRequiredAndGotHighest;
    static TopicPointsCalculatorDelegate isAnyFemaleGotHigherStrategyThanMale = IsAnyFemaleGotHigherStrategyThanMale;
    static TopicPointsCalculatorDelegate isAnyFemaleExist = IsAnyFemaleExist;
    static TopicPointsCalculatorDelegate isAnyRequiredStatLowest = IsAnyRequiredStatLowest;
    static TopicPointsCalculatorDelegate isFallingOnTopic = IsFallingOnTopic;
    static TopicPointsCalculatorDelegate isGotHelp = IsGotHelp;
    static TopicPointsCalculatorDelegate isRollingOnTopic = IsRollingOnTopic;
    static TopicPointsCalculatorDelegate isLoyaltyHigh = IsLoyaltyHigh;
    static TopicPointsCalculatorDelegate isLoyaltyLow = IsLoyaltyLow;
    static TopicPointsCalculatorDelegate isCharacterMale = IsCharacterMale;

    private static Dictionary<DebatePointCollector, List<TopicPointsCalculatorDelegate>> debatePointCollectorToDelegate
    = new Dictionary<DebatePointCollector, List<TopicPointsCalculatorDelegate>>()
    {
            { DebatePointCollector.����, new List<TopicPointsCalculatorDelegate> {isCharacterFemale } },
            { DebatePointCollector.����, new List<TopicPointsCalculatorDelegate>{isCharacterFemale} },
            { DebatePointCollector.��ҹ���, new List<TopicPointsCalculatorDelegate>{ isCharacterFemale, isWisdomAboveSR} },
            { DebatePointCollector.����, new List<TopicPointsCalculatorDelegate>{ isCharacterMale, isWisdomAboveR} },
            { DebatePointCollector.�����, new List<TopicPointsCalculatorDelegate>{ isCharacterMale, isWisdomAboveSSR} },
            { DebatePointCollector.�����о�, new List<TopicPointsCalculatorDelegate>{isGetRightTag} },
            { DebatePointCollector.��ͬ����, new List<TopicPointsCalculatorDelegate>{isGetAllRightTags} },
            { DebatePointCollector.��ѹ����, new List<TopicPointsCalculatorDelegate>{isRollingOthers} },
            { DebatePointCollector.��λ��Ȼ, new List<TopicPointsCalculatorDelegate>{isOnlyGoverner} },
            { DebatePointCollector.����ֱ�, new List<TopicPointsCalculatorDelegate>{isWisdomBelowN} },
            { DebatePointCollector.Ȩ��, new List<TopicPointsCalculatorDelegate>{isStatHighest} },
            { DebatePointCollector.�ʲ��԰�, new List<TopicPointsCalculatorDelegate>{isStatBelowN} },
            { DebatePointCollector.�Ҽ�, new List<TopicPointsCalculatorDelegate>{isCarryWeapon} },
            { DebatePointCollector.һ֦����, new List<TopicPointsCalculatorDelegate>{isSolo} },
            { DebatePointCollector.����λ, new List<TopicPointsCalculatorDelegate>{isRarityFit} },
            { DebatePointCollector.����, new List<TopicPointsCalculatorDelegate>{isAnyUR} },
            { DebatePointCollector.�����ٳ�, new List<TopicPointsCalculatorDelegate>{isStrategyLowest} },
            { DebatePointCollector.����, new List<TopicPointsCalculatorDelegate>{isStrategyLowerThanAny} },
            { DebatePointCollector.����ı��, new List<TopicPointsCalculatorDelegate>{isStrategyRequiredAndGotHighest} },
            { DebatePointCollector.��Ļ, new List<TopicPointsCalculatorDelegate>{isStrategyNotRequiredAndGotHighest} },
            { DebatePointCollector.����, new List<TopicPointsCalculatorDelegate>{isCharacterMale, isAnyFemaleGotHigherStrategyThanMale } },
            { DebatePointCollector.�廨��ͷ, new List<TopicPointsCalculatorDelegate>{isCharacterMale, isAnyFemaleExist , isAnyRequiredStatLowest} },
            { DebatePointCollector.�Ӳ���, new List<TopicPointsCalculatorDelegate>{isFallingOnTopic} },
            { DebatePointCollector.���ڵй�, new List<TopicPointsCalculatorDelegate>{isGotHelp} },
            { DebatePointCollector.��ʿ��˫, new List<TopicPointsCalculatorDelegate>{isRollingOnTopic} },
            { DebatePointCollector.���Ͻ߽�, new List<TopicPointsCalculatorDelegate>{isLoyaltyHigh} },
            { DebatePointCollector.����֮��, new List<TopicPointsCalculatorDelegate>{isLoyaltyLow} },
            { DebatePointCollector.ǿ����, new List<TopicPointsCalculatorDelegate>{isOtherCarryWeapon} },
    };
    private static Dictionary<DebatePointCollector, int[]> CollectorToPoints
        = new Dictionary<DebatePointCollector, int[]>()
        {
            { DebatePointCollector.���� , new int[]{1, 10} },
            { DebatePointCollector.��ҹ���, new int[]{2, 10} },
            { DebatePointCollector.����, new int[]{1, 10} },
            { DebatePointCollector.�����, new int[]{2, 10} },
            { DebatePointCollector.�����о�, new int[]{0, 50} },
            { DebatePointCollector.��ͬ����, new int[]{1, 10} },
            { DebatePointCollector.��ѹ����, new int[]{3, 30} },
            { DebatePointCollector.��λ��Ȼ, new int[]{1, 30} },
            { DebatePointCollector.����ֱ�, new int[]{0, -20} },
            { DebatePointCollector.Ȩ��, new int[]{1, 10} },
            { DebatePointCollector.�ʲ��԰�, new int[]{-1, -10} },
            { DebatePointCollector.�Ҽ�, new int[]{0, -30} },
            { DebatePointCollector.һ֦����, new int[]{1, 10} },
            { DebatePointCollector.����λ, new int[]{1, 40} },
            { DebatePointCollector.����, new int[]{1, 10} },
            { DebatePointCollector.�����ٳ�, new int[]{-1, -20} },
            { DebatePointCollector.����, new int[]{0, -10} },
            { DebatePointCollector.����ı��, new int[]{1, 10} },
            { DebatePointCollector.��Ļ, new int[]{0, 10} },
            { DebatePointCollector.����, new int[]{0, -20} },
            { DebatePointCollector.�廨��ͷ, new int[]{0, -10} },
            { DebatePointCollector.�Ӳ���, new int[]{1, 0} },
            { DebatePointCollector.���ڵй�, new int[]{0, -10} },
            { DebatePointCollector.��ʿ��˫, new int[]{5, 10} },
            { DebatePointCollector.���Ͻ߽�, new int[]{1, 0} },
            { DebatePointCollector.����֮��, new int[]{-1, 0} },
            { DebatePointCollector.ǿ����, new int[]{-1, 20} }
        };
    public static int[] CalculatPoints(DebatePointCollector collector, DebateTopic topic, Character[] playerCharacters, object value)
    {
        debatePointCollectorToDelegate.TryGetValue(collector, out List<TopicPointsCalculatorDelegate> delegates);
        foreach (var delegateItem in delegates)
        {
            if (delegateItem(topic, playerCharacters, value))
            {
                return new int[] { 0, 0 };
            }
        }
        return CollectorToPoints[collector];
    }
    static bool IsCharacterFemale(DebateTopic topic, Character[] playerCharacters, object value)
    {
        bool output = false;
        return output;
    }
    static bool IsCharacterMale(DebateTopic topic, Character[] playerCharacters, object value)
    {
        return !IsCharacterFemale(topic, playerCharacters, value);
    }
    static bool IsWisdomAboveR(DebateTopic topic, Character[] playerCharacters, object value = null)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[CharacterValueType.��] > Rarerity.R)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsWisdomAboveSR(DebateTopic topic, Character[] playerCharacters, object value = null)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[CharacterValueType.��] > Rarerity.SR)
            {
                return true;
            }
        }
        return false;
    }

    static bool IsWisdomAboveSSR(DebateTopic topic, Character[] playerCharacters, object value = null)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[CharacterValueType.��] > Rarerity.SSR)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsWisdomBelowN(DebateTopic topic, Character[] playerCharacters, object value = null)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[CharacterValueType.��] < Rarerity.N)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsGetRightTag(DebateTopic topic, Character[] playerCharacters, object value)
    {
        Tag tag = (Tag)value;
        foreach (Character character in playerCharacters)
        {
            if (character.tagList.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }
    static bool IsGetAllRightTags(DebateTopic topic, Character[] playerCharacters, object value)
    {
        List<Tag> tagList = (List<Tag>)value;
        foreach (Tag tag in tagList)
        {
            for (int i = playerCharacters.Length; i > 0; i--)
            {
                var character = playerCharacters[i - 1];
                if (character.tagList.Contains(tag))
                {
                    break;
                }
                else if (i == 1)
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool IsRollingOthers(DebateTopic topic, Character[] playerCharacters, object value)
    {
        int playerTotal = 0;
        foreach (Character character in playerCharacters)
        {
            foreach (CharacterValueType valueType in topic.characterValue)
            {
                playerTotal += character.CharactersValueDict[valueType];
            }
        }
        var otherPlayers = value as List<Character[]>;
        var otherTotal = new int[otherPlayers.Count];
        for (int i = 0; i < otherPlayers.Count; i++)
        {
            foreach (Character character in otherPlayers[i])
            {
                foreach (CharacterValueType valueType in topic.characterValue)
                {
                    otherTotal[i] += character.CharactersValueDict[valueType];
                }
            }
        }
        foreach (int total in otherTotal)
        {
            if (total > playerTotal)
            {
                return false;
            }
        }
        return true;
    }

    static bool IsOnlyGoverner(DebateTopic topic, Character[] playerCharacters, object value)
    {
        foreach (Character character in playerCharacters)
        {
            //if (character.tagList.Contains(Tag.))
            //{
            //    return true;
            //}
        }
        return false;
    }
    static bool IsStatHighest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var input = value as ArrayList;
        var type = (CharacterValueType)input[0];
        var otherPlayersCharacters = input[1] as List<Character[]>;
        int playerHighestValue = 0;
        foreach (Character character in playerCharacters)
        {
            if (character.CharactersValueDict[type] > playerHighestValue)
            {
                playerHighestValue = character.CharactersValueDict[type];
            }
        }
        foreach (Character[] otherCharacters in otherPlayersCharacters)
        {
            foreach (Character character in otherCharacters)
            {
                if (character.CharactersValueDict[type] > playerHighestValue)
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool IsStatBelowN(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var type = (CharacterValueType)value;
        int playerHighestValue = 0;
        foreach (Character character in playerCharacters)
        {
            if (character.CharactersValueDict[type] < playerHighestValue)
            {
                playerHighestValue = character.CharactersValueDict[type];
            }
        }
        bool output = playerHighestValue < (int)Rarerity.N;
        return output;
    }
    static bool IsCarryWeapon(DebateTopic topic, Character[] playerCharacters, object value)
    {
        bool output = false;
        return output;
    }
    static bool IsOtherCarryWeapon(DebateTopic topic, Character[] playerCharacters, object value)
    {
        //var otherPlayers = value as List<Character[]>;
        //foreach (Character[] otherPlayer in otherPlayers)
        //{
        //    foreach (Character character in otherPlayer)
        //    {
        //        if (character.tagList.Contains())
        //        {
        //            return true;
        //        }
        //    }
        //}
        bool output = false;
        return output;
    }
    static bool IsSolo(DebateTopic topic, Character[] playerCharacters, object value)
    {
        bool output = playerCharacters.Length == 1;
        return output;
    }
    static bool IsRarityFit(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var rarity = topic.raririty;

        foreach (Character character in playerCharacters)
        {
            var characterRarities = new int[]
            {
                (int)character.characterValueRareDict[CharacterValueType.��],
                (int)character.characterValueRareDict[CharacterValueType.��],
                (int)character.characterValueRareDict[CharacterValueType.ı]
            };
            if (characterRarities.Max() == (int)rarity)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsAnyUR(DebateTopic topic, Character[] playerCharacters, object value)
    {
        CharacterValueType valueType = (CharacterValueType)value;
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[valueType] == Rarerity.UR)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsStrategyLowest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        int playerHighestStradegy = 0;
        foreach (Character character in playerCharacters)
        {
            playerHighestStradegy = new int[] { playerHighestStradegy, character.CharactersValueDict[CharacterValueType.ı] }.Max();
        }
        var otherPlayers = value as List<Character[]>;
        foreach (Character[] otherPlayer in otherPlayers)
        {
            foreach (Character character in otherPlayer)
            {
                if (character.CharactersValueDict[CharacterValueType.ı] < playerHighestStradegy)
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool IsStrategyLowerThanAny(DebateTopic topic, Character[] playerCharacters, object value)
    {
        int playerHighestStradegy = 0;
        foreach (Character character in playerCharacters)
        {
            playerHighestStradegy = new int[] { playerHighestStradegy, character.CharactersValueDict[CharacterValueType.ı] }.Max();
        }
        Character[] otherCharacters = value as Character[];
        int otherHighestStradegy = 0;
        foreach (Character character in otherCharacters)
        {
            otherHighestStradegy = new int[] { otherHighestStradegy, character.CharactersValueDict[CharacterValueType.ı] }.Max();
        }
        bool output = new int[] { playerHighestStradegy, otherHighestStradegy }.Min() == playerHighestStradegy;
        return output;
    }
    static bool IsStrategyNotRequiredAndGotHighest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        int playerHighestStradegy = 0;
        foreach (Character character in playerCharacters)
        {
            playerHighestStradegy = new int[] { playerHighestStradegy, character.CharactersValueDict[CharacterValueType.ı] }.Max();
        }
        var otherPlayers = value as List<Character[]>;
        foreach (Character[] otherPlayer in otherPlayers)
        {
            foreach (Character character in otherPlayer)
            {
                if (character.CharactersValueDict[CharacterValueType.ı] > playerHighestStradegy)
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool IsStrategyRequiredAndGotHighest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        if (topic.characterValue.Contains(CharacterValueType.ı))
        {
            return isStrategyNotRequiredAndGotHighest(topic, playerCharacters, value);
        }
        return false;
    }
    static bool IsAnyFemaleGotHigherStrategyThanMale(DebateTopic topic, Character[] playerCharacters, object value)
    {
        //TODO: female
        return false;
    }
    static bool IsAnyFemaleExist(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var otherPlayers = value as List<Character[]>;
        foreach (Character[] otherPlayer in otherPlayers)
        {
            foreach (Character character in otherPlayer)
            {
                //if (femaleArtCode.contain( character.characterArtCode))
                //{
                //    return true;
                //}
            }
        }
        return false;
    }
    static bool IsAnyRequiredStatLowest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var requiredStats = topic.characterValue;
        int[] playerHighestValue = new int[requiredStats.Length];
        foreach (Character character in playerCharacters)
        {
            for (int i = 0; i < requiredStats.Length; i++)
            {
                playerHighestValue[i] = new int[] { playerHighestValue[i], character.CharactersValueDict[requiredStats[i]] }.Max();
            }
        }
        int[] resultValue = playerHighestValue.Select(x => x).ToArray();
        var otherPlayers = value as List<Character[]>;
        for (int i = 0; i < requiredStats.Length; i++)
        {
            foreach (Character[] otherPlayer in otherPlayers)
            {
                foreach (Character character in otherPlayer)
                {
                    resultValue[i] = new int[] { resultValue[i], character.CharactersValueDict[requiredStats[i]] }.Min();
                }
            }
            if (resultValue[i] == playerHighestValue[i])
            {
                return true;
            }
        }
        return false;
    }

    static bool IsFallingOnTopic(DebateTopic topic, Character[] playerCharacters, object value)
    {
        foreach (Character character in playerCharacters)
        {
            foreach(Tag tag in topic.tagRequest)
            {
                if (character.tagList.Contains(tag))
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool IsGotHelp(DebateTopic topic, Character[] playerCharacters, object value)
    {
        bool output = playerCharacters.Length > 1;
        return output;
    }
    static bool IsRollingOnTopic(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var otherPlayers = value as List<Character[]>;
        foreach (CharacterValueType characterValueType in topic.characterValue)
        {
            if (!IsStatHighest(topic, playerCharacters, new ArrayList() { characterValueType, otherPlayers }))
            {
                return false;
            }
        }
        if (!IsGetAllRightTags(topic, playerCharacters, value))
        {
            return false;
        }
        if (!IsRarityFit(topic, playerCharacters, value))
        {
            return false;
        }
        return true;
    }
    static bool IsLoyaltyHigh(DebateTopic topic, Character[] playerCharacters, object value)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.loyalty >= 15)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsLoyaltyLow(DebateTopic topic, Character[] playerCharacters, object value)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.loyalty <= 5)
            {
                return true;
            }
        }
        return false;
    }
}
