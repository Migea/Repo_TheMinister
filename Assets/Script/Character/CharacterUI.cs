using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.Localization;

public class CharacterUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Character character;
    public GameObject tagPref;
    public GameObject tempTagPref;

    public Image Idle;
    public Text Name;
    public Text Health;
    public Text Loyalty;
    public Text Hungry;
    public Text HungrySign;
    public GameObject TagSlot;
    public GameObject TempTagSlot;
    public GameObject fakeTempTag = null;

    public Image Wisdom;
    public Image Writing;
    public Image Strategy;
    public Image Strength;
    public Image Sneak;
    public Image Defense;

    public CharacterInfoUI characterInfoUI;
    private CharacterInfoUI currentCharacterInfoUI;

    public Image FrontRarity;
    public Image BackRarity;

    public Image OnCombatImage;
    public Image OnDebateImage;
    public Image OnGobangImage;
    public Image OnAwayImage;

    private PlayerCharactersInventory inventoryCharacters;
    public CardMode cardMode = CardMode.ViewMode;
    public Tag newTag;

    public Character TargetCharacter;
    public Transform PannelTopTransform;

    public ConfirmPhase confirm = ConfirmPhase.Null;
    public CharacterSlotForQuest CurrentSlot
    {
        get => inventoryCharacters.currentSlot;
        set => inventoryCharacters.currentSlot = value;
    }

    public GameObject characterSelectUI;
    public ESlot CurrentESlot;
    public Transform hungrySign;
    public Transform loyaltySign;
    public Transform healthSign;
    public Text Favor;

    public static Dictionary<Rarerity, Color> TagUIColorCode = new Dictionary<Rarerity, Color>()
    {
        { Rarerity.VB, new Color32(153, 0, 0, 255)},
        { Rarerity.B, new Color32(141, 75, 6, 255)},
        { Rarerity.Null, new Color32(183, 183, 183, 255)},
        { Rarerity.N, Color.white },
        { Rarerity.R, new Color32(171,219,227, 255) },
        { Rarerity.SR, new Color32(180, 167, 214, 255) },
        { Rarerity.SSR, new Color32(255, 217, 102, 255) },
        { Rarerity.UR, new Color32(234, 153, 153, 255) }
    };

    private void Awake()
    {
        inventoryCharacters = FindObjectOfType<PlayerCharactersInventory>();
        //OnCombatImage.gameObject.SetActive(false);
        //OnDebateImage.gameObject.SetActive(false);
        //OnGobangImage.gameObject.SetActive(false);
    }

    public void Setup()
    {
        ResetSigns();
        character.UpdateVariables();
        foreach (Transform t in TempTagSlot.transform)
        {
            Destroy(t.gameObject);
        }
        string idleSpritePath = ("Art/CharacterSprites/Idle/Idle_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
        Idle.sprite = Resources.Load<Sprite>(idleSpritePath);
        Idle.rectTransform.sizeDelta = new Vector2(420f, 630f);
        Name.text = character.CharacterName;
        Health.text = character.health.ToString();
        Loyalty.text = character.loyalty.ToString();
        Hungry.text = character.hungry.ToString();
        if (character.hungry <= 1)
        {
            HungrySign.color = Color.red;
        }
        else
        {
            HungrySign.color = Color.black;
        }
        ModifyValueColor();
        ModifyTags();
        ModifyCardImage();
        if (character.hireStage == HireStage.Away)
        {
            OnAwayImage.gameObject.SetActive(true);
        }
        else
        {
            OnAwayImage.gameObject.SetActive(false);
        }

        if (cardMode == CardMode.ViewMode) SetupSign();
        LocalizedString favorString = new LocalizedString
        {
            TableReference = "Favor",
            TableEntryReference = $"{character.edibleFavor.ToString()}"
        };
        Favor.text = favorString.GetLocalizedString();
    }

    private void ModifyCardImage()
    {
        Rarerity topRarerity = Rarerity.N;
        var targetDict = character.characterValueRareDict;
        foreach (CharacterValueType type in targetDict.Keys)
        {
            if ((int)targetDict[type] > (int)topRarerity)
            {
                topRarerity = targetDict[type];
            }
        }
        string backPath = ("Art/人物卡/背景贴图/" + topRarerity.ToString()).Replace(" ", string.Empty);
        string frontPath = ("Art/人物卡/前景贴图/" + topRarerity.ToString()).Replace(" ", string.Empty);
        BackRarity.sprite = Resources.Load<Sprite>(backPath);
        FrontRarity.sprite = Resources.Load<Sprite>(frontPath);
        if (character.OnDutyState[OndutyType.Combat])
        {
            OnCombatImage.gameObject.SetActive(true);
        }
        else OnCombatImage.gameObject.SetActive(false);
        if (character.OnDutyState[OndutyType.Debate])
        {
            OnDebateImage.gameObject.SetActive(true);
        }
        else OnDebateImage.gameObject.SetActive(false);
        if (character.OnDutyState[OndutyType.Gobang])
        {
            OnGobangImage.gameObject.SetActive(true);
        }
        else OnGobangImage.gameObject.SetActive(false);
    }
    private void ModifyValueColor()
    {
        var targetDict = character.characterValueRareDict;
        string pathTitle = "Art/人物卡/六大项/字体背景/";
        Wisdom.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.智]).Replace(" ", string.Empty));
        Writing.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.才]).Replace(" ", string.Empty));
        Strategy.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.谋]).Replace(" ", string.Empty));
        Strength.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.武]).Replace(" ", string.Empty));
        Sneak.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.刺]).Replace(" ", string.Empty));
        Defense.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.守]).Replace(" ", string.Empty));
    }
    private void ModifyTags()
    {
        foreach (Tag tag in character.tagList)
        {
            var current = Instantiate(tagPref, TagSlot.transform).GetComponentInChildren<TagWithDescribetion>();
            current.name = tag.ToString();
            current.Setup(tag);
        }
        foreach (TemporaryTag temporaryTag in character.temporaryTags)
        {
            var current = Instantiate(tempTagPref, TempTagSlot.transform).GetComponentInChildren<TagWithDescribetion>();
            current.name = tag.ToString();
            current.timeLeft = temporaryTag.timeLeft;
            current.TempTag = true;
            current.Setup(temporaryTag.tag);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 1f);
        var origin = GetComponent<RectTransform>().localPosition;
        GetComponent<RectTransform>().localPosition = new Vector2(origin.x - 10, origin.y - 15);
        if (cardMode == CardMode.EatMode)
        {
            var eatItem = FindObjectOfType<EatItem>();
            int loyalUp = 0;
            int healthUp = eatItem.healthUp;
            int hungryUp = eatItem.hungryUp;
            if (character.edibleFavor == eatItem.edibleType)
            {
                loyalUp = FavorLoyaltyAdd(eatItem.rarerity);
            }
            SetupTempTag();
            SetupSignOnEat(hungryUp, loyalUp, healthUp);
        }
    }

    private void SetupTempTag()
    {
        var eatItem = FindObjectOfType<EatItem>();
        if (eatItem != null)
        {
            if (eatItem.tempTag != Tag.Null)
            {
                fakeTempTag = Instantiate(tempTagPref, TempTagSlot.transform);
                var target = fakeTempTag.GetComponentInChildren<TagWithDescribetion>();
                target.name = tag.ToString();
                target.TempTag = true;
                target.timeLeft = eatItem.duration;
                target.Setup(eatItem.tempTag);
            }
        }
    }

    public int FavorLoyaltyAdd(Rarerity rare)
    {
        int output = 0;
        switch (rare)
        {
            case Rarerity.R:
                output = 1;
                break;
            case Rarerity.SR:
                output = 2;
                break;
            case Rarerity.SSR:
                output = 3;
                break;
            case Rarerity.UR:
                output = 4;
                break;
        }
        return output;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1f);
        var origin = GetComponent<RectTransform>().localPosition;
        GetComponent<RectTransform>().localPosition = new Vector2(origin.x + 10, origin.y + 15);
        if (cardMode == CardMode.EatMode)
        {
            ResetSigns();
            Destroy(fakeTempTag);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnAwayImage.gameObject.activeSelf)
        {
            AudioManager.Play("错误");
            var sampleText = Resources.Load<Text>("Hiring/Message");
            var message = Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
            message.text = "角色正在处理其他事物";
            return;
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            AudioManager.Play("按钮");
            switch (cardMode)
            {
                case CardMode.ViewMode:
                    SelectCharacterInfo();
                    break;
                case CardMode.QuestSelectMode:
                    SelectCharacter();
                    break;
                case CardMode.ItemSelectMode:
                    //if (character.tagList.Count >= 5)
                    //{
                    //    CreateTagSwitchUI();
                    //}
                    //else
                    //{
                    //    character.tagList.Add(newTag);
                    //    GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().RemoveItem();
                    //    FindObjectOfType<ItemInventoryUI>().SetUp();
                    //    inventoryCharacters.RightClickSelectMode();
                    //}
                    ChangeCurrentCharacterAsset();
                    break;
                case CardMode.OnCombatSwitchMode:
                    string CombatText = "确认更换" + character.CharacterName + "为在任 武侍 ?";
                    Confirmation.HoldingMethod Combatholding = ChangeDutyState;
                    StartCoroutine(Confirmation.CreateNewComfirmation(Combatholding, CombatText).Confirm());
                    break;
                case CardMode.OnDebateSwitchMode:
                    string DebatetText = "确认更换 " + character.CharacterName + " 为在任 文客 ?";
                    Confirmation.HoldingMethod Debateholding = ChangeDutyState;
                    StartCoroutine(Confirmation.CreateNewComfirmation(Debateholding, DebatetText).Confirm());
                    break;
                case CardMode.OnGobangSwitchMode:
                    string GobangText = "确认更换" + character.CharacterName + "为在任 弈师 ?";
                    Confirmation.HoldingMethod Gobangholding = ChangeDutyState;
                    StartCoroutine(Confirmation.CreateNewComfirmation(Gobangholding, GobangText).Confirm());
                    break;
                case CardMode.UpgradeSelectMode:
                    SelectForSlot();
                    characterSelectUI.GetComponent<ICharacterSelect>().CloseInventory(this);
                    break;
                case CardMode.EatMode:
                    var eatItem = FindObjectOfType<EatItem>();
                    if (character.edibleFavor == eatItem.edibleType)
                    {
                        eatItem.loyaltyUp = FavorLoyaltyAdd(eatItem.rarerity);
                    }
                    eatItem.EatBy(character);
                    break;
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (cardMode == CardMode.UpgradeSelectMode)
            {
                if (characterSelectUI != null)
                    characterSelectUI.GetComponent<ICharacterSelect>().CloseInventory();
            }
            else if (cardMode == CardMode.OnDebateSwitchMode || cardMode == CardMode.OnCombatSwitchMode || cardMode == CardMode.OnGobangSwitchMode)
            {
                FindObjectOfType<CharacterOndutySwitchUI>().GetComponent<RightClickToClose>().RightClickEvent();
            }
            else
            {
                if (inventoryCharacters != null)
                {
                    inventoryCharacters.RightClickSelectMode();
                }
                else if (PannelTopTransform != null)
                {
                    PannelTopTransform.GetComponent<RightClickToClose>().RightClickEvent();
                }
            }

        }
    }

    private void ChangeCurrentCharacterAsset()
    {
        FindObjectOfType<OnSwitchAssets>().character = character;
        FindObjectOfType<MedicationUI>()?.Setup(character);
        FindObjectOfType<CharacterInfoUI>()?.Setup(character);
        FindObjectOfType<PlayerCharactersInventory>().GetComponent<RightClickToClose>().RightClickEvent();
    }

    private void ChangeDutyState()
    {
        OndutyType ondutyType = OndutyType.Combat;
        switch (cardMode)
        {
            case CardMode.OnCombatSwitchMode:
                ondutyType = OndutyType.Combat;
                break;
            case CardMode.OnDebateSwitchMode:
                ondutyType = OndutyType.Debate;
                break;
            case CardMode.OnGobangSwitchMode:
                ondutyType = OndutyType.Gobang;
                break;
        }
        character.OnDutyState[ondutyType] = false;
        TargetCharacter.OnDutyState[ondutyType] = true;
        FindObjectOfType<CharacterInfoUI>().SetOnSelectButton();
        PannelTopTransform.GetComponent<RightClickToClose>().RightClickEvent();
    }

    private void CreateTagSwitchUI()
    {
        TagExchangeUI tagExchangeUI = Resources.Load<TagExchangeUI>("TagReplacement/TagReplacementUI");
        var current = Instantiate(tagExchangeUI, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        current.SetUp(newTag, character);
    }

    public void SelectCharacter()
    {
        if (cardMode == CardMode.QuestSelectMode)
        {
            CurrentSlot.UndisableField();
            CurrentSlot.character = character;
            CurrentSlot.CheckAllQuestAchievement();
            string headshotSpritePath = ("Art/CharacterSprites/Headshot/Headshot_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
            CurrentSlot.selectImage.sprite = Resources.Load<Sprite>(headshotSpritePath);
            CurrentSlot.selectImage.color = new Color
                (
                CurrentSlot.selectImage.color.r,
                CurrentSlot.selectImage.color.g,
                CurrentSlot.selectImage.color.b,
                1f
                );
            var CharacterSelectWindow = FindObjectOfType<PlayerCharactersInventory>();
            var allCharacters = CharacterSelectWindow.GetComponentsInChildren<CharacterUI>();
            foreach (CharacterUI c in allCharacters) c.CurrentSlot = null;

            CharacterSelectWindow.gameObject.SetActive(false);
        }
    }

    public void SelectCharacterInfo()
    {
        currentCharacterInfoUI = Instantiate(characterInfoUI, MainCanvas.FindMainCanvas());
        currentCharacterInfoUI.Setup(character);
        //Debug.Log(currentCharacterInfoUI);
    }

    public void SelectForSlot()
    {
        if (characterSelectUI != null)
        {
            var target = characterSelectUI.GetComponent<ICharacterSelect>();
            target.ChooseCharacter(character);
            target.SetupSlotIcon();
            target.CloseInventory(this);
        }
    }

    public void SetupSign()
    {
        int loyaltyExtraPerTurn = 0;
        if (character.OnDutyState[OndutyType.Combat] == true) loyaltyExtraPerTurn++;
        if (character.OnDutyState[OndutyType.Debate] == true) loyaltyExtraPerTurn++;
        hungrySign.Find("减").gameObject.SetActive(true);

        if (character.hungry < 1)
        {
            if (loyaltyExtraPerTurn == 0) loyaltySign.Find("减减").gameObject.SetActive(true);
            else if (loyaltyExtraPerTurn == 1) loyaltySign.Find("减").gameObject.SetActive(true);
            healthSign.Find("减").gameObject.SetActive(true);
        }
        else if (character.hungry <= 5)
        {
            if (loyaltyExtraPerTurn == 0) loyaltySign.Find("减").gameObject.SetActive(true);
            else if (loyaltyExtraPerTurn == 1) ;
            else if (loyaltyExtraPerTurn == 2) loyaltySign.Find("加").gameObject.SetActive(true);
        }
        else if (character.hungry < 15)
        {
            if (loyaltyExtraPerTurn == 1) loyaltySign.Find("加").gameObject.SetActive(true);
            if (loyaltyExtraPerTurn == 2) loyaltySign.Find("加加").gameObject.SetActive(true);
        }
        else if (character.hungry >= 15)
        {
            if (loyaltyExtraPerTurn == 0) loyaltySign.Find("加").gameObject.SetActive(true);
            else if (loyaltyExtraPerTurn == 1 || loyaltyExtraPerTurn == 2) loyaltySign.Find("加加").gameObject.SetActive(true);
        }
    }
    public void SetupSignOnEat(int hungryUp, int loyaltySignUp, int healthUp)
    {
        if (hungryUp > 1)
        {
            hungrySign.Find("加加").gameObject.SetActive(true);
        }
        else if (hungryUp == 1)
        {
            hungrySign.Find("加").gameObject.SetActive(true);
        }
        else if (hungryUp == 0) { }
        else if (hungryUp > -2)
        {
            hungrySign.Find("减").gameObject.SetActive(true);
        }
        else if (healthUp > -1)
        {
            hungrySign.Find("减减").gameObject.SetActive(true);
        }

        if (loyaltySignUp > 1)
        {
            loyaltySign.Find("加加").gameObject.SetActive(true);
        }
        else if (loyaltySignUp == 1)
        {
            loyaltySign.Find("加").gameObject.SetActive(true);
        }
        else if (loyaltySignUp == 0) { }
        else if (loyaltySignUp > -2)
        {
            loyaltySign.Find("减").gameObject.SetActive(true);
        }
        else if (loyaltySignUp > -1)
        {
            loyaltySign.Find("减减").gameObject.SetActive(true);
        }

        if (healthUp > 1)
        {
            healthSign.Find("加加").gameObject.SetActive(true);
        }
        else if (healthUp == 1)
        {
            healthSign.Find("加").gameObject.SetActive(true);
        }
        else if (healthUp == 0) { }
        else if (healthUp > -2)
        {
            healthSign.Find("减").gameObject.SetActive(true);
        }
        else if (healthUp > -1)
        {
            healthSign.Find("减减").gameObject.SetActive(true);
        }
    }
    public void ResetSigns()
    {
        foreach (Transform sign in loyaltySign)
        {
            sign.gameObject.SetActive(false);
        }
        foreach (Transform sign in hungrySign)
        {
            sign.gameObject.SetActive(false);
        }
        foreach (Transform sign in healthSign)
        {
            sign.gameObject.SetActive(false);
        }
    }
}
