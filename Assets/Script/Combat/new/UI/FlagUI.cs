using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagUI : MonoBehaviour
{
    public Image Headshot;
    public Image Flag;
    public Text Name;
    public Text Health;
    public Image AttackBackground;
    public Image DefenceBackground;
    public Image AssasinBackground;
    public Text AttackStat;
    public Text DefenceStat;
    public Text AssasinStat;
    public Image CurrentStat;

    public void Setup(Character character)
    {
        var headshotPath = ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode, false);
        Headshot.sprite = Resources.Load<Sprite>(headshotPath);

        var AttackBackgroundPath = ReturnAssetPath
            .ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.��]);
        AttackBackground.sprite = Resources.Load<Sprite>(AttackBackgroundPath);
        AttackStat.text = character.CharactersValueDict[CharacterValueType.��].ToString();

        var DefenceBackgroundPath = ReturnAssetPath
            .ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.��]);
        DefenceBackground.sprite = Resources.Load<Sprite>(DefenceBackgroundPath);
        DefenceStat.text = character.CharactersValueDict[CharacterValueType.��].ToString();
        
        var AssasinBackgroundPath = ReturnAssetPath
            .ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.��]);
        AssasinBackground.sprite = Resources.Load<Sprite>(AssasinBackgroundPath);
        AssasinStat.text = character.CharactersValueDict[CharacterValueType.��].ToString();

        Name.text = character.CharacterName;
        Health.text = character.health.ToString();
    }
    //public void FixedUpdate()
    //{
    //    if (Character.)
    //}
}
