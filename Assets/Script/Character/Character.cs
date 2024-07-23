using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine.Localization;

public enum Tag
{
    Null,
    南无加特林,
    弈星下凡,
    钜子,
    文武双全,
    成道,
    长生不老,
    生死肉骨,
    碧血丹心,
    陆地神仙,
    黯然销魂掌,
    围棋十段,
    状元,
    诗仙,
    卧龙,
    八斗之才,
    武圣,
    无影,
    磐石,
    诸武精通,
    纸上谈兵,
    徒有虚名,
    投机取巧,
    混世魔王,
    心狠手辣,
    墨守成规,
    巧夺天工,
    悬壶济世,
    墨者,
    穿日,
    无声,
    青龙,
    必胜,
    撑天,
    龙之力,
    火力压制,
    醉生梦死,
    金光闪闪,
    光碎,
    龙马精神,
    鹰之力,
    窥得天机,
    百毒不侵,
    嘤嘤狂吠,
    波纹行走,
    象虎之力,
    文,
    武,
    书通二酉,
    才华横溢,
    工于心计,
    力拔山兮,
    出没无常,
    广厦之荫,
    智勇双全,
    偃师,
    奇门遁甲,
    天生神力,
    阳明学派,
    吸星大法,
    巫妖领主,
    龙骑士,
    外交官,
    老当益壮,
    炼金术师,
    近战精通,
    古神转世,
    理财大师,
    纵横家,
    大锤,
    戏精,
    黄帝内经,
    本草纲目,
    御马监,
    驯兽大师,
    朝奉,
    百步穿杨,
    刀王,
    雷电法王,
    皇家血统,
    霸王,
    气功达人,
    诗兴大发,
    如醉如狂,
    氪金战士,
    把素持斋,
    盛食厉兵,
    固若金汤,
    妙手丹心,
    侵略如火,
    仁人君子,
    宝马良驹,
    虎猛,
    独狼,
    忠贞之志,
    景星庆云,
    长袖善舞,
    金钱镖,
    血滴子,
    文正,
    武忠,
    书痴,
    略有才名,
    小有谋略,
    武痴,
    身形矫健,
    老罴当道,
    法外狂徒,
    蛤蟆功,
    欢喜佛,
    恶魔人,
    通晓天文,
    冰霜宝剑,
    飞毛腿,
    火炮,
    东洋语,
    能歌善舞,
    西洋语,
    毒师,
    离经叛道,
    外乡人,
    疯子,
    棋道,
    心算,
    经济学,
    小锤,
    郎中,
    老戏骨,
    驯兽术,
    御马司,
    牧民,
    兼爱,
    货郎,
    非攻,
    箭无虚发,
    根骨清奇,
    一点寒芒,
    买瓜人,
    武艺精湛,
    登堂入室,
    走火入魔,
    素餐,
    荤菜,
    鸿运当头,
    丝绸,
    护心,
    皮甲,
    铁甲,
    辟邪安正,
    珠光宝气,
    家室美满,
    文贞,
    武勇,
    有勇无谋,
    花言巧语,
    绣花枕头,
    梧鼠五技,
    自是三公,
    敝帚自珍,
    不孕不育,
    巨人症,
    侏儒症,
    儒生,
    道士,
    僧人,
    讼师,
    冷血无情,
    阉人,
    吸血鬼,
    狼人,
    膝盖僵硬,
    多动症,
    平平无奇,
    雕,
    习武之人,
    丹童,
    弓,
    剑,
    枪,
    贪污狼藉,
    演员,
    六根不净,
    刀,
    戟,
    医术,
    马倌,
    厄运缠身,
    不孝子,
    腿脚不便,
    年老体衰,
    醉酒,
    身世悲苦,
    精神病,
    近视,
    嗜甜如命,
    营养不良,
    糖尿病,
    夜不能寐,
    干饭人,
    双目失明,
    独臂,
    痴呆,
    身怀六甲,
    小儿麻痹,
    目不识丁,
    得寸进尺,
    无能狂怒,
    头疼,
    半身不遂,
    磕巴,
    惹人嫌,
    调皮鬼,
    天生恶感,
    干呕,
    身体孱弱,
    肥胖症,
    长短腿,
    义肢,
    仙人之躯,
    五味杂陈,
    好酒之人,
    匠人,
    饱腹,
    鸠工庀材,
    体态端正,
    杂七杂八,
    毛发旺盛,
    药毒,
    衣不蔽体,
    无伤大雅,
    潜光隐耀,
    深仁厚泽,
    平步青云,
    主教,
    珠圆玉润,
    故事王,
    琴师,
    醉拳,
    无用之人,
    文化沙漠,
    武功小成,
    袖炮,
    //Temp Type,
    益血,
    固肾,
    提神,
    中毒,
    淬体,
    养神,
    铁王八,
    虎虎生威,
    虎啸龙吟,
    千人千面,
    术数纵横,
    疾如风,
    恶臭,
    臭气熏天,
    机关之躯,
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
    李袁陌,
    女诗人,
    男刀客,
    老者,
    男书生,
    //男布衣,
    //男皮甲,
    //男富,
    男官,
    男武,
    //男老,
    //女武,
    女布衣,
    传教士,
    琴师,
    说书人,
    棋圣,
    方丈,
    官员,
    拾荒者,
    太监,
    舞女,
    花魁,
    南疆女
}
public enum CharacterType
{
    General,
    Main,
    Roit,
    Politic
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
    Quest,
    OnCourt
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
    public int hungry = 10;
    public Rarerity rarerity = Rarerity.Null;
    public CharacterUI characterCard;
    public CharacterUI thisCharacterCard;
    public Transform characterCardInvUI;
    public DefaultInGameAI InGameAI;
    public bool Deserializing = false;
    public EdibleType edibleFavor = EdibleType.荤食;
    public Dictionary<CharacterValueType, int> CharactersValueDict => charactersValueDict;

