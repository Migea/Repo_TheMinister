using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayName
{
    �����𼧰�,
    ��ɮ��ս�׹Ǿ�,
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
            } ,
            {
                PlayName.��ɮ��ս�׹Ǿ�,
                new ArrayList()
                {
                    "��ɮ��ս�׹Ǿ���",
                    "ֻ������ɮ�ý𹿰��ߺ߹��٣�������������Ʒ��˰׹Ǿ���",
                    new List<Tag>()
                    {
                        Tag.ѱ�޴�ʦ,
                        Tag.�Ƶ��ھ�,
                        Tag.���νý�,
                        Tag.��Ƥ��,
                        Tag.��֮��,
                        Tag.Ӫ������,
                        Tag.�ٶ�����,
                        Tag.���в���,
                        Tag.ӥ֮��
                    }
                }
            }
    };
}