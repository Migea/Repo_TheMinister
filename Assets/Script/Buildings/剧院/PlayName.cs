using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayName
{
    �����𼧰�
}

public static class PlayList
{
    public static Dictionary<PlayName, ArrayList> PlayListDict
        = new Dictionary<PlayName, ArrayList>()
    {
            {
                PlayName.�����𼧰�,
                new ArrayList()
                {
                    "�������𼧰ɣ�",
                    "��������Ҫ�����ﲻ�У���������ʺ�ĵط�����Ҫ����Ͱ����",
                    new List<Tag>()
                    {
                        Tag.ϰ��֮��,
                        Tag.������,
                        Tag.ͷ��,
                        Tag.Ϸ��,
                        Tag.��ϲ��,
                        Tag.���в���,
                        Tag.��������,
                        Tag.���,
                        Tag.ӥ֮��
                    }
                }
            }
    };
}