    private Dictionary<CharacterValueType, int> charactersValueDict =
        new Dictionary<CharacterValueType, int>
        {
            {CharacterValueType.智, 0 },
            {CharacterValueType.才, 0 },
            {CharacterValueType.谋, 0 },
            {CharacterValueType.武, 0 },
            {CharacterValueType.刺, 0 },
            {CharacterValueType.守, 0 },
        };
    public Dictionary<CharacterValueType, Rarerity> characterValueRareDict =
        new Dictionary<CharacterValueType, Rarerity>
        {
            {CharacterValueType.智, Rarerity.Null },
            {CharacterValueType.才, Rarerity.Null },
            {CharacterValueType.谋, Rarerity.Null },
            {CharacterValueType.武, Rarerity.Null },
            {CharacterValueType.刺, Rarerity.Null },
            {CharacterValueType.守, Rarerity.Null },
        };

    public List<Tag> tagList = new List<Tag>();
    public List<TemporaryTag> temporaryTags = new List<TemporaryTag>();

    public int ReturnRounds = 0;

    public static List<CharacterArtCode> FemaleCharacters = new List<CharacterArtCode>()
    {
        {CharacterArtCode.女布衣},
        {CharacterArtCode.女诗人}
    };
    public static List<CharacterArtCode> MaleCharacters = new List<CharacterArtCode>()
    {
        {CharacterArtCode.男刀客},
        {CharacterArtCode.老者},
        {CharacterArtCode.男书生},
        {CharacterArtCode.传教士 },
        {CharacterArtCode.男官 },
        {CharacterArtCode.男武 },
        {CharacterArtCode.琴师 },
        {CharacterArtCode.说书人 },
        {CharacterArtCode.棋圣 },
        {CharacterArtCode.方丈 },
        {CharacterArtCode.官员 },
        {CharacterArtCode.拾荒者 }
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
    #region away data
    public CharacterAwaitTribute characterAwaitTribute = null;
    public int waitTime => characterAwaitTribute != null ? characterAwaitTribute.WaitTime : 0;
    public int alreadyWait => characterAwaitTribute != null ? characterAwaitTribute.AlreadyWait : 0;
    public SpawnAfterAwayGuest spawnAfterAway = null;
    public bool OnAssassinEvent = false;
    public string AssasinTarget = string.Empty;
    public string awayMessage = "";
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
            cacList = cacList.Where(x => x != CharacterArtCode.李袁陌 && x != CharacterArtCode.男刀客).ToArray();
            if (characterArtCode == CharacterArtCode.李袁陌 && characterType != CharacterType.Main)
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
                edibleFavor = EdiblesItems.RandomFavor();
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
    public void ApplyFood(ItemName itemName)
    {
        //ApplyFood();
    }
    public void ApplyFood(int hungryIncrease)
    {
        hungry += hungryIncrease;
        if (hungry > 20) hungry = 20;
        if (hungry < 0) HungryEvent();
    }
    public void HungryEvent()
    {
        hungry -= 1;
        if (hungry < 0)
        {
            hungry = 0;
            ApplyHealth(-1);
            ApplyLoyalty(-2);
        }
        else if (hungry <= 5)
        {
            ApplyLoyalty(-1);
        }
        else if (hungry >= 15)
        {
            ApplyLoyalty(1);
        }
        if (thisCharacterCard != null) thisCharacterCard.Setup();
        FindObjectOfType<CharacterInfoUI>()?.SetHealthAndLoyalty(this);
    }
    public void FollowerLoyaltyEvent()
    {
        if (OnDutyState[OndutyType.Combat] == true) ApplyLoyalty(1);
        if (OnDutyState[OndutyType.Debate] == true) ApplyLoyalty(1);
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
            CharactersValueDict[CharacterValueType.智] += varlist[0];
            CharactersValueDict[CharacterValueType.才] += varlist[1];
            CharactersValueDict[CharacterValueType.谋] += varlist[2];
            CharactersValueDict[CharacterValueType.武] += varlist[3];
            CharactersValueDict[CharacterValueType.刺] += varlist[4];
            CharactersValueDict[CharacterValueType.守] += varlist[5];
        }
        foreach (TemporaryTag tag in temporaryTags)
        {
            List<int> varlist = Player.TagInfDict[tag.tag];
            CharactersValueDict[CharacterValueType.智] += varlist[0];
            CharactersValueDict[CharacterValueType.才] += varlist[1];
            CharactersValueDict[CharacterValueType.谋] += varlist[2];
            CharactersValueDict[CharacterValueType.武] += varlist[3];
            CharactersValueDict[CharacterValueType.刺] += varlist[4];
            CharactersValueDict[CharacterValueType.守] += varlist[5];
        }
        foreach (CharacterValueType key in Enum.GetValues(typeof(CharacterValueType)))
        {
            if (key == CharacterValueType.逃) continue;
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
            if (key == CharacterValueType.逃) continue;
            if (characterValueRareDict[key] > output)
                output = characterValueRareDict[key];
        }
        return output;
    }
    private void ResetVariables()
    {
        CharactersValueDict[CharacterValueType.智] = 0;
        CharactersValueDict[CharacterValueType.才] = 0;
        CharactersValueDict[CharacterValueType.谋] = 0;
        CharactersValueDict[CharacterValueType.武] = 0;
        CharactersValueDict[CharacterValueType.刺] = 0;
        CharactersValueDict[CharacterValueType.守] = 0;
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
    public void Away(int rounds, SpawnAfterAwayGuest spawnAfterAway = null, string questID = "")
    {
        hireStage = HireStage.Away;
        OnDutyState[OndutyType.Combat] = false;
        OnDutyState[OndutyType.Debate] = false;
        OnDutyState[OndutyType.Gobang] = false;
        //var e = new UnityEvent();
        //e.AddListener(() => Back());
        if (spawnAfterAway != null)
        {
            this.spawnAfterAway = spawnAfterAway;
            //e.AddListener(() => Instantiate(spawnAfterAway.gameObject));
        }
        characterAwaitTribute = CharacterAwaitTributeManager.Instance.AddTribute(this, rounds, spawnAfterAway == null, questID);
    }
    public void AwayForAssassin()
    {
        OnAssassinEvent = true;
    }
    public void Back()
    {
        hireStage = HireStage.Hired;
        CurrencyInvAnimationManager.Instance.PrestigeChange(1);
    }
    //public IEnumerator AwayCoroutine(int rounds, GameObject spawnAfterAway = null)
    //{
    //    hireStage = HireStage.Away;
    //    OnCombatDuty = false;
    //    OnDebateDuty = false;
    //    OnGobangDuty = false;
    //    var map = FindObjectOfType<Map>();
    //    int targetTime = map.DayTime;
    //    int targetDay = map.Day + rounds;
    //    CurrencyInvAnimationManager.Instance.PrestigeChange(-1);
    //    yield return new WaitUntil(() => (map.Day == targetDay) && (map.DayTime == targetTime));
    //    hireStage = HireStage.Hired;
    //    TryRetire();
    //    yield return new WaitForFixedUpdate();
    //    if (hireStage == HireStage.Hired) TryDeath();
    //    if (hireStage == HireStage.Hired) CurrencyInvAnimationManager.Instance.PrestigeChange(1);
    //    //if (hireStage == HireStage.Hired) NotifyReturn();
    //    if (spawnAfterAway != null) Instantiate(spawnAfterAway);
    //}

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
            TryDeath();
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
    public void TryDeath()
    {
        if (health <= 0)
        {
            hireStage = HireStage.NotInMap;
            transform.parent = GameObject.FindGameObjectWithTag("InGameCharacterInventory").transform;
            LostCharacterAlertManager.CallDeathAlert(this);
        }
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
                        tagList.Add(Tag.无伤大雅);
                        removeList.Remove(tagExchangeUI.originTag);
                        tagExchangeUI.FlipZero(Tag.无伤大雅);
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
    public void ApplyLoyalty(int increase)
    {
        loyalty += increase;
        if (loyalty < 0)
        {
            loyalty = 0;
            StartCoroutine(TryLeavePlayer());
        }
        if (loyalty > 20)
        {
            loyalty = 20;
        }
    }
    public void ApplyHealth(int increase)
    {
        health += increase;
        if (health < 0)
        {
            health = 0;
            TryDeath();
        }
        if (health > 20)
        {
            health = 20;
        }
    }
    public void NotifyReturn()
    {
        AudioManager.Play("角色回归");
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        LocalizedString ReturnString = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = $"回来了"
        };
        message.text = $"{CharacterName}  {ReturnString.GetLocalizedString()}";
        return;
    }
}
