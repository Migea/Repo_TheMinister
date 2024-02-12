using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPolitcalImpact : MonoBehaviour
{
    public static Dictionary<string, Dictionary<FactionType, string>> QuestInfluenceResult = new Dictionary<string, Dictionary<FactionType, string>>()
    {
        {"S-01-��å�ĵ�Ϸ-c", new Dictionary<FactionType, string>(){{FactionType.��ǧ��,"���ɱ�����µ�һ����Ա����Ȼ�˹�Ա�������ص��Ծ������������ӡ�@-5"} }},
        {"S-01-����-b", new Dictionary<FactionType, string>(){{FactionType.�ڵ�,"���¸�����µ�һ����Ա����Ȼ�˹�Ա�������ص��Ծ������������ӡ�@-3"} }},
        {"S-01-�Ϲ���Ƽ-b", new Dictionary<FactionType, string>(){{FactionType.ʿ���ŷ�,"���¸�����µ�һ����Ա����Ȼ�˹�Ա�������ص��Ծ������������ӡ�@-3"} }},
        {"S-01-���䲻��-b", new Dictionary<FactionType, string>(){{FactionType.ʿ���ŷ�,"���¸�����µ�һ����Ա����Ȼ�˹�Ա�������ص��Ծ������������ӡ�@-3"} }},
        {"S-01-�����ѧ-b", new Dictionary<FactionType, string>(){{FactionType.��ǧ��,"���¸�����µ�һ����Ա�������˾�ǧ��һƬ����@-5"} }},
    };

    public static string resultMessage(string QuestID,FactionType OwnerName)
    {
        if (QuestInfluenceResult.ContainsKey(QuestID))
        {
            return QuestInfluenceResult[QuestID][OwnerName];
        }
        else
            return null;
    } 
}

