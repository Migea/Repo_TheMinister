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
    ����,
    ����,
    ����,
    ��ʤ,
    ����,
    ��֮��,
    ����ѹ��,
    ��������,
    �������,
    ����,
    ������,
    ӥ֮��,
    �������,
    �ٶ�����,
    ���ӿ��,
    ��������,
    ��֮��,
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
    �ô����,
    ���ܿ�ŭ,
    ͷ��,
    ������,
    �İ�,
    ������,
    ��Ƥ��,
    �������,
    ��Ż,
    ��������,
    ����֢,
    ������,
    ��֫
}
public enum Rarerity
{
    Null = 0, 
    VB = -4, 
    B = -2, 
    N = 2, 
    R = 4, 
    SR = 6, 
    SSR = 8, 
    UR = 10
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

    [SerializeField] private List<int> TagSpawnRareRate = new List<int>(5) {600, 460, 330, 10, 1, 0 };
    #endregion

    #region Variable
    public CharacterArtCode characterArtCode;
    public int loyalty = 10;
    public int health = 10;

    public CharacterUI characterCard;
    private CharacterUI thisCharacterCard;
    public Transform characterCardInvUI;



    public Dictionary<CharacterValueType, int> CharactersValueDict => charactersValueDict;

    private Dictionary<CharacterValueType, int> charactersValueDict =
        new Dictionary<CharacterValueType, int>
        {
            {CharacterValueType.��, 0 },
            {CharacterValueType.��, 0 },
            {CharacterValueType.ı, 0 },
            {CharacterValueType.��, 0 },
            {CharacterValueType.��, 0 },
            {CharacterValueType.��, 0 },
        };
    public Dictionary<CharacterValueType, Rarerity> characterValueRareDict =
        new Dictionary<CharacterValueType, Rarerity>
        {
            {CharacterValueType.��, Rarerity.Null },
            {CharacterValueType.��, Rarerity.Null },
            {CharacterValueType.ı, Rarerity.Null },
            {CharacterValueType.��, Rarerity.Null },
            {CharacterValueType.��, Rarerity.Null },
            {CharacterValueType.��, Rarerity.Null },
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
            List<int> varlist = Player.TagInfDict[tag];
            CharactersValueDict[CharacterValueType.��] += varlist[0];
            CharactersValueDict[CharacterValueType.��] += varlist[1];
            CharactersValueDict[CharacterValueType.ı] += varlist[2];
            CharactersValueDict[CharacterValueType.��] += varlist[3];
            CharactersValueDict[CharacterValueType.��] += varlist[4];
            CharactersValueDict[CharacterValueType.��] += varlist[5];
        }

        foreach (CharacterValueType key in Enum.GetValues(typeof(CharacterValueType)))
        {
            
            characterValueRareDict[key] = CheckVariablesRare(CharactersValueDict[key]);
            //Debug.Log(key.ToString() + characterValueRareDict[key].ToString());
        }
    }

    private Rarerity CheckVariablesRare(int input)
    {
        if (input >= (int)Rarerity.UR) return Rarerity.UR;
        else if (input >= (int)Rarerity.SSR) return Rarerity.SSR;
        else if (input >= (int)Rarerity.SR) return Rarerity.SR;
        else if (input >= (int)Rarerity.R) return Rarerity.R;
        else if (input >= (int)Rarerity.N) return Rarerity.N;
        else return Rarerity.Null;
    }

    private void ResetVariables()
    {
        CharactersValueDict[CharacterValueType.��] = 0;
        CharactersValueDict[CharacterValueType.��] = 0;
        CharactersValueDict[CharacterValueType.ı] = 0;
        CharactersValueDict[CharacterValueType.��] = 0;
        CharactersValueDict[CharacterValueType.��] = 0;
        CharactersValueDict[CharacterValueType.��] = 0;
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
        Rarerity rare = RandomRare();
        Dictionary<Rarerity, List<Tag>> dict = Player.CharacterFinalTagPool[characterArtCode];
        dict.TryGetValue(rare, out List<Tag> targetList);
        int targetValue = UnityEngine.Random.Range(0, targetList.Count - 1);
        return targetList[targetValue];
    }

    private Tag RandomTag(Rarerity rare)
    {
        List<Tag> targetList = Player.GivenableTagRareDict[rare];
        int targetValue = UnityEngine.Random.Range(0, targetList.Count - 1);
        return targetList[targetValue];
    }

    private Rarerity RandomRare()
    {
        int max = 
            TagSpawnRareRate[0] 
            + TagSpawnRareRate[1] 
            + TagSpawnRareRate[2] 
            + TagSpawnRareRate[3] 
            + TagSpawnRareRate[4];

        int rare = UnityEngine.Random.Range(1, max);
        if (rare < TagSpawnRareRate[0])
        {
            return Rarerity.B;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1]))
        {
            return Rarerity.N;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2]))
        {
            return Rarerity.R;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2] + TagSpawnRareRate[3]))
        {
            return Rarerity.SR;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2] + TagSpawnRareRate[3] + TagSpawnRareRate[4]))
        {
            return Rarerity.SSR;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2] + TagSpawnRareRate[3] + TagSpawnRareRate[4] + TagSpawnRareRate[5]))
        {
            return Rarerity.UR;
        }
        else return Rarerity.Null;
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
