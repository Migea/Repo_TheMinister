using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum QuestType
{
    MainQuest,
    ShopQuest,
    SideQuest,
    StreetQuest
}

public enum QuestLine
{
    //Main
    ̫�ֺ�,

    //Shop


    //Side


    //Street

}

public class QuestLineAgent
{
    private string rootPath = "AllQuests/";
    public QuestType questType;
    public int currentQuestOrder = 0;
    public QuestLine questLine;
    public bool InUse = false;
    public bool Complete => CurrenQuestOnLine == null;

    private string destinationPath;
    public Quest CurrenQuestOnLine
    {
        get
        {
            SetUp();
            string QuestFinalPath = 
                (
                destinationPath 
                + currentQuestOrder 
                + "Q" + questLine.ToString() 
                + currentQuestOrder
                )
                .Replace(" ", string.Empty);
            string FieldFinalPath =
                (
                destinationPath
                + currentQuestOrder
                + "F" + questLine.ToString()
                + currentQuestOrder
                )
                .Replace(" ", string.Empty);
            Quest thisQuest = Resources.Load<Quest>(QuestFinalPath);
            QuestFieldUI thisQuestField = Resources.Load<QuestFieldUI>(FieldFinalPath);
            if (thisQuest == null)
            {
                return null;
            }
            thisQuest.questField = thisQuestField;
            return thisQuest;
        }
    }

    public QuestLineAgent(QuestType questType, QuestLine questLine)
    {
        this.questLine = questLine;
        this.questType = questType;
    }

    private void SetUp()
    {
        destinationPath = rootPath + questType.ToString() + "/"+ questLine.ToString() + "/";
    }

    public void Next()
    {
        currentQuestOrder++;
    }

}
