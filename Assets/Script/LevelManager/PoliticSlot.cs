using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticSlot : MonoBehaviour, ICharacterSelect
{
    public string slotName;
    public GameObject page = null;
    public Image CharacterHead = null;
    public Character characterOnHold = null;
    public int exp;
    public int extraMoney;
    public List<string> requestTagsInString;
    public List<Tag> requestTags;
    public Rarerity Wisdom = Rarerity.Null;
    public Rarerity Writing = Rarerity.Null;
    public Rarerity Strategy = Rarerity.Null;
    public Rarerity Strength = Rarerity.Null;
    public Rarerity Sneak = Rarerity.Null;
    public Rarerity Defense = Rarerity.Null;
    public List<PoliticSlot> preSlots = new List<PoliticSlot>();
    public PoliticCharacter GateHolder = null;
    public Image Frame;
    public Sprite PlayerFrame;
    public Sprite NonPlayerFrame;
    public Sprite HighlightFrame;
    public List<Image> upLines = new List<Image>();
    public List<Image> lowerLines = new List<Image>();
    public int Level = 0;
    public bool unlocked
    {
        get
        {
            if (GateHolder != null && GateHolder.bribed) return true;
            else if (characterOnHold != null) return true;
            return false;
        }
    }
    public void Start()
    {
        SetupTags();
        if (GateHolder != null)
        {
            GateModeSetup();
        }
        else
        {
            EmptySlotModeSetup();
        }
    }
    public void GateModeSetup()
    {
        GateHolder.slot = this;
    }
    public void EmptySlotModeSetup()
    {
        CharacterHead.gameObject.SetActive(false);
    }

    public void SetupTags()
    {
        List<Tag> tags = new List<Tag>();
        foreach (var tagName in requestTagsInString)
        {
            tags.Add((Tag)Enum.Parse(typeof(Tag), tagName));
        }
        requestTags = tags;
    }

    public void ChooseCharacter(Character character)
    {
        characterOnHold = character;
    }

    public void CloseInventory()
    {

    }

    public void CloseInventory(CharacterUI current)
    {

    }

    public void PutCharacterOn(Character character)
    {
        characterOnHold = character;
    }

    public void SetupSlotIcon()
    {

    }
}
