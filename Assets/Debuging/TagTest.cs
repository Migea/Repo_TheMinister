using Language.Lua;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class TagTest : MonoBehaviour
{
    TagWithDescribetion tagWithDescribetion;
    public string tagString;
    private void Awake()
    {
        tagWithDescribetion = GetComponent<TagWithDescribetion>();
        LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
    }

    private void LocalizationSettings_SelectedLocaleChanged(UnityEngine.Localization.Locale obj)
    {
        Enum.TryParse(tagString, out Tag tag);
        tagWithDescribetion.Setup(tag);
    }

    public void OnEnable()
    {
        Enum.TryParse(tagString, out Tag tag);
        tagWithDescribetion.Setup(tag);
    }
}
