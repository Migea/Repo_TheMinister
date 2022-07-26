using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MainCharacterName
{
    �ʵ�,
    ����,
    ̫��,
    ����
}

public class QuestMapAgent : MonoBehaviour
{
    public static Dictionary<MainCharacterName, List<QuestLineAgent>> MainQuestMap
        = new Dictionary<MainCharacterName, List<QuestLineAgent>>()
        {
            { MainCharacterName.�ʵ�,
                new  List<QuestLineAgent>
                {
                    new QuestLineAgent(QuestType.MainQuest, QuestLine.̫�ֺ�)
                } 
            }
        };

    public static Dictionary<BuildingType, List<QuestLineAgent>> ShopQuestMap
        = new Dictionary<BuildingType, List<QuestLineAgent>>()
        {
            {
                BuildingType.���,
                new List<QuestLineAgent>
                {
                    new QuestLineAgent(QuestType.MainQuest, QuestLine.̫�ֺ�)
                }
            }
        };


    public QuestLineAgent LoadShopQuest(BuildingType buildingType)
    {
        var AvailableQuestList = ShopQuestMap[buildingType];
        var outPutQuestLine = CatchNotInUseQuest(AvailableQuestList);
        outPutQuestLine.InUse = true;
        return outPutQuestLine;
    }

    
    public QuestLineAgent CatchNotInUseQuest(List<QuestLineAgent> questLineAgents)
    {
        int index = Random.Range(0, questLineAgents.Count);
        var outPutQuestLine = questLineAgents[index];
        if (outPutQuestLine.InUse)
        {
            var newQuestLineAgents = questLineAgents;
            newQuestLineAgents.RemoveAt(index);
            return CatchNotInUseQuest(newQuestLineAgents);
        }
        return outPutQuestLine;
    }

    
}
