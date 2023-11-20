using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNotice : MonoBehaviour
{
    public Text text;
    private static string reciveQuestTitle = "<size=30>���ڽ���</size>\n";
    private static string finishQuestTitle = "<size=30>�ɹ����</size>\n";
    private static string failQuestTitle = "<size=30>δ�����</size>\n";
    public static void ShowQuestConfirm(string QuestID, string QuestName)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M' ? "����" : "֧��";
        target.text.text = $"{reciveQuestTitle}{type}����<color=#4F3C34>{QuestName}</color>";
    }
    public static void ShowQuestFinishConfirm(string QuestID, string QuestName)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M' ? "����" : "֧��";
        target.text.text = $"{finishQuestTitle}{type}����<color=#234619>{QuestName}</color>";
    }    
    public static void ShowQuestFailConfirm(string QuestID, string QuestName)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M' ? "����" : "֧��";
        target.text.text = $"{failQuestTitle}{type}����<color=#B01717>{QuestName}</color>";
    }
}
