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

namespace PixelCrushers.DialogueSystem.LocalizationPackageSupport
{

    /// <summary>
    /// Custom editor window to populate Localization Package string table with
    /// actor names and dialogue entry text. At runtime, DialogueSystemLocalizationPackageBridge
    /// will read localized values from string table.
    /// </summary>
    public class DialogueToLocalizationTableWindow : EditorWindow
    {

        [MenuItem("Tools/Pixel Crushers/Dialogue System/Third Party/Localization/Dialogue To Localization Table", false, 3)]
        public static void Init()
        {
            var window = EditorWindow.GetWindow(typeof(DialogueToLocalizationTableWindow), false, "DS To Loc") as DialogueToLocalizationTableWindow;
            window.minSize = new Vector2(300, 180);
        }

        private const string PrefsKey = "DialogueSystem.DSToLTPrefs";

        [Serializable]
        public class Prefs
        {
            public List<string> databaseGuids = new List<string>();
            public string localizationSettingsGuid;
            public string stringTableCollectionGuid;
            public string defaultLocaleGuid;
            public string guidFieldTitle = "Guid";
        }

        private Prefs prefs;
        private LocalizationSettings localizationSettings;
        private StringTableCollection stringTableCollection;
        private Locale defaultLocale;
        private List<DialogueDatabase> databases = new List<DialogueDatabase>();
        private ReorderableList databasesList;
        private Vector2 scrollPosition = Vector2.zero;

        private void OnEnable()
        {
            if (EditorPrefs.HasKey(PrefsKey))
            {
                prefs = JsonUtility.FromJson<Prefs>(EditorPrefs.GetString(PrefsKey));
            }
            if (prefs == null) prefs = new Prefs();

            databases.Clear();
            foreach (var databaseGuid in prefs.databaseGuids)
            {
                if (!string.IsNullOrEmpty(databaseGuid))
                {
                    var database = AssetDatabase.LoadAssetAtPath<DialogueDatabase>(AssetDatabase.GUIDToAssetPath(databaseGuid));
                    databases.Add(database);
                }
            }
            localizationSettings = AssetDatabase.LoadAssetAtPath<LocalizationSettings>(AssetDatabase.GUIDToAssetPath(prefs.localizationSettingsGuid));
            stringTableCollection = AssetDatabase.LoadAssetAtPath<StringTableCollection>(AssetDatabase.GUIDToAssetPath(prefs.stringTableCollectionGuid));
            defaultLocale = AssetDatabase.LoadAssetAtPath<Locale>(AssetDatabase.GUIDToAssetPath(prefs.defaultLocaleGuid));
        }

        private void OnDisable()
        {
            prefs.databaseGuids.Clear();
            foreach (var database in databases)
            {
                prefs.databaseGuids.Add((database != null) ? AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(database)) : string.Empty);
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
                if (databasesList == null)
                {
                    databasesList = new ReorderableList(databases, typeof(DialogueDatabase), true, true, true, true);
                    databasesList.drawHeaderCallback += OnDrawDatabasesListHeader;
                    databasesList.drawElementCallback += OnDrawDatabasesListElement;
                    databasesList.onAddCallback += OnAddDatabase;
                }
                databasesList.DoLayoutList();
                prefs.guidFieldTitle = EditorGUILayout.TextField(new GUIContent("Unique Field Title", "Field title to use/create in dialogue database to uniquely and persistently identify each Key in string table."), prefs.guidFieldTitle);
                localizationSettings = EditorGUILayout.ObjectField("Localization Settings", localizationSettings, typeof(LocalizationSettings), false) as LocalizationSettings;
                stringTableCollection = EditorGUILayout.ObjectField("String Table", stringTableCollection, typeof(StringTableCollection), false) as StringTableCollection;
                defaultLocale = EditorGUILayout.ObjectField("Default Locale", defaultLocale, typeof(Locale), false) as Locale;
                EditorGUI.BeginDisabledGroup(!HasAnyDatabases() || stringTableCollection == null || defaultLocale == null || string.IsNullOrEmpty(prefs.guidFieldTitle));
                if (GUILayout.Button("Dialogue To String Table"))
                {
                    CopyDialogueToStringTable();
                }
                EditorGUI.EndDisabledGroup();
            }
            finally
            {
                EditorGUILayout.EndScrollView();
            }
        }

