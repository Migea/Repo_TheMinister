using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public enum Tag
{
    Null,
    ���,
    ���в���,
    С��ı��,
    ���,
    ���νý�,
    �����,
    ����,
    ����,
    �ɷ���,
    ������ı,
    ��������,
    �廨��ͷ,
    �����弼,
    ��������,
    ��������,
    ˫Ŀʧ��,
    ����,
    �մ�,
    ������,
    ���в���,
    ����֢,
    ٪��֢,
    С�����,
    Ŀ��ʶ��,
    ����,
    ��ʿ,
    ɮ��,
    �Ϲ�,
    ��Ѫ����,
    ��󡹦,
    ����,
    ��������,
    Ӫ������,
    ҹ������,
    ����,
    ��Ѫ��,
    ϥ�ǽ�Ӳ,
    ͨ������,
    �ද֢,
    ��Т��,
    ��˪����,
    ����,
    ��������,
    ��ë��,
    ����,
    ����ʿ,
    �ܸ�����,
    ������,
    ƽƽ����,
    ��,
    �ȽŲ���,
    ������˥,
    ϰ��֮��,
    ״Ԫ,
    ʫ��,
    ����,
    ������,
    ��ʥ,
    ��Ӱ,
    ��ʯ,
    ����ʱ������,
    �����·�,
    ��,
    ��,
    ��ͨ����,
    �Ż�����,
    �����ļ�,
    ����ɽ��,
    ����֮��,
    ����˫ȫ,
    ��ʦ,
    ���Ŷݼ�,
    ��������,
    ����ѧ��,
    ���Ǵ�,
    �ɵ�,
    �⽻��,
    �ϵ���׳,
    ��û�޳�,
    �˶�֮��,
    ���侫ͨ,
    ����˫ȫ,
    ֽ��̸��,
    ͽ������,
    Ͷ��ȡ��,
    ����ħ��,
    �ĺ�����,
    �����ͽ,
    ����,
    ��ħ��,
    ��ϲ��,
    ��Ȼ������,
    Χ��ʮ��,
    ����,
    ����
}
public enum Raitity
{
    Null, 
    VB, 
    B, 
    N = 30, 
    R = 50, 
    SR = 70, 
    SSR = 90, 
    UR = 110
}

public enum CharacterArtCode
{
    Ůʫ��,
    �е���,
    ����,
    ������
}

public enum HireStage
{
    Never,
    First,
    Second,
    Third,
    Hired
}
public class Character : MonoBehaviour, IRound
{
    #region ID
    [Header("Character Infomation")]
    public int ID;
    public string CharacterName;
    #endregion

    #region Max
    [SerializeField] private int loyaltyMax = 10;
    [SerializeField] private int healthMax = 10;
    [SerializeField] private int tagMax = 5;

    [SerializeField] private List<int> TagSpawnRareRate = new List<int>(5) { 46, 33, 20, 1, 0 };
    #endregion

    #region Variable
    public CharacterArtCode characterArtCode;
    public int loyalty = 10;
    public int health = 10;

    public CharacterUI characterCard;
    private CharacterUI thisCharacterCard;
    public Transform characterCardInvUI;

    

    [Header("Base Variables")]

    public Dictionary<CharacterValueType, int> characterValueDict =
        new Dictionary<CharacterValueType, int>
        {
            {CharacterValueType.��, 10 },
            {CharacterValueType.��, 10 },
            {CharacterValueType.ı, 10 },
            {CharacterValueType.��, 10 },
            {CharacterValueType.��, 10 },
            {CharacterValueType.��, 10 },
        };
    public Dictionary<CharacterValueType, Raitity> characterValueRareDict =
        new Dictionary<CharacterValueType, Raitity>
        {
            {CharacterValueType.��, Raitity.Null },
            {CharacterValueType.��, Raitity.Null },
            {CharacterValueType.ı, Raitity.Null },
            {CharacterValueType.��, Raitity.Null },
            {CharacterValueType.��, Raitity.Null },
            {CharacterValueType.��, Raitity.Null },
        };

    public List<Tag> tagList = new List<Tag>();

    public int ReturnRounds = 0;


    #endregion

