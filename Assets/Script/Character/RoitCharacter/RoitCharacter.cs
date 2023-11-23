using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoitCharacter : Character
{
    public static List<Tag> RoitTagsA = new List<Tag>() {
                                                        Tag.�����ͽ,
                                                        Tag.�����ͽ,
                                                        Tag.�����ͽ,
                                                        Tag.��Ѫ����,
                                                        Tag.���,
                                                        Tag.���,
                                                        Tag.���,
                                                        Tag.���,
                                                        Tag.���,
                                                        Tag.���,
                                                        Tag.ϰ��֮��,
                                                        Tag.ϰ��֮��,
                                                        Tag.ϰ��֮��,
                                                        Tag.ϰ��֮��,
                                                        Tag.ϰ��֮��,
                                                        Tag.ϰ��֮��,
                                                        Tag.���վ�տ,
                                                        Tag.���վ�տ,
                                                        Tag.���վ�տ,
                                                        Tag.������ı,
                                                        Tag.������ı,
                                                        Tag.������ı,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.Ƥ��,
                                                         Tag.Ƥ��,
                                                         Tag.Ƥ��,
                                                         Tag.Ƥ��,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.�书С��,
                                                         Tag.�书С��,
                                                         Tag.�书С��,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.��ħ��,
                                                         Tag.�������,
                                                         Tag.�������,
                                                         Tag.��������,
                                                         Tag.��������,
                                                         Tag.��û�޳�,
                                                         Tag.�ĺ�����,
                                                         Tag.����ħ��};

    public static List<Tag> badTagsA = new List<Tag>() { Tag.ƽƽ����,
                                                        Tag.ƽƽ����,
                                                        Tag.�廨��ͷ,
                                                        Tag.�廨��ͷ,
                                                        Tag.�廨��ͷ,
                                                        Tag.�İ�,
                                                        Tag.�İ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.����֮��,
                                                        Tag.����֮��,
                                                        Tag.����֮��,
                                                        Tag.ë����ʢ,
                                                        Tag.ë����ʢ,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.�廨��ͷ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.Ӫ������,
                                                        Tag.Ӫ������,
                                                        Tag.Ӫ������,
                                                        Tag.ҹ������,
                                                        Tag.ҹ������,
                                                        Tag.����,
                                                        Tag.С�����,
                                                        Tag.�ô����,
                                                        Tag.�ô����};
    public static List<Tag> RoitTagsB = new List<Tag>() {  Tag.�,
                                                        Tag.��,
                                                        Tag.ǹ,
                                                        Tag.��,
                                                        Tag.��,
                                                        Tag.�,
                                                        Tag.��,
                                                        Tag.ǹ,
                                                        Tag.��,
                                                        Tag.��,
                                                        Tag.�,
                                                        Tag.��,
                                                        Tag.ǹ,
                                                        Tag.��,
                                                        Tag.��,
                                                        Tag.�,
                                                        Tag.��,
                                                        Tag.ǹ,
                                                        Tag.��,
                                                        Tag.��,
                                                        Tag.�,
                                                        Tag.��,
                                                        Tag.ǹ,
                                                        Tag.��,
                                                        Tag.��,
                                                        Tag.�����ͽ,
                                                        Tag.�����ͽ,
                                                        Tag.�����ͽ,
                                                        Tag.��Ѫ����,
                                                        Tag.���վ�տ,
                                                        Tag.���վ�տ,
                                                        Tag.���վ�տ,
                                                        Tag.�����鷢,
                                                        Tag.һ�㺮â,
                                                        Tag.���νý�,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.��û�޳�,
                                                        Tag.�ĺ�����,
                                                        Tag.���侫ͨ,
                                                         };

    public static List<Tag> badTagsB = new List<Tag>() {
                                                        Tag.ƽƽ����,
                                                        Tag.ƽƽ����,
                                                        Tag.�廨��ͷ,
                                                        Tag.�廨��ͷ,
                                                        Tag.�廨��ͷ,
                                                        Tag.�İ�,
                                                        Tag.�İ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.����֮��,
                                                        Tag.����֮��,
                                                        Tag.����֮��,
                                                        Tag.ë����ʢ,
                                                        Tag.ë����ʢ,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.�廨��ͷ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.Ӫ������,
                                                        Tag.Ӫ������,
                                                        Tag.Ӫ������,
                                                        Tag.ҹ������,
                                                        Tag.ҹ������,
                                                        Tag.����,
                                                        Tag.С�����,
                                                        Tag.�ô����,
                                                        Tag.�ô����};

    public static List<Tag> RoitTagsC = new List<Tag>() { Tag.��ë��,
                                                        Tag.��ë��,
                                                        Tag.��ë��,
                                                        Tag.������,
                                                        Tag.������,
                                                        Tag.������,
                                                        Tag.������,
                                                        Tag.����,
                                                        Tag.����,
                                                        Tag.����,
                                                        Tag.�����,
                                                        Tag.��ζ�ӳ�,
                                                        Tag.��ζ�ӳ�,
                                                        Tag.��ζ�ӳ�,
                                                        Tag.�þ�֮��,
                                                        Tag.ѱ����,
                                                        Tag.ѱ����,
                                                        Tag.ѱ����,
                                                        Tag.ѱ�޴�ʦ,
                                                        Tag.�����ͽ,
                                                        Tag.�����ͽ,
                                                        Tag.�����ͽ,
                                                        Tag.��Ѫ����,
                                                        Tag.������ʦ,
                                                        Tag.������ʦ,
                                                        Tag.���,
                                                        Tag.���,
                                                        Tag.ϰ��֮��,
                                                        Tag.ϰ��֮��,
                                                        Tag.���վ�տ,
                                                        Tag.������ı,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.Ƥ��,
                                                         Tag.Ƥ��,
                                                         Tag.Ƥ��,
                                                         Tag.Ƥ��,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.�书С��,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.��ħ��,
                                                         Tag.�������,
                                                         Tag.�������,
                                                         Tag.��������,
                                                         Tag.��������,
                                                         Tag.��û�޳�,
                                                         Tag.�ĺ�����,
                                                         Tag.����};

    public static List<Tag> badTagsC = new List<Tag>() {Tag.ƽƽ����,
                                                        Tag.ƽƽ����,
                                                        Tag.�廨��ͷ,
                                                        Tag.�廨��ͷ,
                                                        Tag.�廨��ͷ,
                                                        Tag.�İ�,
                                                        Tag.�İ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.����֮��,
                                                        Tag.����֮��,
                                                        Tag.����֮��,
                                                        Tag.ë����ʢ,
                                                        Tag.ë����ʢ,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.�廨��ͷ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.Ӫ������,
                                                        Tag.Ӫ������,
                                                        Tag.Ӫ������,
                                                        Tag.ҹ������,
                                                        Tag.ҹ������,
                                                        Tag.����,
                                                        Tag.С�����,
                                                        Tag.�ô����,
                                                        Tag.�ô����,
                                                        Tag.��������,
                                                        Tag.��������};

    public static List<Tag> RoitTagsD = new List<Tag>() {
                                                        Tag.��ͯ,
                                                        Tag.��ͯ,
                                                        Tag.��ͯ,
                                                        Tag.��ͯ,
                                                        Tag.ҽ��,
                                                        Tag.ҽ��,
                                                        Tag.ҽ��,
                                                        Tag.����,
                                                        Tag.���ֵ���,
                                                        Tag.��,
                                                        Tag.��,
                                                        Tag.��,
                                                        Tag.�����ͽ,
                                                        Tag.�����ͽ,
                                                        Tag.�����ͽ,
                                                        Tag.��Ѫ����,
                                                        Tag.���,
                                                        Tag.���,
                                                        Tag.ϰ��֮��,
                                                        Tag.ϰ��֮��,
                                                        Tag.���վ�տ,
                                                        Tag.������ı,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.����,
                                                         Tag.Ƥ��,
                                                         Tag.Ƥ��,
                                                         Tag.����,
                                                         Tag.�书С��,
                                                         Tag.�书С��,
                                                         Tag.�书С��,
                                                         Tag.�Ļ�ɳĮ,
                                                         Tag.���վ�տ,
                                                         Tag.��ħ��,
                                                         Tag.�������,
                                                         Tag.�������,
                                                         Tag.��������,
                                                         Tag.��������,
                                                         Tag.��û�޳�,
                                                         Tag.�ĺ�����,
                                                         Tag.����,
                                                         Tag.����˫ȫ};

    public static List<Tag> badTagsD = new List<Tag>() { Tag.ƽƽ����,
                                                        Tag.ƽƽ����,
                                                        Tag.�廨��ͷ,
                                                        Tag.�廨��ͷ,
                                                        Tag.�廨��ͷ,
                                                        Tag.�İ�,
                                                        Tag.�İ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.�����Ӱ�,
                                                        Tag.����֮��,
                                                        Tag.����֮��,
                                                        Tag.����֮��,
                                                        Tag.ë����ʢ,
                                                        Tag.ë����ʢ,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.��������,
                                                        Tag.�廨��ͷ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.ϥ�ǽ�Ӳ,
                                                        Tag.Ӫ������,
                                                        Tag.Ӫ������,
                                                        Tag.Ӫ������,
                                                        Tag.ҹ������,
                                                        Tag.ҹ������,
                                                        Tag.����,
                                                        Tag.С�����,
                                                        Tag.�ô����,
                                                        Tag.�ô����,
                                                        Tag.��������,
                                                        Tag.��������};
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
        StartCoroutine(RemoveFromGame());
    }
    public void Setup(RoitSpawnRange spawnRange)
    {
        this.Area = spawnRange.Area;
        this.spawnRange = spawnRange;
        characterArtCode = RoitCharacterArtCode;
        SpawnTagOnStart(RoitManager.Instance.Difficulty);
        rarerity = RoitManager.Instance.Difficulty;
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
                inGameAiString = "���";
                break;
        }
        var cloneTarget = Resources.Load<RoitInGameAI>($"InGameNPC/RoitCharacter/{inGameAiString}");
        RoitInGameAI inGameAi = Instantiate(cloneTarget, spawnRange.transform);
        InGameAI = inGameAi;
        characterCard = Resources.Load<Character>("CharacterPrefab/Character").characterCard;
        inGameAi.SetupRoitAI(this, this.spawnRange);
        CharacterName = "����";
    }
    protected IEnumerator RemoveFromGame()
    {
        Func<bool> defeated = () => hireStage == HireStage.Defeated;
        yield return new WaitUntil(defeated);
        int day = Map.Instance.Day;
        Func<bool> after2Days = () => (Map.Instance.Day - day >= 2);
        yield return new WaitUntil(after2Days);
        if (hireStage != HireStage.Hired)
        {
            Destroy(InGameAI.gameObject.gameObject);
            Destroy(gameObject);
        }
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
            tagList.Add(RoitTags[UnityEngine.Random.Range(0, RoitTags.Count)]);
        }
        for (int i = 0; i < (5 - level); i++)
        {
            tagList.Add(badTags[UnityEngine.Random.Range(0, badTags.Count)]);
        }
        UpdateVariables();
    }
}
