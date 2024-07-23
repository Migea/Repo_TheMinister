using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterReciveNotice : MonoBehaviour
{
    public Text Name;
    public Image Head;
    public Image Frame;
    public List<Image> Renders;
    public Text Wisdom;
    public Text Writing;
    public Text Strategy;
    public Text Strength;
    public Text Sneak;
    public Text Defense;
    public Transform tags;
    public List<Color> RarityColors = new List<Color>()
    {
        new Color(63,77,49),
        new Color(147,136,123),
        new Color(87,148,179),
        new Color(165,43,124),
        new Color(248,212,95),
        new Color(217,50,35)
    };
    public UnityEvent destroyEvents = new UnityEvent();

    public virtual void Setup(Character character)
    {
        Rarerity rarerity = character.CheckTopRare();
        Name.text = character.CharacterName;
        Head.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode, false));
        Frame.sprite = Resources.Load<Sprite>($"Art/BuildingUI/杂货铺/初级五金铺/物品框/物品框-{rarerity}");
        //foreach (var render in Renders)
        //{
        //    render.material = Resources.Load<Material>($"Mat/BackInkEffect/{rarerity}");
        //}
        TransformEx.Clear(tags);
        foreach (Tag tag in character.tagList)
        {
            Image tagObj = Instantiate(Resources.Load<Image>("Tag/Tag"), tags);
            tagObj.GetComponentInChildren<TagWithDescribetion>().SetupSmall(tag);
        }
        var wisdom = (int)character.characterValueRareDict[CharacterValueType.智] / 2;
        Wisdom.color = RarityColors[wisdom > 0 ? wisdom : 0];
        var writing = (int)character.characterValueRareDict[CharacterValueType.才] / 2;
        Writing.color = RarityColors[writing > 0 ? writing : 0];
        var strategy = (int)character.characterValueRareDict[CharacterValueType.谋] / 2;
        Strategy.color = RarityColors[strategy > 0 ? strategy : 0];
        var strength = (int)character.characterValueRareDict[CharacterValueType.武] / 2;
        Strength.color = RarityColors[strength > 0 ? strength : 0];
        var sneak = (int)character.characterValueRareDict[CharacterValueType.刺] / 2;
        Sneak.color = RarityColors[sneak > 0 ? sneak : 0];
        var defense = (int)character.characterValueRareDict[CharacterValueType.守] / 2;
        Defense.color = RarityColors[defense > 0 ? defense : 0];
    }
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        destroyEvents.Invoke();
    }
}
