using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace PixelCrushers.DialogueSystem.LocalizationPackageSupport
{

    /// <summary>
    /// Reads localized actor display names and dialogue entry text from
    /// Localization Package string table.
    /// </summary>
    [AddComponentMenu("Pixel Crushers/Dialogue System/UI/Misc/Dialogue System Localization Package Bridge")]
    public class DialogueSystemLocalizationPackageBridge : MonoBehaviour
    {

        public List<LocalizedStringTable> localizedStringTables;
        public Locale defaultLocale;
        public string uniqueFieldTitle = "Guid";

        private List<UnityEngine.Localization.Tables.StringTable> tables = new List<UnityEngine.Localization.Tables.StringTable>();

        private IEnumerator Start()
        {
            yield return LocalizationSettings.InitializationOperation;
            yield return null;
            UpdateActorDisplayNames();
            Localization.language = LocalizationSettings.SelectedLocale.Identifier.Code;
            LocalizationSettings.SelectedLocaleChanged += OnSelectedLocaleChanged;
            CacheStringTables();
        }

        public void CacheStringTables()
        {
            tables.Clear();
            foreach (var table in localizedStringTables)
            {
                if (table != null)
                {
                    tables.Add(table.GetTable());
                }
            }
        }

        private void OnSelectedLocaleChanged(Locale obj)
        {
            UpdateActorDisplayNames();
            Localization.language = LocalizationSettings.SelectedLocale.Identifier.Code;
        }

        public void UpdateActorDisplayNames()
        {
            var locale = LocalizationSettings.SelectedLocale;
            Localization.language = locale.Identifier.Code;
            foreach (var actor in DialogueManager.masterDatabase.actors)
            {
                var guid = actor.LookupValue(uniqueFieldTitle);
                if (!string.IsNullOrEmpty(guid))
                {
                    foreach (var table in tables)
                    {
                        var stringTableEntry = table[guid];
                        if (stringTableEntry != null)
                        {
                            var fieldTitle = (locale == defaultLocale) ? "Display Name" : ("Display Name " + locale.Identifier.Code);
                            DialogueLua.SetActorField(actor.Name, fieldTitle, stringTableEntry.LocalizedValue);
                            break;
                        }
                    }
                }
            }
        }

        public void OnConversationLine(Subtitle subtitle)
        {
            if (string.IsNullOrEmpty(subtitle.formattedText.text)) return;
            var guid = Field.LookupValue(subtitle.dialogueEntry.fields, uniqueFieldTitle);
            foreach (var table in tables)
            {
                var stringTableEntry = table[guid];
                if (stringTableEntry != null)
                {
                    var localizedValue = stringTableEntry.LocalizedValue;
                    subtitle.formattedText = FormattedText.Parse(localizedValue);
                    break;
                }
            }
        }

        public void OnConversationResponseMenu(Response[] responses)
        {
            foreach (Response response in responses)
            {
                var guid = Field.LookupValue(response.destinationEntry.fields, uniqueFieldTitle);
                foreach (var table in tables)
                {
                    var stringTableEntry = table[guid + "_MenuText"];
                    if (stringTableEntry != null)
                    {
                        var localizedValue = (stringTableEntry != null) ? stringTableEntry.LocalizedValue : table[guid].LocalizedValue;
                        response.formattedText = FormattedText.Parse(localizedValue);
                        break;
                    }
                }
            }
        }
    }
}
