using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;

public class FontManager : MonoBehaviour
{
    public Font englishFont;
    public Font frenchFont;
    public Font chineseFont;
    public TMP_FontAsset englishTMPFont;
    public TMP_FontAsset frenchTMPFont;
    public TMP_FontAsset chineseTMPFont;

    public Text fontTrackerText;
    public TextMeshProUGUI fontTrackerTMPText;

    private static List<Text> allTextComponents = new List<Text>();
    private static List<TextMeshProUGUI> allTMPTextComponents = new List<TextMeshProUGUI>();
    private Font currentFont;
    private TMP_FontAsset currentTMPFont;

    private static FontManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        allTextComponents.AddRange(FindObjectsOfType<Text>());
        allTMPTextComponents.AddRange(FindObjectsOfType<TextMeshProUGUI>());

        if (LocalizationSettings.Instance != null)
        {
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;

            var currentLocale = LocalizationSettings.SelectedLocale;
            if (currentLocale != null)
            {
                ApplyFontBasedOnLocale(currentLocale);
            }
        }
        else
        {
            Debug.LogWarning("LocalizationSettings instance is not found.");
        }
    }

    private void OnDestroy()
    {
        if (LocalizationSettings.Instance != null)
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
        }
    }

    private void OnLocaleChanged(Locale newLocale)
    {
        if (newLocale != null)
        {
            ApplyFontBasedOnLocale(newLocale);
        }
        else
        {
            Debug.LogWarning("New locale is null.");
        }
    }

    private void ApplyFontBasedOnLocale(Locale locale)
    {
        if (locale == null)
        {
            Debug.LogWarning("Locale is null.");
            return;
        }

        switch (locale.Identifier.Code)
        {
            case "en":
                currentFont = englishFont;
                currentTMPFont = englishTMPFont;
                break;
            case "fr":
                currentFont = frenchFont;
                currentTMPFont = frenchTMPFont;
                break;
            case "zh":
                currentFont = chineseFont;
                currentTMPFont = chineseTMPFont;
                break;
            default:
                Debug.LogWarning($"Locale code {locale.Identifier.Code} not recognized.");
                return;
        }

        foreach (var text in allTextComponents)
        {
            if (text != null && text.GetComponent<IgnoreFontChange>() == null)
            {
                text.font = currentFont;
            }
        }

        foreach (var textMeshPro in allTMPTextComponents)
        {
            if (textMeshPro != null && textMeshPro.GetComponent<IgnoreFontChange>() == null)
            {
                textMeshPro.font = currentTMPFont;
            }
        }

        UpdateFontTrackerUI();
    }

    private void UpdateFontTrackerUI()
    {
        if (fontTrackerText != null && currentFont != null)
        {
            fontTrackerText.text = $"Current Font: {currentFont.name}";
        }
        else if (fontTrackerText != null)
        {
            fontTrackerText.text = "Current Font: None";
        }

        if (fontTrackerTMPText != null && currentTMPFont != null)
        {
            fontTrackerTMPText.text = $"Current TMP Font: {currentTMPFont.name}";
        }
        else if (fontTrackerTMPText != null)
        {
            fontTrackerTMPText.text = "Current TMP Font: None";
        }
    }

    public static void RegisterTextComponent(Text textComponent)
    {
        if (textComponent != null && !allTextComponents.Contains(textComponent))
        {
            allTextComponents.Add(textComponent);
            if (instance != null && textComponent.GetComponent<IgnoreFontChange>() == null)
            {
                textComponent.font = instance.currentFont;
            }
        }
    }

    public static void RegisterTMPTextComponent(TextMeshProUGUI textMeshProComponent)
    {
        if (textMeshProComponent != null && !allTMPTextComponents.Contains(textMeshProComponent))
        {
            allTMPTextComponents.Add(textMeshProComponent);
            if (instance != null && textMeshProComponent.GetComponent<IgnoreFontChange>() == null)
            {
                textMeshProComponent.font = instance.currentTMPFont;
            }
        }
    }
}