    #region View
    public HireStage hireStage;
    #endregion
    private void Awake()
    {
        SpawnTagOnStart();
        UpdateVariables();
        
    }

    private void Start()
    {
        if (hireStage == HireStage.Hired) CreatUI();

    }

    private bool CheckForAway()
    {
        if (ReturnRounds > 0) return true;
        return false;
    }

    public void UpdateVariables()
    {
        ResetVariables();
        foreach (Tag tag in tagList)
        {
            var varlist = Player.TagInfDict[tag];
            characterValueDict[CharacterValueType.��] += varlist[0];
            characterValueDict[CharacterValueType.��] += varlist[1];
            characterValueDict[CharacterValueType.ı] += varlist[2];
            characterValueDict[CharacterValueType.��] += varlist[3];
            characterValueDict[CharacterValueType.��] += varlist[4];
            characterValueDict[CharacterValueType.��] += varlist[5];
        }

        foreach (CharacterValueType key in Enum.GetValues(typeof(CharacterValueType)))
        {
            characterValueRareDict[key] = CheckVariablesRare(characterValueDict[key]);
            //Debug.Log(key.ToString() + characterValueRareDict[key].ToString());
        }
    }

    private Raitity CheckVariablesRare(int input)
    {
        if (input > (int)Raitity.UR) return Raitity.UR;
        else if (input > (int)Raitity.SSR) return Raitity.SSR;
        else if (input > (int)Raitity.SR) return Raitity.SR;
        else if (input > (int)Raitity.R) return Raitity.R;
        else if (input > (int)Raitity.N) return Raitity.N;
        else return Raitity.Null;
    }

    private void ResetVariables()
    {
        characterValueDict[CharacterValueType.��] = 10;
        characterValueDict[CharacterValueType.��] = 10;
        characterValueDict[CharacterValueType.ı] = 10;
        characterValueDict[CharacterValueType.��] = 10;
        characterValueDict[CharacterValueType.��] = 10;
        characterValueDict[CharacterValueType.��] = 10;
    }

    private void SpawnTagOnStart()
    {
        int tagAmount = UnityEngine.Random.Range(1, 5);
        for (int i = 0; i < 5; i++)
        {
            tagList.Add(RandomTag());
        }
    }

    private void SpawnTag(Tag tag)
    {
        if (tagList.Count >= 5)
        {
            //TODO: Open new UI and choose a exist tag to remove before add new one.
        }
        else tagList.Add(tag);
    }

    private void RemoveTag(Tag tag)
    {
        tagList.Remove(tag);
    }

    private Tag RandomTag()
    {
        Raitity rare = RandomRare();
        var dict = Player.GivenableTagRareDict;
        dict.TryGetValue(rare, out List<Tag> targetList);
        int targetValue = UnityEngine.Random.Range(0, targetList.Count - 1);
        return targetList[targetValue];
    }

    private Tag RandomTag(Raitity rare)
    {
        List<Tag> targetList = Player.GivenableTagRareDict[rare];
        int targetValue = UnityEngine.Random.Range(0, targetList.Count - 1);
        return targetList[targetValue];
    }

    private Raitity RandomRare()
    {
        int rare = UnityEngine.Random.Range(1, 100);
        if (rare < TagSpawnRareRate[0])
        {
            return Raitity.N;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1]))
        {
            return Raitity.R;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2]))
        {
            return Raitity.SR;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2] + TagSpawnRareRate[3]))
        {
            return Raitity.SSR;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2] + TagSpawnRareRate[3] + TagSpawnRareRate[4]))
        {
            return Raitity.UR;
        }
        else return Raitity.Null;
    }

    private void CreatUI()
    {
        thisCharacterCard = Instantiate(characterCard, characterCardInvUI);
        thisCharacterCard.character = this;
        thisCharacterCard.UpdateUI();
    }

    public void RoundPass()
    {
        ReturnRounds -= 1;
        if (ReturnRounds <= 0)
        {
            ReturnToHand();
        }
    }

    public void Away()
    {
        Destroy(thisCharacterCard);
    }

    public void ReturnToHand()
    {
        CreatUI();
    }

    public void Destroy()
    {
        Destroy(thisCharacterCard);
        Destroy(gameObject);
    }


}
