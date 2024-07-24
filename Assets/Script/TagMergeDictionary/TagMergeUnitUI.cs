using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class TagMergeUnitUI : MonoBehaviour
{
    public TagWithDescribetion tagPref;

    public Transform reqireTagsParent;
    public Transform outputTagsParent;
    public Image bracket;
    public List<Sprite> bracketRefs = new List<Sprite>();
    private static Dictionary<Tag, List<Tag>> MergeTagDict => Player.MergeTagDict;

    private void Start()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
    }
    private void OnDestroy()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }
    public void Setup(Tag tag)
    {
        var reqireTags = MergeTagDict[tag];
        foreach (var reqireTag in reqireTags)
        {
            var reqire = Instantiate(tagPref, reqireTagsParent);
            reqire.Setup(reqireTag);
        }
        var output = Instantiate(tagPref, outputTagsParent);
        output.Setup(tag);
        bracket.sprite = bracketRefs[reqireTags.Count - 2];
    }
    public void OnLocaleChanged(Locale locale)
    {
        foreach (TagWithDescribetion tag in reqireTagsParent.GetComponentsInChildren<TagWithDescribetion>())
        {
            tag.Setup((Tag)Enum.Parse(typeof(Tag), tag.tag));
        }
        var output = outputTagsParent.GetComponentInChildren<TagWithDescribetion>();
        output.Setup((Tag)Enum.Parse(typeof(Tag), output.tag));
    }

}
