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

    public static string AssassinStepMessage()
    {
        return AssassinStepMessages[Random.Range(0, AssassinStepMessages.Length - 1)];
    }
}
