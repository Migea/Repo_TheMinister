using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Map map;
    public static Dictionary<Tag, List<int>> TagInfDict = new Dictionary<Tag, List<int>>() {
        {Tag.Null, new List<int>(){0,0,0,0, 0,0}},
        {Tag.���޼�����,new List<int>(){0,0,0,12,0,0}},
        {Tag.�����·�,new List<int>(){0,0,12,0,0,0}},
        {Tag.����,new List<int>(){4,0,0,-4,12,0}},
        {Tag.����˫ȫ,new List<int>(){6,6,6,6,6,6}},
        {Tag.�ɵ�,new List<int>(){10,10,10,10,10,10}},
        {Tag.��������,new List<int>(){12,0,0,0,0,0}},
        {Tag.�������,new List<int>(){0,0,0,0,0,12}},
        {Tag.��Ѫ����,new List<int>(){0,12,0,0,0,0}},
        {Tag.½������,new List<int>(){12,12,12,12,12,12} },
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
        {Tag.����,new List<int>(){0,0,0,4,5,0}},
        {Tag.����,new List<int>(){0,0,0,0,9,0}},
        {Tag.����,new List<int>(){0,0,0,9,0,0}},
        {Tag.��ʤ,new List<int>(){0,0,0,5,0,4}},
        {Tag.����,new List<int>(){0,0,0,0,0,9}},
        {Tag.��֮��,new List<int>(){0,0,0,0,4,5}},
        {Tag.����ѹ��,new List<int>(){0,0,0,-1,11,-1}},
        {Tag.��������,new List<int>(){0,5,0,5,0,0}},
        {Tag.�������,new List<int>(){0,0,0,-1,-1,11}},
        {Tag.����,new List<int>(){0,0,0,0,0,0}},
        {Tag.������,new List<int>(){0,0,0,0,0,0}},
        {Tag.ӥ֮��,new List<int>(){0,0,0,0,4,4}},
        {Tag.�������,new List<int>(){0,0,10,0,0,0}},
        {Tag.�ٶ�����,new List<int>(){5,0,0,0,5,0}},
        {Tag.���ӿ��,new List<int>(){0,0,0,3,0,6}},
        {Tag.��������,new List<int>(){0,0,0,3,6,0}},
        {Tag.��֮��,new List<int>(){0,0,0,6,0,3}},
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
        {Tag.�ٲ�����,new List<int>(){0,0,0,0,6,0}},
        {Tag.����,new List<int>(){0,0,0,6,0,0}},
        {Tag.�׵編��,new List<int>(){-2,-1,0,6,3,0}},
        {Tag.�ʼ�Ѫͳ,new List<int>(){0,0,0,0,0,6}},
        {Tag.����,new List<int>(){-2,-2,-2,6,0,6}},
        {Tag.��������,new List<int>(){1,0,0,0,6,0}},
        {Tag.ʫ�˴�,new List<int>(){0,5,0,0,0,0}},
        {Tag.�������,new List<int>(){0,0,0,5,0,0}},
        {Tag.봽�սʿ,new List<int>(){2,2,2,2,2,2}},
        {Tag.���س�ի,new List<int>(){5,0,0,0,0,0}},
        {Tag.ʢʳ����,new List<int>(){0,0,0,0,5,0}},
        {Tag.��������,new List<int>(){0,0,0,0,0,5}},
        {Tag.���ֵ���,new List<int>(){3,3,0,0,0,0}},
        {Tag.�������,new List<int>(){0,0,0,3,3,0}},
        {Tag.���˾���,new List<int>(){0,6,0,0,0,0}},
        {Tag.��������,new List<int>(){6,0,0,0,0,0}},
        {Tag.����,new List<int>(){0,0,0,5,0,3}},
        {Tag.����,new List<int>(){0,0,2,3,5,-2}},
        {Tag.����֮־,new List<int>(){0,0,0,2,0,5}},
        {Tag.��������,new List<int>(){0,0,6,0,0,0}},
        {Tag.��������,new List<int>(){1,6,0,0,0,0}},
        {Tag.��Ǯ��,new List<int>(){0,0,0,0,7,0}},
        {Tag.����,new List<int>(){2,0,0,0,6,0}},
        {Tag.Ѫ����,new List<int>(){0,0,0,0,8,0}},
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
        {Tag.�����鷢,new List<int>(){0,0,0,0,2,2}},
        {Tag.��������,new List<int>(){0,0,0,3,0,0}},
        {Tag.һ�㺮â,new List<int>(){0,0,0,0,1,3}},
        {Tag.�����,new List<int>(){0,0,2,2,0,0}},
        {Tag.���վ�տ,new List<int>(){0,0,0,2,1,1}},
        {Tag.��������,new List<int>(){0,1,0,3,0,0}},
        {Tag.�߻���ħ,new List<int>(){-3,-2,-1,4,4,2}},
        {Tag.�ز�,new List<int>(){2,0,0,0,0,0}},
        {Tag.���,new List<int>(){0,0,0,2,0,0}},
        {Tag.���˵�ͷ,new List<int>(){0,0,3,0,0,0}},
        {Tag.˿��,new List<int>(){0,2,0,0,0,0}},
        {Tag.����,new List<int>(){0,0,0,0,0,4}},
        {Tag.Ƥ��,new List<int>(){0,0,0,0,4,0}},
        {Tag.����,new List<int>(){0,0,0,4,0,0}},
        {Tag.��а����,new List<int>(){0,0,0,1,0,1}},
        {Tag.��ⱦ��,new List<int>(){1,1,0,0,0,0}},
        {Tag.��������,new List<int>(){1,1,-1,1,-1,1}},
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
        {Tag.Ŀ��ʶ��,new List<int>(){-2,-2,-1,0,0,0}},
        {Tag.�ô����,new List<int>(){0,-2,-4,0,0,0}},
        {Tag.���ܿ�ŭ,new List<int>(){0,0,0,-4,0,-2}},
        {Tag.ͷ��,new List<int>(){-2,-2,-4,0,0,0}},
        {Tag.������,new List<int>(){0,0,0,-5,0,0}},
        {Tag.�İ�,new List<int>(){0,-4,0,0,0,0}},
        {Tag.������,new List<int>(){-1,-1,-1,0,0,0}},
        {Tag.��Ƥ��,new List<int>(){0,0,0,0,0,-2}},
        {Tag.�������,new List<int>(){0,-2,0,0,0,0}},
        {Tag.��Ż,new List<int>(){0,0,0,0,-5,0}},
        {Tag.��������,new List<int>(){1,1,1,-3,-3,-2}},
        {Tag.����֢,new List<int>(){0,0,0,-3,-4,2}},
        {Tag.������,new List<int>(){0,0,0,-4,-1,0}},
        {Tag.��֫,new List<int>(){0,0,0,-3,2,-2}},
        {Tag.����֮��,new List<int>(){0,0,0,7,7,7}},
        {Tag.��ζ�ӳ�,new List<int>(){-1,3,-1,0,1,0}},
        {Tag.�þ�֮��,new List<int>(){0,1,0,0,0,1}},
        {Tag.����,new List<int>(){3,1,0,-1,0,0}},
        {Tag.����,new List<int>(){0,0,0,1,0,0}},
        {Tag.𯹤�ϲ�,new List<int>(){0,0,0,0,0,0}},
        {Tag.��̬����,new List<int>(){0,0,0,0,0,1}},
        {Tag.�����Ӱ�,new List<int>(){1,-1,0,-1,1,0}},
        {Tag.ë����ʢ,new List<int>(){0,0,0,0,-1,1}},
        {Tag.ҩ��,new List<int>(){0,0,0,-2,-2,-2}},
        {Tag.�²�����,new List<int>(){-1,-1,-1,-1,-1,-1}},
        {Tag.���˴���,new List<int>(){0,0,0,0,0,0}},
        {Tag.Ǳ����ҫ,new List<int>(){0,0,0,0,0,10}},
        {Tag.���ʺ���,new List<int>(){8,2,0,0,0,0}},
        {Tag.ƽ������,new List<int>(){0,3,7,0,0,0}},
        {Tag.����,new List<int>(){5,2,0,0,0,0}},
        {Tag.��Բ����,new List<int>(){0,7,0,0,0,0}},
        {Tag.������,new List<int>(){1,1,0,0,0,0}},
        {Tag.��ʦ,new List<int>(){0,2,0,0,1,0}},
        {Tag.��ȭ,new List<int>(){0,0,0,3,0,0}},
        {Tag.����֮��,new List<int>(){0,0,0,1,-1,0}},
        {Tag.�Ļ�ɳĮ,new List<int>(){-1,-1,-1,3,3,3}},
        {Tag.�书С��,new List<int>(){0,0,0,5,0,2}}


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
        Tag.Ŀ��ʶ��,
        Tag.�ô����,
        Tag.���ܿ�ŭ,
        Tag.ͷ��,
        Tag.������,
        Tag.�İ�,
        Tag.������,
        Tag.��Ƥ��,
        Tag.�������,
        Tag.��Ż,
        Tag.��������,
        Tag.����֢,
        Tag.������,
        Tag.��֫,
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
        Tag.���޼�����,
        Tag.�����·�,
        Tag.����,
        Tag.����˫ȫ,
        Tag.��������,
        Tag.�������,
        Tag.��Ѫ����,
        Tag.½������
}}

};
    public static Dictionary<Tag, Rarerity> AllTagRareDict = new Dictionary<Tag, Rarerity>
    {
        {Tag.���˲���,Rarerity.B},
        {Tag.��Т��,Rarerity.B},
        {Tag.�ȽŲ���,Rarerity.B},
        {Tag.������˥,Rarerity.B},
        {Tag.���,Rarerity.B},
        {Tag.��������,Rarerity.B},
        {Tag.����,Rarerity.B},
        {Tag.����,Rarerity.B},
        {Tag.��������,Rarerity.B},
        {Tag.Ӫ������,Rarerity.B},
        {Tag.����,Rarerity.B},
        {Tag.ҹ������,Rarerity.B},
        {Tag.�ɷ���,Rarerity.B},
        {Tag.˫Ŀʧ��,Rarerity.B},
        {Tag.����,Rarerity.B},
        {Tag.�մ�,Rarerity.B},
        {Tag.������,Rarerity.B},
        {Tag.С�����,Rarerity.B},
        {Tag.Ŀ��ʶ��,Rarerity.B},
        {Tag.�ô����,Rarerity.B},
        {Tag.���ܿ�ŭ,Rarerity.B},
        {Tag.ͷ��,Rarerity.B},
        {Tag.������,Rarerity.B},
        {Tag.�İ�,Rarerity.B},
        {Tag.������,Rarerity.B},
        {Tag.��Ƥ��,Rarerity.B},
        {Tag.�������,Rarerity.B},
        {Tag.��Ż,Rarerity.B},
        {Tag.��������,Rarerity.B},
        {Tag.����֢,Rarerity.B},
        {Tag.������,Rarerity.B},
        {Tag.��֫,Rarerity.B},
        {Tag.ҩ��,Rarerity.B},
        {Tag.�²�����,Rarerity.B},
        {Tag.����,Rarerity.N},
        {Tag.����,Rarerity.N},
        {Tag.������ı,Rarerity.N},
        {Tag.��������,Rarerity.N},
        {Tag.�廨��ͷ,Rarerity.N},
        {Tag.�����弼,Rarerity.N},
        {Tag.��������,Rarerity.N},
        {Tag.��������,Rarerity.N},
        {Tag.���в���,Rarerity.N},
        {Tag.����֢,Rarerity.N},
        {Tag.٪��֢,Rarerity.N},
        {Tag.����,Rarerity.N},
        {Tag.��ʿ,Rarerity.N},
        {Tag.ɮ��,Rarerity.N},
        {Tag.��ʦ,Rarerity.N},
        {Tag.��Ѫ����,Rarerity.N},
        {Tag.����,Rarerity.N},
        {Tag.��Ѫ��,Rarerity.N},
        {Tag.����,Rarerity.N},
        {Tag.ϥ�ǽ�Ӳ,Rarerity.N},
        {Tag.�ද֢,Rarerity.N},
        {Tag.ƽƽ����,Rarerity.N},
        {Tag.��,Rarerity.N},
        {Tag.ϰ��֮��,Rarerity.N},
        {Tag.��ͯ,Rarerity.N},
        {Tag.��,Rarerity.N},
        {Tag.��,Rarerity.N},
        {Tag.ǹ,Rarerity.N},
        {Tag.̰���ǽ�,Rarerity.N},
        {Tag.��Ա,Rarerity.N},
        {Tag.��������,Rarerity.N},
        {Tag.��,Rarerity.N},
        {Tag.�,Rarerity.N},
        {Tag.ҽ��,Rarerity.N},
        {Tag.����,Rarerity.N},
        {Tag.����,Rarerity.N},
        {Tag.���˴���,Rarerity.N},
        {Tag.𯹤�ϲ�,Rarerity.N},
        {Tag.��̬����,Rarerity.N},
        {Tag.�����Ӱ�,Rarerity.N},
        {Tag.ë����ʢ,Rarerity.N},
        {Tag.����֮��,Rarerity.N},
        {Tag.����,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.���,Rarerity.R},
        {Tag.��ζ�ӳ�,Rarerity.R},
        {Tag.�þ�֮��,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.���в���,Rarerity.R},
        {Tag.С��ı��,Rarerity.R},
        {Tag.���,Rarerity.R},
        {Tag.���νý�,Rarerity.R},
        {Tag.�����,Rarerity.R},
        {Tag.�����ͽ,Rarerity.R},
        {Tag.��󡹦,Rarerity.R},
        {Tag.��ϲ��,Rarerity.R},
        {Tag.��ħ��,Rarerity.R},
        {Tag.ͨ������,Rarerity.R},
        {Tag.��˪����,Rarerity.R},
        {Tag.��ë��,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.������,Rarerity.R},
        {Tag.�ܸ�����,Rarerity.R},
        {Tag.������,Rarerity.R},
        {Tag.��ʦ,Rarerity.R},
        {Tag.�뾭�ѵ�,Rarerity.R},
        {Tag.������,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.���,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.����ѧ,Rarerity.R},
        {Tag.С��,Rarerity.R},
        {Tag.��Ϸ��,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.ѱ����,Rarerity.R},
        {Tag.����˾,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.�氮,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.�ǹ�,Rarerity.R},
        {Tag.�����鷢,Rarerity.R},
        {Tag.��������,Rarerity.R},
        {Tag.һ�㺮â,Rarerity.R},
        {Tag.�����,Rarerity.R},
        {Tag.���վ�տ,Rarerity.R},
        {Tag.��������,Rarerity.R},
        {Tag.�߻���ħ,Rarerity.R},
        {Tag.�ز�,Rarerity.R},
        {Tag.���,Rarerity.R},
        {Tag.���˵�ͷ,Rarerity.R},
        {Tag.˿��,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.Ƥ��,Rarerity.R},
        {Tag.����,Rarerity.R},
        {Tag.��а����,Rarerity.R},
        {Tag.��ⱦ��,Rarerity.R},
        {Tag.��������,Rarerity.R},
        {Tag.��ȭ,Rarerity.R},
        {Tag.��ʦ,Rarerity.R},
        {Tag.������,Rarerity.R},
        {Tag.��,Rarerity.SR},
        {Tag.��,Rarerity.SR},
        {Tag.��ͨ����,Rarerity.SR},
        {Tag.�Ż�����,Rarerity.SR},
        {Tag.�����ļ�,Rarerity.SR},
        {Tag.����ɽ��,Rarerity.SR},
        {Tag.��û�޳�,Rarerity.SR},
        {Tag.����֮��,Rarerity.SR},
        {Tag.����˫ȫ,Rarerity.SR},
        {Tag.��ʦ,Rarerity.SR},
        {Tag.���Ŷݼ�,Rarerity.SR},
        {Tag.��������,Rarerity.SR},
        {Tag.����ѧ��,Rarerity.SR},
        {Tag.���Ǵ�,Rarerity.SR},
        {Tag.��������,Rarerity.SR},
        {Tag.����ʿ,Rarerity.SR},
        {Tag.�⽻��,Rarerity.SR},
        {Tag.�ϵ���׳,Rarerity.SR},
        {Tag.������ʦ,Rarerity.SR},
        {Tag.��ս��ͨ,Rarerity.SR},
        {Tag.����ת��,Rarerity.SR},
        {Tag.��ƴ�ʦ,Rarerity.SR},
        {Tag.�ݺ��,Rarerity.SR},
        {Tag.��,Rarerity.SR},
        {Tag.Ϸ��,Rarerity.SR},
        {Tag.�Ƶ��ھ�,Rarerity.SR},
        {Tag.���ݸ�Ŀ,Rarerity.SR},
        {Tag.�����,Rarerity.SR},
        {Tag.ѱ�޴�ʦ,Rarerity.SR},
        {Tag.����,Rarerity.SR},
        {Tag.�ٲ�����,Rarerity.SR},
        {Tag.����,Rarerity.SR},
        {Tag.�׵編��,Rarerity.SR},
        {Tag.�ʼ�Ѫͳ,Rarerity.SR},
        {Tag.����,Rarerity.SR},
        {Tag.��������,Rarerity.SR},
        {Tag.ʫ�˴�,Rarerity.SR},
        {Tag.�������,Rarerity.SR},
        {Tag.봽�սʿ,Rarerity.SR},
        {Tag.���س�ի,Rarerity.SR},
        {Tag.ʢʳ����,Rarerity.SR},
        {Tag.��������,Rarerity.SR},
        {Tag.���ֵ���,Rarerity.SR},
        {Tag.�������,Rarerity.SR},
        {Tag.���˾���,Rarerity.SR},
        {Tag.��������,Rarerity.SR},
        {Tag.��Բ����,Rarerity.SR},
        {Tag.�Ļ�ɳĮ,Rarerity.SR},
        {Tag.�书С��,Rarerity.SR},
        {Tag.����֮��,Rarerity.SSR},
        {Tag.����,Rarerity.SR},
        {Tag.����,Rarerity.SR},
        {Tag.����֮־,Rarerity.SR},
        {Tag.��������,Rarerity.SR},
        {Tag.��������,Rarerity.SR},
        {Tag.��Ǯ��,Rarerity.SR},
        {Tag.����,Rarerity.SR},
        {Tag.Ѫ����,Rarerity.SR},
        {Tag.����,Rarerity.SR},
        {Tag.��Ȼ������,Rarerity.SSR},
        {Tag.Χ��ʮ��,Rarerity.SSR},
        {Tag.״Ԫ,Rarerity.SSR},
        {Tag.ʫ��,Rarerity.SSR},
        {Tag.����,Rarerity.SSR},
        {Tag.�˶�֮��,Rarerity.SSR},
        {Tag.��ʥ,Rarerity.SSR},
        {Tag.��Ӱ,Rarerity.SSR},
        {Tag.��ʯ,Rarerity.SSR},
        {Tag.���侫ͨ,Rarerity.SSR},
        {Tag.ֽ��̸��,Rarerity.SSR},
        {Tag.ͽ������,Rarerity.SSR},
        {Tag.Ͷ��ȡ��,Rarerity.SSR},
        {Tag.����ħ��,Rarerity.SSR},
        {Tag.�ĺ�����,Rarerity.SSR},
        {Tag.ī�سɹ�,Rarerity.SSR},
        {Tag.�ɶ��칤,Rarerity.SSR},
        {Tag.��������,Rarerity.SSR},
        {Tag.ī��,Rarerity.SSR},
        {Tag.����,Rarerity.SSR},
        {Tag.����,Rarerity.SSR},
        {Tag.����,Rarerity.SSR},
        {Tag.��ʤ,Rarerity.SSR},
        {Tag.����,Rarerity.SSR},
        {Tag.��֮��,Rarerity.SSR},
        {Tag.����ѹ��,Rarerity.SSR},
        {Tag.��������,Rarerity.SSR},
        {Tag.�������,Rarerity.SSR},
        {Tag.����,Rarerity.SSR},
        {Tag.������,Rarerity.SSR},
        {Tag.ӥ֮��,Rarerity.SSR},
        {Tag.�������,Rarerity.SSR},
        {Tag.�ٶ�����,Rarerity.SSR},
        {Tag.���ӿ��,Rarerity.SSR},
        {Tag.��������,Rarerity.SSR},
        {Tag.��֮��,Rarerity.SSR},
        {Tag.Ǳ����ҫ,Rarerity.SSR},
        {Tag.���ʺ���,Rarerity.SSR},
        {Tag.ƽ������,Rarerity.SSR},
        {Tag.���޼�����,Rarerity.UR},
        {Tag.�����·�,Rarerity.UR},
        {Tag.����,Rarerity.UR},
        {Tag.����˫ȫ,Rarerity.UR},
        {Tag.�ɵ�,Rarerity.UR},
        {Tag.��������,Rarerity.UR},
        {Tag.�������,Rarerity.UR},
        {Tag.��Ѫ����,Rarerity.UR},
   };
    public readonly static Dictionary<Tag, List<Tag>> MergeTagDict = new Dictionary<Tag, List<Tag>>
    {
        {Tag.����,new List<Tag>(){Tag.����,Tag.����}},
        {Tag.����,new List<Tag>(){Tag.����,Tag.����}},
        {Tag.��,new List<Tag>(){Tag.����,Tag.����}},
        {Tag.��,new List<Tag>(){Tag.����,Tag.����}},
        {Tag.�����·�,new List<Tag>(){Tag.Χ��ʮ��,Tag.�ݺ��}},
        {Tag.��Ȼ������,new List<Tag>(){Tag.����,Tag.��,Tag.ƽƽ����}},
        {Tag.�˶�֮��,new List<Tag>(){Tag.��ͨ����,Tag.�Ż�����,Tag.�����ļ�} },
        {Tag.���侫ͨ,new List<Tag>(){Tag.��,Tag.ǹ,Tag.��,Tag.�,Tag.��}},
        {Tag.����˫ȫ,new List<Tag>(){Tag.��,Tag.��}},
        {Tag.ֽ��̸��,new List<Tag>(){Tag.�����ļ�,Tag.���,Tag.��������}},
        {Tag.ͽ������,new List<Tag>(){Tag.�Ż�����,Tag.���в���,Tag.�廨��ͷ}},
        { Tag.Ͷ��ȡ��,new List<Tag>(){Tag.�����ļ�,Tag.С��ı��,Tag.��������}},
        {Tag.����ħ��, new List<Tag>(){Tag.����ɽ��,Tag.���,Tag.�����ͽ}},
        {Tag.�ĺ�����,new List<Tag>(){Tag.��Ѫ����,Tag.��û�޳�}},
        {Tag.ī�سɹ�,new List<Tag>(){Tag.�����,Tag.����֮��,Tag.����}},
        {Tag.�Ż�����,new List<Tag>(){Tag.���в���,Tag.����}},
        {Tag.�����ļ�,new List<Tag>(){Tag.����ѧ,Tag.���}},
        {Tag.����ɽ��,new List<Tag>(){Tag.���,Tag.����֢}},
        {Tag.����֮��,new List<Tag>(){Tag.�����,Tag.����}},
        {Tag.����˫ȫ,new List<Tag>(){Tag.С��ı��,Tag.���}},
        {Tag.��������,new List<Tag>(){Tag.����֢,Tag.٪��֢}},
        {Tag.����ѧ��,new List<Tag>(){Tag.����,Tag.��ʿ,Tag.ɮ��}},
        {Tag.���Ǵ�,new List<Tag>(){Tag.��󡹦,Tag.������˥}},
        {Tag.��������,new List<Tag>(){Tag.��˪����,Tag.��Т��}},
        {Tag.����ʿ,new List<Tag>(){Tag.����,Tag.��ë��}},
        {Tag.�⽻��,new List<Tag>(){Tag.������,Tag.������}},
        {Tag.�ϵ���׳,new List<Tag>() { Tag.ϰ��֮��,Tag.������˥} },
        {Tag.������ʦ,new List<Tag>(){Tag.��ͯ,Tag.��ʦ,Tag.�뾭�ѵ�}},
        {Tag.��ս��ͨ,new List<Tag>(){Tag.��,Tag.��}},
        {Tag.����ת��,new List<Tag>(){Tag.ϥ�ǽ�Ӳ,Tag.������,Tag.����}},
        {Tag.��ƴ�ʦ,new List<Tag>(){Tag.����ѧ,Tag.����}},
        {Tag.Ϸ��,new List<Tag>(){Tag.��Ա,Tag.����}},
        {Tag.�����,new List<Tag>(){Tag.����˾,Tag.����}},
        {Tag.ѱ�޴�ʦ,new List<Tag>(){Tag.����,Tag.ѱ����}},
        {Tag.��Ϸ��,new List<Tag>(){Tag.��Ա,Tag.������˥}},
        {Tag.����,new List<Tag>(){Tag.����,Tag.ѱ����}},
        {Tag.����,new List<Tag>(){Tag.Ӫ������,Tag.��������}},
        {Tag.����,new List<Tag>(){Tag.ī��,Tag.�氮}},
        {Tag.�ɶ��칤,new List<Tag>(){Tag.��,Tag.С��}},
        {Tag.��������,new List<Tag>(){Tag.ҽ��,Tag.����,Tag.���ݸ�Ŀ,Tag.�Ƶ��ھ�}},
        {Tag.ī��,new List<Tag>(){Tag.��ʦ,Tag.�ǹ�}}

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
        {ItemName.��������ҩ,Tag.��������},
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
        {ItemName.ɽ����,Tag.��ͨ����},
        {ItemName.���زо�,Tag.��ʦ},
        {ItemName.����������,Tag.���Ŷݼ�},
        {ItemName.�����,Tag.�ݺ��},
        {ItemName.ŷұ�ӵĴ�,Tag.��},
        {ItemName.�Ƶ��ھ�,Tag.�Ƶ��ھ�},
        {ItemName.���ݸ�Ŀ,Tag.���ݸ�Ŀ},
        {ItemName.��ʯ�ҷ繭,Tag.�ٲ�����},
        {ItemName.�һ�ն�Ƶ�,Tag.����},
        {ItemName.��ľ�׵�ǹ,Tag.�׵編��},
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
        {ItemName.��֥,Tag.���ֵ���},
        {ItemName.���廪��,Tag.��ƴ�ʦ},
        {ItemName.ľ������,Tag.�ز�},
        {ItemName.��˷���,Tag.�ز�},
        {ItemName.��������,Tag.�ز�},
        {ItemName.�峴����,Tag.�ز�},
        {ItemName.��޷����,Tag.���},
        {ItemName.ľ����,Tag.���},
        {ItemName.����ɢ,Tag.����},
        {ItemName.������,Tag.���վ�տ},
        {ItemName.ϴ�赤,Tag.��������},
        {ItemName.��󡹦�ؼ�,Tag.��󡹦},
        {ItemName.������,Tag.ͨ������},
        {ItemName.��˪����,Tag.��˪����},
        {ItemName.�ƽ�,Tag.�����鷢},
        {ItemName.����ǹ,Tag.һ�㺮â},
        {ItemName.�󿳵�,Tag.�����},
        {ItemName.��Ƭ�,Tag.���վ�տ},
        {ItemName.�����澭,Tag.��������},
        {ItemName.�����澭,Tag.�߻���ħ},
        {ItemName.���̱�ʯ,Tag.���˵�ͷ},
        {ItemName.����,Tag.����},
        {ItemName.����ʵ�,Tag.������},
        {ItemName.����ʵ�,Tag.������},
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
        {ItemName.����,Tag.�ܸ�����},
        {ItemName.�챦ʯ,Tag.��ⱦ��},
        {ItemName.��ˮ��,Tag.��ⱦ��},
        {ItemName.����ʯ,Tag.��ⱦ��},
        {ItemName.��ĸ��,Tag.��ⱦ��},
        {ItemName.ī�ӷǹ�,Tag.�ǹ�},
        {ItemName.ī�Ӽ氮,Tag.�氮},
        {ItemName.�����ӡ,Tag.����˾},
        {ItemName.����,Tag.��ʦ},
        {ItemName.Ψ����,Tag.�뾭�ѵ�},
        {ItemName.����ƿ,Tag.���˲���},
        {ItemName.���,Tag.���},
        {ItemName.��Ҷ��,Tag.�þ�֮��},
        {ItemName.�ſ���,Tag.�þ�֮��},
        {ItemName.Ů����,Tag.�þ�֮��},
        {ItemName.��ֳ�д�,Tag.����ѧ},
        {ItemName.ŷұ�ӵ�С��,Tag.С��},
        {ItemName.�˺��Ӳ���,Tag.����},
        {ItemName.�����,Tag.��ζ�ӳ�},
        {ItemName.���õĿ���,Tag.��ë��},
        {ItemName.���ֵ�����,Tag.��������},
        {ItemName.�ϻ�,Tag.ѱ����},
        {ItemName.��,Tag.ѱ����},
        {ItemName.����,Tag.����},
        {ItemName.�廨��,Tag.����},
        {ItemName.��ɰ֬,Tag.��ⱦ��},
        {ItemName.�̵�,Tag.����},
        {ItemName.������,Tag.��ë��},
        {ItemName.�ɹ���,Tag.��ë��},
        {ItemName.������,Tag.��ë��},
        {ItemName.��ü��,Tag.���νý�},
        {ItemName.���,Tag.�����鷢},
        {ItemName.С��,Tag.��ʦ},
        {ItemName.����,Tag.���վ�տ},
        {ItemName.�Ĺ�״,Tag.����},
        {ItemName.���״,Tag.����},
        {ItemName.����,Tag.ƽƽ����},
        {ItemName.����,Tag.ƽƽ����},
        {ItemName.���,Tag.���},
        {ItemName.�ƾ�,Tag.���},
        {ItemName.���,Tag.���},
        {ItemName.«��,Tag.���},
        {ItemName.���ʾ�,Tag.���},
        {ItemName.������,Tag.���},
        {ItemName.����ı�ʯ,Tag.��������},
        {ItemName.ȱ�ڵı�ʯ,Tag.��������},
        {ItemName.������Ļƽ�,Tag.��������},
        {ItemName.����,Tag.���˴���},
        {ItemName.��ѿ,Tag.���˴���},
        {ItemName.��Ƥ,Tag.���˴���},
        {ItemName.����,Tag.���˴���},
        {ItemName.�컨,Tag.���˴���},
        {ItemName.�����,Tag.�廨��ͷ},
        {ItemName.�Ӽ�,Tag.�����弼},
        {ItemName.���ӵ�,Tag.������},
        {ItemName.����,Tag.���в���},
        {ItemName.ϴԩ¼,Tag.��ʦ},
        {ItemName.����,Tag.ҹ������},
        {ItemName.����,Tag.����},
        {ItemName.������,Tag.��ë��},
        {ItemName.��β��,Tag.��ë��},
        {ItemName.Т��,Tag.��Т��},
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
        {ItemName.��ͷ���,Tag.ҽ��},
        {ItemName.�ɻ�ʯ,Tag.�����弼},
        {ItemName.��Ҷ,Tag.�����弼},
        {ItemName.������,Tag.ë����ʢ},
        {ItemName.��ҩ,Tag.ϰ��֮��},
        {ItemName.��,Tag.��������},
        {ItemName.ֹѪ��,Tag.ϰ��֮��},
        {ItemName.��������� ,Tag.��̬����},
        {ItemName.�峴��ѿ,Tag.����},
        {ItemName.�Ļƹ�,Tag.����},
        {ItemName.������,Tag.����},
        {ItemName.�������ܲ�,Tag.����},
        {ItemName.����,Tag.𯹤�ϲ�},
        {ItemName.ͭ��,Tag.𯹤�ϲ�},
        {ItemName.����,Tag.𯹤�ϲ�},
        {ItemName.��ƥ,Tag.𯹤�ϲ�},
        {ItemName.ľͷ,Tag.𯹤�ϲ�},
        {ItemName.Ƥ��,Tag.𯹤�ϲ�},
        {ItemName.í��,Tag.𯹤�ϲ�},
        {ItemName.Ӳľ,Tag.𯹤�ϲ�},
        {ItemName.��ֽ,Tag.�廨��ͷ},
        {ItemName.��֬,Tag.�廨��ͷ},
        {ItemName.��,Tag.�����Ӱ�},
        {ItemName.����,Tag.�����Ӱ�},
        {ItemName.����,Tag.�����Ӱ�},
        {ItemName.��,Tag.�����Ӱ�},
        {ItemName.��,Tag.�����Ӱ�},
        {ItemName.������,Tag.ҩ��},
        {ItemName.����,Tag.ҩ��},
        {ItemName.�˽���,Tag.ҩ��},
        {ItemName.����,Tag.ҩ��},
        {ItemName.�޺���,Tag.ҩ��},
        {ItemName.Ѫ����,Tag.ҩ��},
        {ItemName.�ƾ�,Tag.ҩ��},
        {ItemName.�׻������,Tag.ҩ��},
        {ItemName.ˮ��,Tag.ͷ��},
        {ItemName.����,Tag.��������},
        {ItemName.��ȱ�ڵ�����,Tag.���ܿ�ŭ},
        {ItemName.���·�,Tag.�²�����},
        {ItemName.����,Tag.����֢},
        {ItemName.����,Tag.ҩ��},
        {ItemName.���,Tag.ҩ��},
        {ItemName.���ҷ�,Tag.�����Ӱ�},
        {ItemName.�ǳ���,Tag.ҩ��},
        {ItemName.��ɽ��,Tag.ҩ��},
        {ItemName.��������,Tag.Ǳ����ҫ},
        {ItemName.��������,Tag.���ʺ���},
        {ItemName.��֯������,Tag.ƽ������},
        {ItemName.������,Tag.��Բ����},
        {ItemName.�ƺ�«,Tag.��ȭ},
        {ItemName.ľ����,Tag.ɮ��},
        {ItemName.��˿,Tag.𯹤�ϲ�},
        {ItemName.Ƥë,Tag.𯹤�ϲ�},
        {ItemName.�鲼,Tag.𯹤�ϲ�},
        {ItemName.����,Tag.����֮��},

    };
    public static Dictionary<Tag, GameObject> TagPrefabDict = new Dictionary<Tag, GameObject> { };


    private static Dictionary<Rarerity, List<Tag>> FemalePoestTagPool =
        new Dictionary<Rarerity, List<Tag>>
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫,
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
        };
    private static Dictionary<Rarerity, List<Tag>> FemaleCivilianTagPool =
    new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.ϰ��֮��,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
            Tag.����˫ȫ
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
        {
}}
    };
    private static Dictionary<Rarerity, List<Tag>> MaleScholarTagPool =
       new Dictionary<Rarerity, List<Tag>>
       {
           {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
       };
    private static Dictionary<Rarerity, List<Tag>> MaleBladeuserTagPool =
       new Dictionary<Rarerity, List<Tag>>
   {
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.Ŀ��ʶ��,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���νý�,
            Tag.�����,
            Tag.�뾭�ѵ�,
            Tag.������,
            Tag.����,
            Tag.����,
            Tag.����

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.������ı,
            Tag.����֢,
            Tag.٪��֢,
            Tag.����,
            Tag.��ʿ,
            Tag.ɮ��,
            Tag.��Ѫ����,
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.ϰ��֮��,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.��ʥ,
            Tag.��Ӱ,
            Tag.��ʯ
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
       };
    private static Dictionary<Rarerity, List<Tag>> MaleFighterTagPool =
      new Dictionary<Rarerity, List<Tag>>
   {
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.Ŀ��ʶ��,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���νý�,
            Tag.�����,
            Tag.�뾭�ѵ�,
            Tag.������,
            Tag.����,
            Tag.����,
            Tag.����

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.������ı,
            Tag.����֢,
            Tag.٪��֢,
            Tag.����,
            Tag.��ʿ,
            Tag.ɮ��,
            Tag.��Ѫ����,
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.��ʥ,
            Tag.��Ӱ,
            Tag.��ʯ
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
      };
    private static Dictionary<Rarerity, List<Tag>> MusicianTagPool =
       new Dictionary<Rarerity, List<Tag>>
       {
           {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
       };

    private static Dictionary<Rarerity, List<Tag>> MalePoliticianTagPool =
   new Dictionary<Rarerity, List<Tag>>
   {
           {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.����,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.ϰ��֮��,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
            Tag.����˫ȫ
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
        {
}}
   };

    private static Dictionary<Rarerity, List<Tag>> ElderlyTagPool =
        new Dictionary<Rarerity, List<Tag>>
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.Ŀ��ʶ��,
            Tag.������˥,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.ϰ��֮��,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
            Tag.����˫ȫ
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
        {
}}
        };
    private static Dictionary<Rarerity, List<Tag>> MonkTagPool =
  new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.Ŀ��ʶ��,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���νý�,
            Tag.�����,
            Tag.������,
            Tag.����,
            Tag.����,
            Tag.����

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.������ı,
            Tag.����֢,
            Tag.٪��֢,
            Tag.ɮ��,
            Tag.��Ѫ����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.ϰ��֮��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.��ʥ,
            Tag.��Ӱ,
            Tag.��ʯ
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
  };
    private static Dictionary<Rarerity, List<Tag>> GovernorTagPool =
  new Dictionary<Rarerity, List<Tag>>
  {
            {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.����,
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
            Tag.�뾭�ѵ�,
            Tag.������,
            Tag.����,
            Tag.���,
            Tag.����,
            Tag.����

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.����,
            Tag.������ı,
            Tag.��������,
            Tag.��������,
            Tag.����֢,
            Tag.٪��֢,
            Tag.����,
            Tag.��ʿ,
            Tag.ɮ��,
            Tag.��Ѫ����,
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,

    }},
        {Rarerity.UR,new List<Tag>()
        {
  }}
};
    private static Dictionary<Rarerity, List<Tag>> ChessplayerTagPool =
        new Dictionary<Rarerity, List<Tag>>
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.Ŀ��ʶ��,
            Tag.������˥,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.ϰ��֮��,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
            Tag.����˫ȫ
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,
            Tag.��ʥ,
            Tag.��Ӱ,
            Tag.��ʯ,
            Tag.�ݺ��
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
        };
    private static Dictionary<Rarerity, List<Tag>> StorytellerTagPool =
       new Dictionary<Rarerity, List<Tag>>
       {
           {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
       };
    private static Dictionary<Rarerity, List<Tag>> LooterTagPool =
   new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.Ŀ��ʶ��,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���νý�,
            Tag.�����,
            Tag.�뾭�ѵ�,
            Tag.������,
            Tag.����,
            Tag.����,
            Tag.����

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.������ı,
            Tag.����֢,
            Tag.٪��֢,
            Tag.����,
            Tag.��ʿ,
            Tag.ɮ��,
            Tag.��Ѫ����,
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.ϰ��֮��,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.��ʥ,
            Tag.��Ӱ,
            Tag.��ʯ
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
   };
    private static Dictionary<Rarerity, List<Tag>> MissionaryTagPool =
   new Dictionary<Rarerity, List<Tag>>
   {
           {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
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
            Tag.��Ѫ����,
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
   };
    private static Dictionary<Rarerity, List<Tag>> MCTagPool =
   new Dictionary<Rarerity, List<Tag>>
   {
           {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
   };
    private static Dictionary<Rarerity, List<Tag>> EunuchTagPool =
    new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.ϰ��֮��,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.����ɽ��,
            Tag.��û�޳�,
            Tag.����֮��,
            Tag.����˫ȫ
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
        {
}}
    };
    private static Dictionary<Rarerity, List<Tag>> DancerTagPool =
   new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.��û�޳�,
            Tag.����֮��,
            Tag.����˫ȫ
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,
            Tag.��Ӱ,
            Tag.��ʯ
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
   };
    private static Dictionary<Rarerity, List<Tag>> SouthernFemaleTagPool =
    new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.�ȽŲ���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.С�����,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.������,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
            Tag.����֢,
            Tag.������,
            Tag.��֫,
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
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
            Tag.��Ѫ��,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.̰���ǽ�,
            Tag.��������,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.��û�޳�,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,
            Tag.��Ӱ,


    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
    };
    private static Dictionary<Rarerity, List<Tag>> CharmerTagPool =
