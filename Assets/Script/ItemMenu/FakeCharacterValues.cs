using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCharacterValues : MonoBehaviour
{
    private static Dictionary<CharacterValueType, int> fakeCharacterValues;
    public static void SetFakeCharacterValues()
    {
        CharacterInfoUI characterInfoUI = FindObjectOfType<CharacterInfoUI>();
        fakeCharacterValues = new Dictionary<CharacterValueType, int>()
    {  {CharacterValueType.��,0 },
       {CharacterValueType.��,0 },
       {CharacterValueType.��,0 },
       {CharacterValueType.��,0 },
       {CharacterValueType.��,0 },
       {CharacterValueType.ı,0 } };
        OnSwitchAssets OSA = FindObjectOfType<OnSwitchAssets>();
        Character character = OSA.character;
        List<Tag> tagList = new List<Tag>();
        Debug.Log(OSA.selectedTag);
        tagList.AddRange(character.tagList);
        var debugList = "";
        foreach (Tag tag in tagList)
        {
            debugList += tag.ToString() + ",";
        }
        Debug.Log(debugList);
        tagList.Remove(OSA.selectedTag);
        debugList = "";
        foreach (Tag tag in tagList)
        {
            debugList += tag.ToString() + ",";
        }
        Debug.Log(debugList);
        tagList.Add(OSA.replacementTag);
        debugList = "";
        foreach (Tag tag in tagList)
        {
            debugList += tag.ToString() + ",";
        }
        Debug.Log(debugList);
        foreach (Tag tag in tagList)
        {
            List<int> varlist = Player.TagInfDict[tag];
            fakeCharacterValues[CharacterValueType.��] += varlist[0];
            fakeCharacterValues[CharacterValueType.��] += varlist[1];
            fakeCharacterValues[CharacterValueType.ı] += varlist[2];
            fakeCharacterValues[CharacterValueType.��] += varlist[3];
            fakeCharacterValues[CharacterValueType.��] += varlist[4];
            fakeCharacterValues[CharacterValueType.��] += varlist[5];
        }
        characterInfoUI.SetValues(fakeCharacterValues);
        characterInfoUI.SetValueColors(
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.ı])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��])],
            CharacterUI.TagUIColorCode[Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��])]
            );
    }


}
