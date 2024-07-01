using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEditor.Localization;
using UnityEditorInternal;

namespace PixelCrushers.LocalizationPackageSupport
{

    /// <summary>
    /// Custom editor window to populate Localization Package string table with
    /// fields from a Text Table.
    /// </summary>
    public class TextTableToLocalizationTableWindow : EditorWindow
    {

        [MenuItem("Tools/Pixel Crushers/Common/Third Party/Localization/Text Table To Localization Table", false, 3)]
        public static void Init()
        {
            var window = EditorWindow.GetWindow(typeof(TextTableToLocalizationTableWindow), false, "TextTable To Loc") as TextTableToLocalizationTableWindow;
            window.minSize = new Vector2(300, 280);
        }

        private const string PrefsKey = "PixelCrushers.TextTableToLTPrefs";

        [Serializable]
        public class Prefs
        {
            public List<string> textTableGuids = new List<string>();
            public string localizationSettingsGuid;
            public string stringTableCollectionGuid;
            public string defaultLocaleGuid;
        }

        private Prefs prefs;
        private LocalizationSettings localizationSettings;
        private StringTableCollection stringTableCollection;
        private Locale defaultLocale;
        private List<TextTable> textTables = new List<TextTable>();
        private ReorderableList textTablesList;
        private Vector2 scrollPosition = Vector2.zero;

        private void OnEnable()
        {
            if (EditorPrefs.HasKey(PrefsKey))
            {
                prefs = JsonUtility.FromJson<Prefs>(EditorPrefs.GetString(PrefsKey));
            }
            if (prefs == null) prefs = new Prefs();

            textTables.Clear();
            foreach (var textTableGuid in prefs.textTableGuids)
            {
                if (!string.IsNullOrEmpty(textTableGuid))
                {
                    var textTable = AssetDatabase.LoadAssetAtPath<TextTable>(AssetDatabase.GUIDToAssetPath(textTableGuid));
                    if (textTable != null)
                    {
                        textTables.Add(textTable);
                    }
                }
            }
            localizationSettings = AssetDatabase.LoadAssetAtPath<LocalizationSettings>(AssetDatabase.GUIDToAssetPath(prefs.localizationSettingsGuid));
            stringTableCollection = AssetDatabase.LoadAssetAtPath<StringTableCollection>(AssetDatabase.GUIDToAssetPath(prefs.stringTableCollectionGuid));
            defaultLocale = AssetDatabase.LoadAssetAtPath<Locale>(AssetDatabase.GUIDToAssetPath(prefs.defaultLocaleGuid));
        }

