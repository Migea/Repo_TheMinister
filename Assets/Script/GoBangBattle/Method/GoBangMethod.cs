using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBangMethod
{
    public static Dictionary<Tag, ArrayList> TagToMethodEffect =
        new Dictionary<Tag, ArrayList>()
        {
            { Tag.���, new ArrayList (){new BoxMethod(), 0} },
            { Tag.Χ��ʮ��, new ArrayList (){new BoxMethod(), 1} },
            { Tag.����˫ȫ, new ArrayList(){new DestroyMethod(),0 } },
            { Tag.�����ļ�, new ArrayList(){new DestroyMethod(),1 } },
            { Tag.����, new ArrayList(){new DestroyMethod(),2 } },
            { Tag.�ݺ��, new ArrayList(){new DestroyMethod(),3 } },
            { Tag.С��ı��, new ArrayList(){new DestroyMethod(),4 } },
            { Tag.������ı, new ArrayList(){new DestroyMethod(),5 } },
            { Tag.�����·�, new ArrayList(){new DestroyMethod(),100 } },
            { Tag.Ͷ��ȡ��, new ArrayList(){new DestroyMethod(),20 } },
            { Tag.�������, new ArrayList(){new DestroyMethod(),10 } },
            { Tag.���Ŷݼ�, new ArrayList(){new DestroyMethod(),5 } },
        };
    public static GoBangMainLoop CurrentGame()
    {
        return UnityEngine.GameObject.FindObjectOfType<GoBangMainLoop>();
    }
    public virtual void Run(GoBangMainLoop.point local, int effect)
    {

    }
}
