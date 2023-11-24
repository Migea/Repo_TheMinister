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
        //Debug.Log(OSA.selectedTag);
        tagList.AddRange(character.tagList);
        tagList.Remove(OSA.selectedTag);
        tagList.Add(OSA.replacementTag);

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
            Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��]),
            Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��]),
            Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.ı]),
            Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��]),
            Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��]),
            Character.CheckVariablesRare(fakeCharacterValues[CharacterValueType.��])
            );
    }


}