        private void OnDisable()
        {
            prefs.textTableGuids.Clear();
            foreach (var textTable in textTables)
            {
                prefs.textTableGuids.Add((textTable != null) ? AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(textTable)) : string.Empty);
            }
            prefs.localizationSettingsGuid = (localizationSettings != null) ? AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(localizationSettings)) : string.Empty;
            prefs.stringTableCollectionGuid = (stringTableCollection != null) ? AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(stringTableCollection)) : string.Empty;
            prefs.defaultLocaleGuid = (defaultLocale != null) ? AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(defaultLocale)) : string.Empty;
            EditorPrefs.SetString(PrefsKey, JsonUtility.ToJson(prefs));
        }

        private void OnGUI()
        {
            try
            {
                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
                if (textTablesList == null)
                {
                    textTablesList = new ReorderableList(textTables, typeof(TextTable), true, true, true, true);
                    textTablesList.drawHeaderCallback += OnDrawTextTablesListHeader;
                    textTablesList.drawElementCallback += OnDrawTextTablesListElement;
                    textTablesList.onAddCallback += OnAddTextTable;
                }
                textTablesList.DoLayoutList();
                localizationSettings = EditorGUILayout.ObjectField("Localization Settings", localizationSettings, typeof(LocalizationSettings), false) as LocalizationSettings;
                stringTableCollection = EditorGUILayout.ObjectField("String Table", stringTableCollection, typeof(StringTableCollection), false) as StringTableCollection;
                defaultLocale = EditorGUILayout.ObjectField("Default Locale", defaultLocale, typeof(Locale), false) as Locale;
                EditorGUI.BeginDisabledGroup(!HasAnyTextTables() || stringTableCollection == null || defaultLocale == null);
                if (GUILayout.Button("Text Table(s) To String Table"))
                {
                    CopyTextTablesToStringTable();
                }
                if (GUILayout.Button("String Table To Text Table(s)"))
                {
                    CopyStringTableToTextTables();
                }
                EditorGUI.EndDisabledGroup();
            }
            finally
            {
                EditorGUILayout.EndScrollView();
            }
        }

        private bool HasAnyTextTables()
        {
            return textTables.Find(x => x != null) != null;
        }

        private void OnDrawTextTablesListHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Text Tables");
        }

        private void OnDrawTextTablesListElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (!(0 <= index && index < textTables.Count)) return;
            textTables[index] = EditorGUI.ObjectField(rect, textTables[index], typeof(TextTable), true) as TextTable;
        }

        private void OnAddTextTable(ReorderableList list)
        {
            textTables.Add(null);
        }

        private void CopyTextTablesToStringTable()
        {
            try
            {
                var table = stringTableCollection.StringTables.First(x => x.LocaleIdentifier == defaultLocale.Identifier);
                if (table == null)
                {
                    Debug.LogError("Can't find string table for locale " + defaultLocale.Identifier.Code);
                    return;
                }

                float total = 0;
                foreach (var textTable in textTables)
                {
                    if (textTable == null) continue;
                    total += textTable.fields.Count;
                }

                int progress = 0;
                foreach (var textTable in textTables)
                {
                    if (textTable == null) continue;
                    foreach (var field in textTable.fields.Values)
                    {
                        progress++;
                        if (string.IsNullOrEmpty(field.fieldName) || field.texts == null || field.texts.Count == 0) continue;
                        if (EditorUtility.DisplayCancelableProgressBar("Text Table To String Table", field.fieldName, progress / total))
                        {
                            Debug.Log("Cancelled.");
                            return;
                        }
                        table.AddEntry(field.fieldName, field.texts[0]);
                    }
                }

                Debug.Log("Populated Localization Package string table " + stringTableCollection.name + " with text table fields.", stringTableCollection);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

        private void CopyStringTableToTextTables()
        {
            try
            {

                var table = stringTableCollection.StringTables.First(x => x.LocaleIdentifier == defaultLocale.Identifier);
                if (table == null)
                {
                    Debug.LogError("Can't find string table for locale " + defaultLocale.Identifier.Code);
                    return;
                }

                float total = 0;
                foreach (var textTable in textTables)
                {
                    if (textTable == null) continue;
                    total += textTable.fields.Count;
                }

                int progress = 0;
                foreach (var textTable in textTables)
                {
                    if (textTable == null) continue;

                    var languageCodeToTextTableID = new Dictionary<string, int>();
                    foreach (var kvp in textTable.languages)
                    {
                        languageCodeToTextTableID[kvp.Key] = kvp.Value;
                    }
                    foreach (var field in textTable.fields.Values)
                    {
                        progress++;
                        if (string.IsNullOrEmpty(field.fieldName) || field.texts == null || field.texts.Count == 0) continue;
                        if (EditorUtility.DisplayCancelableProgressBar("String Table To Text Table", field.fieldName, progress / total))
                        {
                            Debug.Log("Cancelled.");
                            return;
                        }
                        foreach (var stringTable in stringTableCollection.StringTables)
                        {
                            var stringTableEntry = stringTable.GetEntry(field.fieldName);
                            if (stringTableEntry == null) continue;
                            int languageID;
                            if (languageCodeToTextTableID.TryGetValue(stringTable.LocaleIdentifier.Code, out languageID))
                            {
                                textTable.SetFieldTextForLanguage(field.fieldName, languageID, stringTableEntry.LocalizedValue);
                            }
                        }
                    }
                }

                Debug.Log("Copied Localization Package string table " + stringTableCollection.name + " back to text table fields.", stringTableCollection);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

    }
}
