using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebateTopicCode
{
    none,
    ī��
}
public class DebateTopic
{
    public static Dictionary<DebateTopicCode, ArrayList> TopicCodeDict =
        new Dictionary<DebateTopicCode, ArrayList>
        {
            {
                DebateTopicCode.ī��,
                new ArrayList()
                {
                    new List<Tag>(){Tag.��ʦ, Tag.����},
                    CharacterValueType.��,
                    1
                }
            }
        };
    public DebateTopicCode DebateTopicCode;
    public List<Tag> tagRequest = new List<Tag>();
    public Rarerity raririty;
    public CharacterValueType[] characterValue = new CharacterValueType[] { CharacterValueType.�� };
    public bool IsClose = false;

    public void Setup()
    {

    }
    //public int CalculatePoints(Character character)
    //{
    //    int total = 0;
    //    total += (int)character.characterValueRareDict[characterValue];
    //    foreach (Tag tag in tagRequest)
    //    {
    //        if (character.tagList.Contains(tag))
    //        {
    //            total += (int)Player.AllTagRareDict[tag] / 2;
    //        }
    //    }
    //    return total;
    //}
}
