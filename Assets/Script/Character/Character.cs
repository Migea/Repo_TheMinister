using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public enum Tag
{
    Null,
    ���޼�����,
    �����·�,
    ����,
    ����˫ȫ,
    �ɵ�,
    ��������,
    �������,
    ��Ѫ����,
    ½������,
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
    �ٲ�����,
    ����,
    �׵編��,
    �ʼ�Ѫͳ,
    ����,
    ��������,
    ʫ�˴�,
    �������,
    봽�սʿ,
    ���س�ի,
    ʢʳ����,
    ��������,
    ���ֵ���,
    �������,
    ���˾���,
    ��������,
    ����,
    ����,
    ����֮־,
    ��������,
    ��������,
    ��Ǯ��,
    ����,
    Ѫ����,
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
    �����鷢,
    ��������,
    һ�㺮â,
    �����,
    ���վ�տ,
    ��������,
    �߻���ħ,
    �ز�,
    ���,
    ���˵�ͷ,
    ˿��,
    ����,
    Ƥ��,
    ����,
    ��а����,
    ��ⱦ��,
    ��������,
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
    ��֫,
    ����֮��,
    ��ζ�ӳ�,
    �þ�֮��,
    ����,
    ����,
    𯹤�ϲ�,
    ��̬����,
    �����Ӱ�,
    ë����ʢ,
    ҩ��,
    �²�����,
    ���˴���,
    Ǳ����ҫ,
    ���ʺ���,
    ƽ������,
    ����,
    ��Բ����,
    ������,
    ��ʦ,
    ��ȭ,
    ����֮��,
    �Ļ�ɳĮ,
    �书С��,

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
    ��Ԭİ,
    Ůʫ��,
    �е���,
    ����,
    ������,
    //�в���,
    //��Ƥ��,
    //�и�,
    �й�,
    ����,
    //����,
    //Ů��,
    Ů����,
    ����ʿ,
    ��ʦ,
    ˵����,
    ��ʥ,
    ����,
    ��Ա,
    ʰ����,
    ̫��,
    ��Ů,
    ����,
    �Ͻ�Ů
}
public enum CharacterType
{
    General,
    Main,
    Roit
}
public enum HireStage
{
    Never,
    InCity,
    Hired,
    NotInMap,
    Defeated,
    Committed,
    Away,
    Quest
}
public class Character : MonoBehaviour, IRound
{
    #region ID
    [Header("Character Infomation")]
    public int ID;
    public string CharacterName;
    #endregion

    #region Max
    private int loyaltyMax = 20;
    private int healthMax = 20;
    [SerializeField] private int tagMax = 5;

    [SerializeField] private List<int> TagSpawnRareRate = new List<int>(5) { 600, 460, 330, 10, 1, 0 };
    #endregion

    #region Variable
    public CharacterType characterType = CharacterType.General;
    public CharacterArtCode characterArtCode;
    public int loyalty = 20;
    public int health = 20;
    public Rarerity rarerity = Rarerity.Null;
    public CharacterUI characterCard;
    public CharacterUI thisCharacterCard;
    public Transform characterCardInvUI;
    public DefaultInGameAI InGameAI;
    public bool Deserializing = false;

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

    public static List<CharacterArtCode> FemaleCharacters = new List<CharacterArtCode>()
    {
        {CharacterArtCode.Ů����},
        {CharacterArtCode.Ůʫ��}
    };
    public static List<CharacterArtCode> MaleCharacters = new List<CharacterArtCode>()
    {
        {CharacterArtCode.�е���},
        {CharacterArtCode.����},
        {CharacterArtCode.������},
        {CharacterArtCode.����ʿ },
        {CharacterArtCode.�й� },
        {CharacterArtCode.���� },
        {CharacterArtCode.��ʦ },
        {CharacterArtCode.˵���� },
        {CharacterArtCode.��ʥ },
        {CharacterArtCode.���� },
        {CharacterArtCode.��Ա },
        {CharacterArtCode.ʰ���� }
    };
    #endregion

    #region View
    public HireStage hireStage = HireStage.NotInMap;
    public bool OnCombatDuty = false;
    public bool OnDebateDuty = false;
    public bool OnGobangDuty = false;

