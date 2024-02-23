using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepMessage : MonoBehaviour
{

    public static string[] AssassinStepMessages = new string[]
    {
         "�����������أ��۲�Ŀ�ꡣ",
         "�����г��ϻ켣����Ϥ��Χ�Ľֵ�����Ū��",
         "���������������һ��ذ�ס�",
         "���ڻ��ƴ�ɱ�ƻ�����ϸ��ͼ��",
         "�������Ŀ���Ŀ���ס����",
         "���ڲ���м�װ���죬�Ѽ�����Ŀ����л���",
         "���������°��й۲�Ŀ�����ӡ�",
         "����ҹ��̽����ǽ�µ�����ͨ����",
         "���ڲ��Զ�ҩ��Ч����",
         "����ҹ����ϰ���ݶ������Ծ��",
         "�����м��мٰ�С����ע��Ŀ��Ļ��",
         "���ڸ����Ϲ۲������ж�����ж�ʱ����",
         "���ڻ���ҹ���¡�",
         "������������ߺ�����αװ���ߡ�",
         "���ڹ۲�Ŀ�������ϰ�ߺ�ƫ�á�",
         "�������й�עĿ������¶�̬�ͱ仯��",
         "���ڽ���ڤ�룬���ȶ���̬�ͼ��о���"
    };

    public static string[] AssassinCompleteMessages = new string[]
    {
        "���������ֳ�",
        "����αװ�����˳����ֳ�",
        "�������ظɲݵ������뿪��",
        "�����ú�ˮ��ϴ�������ϵ�Ѫ����",
        "������������ʹ�õĴ�ɱ���ߡ�",
        "��ʱ������ƫƧ�������ڡ�"
    };

    public static string[] AssassinFailMessages = new string[]
    {
        "��һ������ͬ������Χ������·���ӡ�",
        "Ϊ�˱��ܣ����²��ж�ҩ�ļ�����",
        "��Ǳ��ʱ��ݱ���¶��",
        "��ɱʱ�����������������֡�",
        "���������ʱ������ע�⡣"

    };
    public static string AssassinStepMessage()
    {
        return AssassinStepMessages[Random.Range(0, AssassinStepMessages.Length - 1)];
    }

    public static string AssassinCompleteStepMessage()
    {
        return AssassinCompleteMessages[Random.Range(0, AssassinCompleteMessages.Length - 1)];
    }

    public static string AssassinFailStepMessage()
    {
        return AssassinFailMessages[Random.Range(0, AssassinFailMessages.Length - 1)];
    }

    public static Dictionary<string, List<string>> AppointQuestMessages = new Dictionary<string, List<string>>
    {
        {"S-01-͵�Թ�Ʒ-a", new List<string>()
        {
            "����ǰ�������¡�",
            "���ڲ����ն���",
            "���ڲ����ն���"
        } },
        {"S-01-ҽ��-a", new List<string>()
        {
            "����ǰ���޷��˼��С�",
            "����Ϊ�޷��˺��Ӱ�����ϡ�",
            "���ڿ���ҩ����"
        } },
        {"S-01-ץ��-a", new List<string>()
        {
            "����Χ׷������",
            "���ڲ���ƶ���"
        } },
        {"S-01-ʩ��-a", new List<string>()
        {
            "���ڰ������С��ַ����ࡣ",
            "���ڸ���ǰ�����µ�����",
            "���ڰ�æ��̯��"
        } },
        {"S-01-��ѧϰ�������-a", new List<string>()
        {
            "���ڽ���дʫ���ĵá�",
            "���ھ��������ǵķ�����",
            "���ڽ��������Ǵ󾸵����ǡ�"
        } },
        {"S-01-�������-a", new List<string>()
        {
            "���ڸ�����ΰ���С�",
            "����ץ��Χס��ΰ�ҵĻ�졣",
            "���������ʻ�졣"
        } },
        {"S-01-�ɻ�-a", new List<string>()
        {
            "����ǰ���ǽ���",
            "������ѡ���䡣"
        } },




    };
    public static Dictionary<string, string> AppointSuccessQuestMessages = new Dictionary<string, string>
    {
        {"S-01-͵�Թ�Ʒ-a", "����͵�Թ�Ʒ��������" },
        {"S-01-ҽ��-a", "�޷��˵ĺ��ӳ���ҩ�����к�ת��" },
        {"S-01-ץ��-a", "����δ���ҵ����ˡ�" },
        {"S-01-ʩ��-a", "��С���ʩ��Բ���ɹ���" },
        {"S-01-��ѧϰ�������-a", "�����ǶԴ˴εĽ��������⡣" },
        {"S-01-�������-a","��칩����Ļ����ʹ��" },
        {"S-01-�ɻ�-a" ,"�����õ�����ʮ�ָ��ˡ�"}
    };

    public static string AppointMessage(string QuestID, int Step)
    {
        string succMessage;
        List<string> stepMessages = new List<string>();
        var target = StepMessage.AppointQuestMessages;
        if (Step != 0)
        {
            if (target.ContainsKey(QuestID))
            {
                Step--;
                target.TryGetValue(QuestID, out stepMessages);
                var targetList = stepMessages;
                targetList.Reverse();
                return targetList[Step];
            }
            else
            {
                return null;

            }


        }
        else
        {
            var sucTarget = StepMessage.AppointSuccessQuestMessages;
            sucTarget.TryGetValue(QuestID, out succMessage);
            return succMessage;
        }
    }
}
