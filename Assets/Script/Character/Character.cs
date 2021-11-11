using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.Linq;
public enum Tag
{
    Null,
    ����ʱ������,
    �����·�,
    ����,
    ����˫ȫ,
    �ɵ�,
    ��Ȼ������,
    Χ��ʮ��,
    ״Ԫ,
    ʫ��,
    ����,
    �˶�֮��,
    ��ʥ,
    ��Ӱ,
    ��ʯ,
    ���侫ͨ,
    ֽ��̸��,
    ͽ������,
    Ͷ��ȡ��,
    ����ħ��,
    �ĺ�����,
    ī�سɹ�,
    �ɶ��칤,
    ��������,
    ī��,
    ��,
    ��,
    ��ͨ����,
    �Ż�����,
    �����ļ�,
    ����ɽ��,
    ��û�޳�,
    ����֮��,
    ����˫ȫ,
    ��ʦ,
    ���Ŷݼ�,
    ��������,
    ����ѧ��,
    ���Ǵ�,
    ��������,
    ����ʿ,
    �⽻��,
    �ϵ���׳,
    ������ʦ,
    ��ս��ͨ,
    ����ת��,
    ��ƴ�ʦ,
    �ݺ��,
    ��,
    Ϸ��,
    �Ƶ��ھ�,
    ���ݸ�Ŀ,
    �����,
    ѱ�޴�ʦ,
    ����,
    ����,
    ����,
    ���,
    ���в���,
    С��ı��,
    ���,
    ���νý�,
    �����,
    �����ͽ,
    ��󡹦,
    ��ϲ��,
    ��ħ��,
    ͨ������,
    ��˪����,
    ��ë��,
    ����,
    ������,
    �ܸ�����,
    ������,
    ��ʦ,
    �뾭�ѵ�,
    ������,
    ����,
    ���,
    ����,
    ����ѧ,
    С��,
    ����,
    ��Ϸ��,
    ѱ����,
    ����˾,
    ����,
    �氮,
    ����,
    �ǹ�,
    ����,
    ����,
    ������ı,
    ��������,
    �廨��ͷ,
    �����弼,
    ��������,
    ��������,
    ���в���,
    ����֢,
    ٪��֢,
    ����,
    ��ʿ,
    ɮ��,
    ��ʦ,
    ��Ѫ����,
    ����,
    ��Ѫ��,
    ����,
    ϥ�ǽ�Ӳ,
    �ද֢,
    ƽƽ����,
    ��,
    ϰ��֮��,
    ��ͯ,
    ��,
    ��,
    ǹ,
    ̰���ǽ�,
    ��Ա,
    ��������,
    ��,
    �,
    ҽ��,
    ����,
    ���˲���,
    ��Т��,
    �ȽŲ���,
    ������˥,
    ���,
    ��������,
    ����,
    ����,
    ��������,
    Ӫ������,
    ����,
    ҹ������,
    �ɷ���,
    ˫Ŀʧ��,
    ����,
    �մ�,
    ������,
    С�����,
    Ŀ��ʶ��,
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
    InCity,
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
    public HireStage hireStage = HireStage.Never;
    #endregion
    private void Awake()
    {
        SpawnTagOnStart();
        UpdateVariables();
        CharacterArtCode[] cacList = (CharacterArtCode[])Enum.GetValues(typeof(CharacterArtCode));
        characterArtCode = cacList[UnityEngine.Random.Range(0,cacList.Length)];
    }

    private void Start()
    {
        BelongCheck();
    }

    public void ChangeNextHireStage()
    {
        switch (hireStage)
        {
            case HireStage.Never:
                hireStage = HireStage.InCity;
                return;
            case HireStage.InCity:
                hireStage = HireStage.Hired;
                BelongCheck();
                return;
        }
    }

    public void BelongCheck()
    {
        if (hireStage == HireStage.Hired)
        {
            transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
            CreatInventoryCardUI();
        }
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

    private void CreatInventoryCardUI()
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
        CreatInventoryCardUI();
    }

    public void Destroy()
    {
        Destroy(thisCharacterCard);
        Destroy(gameObject);
    }

    public void TryHire()
    {
        int total = loyaltyMax;
        int result = UnityEngine.Random.Range(0, loyaltyMax);
        bool success = result < loyalty;

        if (success)
        {
            hireStage = HireStage.Hired;
        }
    }

    public void TryRetire()
    {
        if (loyalty <= 0)
        {
            hireStage = HireStage.InCity;
            transform.parent = GameObject.FindGameObjectWithTag("InGameCharacterInventory").transform;
        }
    }

    
}