        private bool HasAnyDatabases()
        {
            return databases.Find(x => x != null) != null;
        }

        private void OnDrawDatabasesListHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Databases");
        }

        private void OnDrawDatabasesListElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (!(0 <= index && index < databases.Count)) return;
            databases[index] = EditorGUI.ObjectField(rect, databases[index], typeof(DialogueDatabase), true) as DialogueDatabase;
        }

        private void OnAddDatabase(ReorderableList list)
        {
            databases.Add(null);
        }

        private void CopyDialogueToStringTable()
        {
            try
            {

                Undo.RecordObjects(new UnityEngine.Object[] { stringTableCollection.SharedData, stringTableCollection }, "Modified table");

                var table = stringTableCollection.StringTables.First(x => x.LocaleIdentifier == defaultLocale.Identifier);
                if (table == null)
                {
                    Debug.LogError("Can't find string table for locale " + defaultLocale.Identifier.Code);
                    return;
                }

                var hasRecordedDatabaseUndo = false;
                float total = 0;
                foreach (var database in databases)
                {
                    if (database == null) continue;
                    total += database.actors.Count + database.conversations.Count;
                }
                int progress = 0;

                // Actor display names:
                foreach (var database in databases)
                {
                    if (database == null) continue;
                    foreach (var actor in database.actors)
                    {
                        progress++;
                        if (EditorUtility.DisplayCancelableProgressBar("Dialogue To String Table", actor.Name, progress / total))
                        {
                            Debug.Log("Cancelled.");
                            return;
                        }

                        // Get actor guid:
                        var field = Field.Lookup(actor.fields, prefs.guidFieldTitle);
                        if (field == null)
                        {
                            if (!hasRecordedDatabaseUndo)
                            {
                                hasRecordedDatabaseUndo = true;
                                Undo.RecordObject(database, "Modify database");
                            }
                            field = new Field(prefs.guidFieldTitle, Guid.NewGuid().ToString(), FieldType.Text);
                            actor.fields.Add(field);
                        }

                        var actorDisplayName = actor.FieldExists("Display Name") ? actor.LookupValue("Display Name") : actor.Name;
                        table.AddEntry(field.value, actorDisplayName);
                    }
                }

                // Conversations:
                foreach (var database in databases)
                {
                    if (database == null) continue;
                    foreach (var conversation in database.conversations)
                    {
                        progress++;
                        if (EditorUtility.DisplayCancelableProgressBar("Dialogue To String Table", conversation.Title, progress / total))
                        {
                            Debug.Log("Cancelled.");
                            return;
                        }

                        foreach (var entry in conversation.dialogueEntries)
                        {
                            // Get dialogue entry guid:
                            var field = Field.Lookup(entry.fields, prefs.guidFieldTitle);
                            if (field == null)
                            {
                                if (!hasRecordedDatabaseUndo)
                                {
                                    hasRecordedDatabaseUndo = true;
                                    Undo.RecordObject(database, "Modify database");
                                }
                                field = new Field(prefs.guidFieldTitle, Guid.NewGuid().ToString(), FieldType.Text);
                                entry.fields.Add(field);
                            }

                            // Add localized entries:
                            table.AddEntry(field.value, entry.DialogueText);
                            if (!string.IsNullOrEmpty(entry.MenuText))
                            {
                                table.AddEntry(field.value + "_MenuText", entry.MenuText);
                            }
                        }
                    }
                }

                Debug.Log("Populated Localization Package string table " + stringTableCollection.name + " with dialogue database fields.", stringTableCollection);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

    }
}