    public Dictionary<OndutyType, bool> OnDutyState
        = new Dictionary<OndutyType, bool>()
        {
            { OndutyType.Combat, false },
            { OndutyType.Debate, false },
            { OndutyType.Gobang, false }
        };
    #endregion
    #region wealth
    public int Money = 250;
    public int Influence = 200;
    public int Prestige = 200;
    #endregion
    #region away data
    public CharacterAwaitTribute characterAwaitTribute = null;
    public int waitTime => characterAwaitTribute != null ? characterAwaitTribute.WaitTime : 0;
    public int alreadyWait => characterAwaitTribute != null ? characterAwaitTribute.AlreadyWait : 0;
    public SpawnAfterAwayGuest spawnAfterAway = null;
    #endregion
    private void Awake()
    {
        if (Deserializing) return;
        AwakeAction();
    }
    public virtual void AwakeAction()
    {
        if (characterType == CharacterType.General)
        {
            CharacterArtCode[] cacList = (CharacterArtCode[])Enum.GetValues(typeof(CharacterArtCode));
            cacList = cacList.Where(x => x != CharacterArtCode.��Ԭİ && x != CharacterArtCode.�е���).ToArray();
            if (characterArtCode == CharacterArtCode.��Ԭİ && characterType != CharacterType.Main)
                characterArtCode = cacList[UnityEngine.Random.Range(0, cacList.Length)];

            if (hireStage == HireStage.InCity)
            {

            }
            else if (tagList.Count == 0)
            {
                SpawnTagOnStart(rarerity);
            }
            if (hireStage != HireStage.Hired)
            {
                OnDutyState[OndutyType.Combat] = false;
                OnDutyState[OndutyType.Debate] = false;
                OnDutyState[OndutyType.Gobang] = false;
            }
            else
            {
                OnDutyState[OndutyType.Combat] = OnCombatDuty;
                OnDutyState[OndutyType.Debate] = OnDebateDuty;
                OnDutyState[OndutyType.Gobang] = OnGobangDuty;
            }
            UpdateVariables();
        }
    }

    private void Start()
    {
        if (Deserializing) return;
        StartAction();
    }
    public virtual void StartAction()
    {
        if (characterType == CharacterType.General)
        {
            if (hireStage == HireStage.InCity)
            {
                SpawnInGameAI();
                var rareList = new List<Rarerity>() { Rarerity.N, Rarerity.N, Rarerity.N, Rarerity.N, Rarerity.N, Rarerity.R, Rarerity.R, Rarerity.R, Rarerity.SR, Rarerity.SR };
                rarerity = rareList[UnityEngine.Random.Range(0, rareList.Count)];
                tagList = new List<Tag>();
                SpawnTagOnStart(rarerity);
                UpdateVariables();
            }
        }
        if (CharacterName == string.Empty)
        {
            CharacterName = RandomCharacterNameSpawner.SpawnCharacterName(characterArtCode);
        }
    }
    public DefaultInGameAI SpawnInGameAI()
    {
        string path = $"InGameNPC/InGameNPC/{characterArtCode.ToString()}";
        DefaultInGameAI prefab = null;
        prefab = Resources.Load<DefaultInGameAI>(path);
        if (prefab == null)
        {
            Debug.Log(path);
        }
        InGameAI = Instantiate(prefab, transform);
        InGameAI.Setup(this);
        return InGameAI;
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

    public CharacterUI BelongCheck()
    {
        if (hireStage == HireStage.Hired || hireStage == HireStage.Away)
        {
            transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
            return CreatInventoryCardUI();
        }
        else if (hireStage != HireStage.Away)
        {
            Destroy(gameObject);
        }
        return null;
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
            if (key == CharacterValueType.��) continue;
            characterValueRareDict[key] = CheckVariablesRare(CharactersValueDict[key]);
            //Debug.Log(key.ToString() + characterValueRareDict[key].ToString());
        }
    }

