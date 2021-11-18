using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameItemFile")]
public class SOItem : ScriptableObject
{
    
    public static Dictionary<ItemName, Tag> ItemMap = new Dictionary<ItemName, Tag>() 
    {
        {ItemName.ɽ����,Tag.��ͨ����},
        {ItemName.���زо�,Tag.��ʦ},
        {ItemName.����������,Tag.���Ŷݼ�},
        {ItemName.��󡹦�ؼ�,Tag.��󡹦},
        {ItemName.������,Tag.ͨ������},
        {ItemName.��˪����,Tag.��˪����},
        {ItemName.����,Tag.����},
        {ItemName.����ʵ�,Tag.������},
        {ItemName.����ʵ�,Tag.������},
        {ItemName.����,Tag.�ܸ�����},
        {ItemName.�Ӽ�,Tag.�����弼},
        {ItemName.���ӵ�,Tag.������},
        {ItemName.����,Tag.���в���},
        {ItemName.����,Tag.ҹ������},
        {ItemName.��,Tag.��},
        {ItemName.ë��,Tag.����},
        {ItemName.����,Tag.��ʿ},
        {ItemName.����,Tag.ɮ��}
    };
    public static Dictionary<ItemType, List<ItemName>> ItemTypeDict = new Dictionary<ItemType, List<ItemName>>()
    {
        { 
            ItemType.����, new List<ItemName>()
            {
                ItemName.��˪����,
                ItemName.����,
                ItemName.ŷұ�ӵĴ�,
                ItemName.ŷұ�ӵ�С��,
                ItemName.��,
                ItemName.��,
                ItemName.ǹ,
                ItemName.��,
                ItemName.�
            }
        },
        {
            ItemType.��ҩ, new List<ItemName>()
            {
                ItemName.���ӵ�
            }
        },
        {
            ItemType.�鼮, new List<ItemName>()
            {
                ItemName.ɽ����,
                ItemName.���زо�,
                ItemName.��󡹦�ؼ�,
                ItemName.����ʵ�,
                ItemName.����ʵ�,
                ItemName.�Ӽ�,
                ItemName.�����,
                ItemName.�Ƶ��ھ�,
                ItemName.���ݸ�Ŀ,
                ItemName.ī�ӷǹ�,
                ItemName.ī�Ӽ氮,
                ItemName.����,
                ItemName.Ψ����,
                ItemName.���,
                ItemName.��ֳ�д�,
                ItemName.�˺��Ӳ���,
                ItemName.�����,
                ItemName.ϴԩ¼,
                ItemName.Т����,
                ItemName.��,
                ItemName.ҩ�Ĵ�ȫ,
                ItemName.��Ա����������,
                ItemName.��ͷ���
            }
        },
        {
            ItemType.����, new List<ItemName>()
            {
                ItemName.��,
                ItemName.���ֵ�����,
            }
        },
        {
            ItemType.��װ, new List<ItemName>()
            {
                ItemName.����
            }
        },
        {
            ItemType.����, new List<ItemName>()
            {
            }
        },
        {
            ItemType.�ӻ�, new List<ItemName>()
            {
                ItemName.����������,
                ItemName.������,
                ItemName.����,
                ItemName.ë��,
                ItemName.����,
                ItemName.����,
                ItemName.�����ӡ,
                ItemName.����ƿ,
                ItemName.�Ĺ�״,
                ItemName.���״,
                ItemName.�Ӽ�,
                ItemName.����
            }
        },
        {
            ItemType.ҩ��, new List<ItemName>()
            {
                ItemName.����
            }
        }
    };
    public Sprite NullSprite;

    private void Awake()
    {
    }



}
