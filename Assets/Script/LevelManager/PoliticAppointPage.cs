using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticAppointPage : PoliticPage, IPoliticSelectionAction
{
    public Character target => PoliticCharacterSelect.SelectedCharacter;
    public PoliticCharacterSelect politicCharacterSelect = null;
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Transform TagParent = null;
    public Image Wisdom = null;
    public Image Writing = null;
    public Image Strategy = null;
    public Image Strength = null;
    public Image Sneak = null;
    public Image Defense = null;
    public Transform ValueParent = null;
    public GameObject ConfirmButton = null;
    public GameObject OngoingView = null;
    public TagWithDescribetion tagWithDescribetion = null;
    public void Setup(PoliticSlot slot)
    {
        this.slot = slot;
        Debug.Log(slot.GateHolder.characterArtCode);
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(slot.GateHolder.characterArtCode, false);
        titleText.text = slot.slotName;

        politicCharacterSelect.politicSelectionAction = this;
        politicCharacterSelect.SetupEmpty();
        ConfirmButton.SetActive(false);
    }
    public void SetTags()
    {
        foreach (Tag tag in slot.requestTags)
        {
            var clone = Instantiate(tagWithDescribetion, TagParent);
            clone.Setup(tag);
        }
    }
    public void SetValues()
    {
        if (slot.Wisdom != Rarerity.Null)
        {
            Wisdom.sprite = Resources.Load<Sprite>($"Art/���￨/������/���屳��/{slot.Wisdom.ToString()}");
        }
    }
    public void TryStartEvent()
    {
        if (target.loyalty < 10)
        {
            var sampleText = Resources.Load<Text>("Hiring/Message");
            var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
            message.text = $"{target.CharacterName}���ҳ϶ȹ���";
            return;
        }
        if (TestCharacter() == true)
        {
            StartEvent();
        }
        else
        {
            var sampleText = Resources.Load<Text>("Hiring/Message");
            var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
            message.text = $"{target.CharacterName}������ְλ����";
        }
    }
    public void StartEvent()
    {
        slot.characterOnHold = target;
    }
    public bool TestCharacter()
    {
        var character = target;
        foreach (Tag tag in slot.requestTags)
        {
            if (!character.tagList.Contains(tag)) return false;
        }
        var valueDict = character.characterValueRareDict;
        if (slot.Wisdom > 0 && slot.Wisdom > valueDict[CharacterValueType.��]) return false;
        if (slot.Writing > 0 && slot.Writing > valueDict[CharacterValueType.��]) return false;
        if (slot.Strategy > 0 && slot.Strategy > valueDict[CharacterValueType.ı]) return false;
        if (slot.Strength > 0 && slot.Strength > valueDict[CharacterValueType.��]) return false;
        if (slot.Sneak > 0 && slot.Sneak > valueDict[CharacterValueType.��]) return false;
        if (slot.Defense > 0 && slot.Defense > valueDict[CharacterValueType.��]) return false;
        return true;
    }
    public void AfterPoliticSelectionEvent()
    {
        ConfirmButton.gameObject.SetActive(true);
    }
}