    public static Rarerity CheckVariablesRare(int input)
    {
        if (input >= (int)Rarerity.UR) return Rarerity.UR;
        else if (input >= (int)Rarerity.SSR) return Rarerity.SSR;
        else if (input >= (int)Rarerity.SR) return Rarerity.SR;
        else if (input >= (int)Rarerity.R) return Rarerity.R;
        else if (input >= (int)Rarerity.N) return Rarerity.N;
        else return Rarerity.Null;
    }
    public Rarerity CheckTopRare()
    {
        Rarerity output = Rarerity.N;
        foreach (CharacterValueType key in Enum.GetValues(typeof(CharacterValueType)))
        {
            if (key == CharacterValueType.��) continue;
            if (characterValueRareDict[key] > output)
                output = characterValueRareDict[key];
        }
        return output;
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

    protected virtual void SpawnTagOnStart(Rarerity rarerity = Rarerity.Null)
    {
        int maxTag = 5;
        if (rarerity == Rarerity.Null)
        {
            this.rarerity = Rarerity.N;
            for (int i = 0; i < maxTag; i++)
            {
                tagList.Add(RandomTag());
            }
            return;
        }
        else
        {
            int randomBad = UnityEngine.Random.Range(0, 2);
            tagList.Add(RandomTag(rarerity));
            for (int i = 0; i < maxTag - (1 + randomBad); i++)
            {
                tagList.Add(RandomTag(Rarerity.N));
            }
            for (int i = 0; i < randomBad; i++)
            {
                tagList.Add(RandomTag(Rarerity.B));
            }
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

    public void ExchangeTag(Tag newTag, Tag oldTag)
    {
        tagList.Remove(oldTag);
        tagList.Add(newTag);
        StartCoroutine(TryMergeTags());
    }
    protected virtual Tag RandomTag()
    {
        Rarerity rare = RandomRare();
        if (rare > rarerity)
        {
            rarerity = rare;
        }
        Dictionary<Rarerity, List<Tag>> dict = Player.CharacterFinalTagPool[characterArtCode];
        dict.TryGetValue(rare, out List<Tag> targetList);
        int targetValue = UnityEngine.Random.Range(0, targetList.Count - 1);
        return targetList[targetValue];
    }

    protected Tag RandomTag(Rarerity rare)
    {
        List<Tag> targetList = Player.GivenableTagRareDict[rare];
        if (targetList.Count == 0)
        {
            Debug.Log("No tag in this rarerity");
            return Tag.Null;
        }
        int targetValue = UnityEngine.Random.Range(0, targetList.Count - 1);
        return targetList[targetValue];
    }

    protected Rarerity RandomRare()
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

    public CharacterUI CreatInventoryCardUI()
    {
        thisCharacterCard = Instantiate(characterCard, characterCardInvUI);
        thisCharacterCard.character = this;
        thisCharacterCard.Setup();
        return thisCharacterCard;
    }
    public void RoundPass()
    {
        ReturnRounds -= 1;
        if (ReturnRounds <= 0)
        {
            ReturnToHand();
            if (health <= 0) TryDeath();
            else if (loyalty <= 0) TryDeath();
        }
    }
    public void Away(int rounds, SpawnAfterAwayGuest spawnAfterAway = null)
    {
        hireStage = HireStage.Away;
        OnDutyState[OndutyType.Combat] = false;
        OnDutyState[OndutyType.Debate] = false;
        OnDutyState[OndutyType.Gobang] = false;
        var e = new UnityEvent();
        e.AddListener(() => Back());
        if (spawnAfterAway != null)
        {
            this.spawnAfterAway = spawnAfterAway;
            e.AddListener(() => Instantiate(spawnAfterAway.gameObject));
        }
        characterAwaitTribute = CharacterAwaitTributeManager.Instance.AddTribute(this, rounds * 3, e);
    }
    public void Back()
    {
        hireStage = HireStage.Hired;
        CurrencyInvAnimationManager.Instance.PrestigeChange(1);
    }
    public IEnumerator AwayCoroutine(int rounds, GameObject spawnAfterAway = null)
    {
        hireStage = HireStage.Away;
        OnCombatDuty = false;
        OnDebateDuty = false;
        OnGobangDuty = false;
        var map = FindObjectOfType<Map>();
        int targetTime = map.DayTime;
        int targetDay = map.Day + rounds;
        CurrencyInvAnimationManager.Instance.PrestigeChange(-1);
        yield return new WaitUntil(() => (map.Day == targetDay) && (map.DayTime == targetTime));
        hireStage = HireStage.Hired;
        TryRetire();
        yield return new WaitForFixedUpdate();
        if (hireStage == HireStage.Hired) TryDeath();
        if (hireStage == HireStage.Hired) CurrencyInvAnimationManager.Instance.PrestigeChange(1);
        if (spawnAfterAway != null) Instantiate(spawnAfterAway);
    }

    public void ReturnToHand()
    {
        CreatInventoryCardUI();
    }

    public void Destroy()
    {
        FindObjectOfType<CharacterSpawnPool>().RotateCharacters(characterArtCode);
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
    public IEnumerator TryLeavePlayer()
    {
        yield return StartCoroutine(TryRetire());
        if (hireStage == HireStage.Hired)
            StartCoroutine(TryDeath());
    }

    public IEnumerator TryRetire()
    {
        if (loyalty <= 0)
        {
            hireStage = HireStage.NotInMap;
            transform.parent = GameObject.FindGameObjectWithTag("InGameCharacterInventory").transform;
            LostCharacterAlertManager.CallRetireAlert(this);
        }
        yield return null;
    }
    public IEnumerator TryDeath()
    {
        if (health <= 0)
        {
            hireStage = HireStage.NotInMap;
            transform.parent = GameObject.FindGameObjectWithTag("InGameCharacterInventory").transform;
            LostCharacterAlertManager.CallDeathAlert(this);
        }
        yield return null;
    }
    public IEnumerator TryMergeTags(bool Changed = true)
    {
        bool firstTimeChange = true;
        foreach (var suspect in Player.MergeTagDict)
        {
            var suspectList = suspect.Value.ToList();
            List<Tag> CurrentList = suspectList;
            foreach (var item in tagList)
            {
                if (CurrentList.Contains(item))
                {
                    CurrentList.Remove(item);
                }
            }
            if (CurrentList.Count != 0)
            {
                continue;
            }
            tagList.Add(suspect.Key);
            for (int i = 0; i < Player.MergeTagDict[suspect.Key].Count; i++)
            {
                tagList.Remove(Player.MergeTagDict[suspect.Key].ToList()[i]);
            }
            var OSA = FindObjectOfType<OnSwitchAssets>();
            if (OSA != null)
            {
                OSA.MergTag = suspect.Key;
                var UIspec = FindObjectsOfType<UISpecForSwitch>();
                var removeList = suspect.Value.ToList();
                foreach (var tagExchangeUI in UIspec)
                {
                    if (tagExchangeUI.gameObject == OSA.OnChange)
                    {
                        if (!Changed)
                        {
                            tagExchangeUI.FlipZero(suspect.Key);
                        }
                        removeList.Remove(tagExchangeUI.originTag);
                        firstTimeChange = false;
                        continue;
                    }
                    if (removeList.Contains(tagExchangeUI.originTag))
                    {
                        tagList.Add(Tag.���˴���);
                        removeList.Remove(tagExchangeUI.originTag);
                        tagExchangeUI.FlipZero(Tag.���˴���);
                    }
                }
                UpdateVariables();
                CharacterInfoUI characterInfoUI = FindObjectOfType<CharacterInfoUI>();
                characterInfoUI.SetValues(charactersValueDict);
                yield return new WaitForSeconds(FindObjectOfType<UISpecForSwitch>().duration * 2);
            }
            break;
        }
        //Debug.Log($"tryAgain:{firstTimeChange}");
        if (firstTimeChange == false) StartCoroutine(TryMergeTags(false));
    }

    public void FightHealthModify(int damage)
    {
        if (damage <= 0) damage = 0;
        health -= damage;
        if (health <= 0)
        {

        }
    }
    public void NotifyReturn()
    {
        AudioManager.Play("��ɫ�ع�");
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        message.text = $"{CharacterName}  ������";
        return;
    }


}