new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.���˲���,
            Tag.��������,
            Tag.����,
            Tag.��������,
            Tag.�ɷ���,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.�ô����,
            Tag.���ܿ�ŭ,
            Tag.ͷ��,
            Tag.������,
            Tag.�İ�,
            Tag.��Ƥ��,
            Tag.�������,
            Tag.��Ż,
            Tag.��������,
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
            Tag.���νý�,
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
            Tag.����,
            Tag.��ʿ,
            Tag.ɮ��,
            Tag.��Ѫ����,
            Tag.��Ѫ��,
            Tag.����,
            Tag.�ද֢,
            Tag.ƽƽ����,
            Tag.��,
            Tag.��,
            Tag.ǹ,
            Tag.̰���ǽ�,
            Tag.��������,
            Tag.��,
            Tag.�

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.��û�޳�,
            Tag.����֮��,
            Tag.����˫ȫ
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,
            Tag.��Ӱ,
            Tag.��ʯ
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
};


    public static Dictionary<CharacterArtCode, Dictionary<Rarerity, List<Tag>>> CharacterFinalTagPool =
        new Dictionary<CharacterArtCode, Dictionary<Rarerity, List<Tag>>>()
        {
            {CharacterArtCode.Ůʫ��, FemalePoestTagPool },
            {CharacterArtCode.������, MaleScholarTagPool },
            {CharacterArtCode.�е���, MaleBladeuserTagPool },
            //{CharacterArtCode.�в���, MaleCivilianTagPool },
            //{CharacterArtCode.��Ƥ��, MaleLeatherArmorTagPool },
            //{CharacterArtCode.�и�, MaleWealthyTagPool },
            {CharacterArtCode.�й�, MalePoliticianTagPool },
            {CharacterArtCode.����, MaleFighterTagPool },
            //{CharacterArtCode.����, MaleElderlyTagPool },
            //{CharacterArtCode.Ů��, FemaleFighterTagPool },
            {CharacterArtCode.Ů����, FemaleCivilianTagPool },
            {CharacterArtCode.����, ElderlyTagPool },
            {CharacterArtCode.����, MonkTagPool },
            {CharacterArtCode.��Ա, GovernorTagPool },
            {CharacterArtCode.��ʥ, ChessplayerTagPool },
            {CharacterArtCode.��ʦ, MusicianTagPool},
            {CharacterArtCode.˵����, StorytellerTagPool},
            {CharacterArtCode.ʰ����, LooterTagPool},
            {CharacterArtCode.����ʿ, MissionaryTagPool },
            {CharacterArtCode.��Ԭİ, MCTagPool },
            {CharacterArtCode.̫��, EunuchTagPool },
            {CharacterArtCode.��Ů, DancerTagPool },
            {CharacterArtCode.�Ͻ�Ů, SouthernFemaleTagPool},
            {CharacterArtCode.����, CharmerTagPool}
        };

    public static Dictionary<TagType, List<Tag>> TagTypes =
        new Dictionary<TagType, List<Tag>>()
        {
            {TagType.ȫ��, new List<Tag>()
            {
                Tag.����˫ȫ,
                Tag.�ɵ�,
                Tag.��������,
                Tag.�������,
                Tag.��Ѫ����,
                Tag.½������
            } },
            {TagType.��е, new List<Tag>()
            {
                Tag.���޼�����,
                Tag.����,
                Tag.����,
                Tag.����,
                Tag.��ʤ,
                Tag.����,
                Tag.��֮��,
                Tag.����ѹ��,
                Tag.�ٲ�����,
                Tag.����,
                Tag.�׵編��,
                Tag.�ʼ�Ѫͳ,
                Tag.����,
                Tag.��Ǯ��,
                Tag.����,
                Tag.Ѫ����,
                Tag.��˪����,
                Tag.����,
                Tag.�����鷢,
                Tag.��������,
                Tag.һ�㺮â,
                Tag.��,
                Tag.��,
                Tag.ǹ,
                Tag.��,
                Tag.�
            } },
            {TagType.�Ĳ�, new List<Tag>()
            {
                Tag.�����·�,
                Tag.Χ��ʮ��,
                Tag.״Ԫ,
                Tag.ʫ��,
                Tag.����,
                Tag.�˶�֮��,
                Tag.ֽ��̸��,
                Tag.ͽ������,
                Tag.Ͷ��ȡ��,
                Tag.��������,
                Tag.�������,
                Tag.��ͨ����,
                Tag.�Ż�����,
                Tag.�����ļ�,
                Tag.����ѧ��,
                Tag.������ʦ,
                Tag.�ݺ��,
                Tag.Ϸ��,
                Tag.ʫ�˴�,
                Tag.���س�ի,
                Tag.���˾���,
                Tag.����,
                Tag.���,
                Tag.���в���,
                Tag.С��ı��,
                Tag.��ϲ��,
                Tag.ͨ������,
                Tag.�氮,
                Tag.�ǹ�,
                Tag.����,
                Tag.��ʿ,
                Tag.ɮ��,
                Tag.���ʺ���,
            } },
            {TagType.����, new List<Tag>()
            {
                Tag.����,
                Tag.��Ȼ������,
                Tag.��ʥ,
                Tag.��Ӱ,
                Tag.��ʯ,
                Tag.���侫ͨ,
                Tag.����ħ��,
                Tag.�ĺ�����,
                Tag.ī�سɹ�,
                Tag.����֮��,
                Tag.����ɽ��,
                Tag.��û�޳�,
                Tag.����֮��,
                Tag.����˫ȫ,
                Tag.��ʦ,
                Tag.���Ŷݼ�,
                Tag.��������,
                Tag.��������,
                Tag.����ʿ,
                Tag.�ϵ���׳,
                Tag.��ս��ͨ,
                Tag.����ת��,
                Tag.��������,
                Tag.�������,
                Tag.봽�սʿ,
                Tag.ʢʳ����,
                Tag.��������,
                Tag.�������,
                Tag.����֮־,
                Tag.���,
                Tag.���νý�,
                Tag.�����,
                Tag.�����ͽ,
                Tag.��󡹦,
                Tag.���վ�տ,
                Tag.��������,
                Tag.�߻���ħ,
                Tag.ϰ��֮��,
                Tag.Ǳ����ҫ,
                Tag.�书С��,
                Tag.�Ļ�ɳĮ,
                Tag.��ȭ,

            } },
            {TagType.����, new List<Tag>()
            {
                Tag.�ɶ��칤,
                Tag.��,
                Tag.С��,
                Tag.����
            } },
            {TagType.����, new List<Tag>()
            {
                Tag.��������,
                Tag.�Ƶ��ھ�,
                Tag.���ݸ�Ŀ,
                Tag.���ֵ���,
                Tag.����,
                Tag.��ͯ,
                Tag.ҽ��
            } },
            {TagType.�̼�, new List<Tag>()
            {
                Tag.��ƴ�ʦ,
                Tag.����,
                Tag.��������,
                Tag.����,
                Tag.����ѧ,
                Tag.����
            } },
            {TagType.��ְ, new List<Tag>()
            {
                Tag.��,
                Tag.��,
                Tag.�⽻��,
                Tag.�����,
                Tag.����,
                Tag.����,
                Tag.����˾,
                Tag.����,
                Tag.����,
                Tag.����
            } },
            {TagType.����, new List<Tag>()
            {
                Tag.ӥ֮��,
                Tag.���ӿ��,
                Tag.��������,
                Tag.��֮��,
                Tag.ѱ�޴�ʦ,
                Tag.��������,
                Tag.����,
                Tag.����,
                Tag.��ë��,
                Tag.ѱ����,
                Tag.��
            } },
            {TagType.����, new List<Tag>()
            {
                Tag.����,
                Tag.������,
                Tag.��������,
                Tag.��Բ����,
                Tag.���˵�ͷ,
                Tag.˿��,
                Tag.��а����,
                Tag.��ⱦ��,

            } },
            {TagType.ͨ��, new List<Tag>()
            {
                Tag.��ħ��,
                Tag.������,
                Tag.�ܸ�����,
                Tag.������,
                Tag.��ʦ,
                Tag.�뾭�ѵ�,
                Tag.������,
                Tag.����,
                Tag.��Ϸ��,
                Tag.����,
                Tag.�����,
                Tag.�ز�,
                Tag.���,
                Tag.��������,
                Tag.��ζ�ӳ�,
                Tag.�þ�֮��,
                Tag.������,
                Tag.��ʦ,
                Tag.������ı,
                Tag.��������,
                Tag.�廨��ͷ,
                Tag.�����弼,
                Tag.��������,
                Tag.��������,
                Tag.���в���,
                Tag.����֢,
                Tag.٪��֢,
                Tag.��ʦ,
                Tag.��Ѫ����,
                Tag.����,
                Tag.��Ѫ��,
                Tag.����,
                Tag.ƽƽ����,
                Tag.̰���ǽ�,
                Tag.��Ա,
                Tag.��������,
                Tag.����,
                Tag.���˴���,
                Tag.𯹤�ϲ�,
                Tag.��̬����,
                Tag.�����Ӱ�,
                Tag.ë����ʢ,
                Tag.������˥,
                Tag.���,
                Tag.����,
                Tag.��������,
                Tag.Ӫ������,
                Tag.�ɷ���,
                Tag.������,
                Tag.�ô����,
                Tag.���ܿ�ŭ,
                Tag.�İ�,
                Tag.������,
                Tag.��Ƥ��,
                Tag.��������
            } },
            {TagType.����, new List<Tag>()
            {
                Tag.�������,
                Tag.����,
                Tag.Ƥ��,
                Tag.����
            } },
            {TagType.����, new List<Tag>()
            {
                Tag.����֮��,
                Tag.���˲���,
                Tag.��������,
                Tag.Ŀ��ʶ��,
                Tag.�������,
                Tag.�²�����
            } },
            {TagType.����, new List<Tag>()
            {
                Tag.ϥ�ǽ�Ӳ,
                Tag.�ද֢,
                Tag.��Т��,
                Tag.�ȽŲ���,
                Tag.����,
                Tag.����,
                Tag.ҹ������,
                Tag.˫Ŀʧ��,
                Tag.����,
                Tag.�մ�,
                Tag.С�����,
                Tag.ͷ��,
                Tag.������,
                Tag.��Ż,
                Tag.����֢,
                Tag.������,
                Tag.��֫,
                Tag.ҩ��

            } },

        };
}
