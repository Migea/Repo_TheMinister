using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayName
{
    �����𼧰�,
    ��ɮ��ս�׹Ǿ�,
    �ν���,
    ʮ�����,
    ���ϵ��������,
    ������,
    ����,
    ���������˽���,
}

public static class PlayList
{
    public static Dictionary<PlayName, ArrayList> PlayListDict
        = new Dictionary<PlayName, ArrayList>()
    {
            {
                PlayName.��ɮ��ս�׹Ǿ�,
                new ArrayList()
                {
                    "��ɮ��ս�׹Ǿ���",
                    "ֻ������ɮ�ý𹿰��ߺ߹��٣�������������Ʒ��˰׹Ǿ���",
                    new List<Tag>()
                    {
                        Tag.ӥ֮��,
                        Tag.��Ϸ��
                    }
                }
            },
            {
                PlayName.�ν���,
                new ArrayList()
                {
                    "�ν���",
                    "�ν�����������ɽʱ��·���ͻ���ָ�˴��ݣ�ֻ�����ӻ���ȡ��һ���ƺ���һ��ں�ֱ�����ڣ���ȭ���žͰ��ͻ��Ʒ���",
                    new List<Tag>()
                    {
                        Tag.����
                    }
                }
            },
            {
                PlayName.ʮ�����,
                new ArrayList()
                {
                    "ʮ�����",
                    "������������������Я��ʮ����������������ס��ֻ��ʤ������һֻ���ȴͻȻ�ӿ��и�����£�������Ȼץס�˴�������ȥ����Ц������û�뵽�ɣ�������ҵ�����·�ߣ���",
                    new List<Tag>()
                    {
                        Tag.����,
                        Tag.�
                    }
                }

            },
            {
                PlayName.���ϵ��������,
                new ArrayList()
                {
                    "���ϵ��������",
                    "���ռֱ���͵͵����鷿��һ��ͤ�ͻ�������һ������ͤ�����������Ŵ����˹����������������ǰ�鿴�����־���һ׳������ͷ���ۣ���򢻢�롣",
                    new List<Tag>()
                    {
                        Tag.��Ƥ��,
                        Tag.��������
                    }
                }

            },
            {
                PlayName.������,
                new ArrayList()
                {
                    "������",
                    "������ʱ������κ����������ǰ��˵���˱����������������Ϊ�޳�����������δ������˺����޳�֮�ˣ�������������׹�����£���ȥ��",
                    new List<Tag>()
                    {
                        Tag.С��ı��,
                        Tag.��ʦ,
                    }
                }
            },
            {
                PlayName.����,
                new ArrayList()
                {
                    "����",
                    "����㿴�����ⳡ�磬����Ϳ������ⳡ�硣����㿴�������Ľ�֣���ô��Ϳ����˽�֡�",
                    new List<Tag>()
                    {
                        Tag.�Ļ�ɳĮ,
                    }
                }
            },
            {
                PlayName.���������˽���,
                new ArrayList()
                {
                    "���������˽���",
                    "��磬��һֱ�����ҽ���ǲ��������ɡ�",
                    new List<Tag>()
                    {
                        Tag.������,
                        Tag.��ⱦ��
                    }
                }
                
            }
    };
}