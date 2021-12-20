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
        {ItemName.����,Tag.ɮ��},
        {ItemName.������,Tag.����},
        {ItemName.�����滨��,Tag.����},
        {ItemName.�������,Tag.����},
        {ItemName.��ʤ��,Tag.��ʤ},
        {ItemName.����ǹ,Tag.����},
        {ItemName.��Դ��,Tag.��֮��},
        {ItemName.�˻�����,Tag.����ѹ��},
        {ItemName.������,Tag.��������},
        {ItemName.�ƽ��,Tag.�������},
        {ItemName.��ʯ,Tag.���� },
        {ItemName.����,Tag.������},
        {ItemName.��֮ӥ,Tag.ӥ֮��},
        {ItemName.����컯��,Tag.�������},
        {ItemName.����������,Tag.�ٶ�����},
        {ItemName.Ȯ,Tag.���ӿ��},
        {ItemName.����,Tag.��������},
        {ItemName.��,Tag.��֮��},
        {ItemName.��ʯ�ҷ繭,Tag.�ٲ�����},
        {ItemName.�һ�ն�Ƶ�,Tag.����},
        {ItemName.��ľ�׵�ǹ,Tag.�׵編��},
        {ItemName.��ʮ���ı���,Tag.봽�սʿ},
        {ItemName.���ξ�,Tag.ʫ�˴�},
        {ItemName.��ζ��,Tag.�������},
        {ItemName.��֮��,Tag.�ʼ�Ѫͳ},
        {ItemName.��Է����,Tag.����},
        {ItemName.��Ԫ��,Tag.��������},
        {ItemName.�����ײ�,Tag.���س�ի},
        {ItemName.������ݥ,Tag.���س�ի},
        {ItemName.�˱�ҰѼ,Tag.ʢʳ����},
        {ItemName.���ֽ��,Tag.ʢʳ����},
        {ItemName.ҽʥ��ҩ��,Tag.���ֵ���},
        {ItemName.��Ѫ��,Tag.�������},
        {ItemName.ľ����,Tag.���˾���},
        {ItemName.˺�������,Tag.��������},
        {ItemName.���ư�����,Tag.��������},
        {ItemName.���ƻ�,Tag.����},
        {ItemName.������,Tag.����},
        {ItemName.�컧��,Tag.����֮־},
        {ItemName.������,Tag.��������},
        {ItemName.����װ,Tag.��������},
        {ItemName.��Ǯ��,Tag.��Ǯ��},
        {ItemName.����,Tag.����},
        {ItemName.Ѫ����,Tag.Ѫ����},
        {ItemName.ľ������,Tag.�ز�},
        {ItemName.��˷���,Tag.�ز�},
        {ItemName.��������,Tag.�ز�},
        {ItemName.�峴����,Tag.�ز�},
        {ItemName.��޷����,Tag.���},
        {ItemName.ľ����,Tag.���},
        {ItemName.ϴ�赤,Tag.��������},
        {ItemName.�ƽ�,Tag.�����鷢},
        {ItemName.����ǹ,Tag.һ�㺮â},
        {ItemName.�󿳵�,Tag.�����},
        {ItemName.��Ƭ�,Tag.���վ�տ},
        {ItemName.�����澭,Tag.��������},
        {ItemName.�����澭,Tag.�߻���ħ},
        {ItemName.���̱�ʯ,Tag.���˵�ͷ},
        {ItemName.˿��,Tag.˿��},
        {ItemName.���ľ�,Tag.����},
        {ItemName.Ƥ��,Tag.Ƥ��},
        {ItemName.����,Tag.����},
        {ItemName.�˲�,Tag.��а����},
        {ItemName.����,Tag.��а����},
        {ItemName.����,Tag.��а����},
        {ItemName.ˮ�̻�,Tag.��а����},
        {ItemName.����,Tag.��а����},
        {ItemName.�ع�,Tag.��а����},
        {ItemName.�챦ʯ,Tag.��ⱦ��},
        {ItemName.��ˮ��,Tag.��ⱦ��},
        {ItemName.����ʯ,Tag.��ⱦ��},
        {ItemName.��ĸ��,Tag.��ⱦ��},
        {ItemName.���ֵ�����,Tag.��������},

    };
    public static Dictionary<ItemType, List<ItemName>> ItemTypeDict = new Dictionary<ItemType, List<ItemName>>()
    {
        { 
            ItemType.����, new List<ItemName>()
            {
                ItemName.�������,
                ItemName.������,
                ItemName.��ʤ��,
                ItemName.����ǹ,
                ItemName.��Դ��,
                ItemName.��ʯ�ҷ繭,
                ItemName.�һ�ն�Ƶ�,
                ItemName.��ľ�׵�ǹ,
                ItemName.��ʮ���ı���,
                ItemName.��Է����,
                ItemName.��֮��,
                ItemName.��˪����,
                ItemName.����,
                ItemName.ŷұ�ӵĴ�,
                ItemName.ŷұ�ӵ�С��,
                ItemName.�ƽ�,
                ItemName.����ǹ,
                ItemName.�󿳵�,
                ItemName.��,
                ItemName.��,
                ItemName.ǹ,
                ItemName.��,
                ItemName.�,
                ItemName.��ȱ�ڵ�����,
            }
        },
        {
            ItemType.��ҩ, new List<ItemName>()
            {
                ItemName.���ӵ�,
                ItemName.��������ҩ,
                ItemName.ʮȫ����,
                ItemName.����컯��,
                ItemName.����������,
                ItemName.������,
                ItemName.��������ɢ,
                ItemName.ҽʥ��ҩ��,
                ItemName.����ɢ,
                ItemName.������,
                ItemName.ϴ�赤,
                ItemName.��ҩ,
                ItemName.ֹѪ��

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
                ItemName.��Ԫ��,
                ItemName.�����澭,
                ItemName.�����澭,
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
                ItemName.��ͷ���,
                ItemName.�����,

            }
        },
        {
            ItemType.����, new List<ItemName>()
            {
                ItemName.��,
                ItemName.���ֵ�����,
                ItemName.��֮ӥ,
                ItemName.Ȯ,
                ItemName.����,
                ItemName.��,
                ItemName.���ƻ�,
                ItemName.������,
                ItemName.�ϻ�,
                ItemName.��,

            }
        },
        {
            ItemType.��װ, new List<ItemName>()
            {
                ItemName.����,
                ItemName.�ƽ��,
                ItemName.�컧��,
                ItemName.������,
                ItemName.����װ,
                ItemName.����,
                ItemName.���ľ�,
                ItemName.Ƥ��,
                ItemName.����,
                ItemName.����,
                ItemName.���廪��,
                ItemName.���·�
            }
        },
        {
            ItemType.����, new List<ItemName>()
            {
                ItemName.�����滨��,
                ItemName.�˻�����,
                ItemName.��Ǯ��,
                ItemName.����,
                ItemName.Ѫ����,
                ItemName.��ü��,
                ItemName.���,
                ItemName.С��,
                ItemName.����,
                ItemName.�ɻ�ʯ,

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
                ItemName.����,
                ItemName.����,
                ItemName.�̵�,
                ItemName.�廨��,
                ItemName.�Ļ�ɳĮ,
                ItemName.�����ӡ,
                ItemName.���������
            }
        },
        {
            ItemType.ҩ��, new List<ItemName>()
            {
                ItemName.����,
                ItemName.��֥,
                ItemName.�˲�,
                ItemName.����,
                ItemName.����,
                ItemName.ˮ�̻�,
                ItemName.����,
                ItemName.�ع�,
                ItemName.������,
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
                ItemName.����,
                ItemName.��ɽ��,
                ItemName.�ǳ���
            }
        },
        {
            ItemType.����, new List<ItemName>()
            {
                ItemName.��Ƭ�,
                ItemName.˿��,
                ItemName.�����,
                ItemName.����,
                ItemName.��ѿ,
                ItemName.��Ƥ,
                ItemName.����,
                ItemName.�컨,
                ItemName.��Ҷ,
                ItemName.��,
                ItemName.����,
                ItemName.ͭ��,
                ItemName.����,
                ItemName.��ƥ,
                ItemName.ľͷ,
                ItemName.Ƥ��,
                ItemName.í��,
                ItemName.Ӳľ,
                ItemName.��ֽ,
                ItemName.��֬,
                ItemName.��,
                ItemName.����,
                ItemName.����,
                ItemName.��,
                ItemName.��

            }
        },
        {
            ItemType.����, new List<ItemName>()
            {
                ItemName.����,
                ItemName.˺�������,
                ItemName.���ư�����,
                ItemName.���õĿ���,
                ItemName.������,
                ItemName.�ɹ���,
                ItemName.������,
                ItemName.������,
                ItemName.��β��,
                ItemName.����,

            }
        },
        {
            ItemType.��Ʒ, new List<ItemName>()
            {
                ItemName.�����,
                ItemName.��ʯ,
                ItemName.��Ѫ��,
                ItemName.ľ����,
                ItemName.���̱�ʯ,
                ItemName.�챦ʯ,
                ItemName.��ˮ��,
                ItemName.����ʯ,
                ItemName.��ĸ��,
                ItemName.��ɰ֬,
                ItemName.����ı�ʯ,
                ItemName.ȱ�ڵı�ʯ,
                ItemName.������Ļƽ�
            }
        },
        {
            ItemType.��Ʒ, new List<ItemName>()
            {
                ItemName.������,
                ItemName.���ξ�,
                ItemName.��ζ��,
                ItemName.��Ҷ��,
                ItemName.�ſ���,
                ItemName.Ů����,
                ItemName.���,
                ItemName.�ƾ�,
                ItemName.���,
                ItemName.«��,
                ItemName.���ʾ�,
                ItemName.������,
                ItemName.ˮ��,
                ItemName.����,

            }
        },
        {
            ItemType.��Ʒ, new List<ItemName>()
            {
                ItemName.�����ײ�,
                ItemName.������ݥ,
                ItemName.�˱�ҰѼ,
                ItemName.���ֽ��,
                ItemName.ľ������,
                ItemName.��˷���,
                ItemName.��������,
                ItemName.�峴����,
                ItemName.��޷����,
                ItemName.ľ����,
                ItemName.�峴��ѿ,
                ItemName.�Ļƹ�,
                ItemName.������,
                ItemName.�������ܲ�

            }
        }
    };

    public static Dictionary<BuildingType, List<ItemName>> BuildingCraftDict = new Dictionary<BuildingType, List<ItemName>>()
    {
        {
            BuildingType.������, new List<ItemName>()
            {
                ItemName.��,
                ItemName.ǹ,
                ItemName.��,
                ItemName.�,
                ItemName.��,
                ItemName.��ʯ�ҷ繭,
                ItemName.�һ�ն�Ƶ�,
                ItemName.��ľ�׵�ǹ,
                ItemName.��ʤ��,
                ItemName.������,
                ItemName.����ǹ,
                ItemName.��Դ��,
                ItemName.��Ǯ��,
                ItemName.����,
                ItemName.Ѫ����,
                ItemName.��ü��,
                ItemName.�˻�����,
                ItemName.�����滨��
            }
        },
        {
            BuildingType.ҩ��, new List<ItemName>()
            {
                ItemName.���ӵ�,
                ItemName.��ҩ,
                ItemName.��������ҩ,
                ItemName.ʮȫ����,
                ItemName.����ɢ,
                ItemName.������,
                ItemName.ϴ�赤,
                ItemName.ֹѪ��,
                ItemName.����������,
                ItemName.����컯��
            }    
        },
        {
            BuildingType.��֯��, new List<ItemName>()
            {
                ItemName.Ƥ��,
                ItemName.����,
                ItemName.�ƽ��,
                ItemName.������,
                ItemName.�컧��,
                ItemName.���廪��
            }
        }
    };

    public static Dictionary<ItemName, List<ItemName>> MergeItemDict = new Dictionary<ItemName,List<ItemName>>
    {
        {ItemName.��,new List<ItemName>(){ItemName.����,ItemName.Ƥ��}},
        {ItemName.ǹ,new List<ItemName>(){ItemName.����,ItemName.ľͷ}},
        {ItemName.��,new List<ItemName>(){ItemName.ͭ��,ItemName.����}},
        {ItemName.�,new List<ItemName>(){ItemName.����,ItemName.����}},
        {ItemName.��,new List<ItemName>(){ItemName.ľͷ,ItemName.����}},
        {ItemName.��ʯ�ҷ繭,new List<ItemName>(){ItemName.��,ItemName.��ĸ��}},
        {ItemName.�һ�ն�Ƶ�,new List<ItemName>(){ItemName.��,ItemName.��Ѫ��}},
        {ItemName.��ľ�׵�ǹ,new List<ItemName>(){ItemName.ǹ,ItemName.��ˮ��}},
        {ItemName.Ƥ��,new List<ItemName>(){ItemName.����,ItemName.Ƥ��}},
        {ItemName.����,new List<ItemName>(){ItemName.����,ItemName.����}},
        {ItemName.�ƽ��,new List<ItemName>(){ItemName.����,ItemName.������Ļƽ�}},
        {ItemName.������,new List<ItemName>(){ItemName.����װ,ItemName.�廨��}},
        {ItemName.�컧��,new List<ItemName>(){ItemName.������,ItemName.�챦ʯ}},
        {ItemName.���廪��,new List<ItemName>(){ItemName.����,ItemName.���ֵ�����}},
        {ItemName.����,new List<ItemName>(){ItemName.���,ItemName.����}},
        {ItemName.��Ǯ��,new List<ItemName>(){ItemName.���,ItemName.������Ļƽ�}},
        {ItemName.��ҩ,new List<ItemName>(){ItemName.�ƾ�,ItemName.�˽���}},
        {ItemName.����ɢ,new List<ItemName>(){ItemName.�޺���,ItemName.������}},
        {ItemName.��������ҩ,new List<ItemName>(){ItemName.����,ItemName.��֥,ItemName.������}},
        {ItemName.ʮȫ����,new List<ItemName>(){ItemName.����,ItemName.�˲�,ItemName.����}},
        {ItemName.ϴ�赤,new List<ItemName>(){ItemName.���,ItemName.����}},
        {ItemName.������,new List<ItemName>(){ItemName.����,ItemName.����}},
        {ItemName.����������,new List<ItemName>(){ItemName.�׻������,ItemName.��ɽ��}},
        {ItemName.����컯��,new List<ItemName>(){ItemName.�׻������,ItemName.�ǳ���}}






    };
    public Sprite NullSprite;




}
