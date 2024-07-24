using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.QuestMachine;
using System.Linq;
using UnityEngine.SocialPlatforms;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.Localization.Settings;
using System.Security.Cryptography;
public class AwayQuestUI : MonoBehaviour, ICharacterSelect
{
    [System.Serializable]
    struct TypeRareStruct
    {
        public CharacterValueType Key;
        public Rarerity rarerity;
    }
    public string QuestNameString;
    public string QuestID;
    public int CharacterAllow = 3;
    public GameObject spawnAfterQuest;
    public List<Image> CharacterImages;
    public Transform TagContent;
    public Text healthText;
    public Text loyaltyText;
    public int health = 0;
    public int loyalty = 0;
    public List<Tag> Tags = new List<Tag>();
    public GameObject tagTemp;
    public Transform TypeRareContent;
    [SerializeField]
    private List<TypeRareStruct> TypeRareStructDict = new List<TypeRareStruct>();
    public GameObject typeTemp;
    public List<Character> characters = new List<Character>() { null, null, null };
    public Text QuestName;
    public Text daySpend;
    public int AwayDays = 0;
    private int currentIndex;
    private void Start()
    {
        transform.parent = MainCanvas.FindMainCanvas();
        var rt = GetComponent<RectTransform>();
        rt.localScale = Vector3.one;
        rt.anchoredPosition = Vector3.zero;
        Setup();
        GetComponent<Canvas>().sortingOrder = 101;
    }
    public void Setup()
    {

        typeTemp.gameObject.SetActive(false);
        foreach (TypeRareStruct type in TypeRareStructDict)
        {
            var current = Instantiate(typeTemp, TypeRareContent).GetComponent<Image>();
            current.sprite = Resources.Load<Sprite>($"Art/人物卡/六大项/字体背景/{type.rarerity}");
            current.GetComponentInChildren<Text>().text = type.Key.ToString();
            current.gameObject.SetActive(true);
        }
        if (TypeRareStructDict.Count == 0) TypeRareContent.gameObject.SetActive(false);
        tagTemp.gameObject.SetActive(false);
        foreach (Tag tag in Tags)
        {
            var current = Instantiate(tagTemp, TagContent).GetComponentInChildren<TagWithDescribetion>();
            current.name = tag.ToString();
            current.SetupSmaller(tag);
            current.transform.parent.gameObject.SetActive(true);
        }
        healthText.text = health.ToString();
        loyaltyText.text = loyalty.ToString();
        QuestName.text = QuestNameString;
        daySpend.text = AwayDays + "天";
        for (int i = 0; i < 3 - CharacterAllow; i++)
        {
            CharacterImages[2 - i].transform.parent.gameObject.SetActive(false);
        }
    }
    public void OnEnable()
    {
        LocaleUpdates();
    }
    public void LocaleUpdates()
    {
        var healthToMove = healthText.transform.parent.GetComponentInChildren<Image>().GetComponentInChildren<Text>();
        var loayalToMove = loyaltyText.transform.parent.GetComponentInChildren<Image>().GetComponentInChildren<Text>();
        var button = daySpend.transform.parent.GetComponentInChildren<Button>().GetComponentInChildren<Text>();
        if (LocalizationSettings.SelectedLocale.Identifier == "zh")
        {

            healthToMove.rectTransform.anchoredPosition = new Vector2(-3.3f, 1f);
            loayalToMove.rectTransform.anchoredPosition = new Vector2(-3.3f, 1f);
            button.rectTransform.anchoredPosition = new Vector2(1.5f, 0f);
        }
        else
        {
            healthToMove.rectTransform.anchoredPosition = new Vector2(1.3f, 4.5f);
            loayalToMove.rectTransform.anchoredPosition = new Vector2(-3.3f, 1f);
            Debug.Log(button == null);
            button.rectTransform.anchoredPosition = new Vector2(3f, 7.5f);
        }
    }
    public void ChangeCharacter(int index)
    {
        currentIndex = index;
    }
    public bool TryFit()
    {
        var tryTags = Tags;
        var TypeRare = TypeRareStructDict.ToDictionary(x => x.Key, x => x.rarerity);
        var tryTypeRare = TypeRare.Keys.ToList();
        var sentCharacters = characters.Where(x => x != null).ToList();
        if (sentCharacters.Count == 0) return false;
        foreach (Character character in sentCharacters)
        {
            //if (character.health < health || character.loyalty < loyalty) return false;
            var containTags = character.tagList.Where(tag => tryTags.Contains(tag));
            tryTags = tryTags.Where(tag => !containTags.Contains(tag)).ToList();
            foreach (CharacterValueType type in tryTypeRare.ToList())
            {
                if (character.characterValueRareDict[type] >= TypeRare[type])
                {
                    tryTypeRare.Remove(type);
                }
            }
        }
        bool fitAll = tryTags.Count == 0 && tryTypeRare.Count == 0;
        return fitAll;
    }
    public void Confirm()
    {
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        if (TryFit())
        {
            message.text = "角色启程去执行任务了";
            foreach (Character character in characters.Where(x => x != null).ToList())
            {
                character.awayMessage = $"Away@{QuestID}";
                character.Away(AwayDays, spawnAfterQuest.GetComponent<SpawnAfterAwayGuest>(), QuestID);
                character.health -= health;
                character.loyalty -= loyalty;
            }
            NextQuestStage();
            QuestDayCounterManager.Instance.AddCounter(QuestID, AwayDays);
            Destroy(gameObject);
        }
        else
        {
            message.text = "角色没有满足所有需求";
        }
    }
    public void NextQuestStage()
    {
        //QuestMachine.SetQuestNodeState(QuestID, "派遣", QuestNodeState.True);
        var questJournal = FindObjectOfType<QuestJournal>();
        var targetQuest = questJournal.FindQuest(QuestID);
        targetQuest.GetNode("派遣").SetState(QuestNodeState.True);
        questJournal.RepaintUIs();
        //QuestMachine.SetQuestNodeState(QuestID, "等待派遣", QuestNodeState.Active);
    }
    public void ChooseCharacter(Character character)
    {
        Debug.Log(characters.Count);
        Debug.Log(currentIndex);
        if (characters[currentIndex] != null)
        {
            RemoveFromRoom(currentIndex);
        }
        characters[currentIndex] = character;
    }
    public void SetupSlotIcon()
    {
        string sp = ReturnAssetPath.ReturnCharacterSpritePath(characters[currentIndex].characterArtCode);
        CharacterImages[currentIndex].sprite = Resources.Load<Sprite>(sp);
    }
    public void CloseInventory()
    {
        var target = GetComponent<SpawnUI>();
        target.CurrentTarget.gameObject.SetActive(false);
    }
    public void CloseInventory(CharacterUI current)
    {
        StartCoroutine(CloseInventoryRator(current));
    }
    public IEnumerator CloseInventoryRator(CharacterUI current)
    {
        Destroy(current.gameObject);
        yield return new WaitUntil(() => current == null);
        CloseInventory();
    }
    public void OpenInventory()
    {
        var target = GetComponent<SpawnUI>();
        if (target.CurrentTarget == null)
        {
            target.SpawnHere();
            PlayerCharactersInventory UI = target.CurrentTarget.GetComponent<PlayerCharactersInventory>();
            UI.SetupMode(CardMode.UpgradeSelectMode);
            UI.SetupSelection(gameObject);
        }
        target.CurrentTarget.gameObject.SetActive(true);
    }
    public void RemoveFromRoom(int index)
    {
        var last = characters[index];
        var target = GetComponent<SpawnUI>().CurrentTarget.GetComponent<PlayerCharactersInventory>().SetupNewCharacter(last);
        target.cardMode = CardMode.UpgradeSelectMode;
        target.characterSelectUI = gameObject;
        characters[index] = null;
    }
}
