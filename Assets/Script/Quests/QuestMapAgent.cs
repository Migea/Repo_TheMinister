using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMapAgent : MonoBehaviour
{
    public static Dictionary<QuestLine, QuestLineAgent> QuestMap
        = new Dictionary<QuestLine, QuestLineAgent>()
        {
            { QuestLine.̫�ֺ�, new QuestLineAgent(QuestType.MainQuest, QuestLine.̫�ֺ�)}
        };
}
