using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoitCharacter : Character
{
    public static List<Tag> RoitTagsA = new List<Tag>() {Tag.�����ͽ,
                                                         Tag.��Ѫ����,
                                                         Tag.����,
                                                         Tag.��ħ��,
                                                         Tag.�����鷢,
                                                         Tag.һ�㺮â,
                                                         Tag.���վ�տ,
                                                         Tag.����,
                                                         Tag.Ƥ��,
                                                         Tag.����,
                                                         Tag.�书С��,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.�������,
                                                         Tag.��������,
                                                         Tag.��������,
                                                         Tag.��û�޳�,
                                                         Tag.��֮��,
                                                         Tag.���ӿ��,
                                                         Tag.�ĺ�����,
                                                         Tag.����ħ��,
                                                         Tag.ѱ�޴�ʦ};

    public static List<Tag> badTagsA = new List<Tag>() { Tag.ƽƽ����,
                                                        Tag.�廨��ͷ,
                                                        Tag.�İ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.����֮��,
                                                        Tag.ë����ʢ,
                                                        Tag.��ϲ��,
                                                        Tag.������,
                                                        Tag.����,
                                                        Tag.��������,
                                                        Tag.�廨��ͷ,
                                                        Tag.������ };
    public static List<Tag> RoitTagsB = new List<Tag>() { Tag.���,
                                                        Tag.���νý�,
                                                        Tag.�����,
                                                        Tag.��ʦ,
                                                        Tag.ѱ����,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.��Ѫ��,
                                                        Tag.����,
                                                        Tag.ϰ��֮�� };

    public static List<Tag> badTagsB = new List<Tag>() { Tag.ϥ�ǽ�Ӳ,
                                                        Tag.����,
                                                        Tag.Ӫ������,
                                                        Tag.ҹ������,
                                                        Tag.����,
                                                        Tag.С�����,
                                                        Tag.�ô����,
                                                        Tag.��Ż,
                                                        Tag.�������� };

    public static List<Tag> RoitTagsC = new List<Tag>() { Tag.��ë��,
                                                        Tag.������,
                                                        Tag.����,
                                                        Tag.�����,
                                                        Tag.��ζ�ӳ�,
                                                        Tag.�þ�֮��,
                                                        Tag.����֢,
                                                        Tag.��ʦ };

    public static List<Tag> badTagsC = new List<Tag>() { Tag.�ද֢,
                                                        Tag.��Ƥ��,
                                                        Tag.�²�����,
                                                        Tag.��������,
                                                        Tag.��ͯ,
                                                        Tag.��������,
                                                        Tag.ҽ�� };

    public static List<Tag> RoitTagsD = new List<Tag>() {Tag.�,
                                                        Tag.��,
                                                        Tag.ǹ,
                                                        Tag.��,
                                                        Tag.��,
                                                        Tag.������ı,
                                                        Tag.����֢,
                                                        Tag.�����弼 };

    public static List<Tag> badTagsD = new List<Tag>() { Tag.����֢,
                                                        Tag.������,
                                                        Tag.��֫,
                                                        Tag.ҩ��,
                                                        Tag.������˥,
                                                        Tag.�ȽŲ���,
                                                        Tag.����,
                                                        Tag.����};
    public char Area = 'A';
    public List<Tag> RoitTags => Area == 'A' ? RoitTagsA : Area == 'B' ? RoitTagsB : Area == 'C' ? RoitTagsC : RoitTagsD;
    public List<Tag> badTags => Area == 'A' ? badTagsA : Area == 'B' ? badTagsB : Area == 'C' ? badTagsC : badTagsD;
    public static CharacterArtCode characterArtCodeA = CharacterArtCode.����;
    public static CharacterArtCode characterArtCodeB = CharacterArtCode.�е���;
    public static CharacterArtCode characterArtCodeC = CharacterArtCode.ʰ����;
    public static CharacterArtCode characterArtCodeD = CharacterArtCode.�й�;
    public CharacterArtCode RoitCharacterArtCode => Area == 'A' ? characterArtCodeA : Area == 'B' ? characterArtCodeB : Area == 'C' ? characterArtCodeC : characterArtCodeD;
    public RoitInGameAI RoitAITemp;
    public RoitSpawnRange spawnRange;
    public override void AwakeAction()
    {
        characterType = CharacterType.Roit;
        hireStage = HireStage.InCity;
    }
    public override void StartAction()
    {
    }
    public void Setup(RoitSpawnRange spawnRange)
    {
        this.Area = spawnRange.Area;
        this.spawnRange = spawnRange;
        characterArtCode = RoitCharacterArtCode;
        SpawnTagOnStart(RoitManager.Instance.Difficulty);
        string inGameAiString = "";
        switch (Area)
        {
            case 'A':
                inGameAiString = "�ְ�";
                break;
            case 'B':
                inGameAiString = "ǿ��";
                break;
            case 'C':
                inGameAiString = "������";
                break;
            case 'D':
                inGameAiString = "����";
                break;
        }
        var cloneTarget = Resources.Load<RoitInGameAI>($"InGameNPC/RoitCharacter/{inGameAiString}");
        RoitInGameAI inGameAi = Instantiate(cloneTarget, spawnRange.transform);
        InGameAI = inGameAi;
        characterCard = Resources.Load<Character>("CharacterPrefab/Character").characterCard;
        inGameAi.SetupRoitAI(this, this.spawnRange);
        CharacterName = "����";
    }
    protected override void SpawnTagOnStart(Rarerity rarerity = Rarerity.Null)
    {
        int level = 0;
        switch (rarerity)
        {
            case Rarerity.N:
                level = 1;
                break;
            case Rarerity.R:
                level = 2;
                break;
            case Rarerity.SR:
                level = 3;
                break;
            case Rarerity.SSR:
                level = 4;
                break;
            case Rarerity.UR:
                level = 5;
                break;
            default:
                break;

        }
        for (int i = 0; i < level; i++)
        {
            tagList.Add(RoitTags[Random.Range(0, RoitTags.Count)]);
        }
        for (int i = 0; i < (5 - level); i++)
        {
            tagList.Add(badTags[Random.Range(0, badTags.Count)]);
        }
    }
}
