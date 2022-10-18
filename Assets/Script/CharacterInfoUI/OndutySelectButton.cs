using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OndutySelectButton : MonoBehaviour
{
    public OndutyType ondutyType = OndutyType.Combat;
    public bool OnSelect = false;
    Character character;
    public void Setup(Character character)
    {
        this.character = character;
        OnSelect = character.OnDutyState[ondutyType];
        if (OnSelect)
        {
            GetComponent<Image>().color = new Color(255, 255, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }
    public void Setup()
    {
        if (character != null)
        {
            Setup(character);
        }
    }
    public void OnClick()
    {
        if (!OnSelect)
        {
            switch (ondutyType)
            {
                case OndutyType.Combat:
                    if (character.CharactersValueDict[CharacterValueType.��] > 0 && character.CharactersValueDict[CharacterValueType.��] > 0)
                    {
                        SelectOnDuty.TrySelectOnDuty(character, ondutyType);
                        Setup();
                    }
                    else
                    {
                        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
                        alert.text = "��Ϊ������Ҫ�����ͬʱ����0";
                    }
                    break;
                case OndutyType.Debate:
                    if (character.CharactersValueDict[CharacterValueType.��] > 0 || character.CharactersValueDict[CharacterValueType.��] > 0|| character.CharactersValueDict[CharacterValueType.ı] > 0)
                    {
                        SelectOnDuty.TrySelectOnDuty(character, ondutyType);
                        Setup();
                    }
                    else
                    {
                        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
                        alert.text = "��Ϊ�Ŀ���Ҫ�ǲ�ı����һ������0";
                    }
                    break;
                case OndutyType.Gobang:
                    SelectOnDuty.TrySelectOnDuty(character, ondutyType);
                    Setup();
                    break;
            }
        }
        else
        {
            character.OnDutyState[ondutyType] = false;
            Setup();
        }
    }
}
