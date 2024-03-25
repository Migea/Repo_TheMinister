using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum EdibleType
{
    ��ҩ,
    ��ҩ,
    ����,
    ����,
    ��ʳ,
    ��ʳ,
    ���,
    ��ˮ,
    ��ҩ
};
public class EdiblesItems : MonoBehaviour
{


    // Start is called before the first frame update
    public static Dictionary<ItemName, List<int>> FoodRecovery = new Dictionary<ItemName, List<int>>()
    {
        {ItemName.������,new List<int>(){-3,0}},
        {ItemName.����,new List<int>(){-3,0}},
        {ItemName.�˽���,new List<int>(){-3,0}},
        {ItemName.����,new List<int>(){-3,0}},
        {ItemName.�޺���,new List<int>(){-3,0}},
        {ItemName.Ѫ����,new List<int>(){-3,0}},
        {ItemName.�ƾ�,new List<int>(){-3,0}},
        {ItemName.�׻������,new List<int>(){-3,0}},
        {ItemName.����,new List<int>(){-3,0}},
        {ItemName.���,new List<int>(){-3,0}},
        {ItemName.��ɽ��,new List<int>(){-3,0}},
        {ItemName.�ǳ���,new List<int>(){-3,0}},
        {ItemName.����,new List<int>(){-3,0}},
        {ItemName.�˲�,new List<int>(){2,1}},
        {ItemName.����,new List<int>(){2,1}},
        {ItemName.����,new List<int>(){2,1}},
        {ItemName.ˮ�̻�,new List<int>(){2,1}},
        {ItemName.����,new List<int>(){2,1}},
        {ItemName.�ع�,new List<int>(){2,1}},
        {ItemName.������,new List<int>(){1,0}},
        {ItemName.��֥,new List<int>(){10,1}},
        {ItemName.����,new List<int>(){0,1}},
        {ItemName.��ѿ,new List<int>(){0,1}},
        {ItemName.��Ƥ,new List<int>(){0,1}},
        {ItemName.����,new List<int>(){0,1}},
        {ItemName.�컨,new List<int>(){0,1}},
        {ItemName.���ҷ�,new List<int>(){0,1}},
        {ItemName.����,new List<int>(){0,1}},
        {ItemName.��,new List<int>(){0,1}},
        {ItemName.����,new List<int>(){0,1}},
        {ItemName.��,new List<int>(){0,1}},
        {ItemName.��,new List<int>(){0,1}},
        {ItemName.�����,new List<int>(){0,1}},
        {ItemName.ľ������,new List<int>(){0,5}},
        {ItemName.��˷���,new List<int>(){0,5}},
        {ItemName.��������,new List<int>(){0,5}},
        {ItemName.�峴����,new List<int>(){0,5}},
        {ItemName.�����ײ�,new List<int>(){0,7}},
        {ItemName.������ݥ,new List<int>(){0,7}},
        {ItemName.�峴��ѿ,new List<int>(){0,4}},
        {ItemName.�Ļƹ�,new List<int>(){0,4}},
        {ItemName.������,new List<int>(){0,4}},
        {ItemName.�������ܲ�,new List<int>(){0,4}},
        {ItemName.��޷����,new List<int>(){0,5}},
        {ItemName.ľ����,new List<int>(){0,5}},
        {ItemName.�˱�ҰѼ,new List<int>(){0,7}},
        {ItemName.���ֽ��,new List<int>(){0,7}},
        {ItemName.ˮ��,new List<int>(){-2,0}},
        {ItemName.����,new List<int>(){-4,0}},
        {ItemName.���,new List<int>(){-1,0}},
        {ItemName.�ƾ�,new List<int>(){-1,0}},
        {ItemName.���,new List<int>(){-1,0}},
        {ItemName.«��,new List<int>(){-1,0}},
        {ItemName.���ʾ�,new List<int>(){-1,0}},
        {ItemName.������,new List<int>(){-1,0}},
        {ItemName.��Ҷ��,new List<int>(){1,0}},
        {ItemName.�ſ���,new List<int>(){1,0}},
        {ItemName.Ů����,new List<int>(){1,0}},
        {ItemName.���ξ�,new List<int>(){2,0}},
        {ItemName.��ζ��,new List<int>(){2,0}},
        {ItemName.������,new List<int>(){4,0}},
        {ItemName.ֹѪ��,new List<int>(){4,0}},
        {ItemName.��ҩ,new List<int>(){4,0}},
        {ItemName.���ӵ�,new List<int>(){-1,0}},
        {ItemName.������,new List<int>(){1,0}},
        {ItemName.ϴ�赤,new List<int>(){1,0}},
        {ItemName.������,new List<int>(){2,0}},
        {ItemName.��������ɢ,new List<int>(){2,0}},
        {ItemName.����컯��,new List<int>(){3,0}},
        {ItemName.����������,new List<int>(){10,0}},
        {ItemName.��������ҩ,new List<int>(){20,0}},
        {ItemName.ʮȫ����,new List<int>(){20,0}},
        {ItemName.����,new List<int>(){0,10}},
    };
    public static EdibleType RandomFavor()
    {
        List<EdibleType> list = new List<EdibleType>();
        foreach (EdibleType type in Enum.GetValues(typeof(EdibleType)))
        {
            list.Add(type);
        }
        int index = UnityEngine.Random.Range(0, list.Count);
        return list[index];
    }

