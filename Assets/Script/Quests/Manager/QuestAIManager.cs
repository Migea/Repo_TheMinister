using PixelCrushers.QuestMachine;
using PixelCrushers.QuestMachine.Wrappers;
using SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class QuestAIManager : MonoBehaviour, IDiceRollEvent
{
    public static QuestAIManager Instance;
    public ChapterCounter chapterCounter => ChapterCounter.Instance;
    public SOSubQuestDB subQuestDB;
    public string CurrentSave = string.Empty;
    public QUEST_GIVER_BY_ORDER CurrentQuestList => subQuestDB.QUEST_GIVER_BY_ORDER[chapterCounter.Chapter];
    public List<QuestGiverAI> InactiveQuestGivers = new List<QuestGiverAI>();
    public List<QuestGiverAI> ActiveQuestsGivers = new List<QuestGiverAI>();
    private int inGameQuestCount = 0;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            Dice.Instance.RegisterObserver(this);
        }
        else
        {
            Destroy(this);
        }
        if (subQuestDB != null)
        {
            if (subQuestDB.CurrentSave != CurrentSave) subQuestDB.NewCurrent(CurrentSave);
            CloneList();
        }
    }
    public void QuestCountAdd()
    {
        inGameQuestCount++;
    }
    public void QuestCountMinus()
    {
        inGameQuestCount--;
    }
    public void QuestCountZero()
    {
        inGameQuestCount = 0;
    }
    public void TryActiveNextQuest()
    {
        if (inGameQuestCount < 7)
            ActiveNextQuest();
    }

    public void ActiveNextQuest()
    {
        if (InactiveQuestGivers == null || InactiveQuestGivers.Count == 0) return;
        QuestGiverAI spawnAI = null;
        for (int i = 0; i < InactiveQuestGivers.Count; i++)
        {
            var target = InactiveQuestGivers[i];
            Func<bool> SingleQuest = () => target.QuestChainName == string.Empty;
            Func<bool> InOrderChainQuest = () => target.QuestChainOrder == subQuestDB.CurrentQuestChainOrder(target.QuestChainName);
            if (SingleQuest.Invoke())
            {
                spawnAI = target;
                break;
            }
            else if (InOrderChainQuest.Invoke())
            {
                spawnAI = target;
                break;
            }
        }
        if (spawnAI != null)
        {
            if (spawnAI.QuestSpawnPref != null)
            {
                Instantiate(spawnAI.QuestSpawnPref, transform);
            }
            else
            {
                var spawnedClone = Instantiate(spawnAI, transform);
            }
            InactiveQuestGivers.Remove(spawnAI);
            ActiveQuestsGivers.Add(spawnAI);
            QuestCountAdd();
        }
    }
    public void CloneList()
    {
        InactiveQuestGivers = new List<QuestGiverAI>(CurrentQuestList.questGivers);
    }
    public void Save(GameSave gameSave)
    {
        //save quest chain states
        gameSave.questChainStateWrapper = subQuestDB.CURRENT.Clone() as QuestChainStateWrap;
        gameSave.InactiveQuestGivers = InactiveQuestGivers;

        //save quest current states and showed quest gameobjects.
        foreach (var questGiver in ActiveQuestsGivers)
        {
            if (questGiver.triggered)
            {
                gameSave.TriggeredQuestGivers.Add(questGiver);
            }
            else
            {
                gameSave.UntriggeredQuestGivers.Add(questGiver);
            }
        }
    }

    public void Load(GameSave gameSave)
    {
        subQuestDB.CURRENT = gameSave.questChainStateWrapper;

        InactiveQuestGivers = gameSave.InactiveQuestGivers;

        var untriggereds = gameSave.UntriggeredQuestGivers;
        foreach (var untriggered in untriggereds)
        {
            if (untriggered.QuestSpawnPref != null)
            {
                Instantiate(untriggered.QuestSpawnPref, transform);
            }
            else
            {
                var spawnedClone = Instantiate(untriggered, transform);
            }
            InactiveQuestGivers.Remove(untriggered);
            ActiveQuestsGivers.Add(untriggered);
        }

        var triggereds = gameSave.TriggeredQuestGivers;
        foreach (var triggered in triggereds)
        {
            Instantiate(triggered.ReloadPref, transform);
            ActiveQuestsGivers.Add(triggered);
        }
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        TryActiveNextQuest();
    }
}
