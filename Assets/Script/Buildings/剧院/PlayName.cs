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
            },
            {
                PlayName.�ν���,
                new ArrayList()
                {
                    "�ν���",
                    "�ν�����������ɽʱ��·���ͻ���ָ�˴��ݣ�ֻ�����ӻ���ȡ��һ���ƺ���һ��ں�ֱ�����ڣ���ȭ���žͰ��ͻ��Ʒ���",
                    new List<Tag>()
                    {
                        
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

                    }
                }
                
            }


    };
}