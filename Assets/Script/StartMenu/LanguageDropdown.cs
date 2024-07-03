using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class LanguageDropdown : MonoBehaviour
{
    public Dropdown languageDropdown;

    void Start()
    {
        PopulateDropdown();
        languageDropdown.onValueChanged.AddListener(delegate { OnLanguageChanged(languageDropdown); });
    }

    void PopulateDropdown()
    {
        languageDropdown.ClearOptions();
        var options = new List<string>();

        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            options.Add(locale.name);
        }

        languageDropdown.AddOptions(options);
        // Set the current selected locale
        var selectedLocale = LocalizationSettings.SelectedLocale;
        languageDropdown.value = LocalizationSettings.AvailableLocales.Locales.IndexOf(selectedLocale);
    }

    void OnLanguageChanged(Dropdown change)
    {
        var selectedLocale = LocalizationSettings.AvailableLocales.Locales[change.value];
        StartCoroutine(SetLocale(selectedLocale));
    }

    IEnumerator SetLocale(Locale locale)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = locale;
        Debug.Log(locale.LocaleName.ToString());
        UILocalizationManager.instance.currentLanguage = locale.ToString();
        DialogueManager.SetLanguage(locale.LocaleName);
    }
}