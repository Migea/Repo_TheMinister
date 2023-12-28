using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EdibleType
{
    ��ҩ,
    ��ҩ,
    ����,
    ����,
    ��ʳ,
    ��ʳ,
    ���
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
        {ItemName.�˲�,new List<int>(){2,1}},
        {ItemName.����,new List<int>(){2,1}},
        {ItemName.����,new List<int>(){2,1}},
        {ItemName.ˮ�̻�,new List<int>(){2,1}},
        {ItemName.����,new List<int>(){2,1}},
        {ItemName.�ع�,new List<int>(){2,1}},
        {ItemName.��֥,new List<int>(){10,1}},
        {ItemName.����,new List<int>(){0,0}},
        {ItemName.��ѿ,new List<int>(){0,0}},
        {ItemName.��Ƥ,new List<int>(){0,0}},
        {ItemName.����,new List<int>(){0,0}},
        {ItemName.�컨,new List<int>(){0,0}},
        {ItemName.���ҷ�,new List<int>(){0,0}},
        {ItemName.��,new List<int>(){0,0}},
        {ItemName.����,new List<int>(){0,0}},
        {ItemName.��,new List<int>(){0,0}},
        {ItemName.��,new List<int>(){0,0}},
        {ItemName.ľ������,new List<int>(){0,3}},
        {ItemName.��˷���,new List<int>(){0,3}},
        {ItemName.��������,new List<int>(){0,3}},
        {ItemName.�峴����,new List<int>(){0,3}},
        {ItemName.��޷����,new List<int>(){0,3}},
        {ItemName.ľ����,new List<int>(){0,3}},

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
                ItemName.����,
                ItemName.���ҷ�,
        }

        },
        {EdibleType.����,new List<ItemName>()
        {
                ItemName.��,
                ItemName.����,
                ItemName.��,
                ItemName.��,
        }

        },
        {EdibleType.��ʳ,new List<ItemName>()
        {
                ItemName.ľ������,
                ItemName.��˷���,
                ItemName.��������,
                ItemName.�峴����,
                ItemName.������ݥ,
        }

        },
        {
            EdibleType.��ʳ,new List<ItemName>()
            {
                ItemName.��޷����,
                ItemName.ľ����,
                ItemName.�˱�ҰѼ,
            }
        }
    };
}
