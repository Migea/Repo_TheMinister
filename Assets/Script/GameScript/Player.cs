using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Map map;
    public static Dictionary<Tag, List<int>> TagInfDict = new Dictionary<Tag, List<int>>() {
        {Tag.Null, new List<int>(){0,0,0,0, 0,0}},
        {Tag.����ʱ������,new List<int>(){0,0,0,12,0,0}},
        {Tag.�����·�,new List<int>(){0,0,12,0,0,0}},
        {Tag.����,new List<int>(){4,0,0,-4,12,0}},
        {Tag.����˫ȫ,new List<int>(){6,6,6,6,6,6}},
        {Tag.�ɵ�,new List<int>(){10,10,10,10,10,10}},
        {Tag.��Ȼ������,new List<int>(){-6,-5,-6,9,9,9}},
        {Tag.Χ��ʮ��,new List<int>(){0,0,10,0,0,0}},
        {Tag.״Ԫ,new List<int>(){8,0,0,0,0,0}},
        {Tag.ʫ��,new List<int>(){0,8,0,0,0,0}},
        {Tag.����,new List<int>(){0,0,8,0,0,0}},
        {Tag.�˶�֮��,new List<int>(){7,7,7,-3,-4,-4}},
        {Tag.��ʥ,new List<int>(){0,0,0,8,0,0}},
        {Tag.��Ӱ,new List<int>(){0,0,0,0,8,0}},
        {Tag.��ʯ,new List<int>(){0,0,0,0,0,8}},
        {Tag.���侫ͨ,new List<int>(){-4,-4,-3,7,7,7}},
        {Tag.ֽ��̸��,new List<int>(){10,0,-1,0,0,0}},
        {Tag.ͽ������,new List<int>(){-1,10,0,0,0,0}},
        {Tag.Ͷ��ȡ��,new List<int>(){0,-1,10,0,0,0}},
        {Tag.����ħ��,new List<int>(){0,0,0,10,0,-1}},
        {Tag.�ĺ�����,new List<int>(){0,0,0,0,10,-1}},
        {Tag.ī�سɹ�,new List<int>(){0,0,0,0,-1,10}},
        {Tag.�ɶ��칤,new List<int>(){3,0,-1,0,0,8}},
        {Tag.��������,new List<int>(){10,7,0,-3,-2,-2}},
        {Tag.ī��,new List<int>(){7,-3,0,-4,10,0}},
        {Tag.��,new List<int>(){3,3,3,-1,0,-1}},
        {Tag.��,new List<int>(){-1,-1,0,3,3,3}},
        {Tag.��ͨ����,new List<int>(){5,0,0,0,0,0}},
        {Tag.�Ż�����,new List<int>(){0,5,0,0,0,0}},
        {Tag.�����ļ�,new List<int>(){0,0,5,0,0,0}},
        {Tag.����ɽ��,new List<int>(){0,0,0,5,0,0}},
        {Tag.��û�޳�,new List<int>(){0,0,0,0,5,0}},
        {Tag.����֮��,new List<int>(){0,0,0,0,0,5}},
        {Tag.����˫ȫ,new List<int>(){0,-4,5,5,0,0}},
        {Tag.��ʦ,new List<int>(){5,0,0,-4,5,0}},
        {Tag.���Ŷݼ�,new List<int>(){0,5,0,0,-4,5}},
        {Tag.��������,new List<int>(){0,0,-1,8,0,0}},
        {Tag.����ѧ��,new List<int>(){4,4,4,-2,-2,-1}},
        {Tag.���Ǵ�,new List<int>(){0,0,0,37,43,0}},
        {Tag.��������,new List<int>(){0,0,0,7,0,0}},
        {Tag.����ʿ,new List<int>(){-2,0,-3,4,4,4}},
        {Tag.�⽻��,new List<int>(){4,4,0,-1,0,0}},
        {Tag.�ϵ���׳,new List<int>(){0,-3,0,2,2,6}},
        {Tag.������ʦ,new List<int>(){6,-5,0,0,6,0}},
        {Tag.��ս��ͨ,new List<int>(){-4,-4,0,5,5,5}},
        {Tag.����ת��,new List<int>(){8,-25,4,8,4,8}},
        {Tag.��ƴ�ʦ,new List<int>(){0,2,3,0,0,0}},
        {Tag.�ݺ��,new List<int>(){0,2,5,0,0,0}},
        {Tag.��,new List<int>(){0,0,-1,0,0,8}},
        {Tag.Ϸ��,new List<int>(){0,3,3,0,0,0}},
        {Tag.�Ƶ��ھ�,new List<int>(){8,5,0,-6,0,0}},
        {Tag.���ݸ�Ŀ,new List<int>(){7,0,0,0,0,0}},
        {Tag.�����,new List<int>(){0,0,0,0,0,5}},
        {Tag.ѱ�޴�ʦ,new List<int>(){0,0,0,0,3,3}},
        {Tag.����,new List<int>(){0,3,4,0,0,0}},
        {Tag.����,new List<int>(){2,2,2,-1,-1,0}},
        {Tag.����,new List<int>(){-1,-1,0,2,2,2}},
        {Tag.���,new List<int>(){3,0,0,0,0,0}},
        {Tag.���в���,new List<int>(){0,3,0,0,0,0}},
        {Tag.С��ı��,new List<int>(){0,0,3,0,0,0}},
        {Tag.���,new List<int>(){0,0,0,3,0,0}},
        {Tag.���νý�,new List<int>(){0,0,0,0,3,0}},
        {Tag.�����,new List<int>(){0,0,0,0,0,3}},
        {Tag.�����ͽ,new List<int>(){0,-4,4,0,4,0}},
        {Tag.��󡹦,new List<int>(){0,-2,-2,2,2,4}},
        {Tag.��ϲ��,new List<int>(){4,0,0,0,0,0}},
        {Tag.��ħ��,new List<int>(){0,0,0,2,1,1}},
        {Tag.ͨ������,new List<int>(){0,0,4,0,0,0}},
        {Tag.��˪����,new List<int>(){0,0,0,4,0,0}},
        {Tag.��ë��,new List<int>(){0,0,0,0,2,0}},
        {Tag.����,new List<int>(){0,0,0,0,0,3}},
        {Tag.������,new List<int>(){2,1,0,0,0,0}},
        {Tag.�ܸ�����,new List<int>(){0,0,0,0,2,0}},
        {Tag.������,new List<int>(){2,1,0,0,0,0}},
        {Tag.��ʦ,new List<int>(){0,0,0,0,3,0}},
        {Tag.�뾭�ѵ�,new List<int>(){2,0,0,0,0,0}},
        {Tag.������,new List<int>(){0,0,1,0,2,0}},
        {Tag.����,new List<int>(){-1,-1,-1,3,0,2}},
        {Tag.���,new List<int>(){0,0,3,0,0,0}},
        {Tag.����,new List<int>(){0,2,0,0,0,0}},
        {Tag.����ѧ,new List<int>(){0,0,2,0,0,0}},
        {Tag.С��,new List<int>(){0,0,0,0,0,4}},
        {Tag.����,new List<int>(){2,1,0,0,0,0}},
        {Tag.��Ϸ��,new List<int>(){0,0,3,0,0,0}},
        {Tag.ѱ����,new List<int>(){0,0,0,0,3,0}},
        {Tag.����˾,new List<int>(){0,0,0,0,0,3}},
        {Tag.����,new List<int>(){0,0,0,0,0,2}},
        {Tag.�氮,new List<int>(){0,0,0,0,0,0}},
        {Tag.����,new List<int>(){0,2,0,0,0,0}},
        {Tag.�ǹ�,new List<int>(){5,0,0,-1,0,0}},
        {Tag.����,new List<int>(){1,1,1,-1,0,-1}},
        {Tag.����,new List<int>(){-1,-1,0,1,1,1}},
        {Tag.������ı,new List<int>(){0,0,-2,1,0,0}},
        {Tag.��������,new List<int>(){0,-2,1,0,0,0}},
        {Tag.�廨��ͷ,new List<int>(){-2,1,0,0,0,0}},
        {Tag.�����弼,new List<int>(){-2,0,0,0,1,0}},
        {Tag.��������,new List<int>(){1,0,0,0,-2,0}},
        {Tag.��������,new List<int>(){0,0,1,0,0,-2}},
        {Tag.���в���,new List<int>(){0,0,0,0,0,0}},
        {Tag.����֢,new List<int>(){0,0,0,1,0,0}},
        {Tag.٪��֢,new List<int>(){1,0,0,0,0,0}},
        {Tag.����,new List<int>(){0,1,0,0,0,0}},
        {Tag.��ʿ,new List<int>(){0,0,1,0,0,0}},
        {Tag.ɮ��,new List<int>(){1,0,0,0,0,0}},
        {Tag.��ʦ,new List<int>(){0,0,1,0,0,0}},
        {Tag.��Ѫ����,new List<int>(){-3,0,0,1,2,1}},
        {Tag.����,new List<int>(){0,0,0,-1,1,-1}},
        {Tag.��Ѫ��,new List<int>(){0,-2,0,1,2,0}},
        {Tag.����,new List<int>(){0,0,-2,2,0,1}},
        {Tag.ϥ�ǽ�Ӳ,new List<int>(){0,0,0,0,-1,0}},
        {Tag.�ද֢,new List<int>(){0,0,0,1,-1,0}},
        {Tag.ƽƽ����,new List<int>(){0,0,0,0,0,0}},
        {Tag.��,new List<int>(){-1,-2,0,0,2,2}},
        {Tag.ϰ��֮��,new List<int>(){0,-2,0,1,1,1}},
        {Tag.��ͯ,new List<int>(){2,0,0,-1,-1,0}},
        {Tag.��,new List<int>(){0,0,0,0,2,-1}},
        {Tag.��,new List<int>(){0,0,0,1,0,0}},
        {Tag.ǹ,new List<int>(){0,0,0,1,-1,1}},
        {Tag.̰���ǽ�,new List<int>(){-1,-1,2,0,0,0}},
        {Tag.��Ա,new List<int>(){0,1,0,0,0,0}},
        {Tag.��������,new List<int>(){-1,0,0,0,0,0}},
        {Tag.��,new List<int>(){0,0,0,0,0,1}},
        {Tag.�,new List<int>(){0,0,0,0,-1,2}},
        {Tag.ҽ��,new List<int>(){2,1,0,-2,0,0}},
        {Tag.����,new List<int>(){0,0,0,0,0,0}},
        {Tag.���˲���,new List<int>(){0,0,-4,0,0,0}},
        {Tag.��Т��,new List<int>(){0,-3,0,0,0,0}},
        {Tag.�ȽŲ���,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.������˥,new List<int>(){1,0,0,-2,-2,-2}},
        {Tag.���,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.��������,new List<int>(){-5,-5,2,1,1,2}},
        {Tag.����,new List<int>(){-2,-2,-2,2,0,0}},
        {Tag.����,new List<int>(){0,0,0,-3,0,0}},
        {Tag.��������,new List<int>(){0,0,0,-2,0,0}},
        {Tag.Ӫ������,new List<int>(){0,0,0,-2,0,0}},
        {Tag.����,new List<int>(){0,0,0,-5,0,0}},
        {Tag.ҹ������,new List<int>(){0,0,0,-3,-3,2}},
        {Tag.�ɷ���,new List<int>(){-1,-1,-1,-1,-1,-1}},
        {Tag.˫Ŀʧ��,new List<int>(){0,0,0,-2,0,-3}},
        {Tag.����,new List<int>(){0,0,0,-1,-2,-2}},
        {Tag.�մ�,new List<int>(){-2,-2,-2,1,0,0}},
        {Tag.������,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.С�����,new List<int>(){0,0,-1,-2,-1,-1}},
        {Tag.Ŀ��ʶ��,new List<int>(){-2,-2,-1,0,0,0}}

    };
    public static Dictionary<Rarerity, List<Tag>> GivenableTagRareDict = new Dictionary<Rarerity, List<Tag>>()
        {
        {Rarerity.B,new List<Tag>()
        {
        Tag.���˲���,
        Tag.�ȽŲ���,
        Tag.������˥,
        Tag.��������,
        Tag.����,
        Tag.����,
        Tag.��������,
        Tag.�ɷ���,
        Tag.˫Ŀʧ��,
        Tag.����,
        Tag.�մ�,
        Tag.С�����,
        Tag.Ŀ��ʶ��
    }},

        {Rarerity.R,new List<Tag>()
        {
        Tag.���,
        Tag.���в���,
        Tag.С��ı��,
        Tag.���,
        Tag.���νý�,
        Tag.�����,
        Tag.�뾭�ѵ�,
        Tag.������,
        Tag.����,
        Tag.���,
        Tag.����,
        Tag.����
    }},
        {Rarerity.N,new List<Tag>()
       {
        Tag.������ı,
        Tag.��������,
        Tag.��������,
        Tag.����֢,
        Tag.٪��֢,
        Tag.����,
        Tag.��ʿ,
        Tag.ɮ��,
        Tag.��Ѫ����,
        Tag.����,
        Tag.Ӫ������,
        Tag.ϥ�ǽ�Ӳ,
        Tag.�ද֢,
        Tag.ƽƽ����,
        Tag.ϰ��֮��,
        Tag.��,
        Tag.��,
        Tag.ǹ,
        Tag.��,
        Tag.�,
        Tag.��������,
        Tag.̰���ǽ�,
        Tag.��������,
        Tag.��Ѫ��,
        Tag.����
    }},
        {Rarerity.SR,new List<Tag>()
       {
        Tag.�Ż�����,
        Tag.�����ļ�,
        Tag.����ɽ��,
        Tag.����֮��,
        Tag.����˫ȫ,
    }},
        {Rarerity.SSR,new List<Tag>()
       {
        Tag.״Ԫ,
        Tag.ʫ��,
        Tag.����,
        Tag.��ʥ,
        Tag.��Ӱ,
        Tag.��ʯ
    }},
        {Rarerity.UR,new List<Tag>()
       {}}

};
    public static Dictionary<Rarerity, List<Tag>> MergeableTagRareDict = new Dictionary<Rarerity, List<Tag>> {
        {Rarerity.B,new List<Tag>()
        {
        Tag.����
    }},

        {Rarerity.R,new List<Tag>()
        {
        Tag.����,
        Tag.����,
        Tag.�����ͽ,
        Tag.��ϲ��,
        Tag.��ħ��,
        Tag.��Ϸ��,
        Tag.����

    }},
        {Rarerity.N,new List<Tag>()
       {
           }},
        {Rarerity.SR,new List<Tag>()
       {
        Tag.��,
        Tag.��,
        Tag.��������,
        Tag.����ѧ��,
        Tag.���Ǵ�,
        Tag.��������,
        Tag.����ʿ,
        Tag.�⽻��,
        Tag.�ϵ���׳,
        Tag.������ʦ,
        Tag.��ս��ͨ,
        Tag.����ת��,
        Tag.��ƴ�ʦ,
        Tag.Ϸ��,
        Tag.�����,
        Tag.ѱ�޴�ʦ,
        Tag.����
    }},
        {Rarerity.SSR,new List<Tag>()
       {
        Tag.��Ȼ������,
        Tag.Χ��ʮ��,
        Tag.�˶�֮��,
        Tag.���侫ͨ,
        Tag.ֽ��̸��,
        Tag.ͽ������,
        Tag.Ͷ��ȡ��,
        Tag.����ħ��,
        Tag.�ĺ�����,
        Tag.ī�سɹ�,
        Tag.�ɶ��칤,
        Tag.��������,
        Tag.ī��

    }},
        {Rarerity.UR,new List<Tag>()
       {
        Tag.����ʱ������,
        Tag.�����·�,
        Tag.����,
        Tag.����˫ȫ
}}

};
    public static Dictionary<List<Tag>, Tag> MergeTagDict = new Dictionary<List<Tag>, Tag>
    {
        {new List<Tag>(){Tag.����,Tag.����},Tag.����},
        {new List<Tag>(){Tag.����,Tag.����},Tag.����},
        {new List<Tag>(){Tag.����,Tag.����},Tag.��},
        {new List<Tag>(){Tag.����,Tag.����},Tag.��},
        {new List<Tag>(){Tag.����,Tag.����},Tag.��},
        {new List<Tag>(){Tag.Χ��ʮ��,Tag.�ݺ��},Tag.�����·�},
        {new List<Tag>(){Tag.����,Tag.��,Tag.ƽƽ����},Tag.��Ȼ������},
        {new List<Tag>(){Tag.��ͨ����,Tag.�Ż�����,Tag.�����ļ�},Tag.�˶�֮��},
        {new List<Tag>(){Tag.��,Tag.ǹ,Tag.��,Tag.�,Tag.��},Tag.���侫ͨ},
        {new List<Tag>(){Tag.��,Tag.��},Tag.����˫ȫ},
        {new List<Tag>(){Tag.�����ļ�,Tag.���,Tag.��������},Tag.ֽ��̸��},
        {new List<Tag>(){Tag.�Ż�����,Tag.���в���,Tag.�廨��ͷ},Tag.ͽ������},
        {new List<Tag>(){Tag.�����ļ�,Tag.С��ı��,Tag.��������}, Tag.Ͷ��ȡ��},                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               {new List<Tag>(){Tag.����ɽ��,Tag.���,Tag.�����ͽ},Tag.����ħ��},
        {new List<Tag>(){Tag.��Ѫ����,Tag.��û�޳�},Tag.�ĺ�����},
        {new List<Tag>(){Tag.�����,Tag.����֮��,Tag.����},Tag.ī�سɹ�},
        {new List<Tag>(){Tag.���в���,Tag.����},Tag.�Ż�����},
        {new List<Tag>(){Tag.����ѧ,Tag.���},Tag.�����ļ�},
        {new List<Tag>(){Tag.���,Tag.����֢},Tag.����ɽ��},
        {new List<Tag>(){Tag.�����,Tag.����},Tag.����֮��},
        {new List<Tag>(){Tag.С��ı��,Tag.���},Tag.����˫ȫ},
        {new List<Tag>(){Tag.����֢,Tag.٪��֢},Tag.��������},
        {new List<Tag>(){Tag.����,Tag.��ʿ,Tag.ɮ��},Tag.����ѧ��},
        {new List<Tag>(){Tag.��󡹦,Tag.������˥},Tag.���Ǵ�},
        {new List<Tag>(){Tag.��˪����,Tag.��Т��},Tag.��������},
        {new List<Tag>(){Tag.����,Tag.��ë��},Tag.����ʿ},
        {new List<Tag>(){Tag.������,Tag.������},Tag.�⽻��},
        {new List<Tag>(){Tag.ϰ��֮��,Tag.������˥},Tag.�ϵ���׳},
        {new List<Tag>(){Tag.��ͯ,Tag.��ʦ,Tag.�뾭�ѵ�},Tag.������ʦ},
        {new List<Tag>(){Tag.��,Tag.��},Tag.��ս��ͨ},
        {new List<Tag>(){Tag.ϥ�ǽ�Ӳ,Tag.������,Tag.����},Tag.����ת��},
        {new List<Tag>(){Tag.����ѧ,Tag.����},Tag.��ƴ�ʦ},
        {new List<Tag>(){Tag.��Ա,Tag.����},Tag.Ϸ��},
        {new List<Tag>(){Tag.����ѧ,Tag.���},Tag.�����ļ�},
        {new List<Tag>(){Tag.����˾,Tag.����},Tag.�����},
        {new List<Tag>(){Tag.����,Tag.ѱ����},Tag.ѱ�޴�ʦ},
        {new List<Tag>(){Tag.��Ա,Tag.������˥},Tag.��Ϸ��},
        {new List<Tag>(){Tag.����,Tag.ѱ����},Tag.����},
        {new List<Tag>(){Tag.Ӫ������,Tag.��������},Tag.����},
        {new List<Tag>(){Tag.ī��,Tag.�氮},Tag.����},
        {new List<Tag>(){Tag.��,Tag.С��},Tag.�ɶ��칤},
        {new List<Tag>(){Tag.ҽ��,Tag.����,Tag.���ݸ�Ŀ,Tag.�Ƶ��ھ�},Tag.��������},
        {new List<Tag>(){Tag.��ʦ,Tag.�ǹ�},Tag.ī��}

    };
    public static Dictionary<Rarerity, List<Tag>> ItemgiveTagRareDict = new Dictionary<Rarerity, List<Tag>>()
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.��Т��,
            Tag.���,
            Tag.ҹ������,
            Tag.������
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.��󡹦,
            Tag.ͨ������,
            Tag.��˪����,
            Tag.��ë��,
            Tag.����,
            Tag.������,
            Tag.�ܸ�����,
            Tag.������,
            Tag.��ʦ,
            Tag.����,
            Tag.����ѧ,
            Tag.С��,
            Tag.ѱ����,
            Tag.����˾,
            Tag.�氮,
            Tag.�ǹ�

    }},
        {Rarerity.N,new List<Tag>()
       {
            Tag.����,
            Tag.����,
            Tag.��������,
            Tag.�廨��ͷ,
            Tag.�����弼,
            Tag.���в���,
            Tag.��ʦ,
            Tag.����,
            Tag.��,
            Tag.��ͯ,
            Tag.��Ա,
            Tag.ҽ��,
            Tag.����
           }},
        {Rarerity.SR,new List<Tag>()
       {
            Tag.��ͨ����,
            Tag.��ʦ,
            Tag.���Ŷݼ�,
            Tag.�ݺ��,
            Tag.��,
            Tag.�Ƶ��ھ�,
            Tag.���ݸ�Ŀ
    }},
        {Rarerity.SSR,new List<Tag>()
       {

    }},
        {Rarerity.UR,new List<Tag>()
       {
}}
    };
    public static Dictionary<ItemName, Tag> ItemToTag = new Dictionary<ItemName, Tag>
    {
        {ItemName.ɽ����,Tag.��ͨ����},
        {ItemName.���زо�,Tag.��ʦ},
        {ItemName.����������,Tag.���Ŷݼ�},
        {ItemName.�����,Tag.�ݺ��},
        {ItemName.ŷұ�ӵĴ�,Tag.��},
        {ItemName.�Ƶ��ھ�,Tag.�Ƶ��ھ�},
        {ItemName.���ݸ�Ŀ,Tag.���ݸ�Ŀ},
        {ItemName.��󡹦�ؼ�,Tag.��󡹦},
        {ItemName.������,Tag.ͨ������},
        {ItemName.��˪����,Tag.��˪����},
        {ItemName.����,Tag.����},
        {ItemName.����ʵ�,Tag.������},
        {ItemName.����ʵ�,Tag.������},
        {ItemName.����,Tag.�ܸ�����},
        {ItemName.ī�ӷǹ�,Tag.�ǹ�},
        {ItemName.ī�Ӽ氮,Tag.�氮},
        {ItemName.�����ӡ,Tag.����˾},
        {ItemName.����,Tag.��ʦ},
        {ItemName.Ψ����,Tag.�뾭�ѵ�},
        {ItemName.����ƿ,Tag.���˲���},
        {ItemName.���,Tag.���},
        {ItemName.��ֳ�д�,Tag.����ѧ},
        {ItemName.ŷұ�ӵ�С��,Tag.С��},
        {ItemName.�˺��Ӳ���,Tag.����},
        {ItemName.�Ĺ�״,Tag.����},
        {ItemName.���״,Tag.����},
        {ItemName.���ֵ�����,Tag.��������},
        {ItemName.�����,Tag.�廨��ͷ},
        {ItemName.�Ӽ�,Tag.�����弼},
        {ItemName.���ӵ�,Tag.������},
        {ItemName.����,Tag.���в���},
        {ItemName.ϴԩ¼,Tag.��ʦ},
        {ItemName.����,Tag.ҹ������},
        {ItemName.����,Tag.����},
        {ItemName.Т����,Tag.��Т��},
        {ItemName.��,Tag.��},
        {ItemName.ë��,Tag.����},
        {ItemName.����,Tag.��ʿ},
        {ItemName.����,Tag.ɮ��},
        {ItemName.��,Tag.����},
        {ItemName.ҩ�Ĵ�ȫ,Tag.��ͯ},
        {ItemName.��,Tag.��},
        {ItemName.��,Tag.��},
        {ItemName.ǹ,Tag.ǹ},
        {ItemName.��,Tag.��},
        {ItemName.�,Tag.�},
        {ItemName.��Ա����������,Tag.��Ա},
        {ItemName.��ͷ���,Tag.ҽ��}
    };
    public static Dictionary<Tag, GameObject> TagPrefabDict = new Dictionary<Tag, GameObject> { };






}
