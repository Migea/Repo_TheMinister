using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PoliticAssassinPage : PoliticPage, IPoliticSelectionAction
{
    public Character target => PoliticCharacterSelect.SelectedCharacter;
    public PoliticCharacterSelect politicCharacterSelect = null;
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Image gateHolderImage = null;
    public Text gateHolderNameText = null;
    public Text difficultyText = null;
    public Text winRateText = null;
    public GameObject winRateObject = null;
    public GameObject ConfirmButton = null;
    public GameObject OngoingView = null;
    public void Setup(PoliticSlot slot)
    {
        this.slot = slot;
        Debug.Log(slot.GateHolder.characterArtCode);
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(slot.GateHolder.characterArtCode, false);
        gateHolderImage.sprite = Resources.Load<Sprite>(spritePath);
        gateHolderNameText.text = slot.GateHolder.CharacterName;
        titleText.text = slot.slotName;
        SetDifficulty(slot.GateHolder.AssassinDifficulty);
        politicCharacterSelect.politicSelectionAction = this;
        politicCharacterSelect.SetupEmpty();
        winRateObject.SetActive(false);
        ConfirmButton.SetActive(false);
        if (slot.GateHolder.Assassin != null)
        {
            SetOnGoing();
        }
        else
        {
            
            ConfirmButton.SetActive(true);
            OngoingView.SetActive(false);
        }
    }
    public void TryStartEvent()
    {
        ShowMessage($"{target.CharacterName}�ѳ���");

        StartEvent();
    }
    public void StartEvent()
    {
        PoliticSystemManager.Instance.OngoingAssassinEvents.Add(PoliticAssassinEvent.StartAssassin(slot.GateHolder, target));
        SetOnGoing();
    }
    public void SetOnGoing()
    {
        politicCharacterSelect.SetOnGoing(slot.GateHolder.Assassin);
        ConfirmButton.SetActive(false);
        OngoingView.SetActive(true);
    }
    public void SetOffGoing()
    {
        politicCharacterSelect.SetupEmpty();
        ConfirmButton.SetActive(false);
        OngoingView.SetActive(false);
    }
    public void SetDifficulty(int difficulty)
    {
        string output = string.Empty;
        if (difficulty > 70)
        {
            output = "���ɻ�";
        }
        else if (difficulty > 40)
        {
            output = "����";
        }
        else if (difficulty > 30)
        {
            output = "��";
        }
        else if (difficulty > 15)
        {
            output = "һ��";
        }
        else if (difficulty > 5)
        {
            output = "��";
        }
        else
        {
            output = "����";
        }
        difficultyText.text = $"��ɱ�Ѷ�\r\n<color=red><size=20>{output}</size></color>";
    }
    public void SetWinRate(float rate)
    {
        string output = string.Empty;
        if (rate > 100 / 100)
        {
            output = "��ɱ";
        }
        else if (rate > 80 / 100)
        {
            output = "����";
        }
        else if (rate > 60 / 100)
        {
            output = "�ϸ�";
        }
        else if (rate > 40 / 100)
        {
            output = "�е�";
        }
        else if (rate > 20 / 100)
        {
            output = "�ϵ�";
        }
        else if (rate > 10 / 100)
        {
            output = "��";
        }
        else if (rate > 5 / 100)
        {
            output = "����";
        }
        else if (rate > 0)
        {
            output = "��ã";
        }
        else
        {
            output = "������";
        }
        winRateText.text = $"�ɹ���\r\n<color=red><size=20>{output}</size></color>";
        winRateObject.SetActive(true);
    }

    public void AfterPoliticSelectionEvent()
    {
        int value = PoliticCharacterSelect.SelectedCharacter.CharactersValueDict[CharacterValueType.��];
        int total = slot.GateHolder.AssassinDifficulty;
        SetWinRate((float)value / (float)total);
        ConfirmButton.gameObject.SetActive(true);
    }
    public void ShowMessage(string messageString)
    {
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        message.text = messageString;
    }
}
