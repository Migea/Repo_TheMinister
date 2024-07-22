using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public class TagWithDescribetion : MonoBehaviour, IDetailAble, IPointerEnterHandler, IPointerExitHandler
{
    public Image Image;
    public Text text;
    private Tag Tag;
    public int timeLeft = 0;
    public bool TempTag = false;

    public void SetOffDetail()
    {
        TagDescriptionUI.Hide();
    }

    public void SetOnDetail(string target)
    {
        if (TempTag)
        {
            TagDescriptionUI.ShowTemp(Tag.ToString(), timeLeft);
            return;
        }
        TagDescriptionUI.Show(Tag.ToString());
    }

    public void Setup(Tag tag)
    {
        //Legacy:
        //Image.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnTagPath(tag));
        //Tag = tag;
        Tag = tag;
        ChangeTagBackground();
        ChangeTagText();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOnDetail("");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetOffDetail();
    }
    public void ChangeTagBackground()
    {

        Image.sprite = GetTagBackground(Tag);
    }
    public static Sprite GetTagBackground(Tag tag)
    {
        Rarerity framRarity = Player.AllTagRareDict[tag];
        string path = "Art/Tags/TagBG/";
        path = $"{path}{framRarity}";
        return Resources.Load<Sprite>(path);
    }
    public void ChangeTagText()
    {
        text.text = GetTagText(Tag);
        text.lineSpacing = 0.4f;
        //remove After Test
        text.text = GetDisplayTagText(Tag);
    }
    public static string GetTagText(Tag tag)
    {
        LocalizedString tagString = new LocalizedString
        {
            TableReference = "Tag",
            TableEntryReference = $"…Ë÷√_{tag.ToString()}"
        };
        return tagString.GetLocalizedString();
    }
    public static string GetDisplayTagText(Tag tag)
    {
        LocalizedString tagString = new LocalizedString
        {
            TableReference = "DisplayTags",
            TableEntryReference = $"{tag.ToString()}"
        };
        return tagString.GetLocalizedString();
    }
}
