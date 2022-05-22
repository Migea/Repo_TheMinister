using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebateTopicCode
{
    �����ҷ�,
    �����徭,
    ��ʷ����,
    ��������,
    �˼�����,
    ��������,
    ��ľΪ��,
    �������,
    �������,
    Լ������,
    �����黹,
    ָ¹Ϊ��,
    ӽʷ����,
    ɽˮ��԰,
    �������,
    ӽ���㻳,
    �����Թ,
    ��������,
    ��ŷ��
}
public class DebateTopic
{
    public static Dictionary<DebateTopicCode, ArrayList> TopicCodeDict =
        new Dictionary<DebateTopicCode, ArrayList>
        {
            {
                DebateTopicCode.�����ҷ�,
                new ArrayList()
                {
                    Rarerity.N,
                    new List<Tag>(){Tag.��ʦ, Tag.����},
                    new CharacterValueType[] { CharacterValueType.�� },
                    new Rarerity[] { Rarerity.N}
                }
            }
        };
    public DebateTopicCode debateTopicCode;
    public Rarerity raririty;
    public List<Tag> tagRequest = new List<Tag>();
    public CharacterValueType[] characterValue = new CharacterValueType[] { };
    public bool IsClose = false;

    public void Setup(DebateTopicCode code)
    {
        debateTopicCode = code;
        raririty = (Rarerity)TopicCodeDict[debateTopicCode][0];
        tagRequest = (List<Tag>)TopicCodeDict[debateTopicCode][1];
        characterValue = (CharacterValueType[])TopicCodeDict[debateTopicCode][2];
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