    public static Dictionary<EdibleType, List<ItemName>> EdibleTypeDict = new Dictionary<EdibleType, List<ItemName>>()
    {
        {EdibleType.��ҩ,new List<ItemName>()
        {
        ItemName.������,
        ItemName.����,
        ItemName.�˽���,
        ItemName.����,
        ItemName.�޺���,
        ItemName.Ѫ����,
        ItemName.�ƾ�,
        ItemName.�׻������,
        ItemName.����,
        ItemName.���,
        ItemName.��ɽ��,
        ItemName.�ǳ���,
        ItemName.����,
        }
    },
            {EdibleType.��ҩ,new List<ItemName>()
        {
                ItemName.�˲�,
                ItemName.����,
                ItemName.����,
                ItemName.ˮ�̻�,
                ItemName.����,
                ItemName.�ع�,
                ItemName.������,
                ItemName.��֥,
        }

        },
        {EdibleType.����,new List<ItemName>()
        {
                ItemName.����,
                ItemName.��ѿ,
                ItemName.��Ƥ,
                ItemName.����,
                ItemName.�컨,
                ItemName.���ҷ�,
                ItemName.����
        }

        },
        {EdibleType.����,new List<ItemName>()
        {
                ItemName.��,
                ItemName.����,
                ItemName.��,
                ItemName.��,
                ItemName.�����
        }

        },
        {EdibleType.��ʳ,new List<ItemName>()
        {
                ItemName.ľ������,
                ItemName.��˷���,
                ItemName.��������,
                ItemName.�峴����,
                ItemName.�����ײ�,
                ItemName.������ݥ,
                ItemName.�峴��ѿ,
                ItemName.�Ļƹ�,
                ItemName.������,
                ItemName.�������ܲ�,
                ItemName.����
        }

        },
        {
            EdibleType.��ʳ,new List<ItemName>()
            {
                ItemName.��޷����,
                ItemName.ľ����,
                ItemName.�˱�ҰѼ,
                ItemName.���ֽ��
            }
        },
         {
            EdibleType.��ˮ,new List<ItemName>()
            {
                ItemName.ˮ��,
                ItemName.����,
                ItemName.���,
                ItemName.�ƾ�,
                ItemName.���,
                ItemName.«��,
                ItemName.���ʾ�,
                ItemName.������,
                ItemName.��Ҷ��,
                ItemName.�ſ���,
                ItemName.Ů����,
                ItemName.���ξ�,
                ItemName.��ζ��,
                ItemName.������
            }
        },
         {
            EdibleType.��ҩ,new List<ItemName>()
            {
                ItemName.ֹѪ��,
                ItemName.��ҩ,
                ItemName.���ӵ�,
                ItemName.������,
                ItemName.ϴ�赤,
                ItemName.������,
                ItemName.��������ɢ,
                ItemName.����컯��,
                ItemName.����������,
                ItemName.��������ҩ,
                ItemName.ʮȫ����
            }
        },
    };

    public static Dictionary<ItemName, Tag> ItemToTempDict = new Dictionary<ItemName, Tag>()
    {
        {ItemName.�˲�,Tag.��Ѫ},
        {ItemName.����,Tag.����},
        {ItemName.����,Tag.����},
        {ItemName.����,Tag.�ж�},
        {ItemName.������,Tag.����},
        {ItemName.ϴ�赤,Tag.����},
        {ItemName.������,Tag.����},
        {ItemName.��������ɢ,Tag.����},
        {ItemName.����컯��,Tag.����},
    };
    public static Dictionary<ItemName, int> ItemTempDuration = new Dictionary<ItemName, int>()
    {
        {ItemName.�˲�,4},
        {ItemName.����,4},
        {ItemName.����,4},
        {ItemName.����,6},
        {ItemName.������,2},
        {ItemName.ϴ�赤,2},
        {ItemName.������,3},
        {ItemName.��������ɢ,3},
        {ItemName.����컯��,4},

    };
    public static bool IsEdible(ItemName item)
    {
        if (FoodRecovery.Keys.ToList().Contains(item)) return true;
        return false;
    }
    public static EdibleType GetEdibleType(ItemName item)
    {
        foreach (var unit in EdibleTypeDict)
        {
            if (unit.Value.Contains(item))
            {
                return unit.Key;
            }
        }
        return EdibleType.��ҩ;
    }
}
