using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class TextSpacingUpdater : MonoBehaviour
{
    Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
    }
    private void OnDestroy()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }

    private void OnLocaleChanged(Locale locale)
    {
        if (locale.Identifier != "zh")
        {
            text.lineSpacing = 0.4f;
        }
        else
        {
            text.lineSpacing = 0.8f;
        }
    }
}
