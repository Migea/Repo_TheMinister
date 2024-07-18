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
        Rarerity framRarity = Player.AllTagRareDict[Tag];
        string path = "Art/Tags/TagBG/";
        //try
        //{

        //var framRarity = Player.AllTagRareDict[Tag];
        //}
        //catch(KeyNotFoundException)
        //{
        //    Debug.Log(Tag.ToString());
        //}

        path = $"{path}{framRarity}";
        Image.sprite = Resources.Load<Sprite>(path);
    }
    public void ChangeTagText()
    {
        LocalizedString tagString = new LocalizedString
        {
            TableReference = "Tag",
            TableEntryReference = $"…Ë÷√_{Tag.ToString()}"
        };
        text.text = tagString.GetLocalizedString();
    }
}
