using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStepMessage : MonoBehaviour
{
    public string QuestID;
    public int Node;

    public static Dictionary<string, List<string>> NodeMessages = new Dictionary<string, List<string>>()
    {
        {"S-01-͵�Թ�Ʒ-a", new List<string>()
            {
                "ǰ�������¡�",
                "ǰ�������¡�",
                "�ڷ����з��ù�Ʒ��",
                "�ڰ����ȴ�������",
                "�ڰ����ȴ�������",
                "��ץ��������"

            }
        },
        {"S-01-ҽ��-a", new List<string>()
            {
                "�۲첡����̦��",
                "�۲첡����̦��",
                "�۲첡����ɫ��",
                "�۲첡����ɫ��",
                "������������",
                "������������",
                "��д���Ʋ�����ҩ����",
                "������ץҩ��",
                "������ץҩ��",

            }
        },
    };

    public string AppointMessage()
    {
        return NodeMessages[QuestID][Node];

    }

}
