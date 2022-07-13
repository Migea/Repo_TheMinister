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
            },
            {DebateTopicCode.�����徭,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.��ͨ����, Tag.����ѧ��, Tag.���},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.��ʷ����,new ArrayList(){Rarerity.SSR,new List < Tag > (){Tag.״Ԫ, Tag.��ϲ��, Tag.����},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SSR}}},
            {DebateTopicCode.��������,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.���˾���, Tag.�⽻��},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.�˼�����,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.����ת��, Tag.���س�ի, Tag.ɮ��},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.��������,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.�Ƶ��ھ�, Tag.��ʿ},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.��ľΪ��,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.��������, Tag.����},new CharacterValueType[] {CharacterValueType.ı},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.�������,new ArrayList(){Rarerity.R,new List < Tag > (){Tag.С��ı��, Tag.��Ա},new CharacterValueType[] {CharacterValueType.ı},new Rarerity[] {Rarerity.R}}},
            {DebateTopicCode.�������,new ArrayList(){Rarerity.SSR,new List < Tag > (){Tag.ī�سɹ�, Tag.�ݺ��},new CharacterValueType[] {CharacterValueType.ı},new Rarerity[] {Rarerity.SSR}}},
            {DebateTopicCode.Լ������,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.����, Tag.��ʦ, Tag.����},new CharacterValueType[] {CharacterValueType.ı},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.�����黹,new ArrayList(){Rarerity.R,new List < Tag > (){Tag.���, Tag.��Ϸ��},new CharacterValueType[] {CharacterValueType.ı},new Rarerity[] {Rarerity.R}}},
            {DebateTopicCode.ָ¹Ϊ��,new ArrayList(){Rarerity.R,new List < Tag > (){Tag.�뾭�ѵ�, Tag.�����ͽ},new CharacterValueType[] {CharacterValueType.ı},new Rarerity[] {Rarerity.R}}},
            {DebateTopicCode.ӽʷ����,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.���˾���, Tag.����},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.ɽˮ��԰,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.��������, Tag.���˴���},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.�������,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.���Ŷݼ�, Tag.������, Tag.������},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.ӽ���㻳,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.�Ż�����, Tag.���в���},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.�����Թ,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.ʫ�˴�, Tag.��������, Tag.�廨��ͷ},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.��������,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.����˫ȫ, Tag.���Ŷݼ�, Tag.��������},new CharacterValueType[] {CharacterValueType.��},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.��ŷ��,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.����֮־, Tag.��Ϸ��},new CharacterValueType[] {CharacterValueType.ı},new Rarerity[] {Rarerity.SR}}}

        };
    public DebateTopicCode debateTopicCode;
    public Rarerity rarerity;
    public List<Tag> tagRequest = new List<Tag>();
    public CharacterValueType[] characterValue = new CharacterValueType[] { };
    public bool IsClose = false;

    public void Setup(DebateTopicCode code)
    {
        debateTopicCode = code;
        rarerity = (Rarerity)TopicCodeDict[debateTopicCode][0];
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
