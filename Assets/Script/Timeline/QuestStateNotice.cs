using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestStateNotice : MonoBehaviour
{
    public Text text; 
    public static void ShowQuestStage(string QuestID, string QuestName, bool success)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M' ? "����" : "֧��";
        string state = success ? "�����" : "��ʧ��";
        string color = success ? "60FF45":"FF0000";
        target.text.text = $"{type}����:{QuestName}<color=#{color}>{state}</color>";
    }
}
