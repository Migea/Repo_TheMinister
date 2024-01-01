using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticImpeachPage : PoliticPage
{
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Image gateHolderImage = null;
    public Text gateHolderNameText = null;
    public Text difficultyText = null;
    public GameObject difficultyGameobject = null;
    public Text alreadyImpeachedTimes = null;
    public Text itemContainText = null;
    public Text slotReward = null;
    public GameObject ConfirmButton = null;
    public GameObject OngoingView = null;
    public ItemName impeachItem = ItemName.��������;
    public void Setup(PoliticSlot slot)
    {
        this.slot = slot;
        var gateHolder = slot.GateHolder;
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(gateHolder.characterArtCode, false);
        gateHolderImage.sprite = Resources.Load<Sprite>(spritePath);
        gateHolderNameText.text = gateHolder.CharacterName;

        SetDifficulty(slot.GateHolder.ImpeachDifficulty);
        SetAlreadyImpeachedTimes(slot.GateHolder.ImpeachTime);
        SetItemContain();

    }

    private void SetItemContain()
    {
        var itemInv = FindObjectOfType<ItemInventory>();
        int contain = 0;
        int request = slot.GateHolder.ImpeachItemRequstNumber - slot.GateHolder.ImpeachTime;
        if (request < 0) request = 0;
        string requestString = $"<color=green>{request}</color>";
        if (itemInv.CheckItem(impeachItem))
        {
            contain = itemInv.ItemDict[impeachItem];
        }
        if (request < contain)
        {
            requestString = $"<color=red>{request}</color>";
        }
        itemContainText.text = $"{requestString}/{contain}";
    }

    private void SetAlreadyImpeachedTimes(int impeachTime)
    {
        alreadyImpeachedTimes.text = $"�ѵ���{impeachTime}��";
    }

    private void SetDifficulty(int impeachDifficulty)
    {
        string difficultyInColor = string.Empty;
        if (impeachDifficulty > LevelManager.Instance.level)
        {
            difficultyInColor = $"<size=20><color=red>{impeachDifficulty}</color></size>";
        }
        else
        {
            difficultyInColor = $"<size=20><color=green>{impeachDifficulty}</color></size>";
        }
        difficultyText.text = $"��Ҫ����\r\n{difficultyInColor}";
    }
    public void TryImpeach()
    {
        if (LevelManager.Instance.level < slot.GateHolder.ImpeachDifficulty)
        {
            ShowMessage("����Ҫ���ߵ������ȼ�");
            return;
        }
        int contain = 0;
        var itemInv = FindObjectOfType<ItemInventory>();
        int request = slot.GateHolder.ImpeachItemRequstNumber - slot.GateHolder.ImpeachTime;
        if (request < 0) request = 0;
        if (itemInv.CheckItem(impeachItem))
        {
            contain = itemInv.ItemDict[impeachItem];
        }
        if (contain < request)
        {
            ShowMessage("����Ҫ����ĵ�������");
            return;
        }
        ShowMessage($"�ɹ�����{slot.GateHolder.CharacterName}����¸�ѶȽ���");
        slot.GateHolder.ImpeachTime += 1;
        SetAlreadyImpeachedTimes(slot.GateHolder.ImpeachTime);
        SetItemContain();
    }
    public void ShowMessage(string messageString)
    {
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        message.text = messageString;
    }
}
