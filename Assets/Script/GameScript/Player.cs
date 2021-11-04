using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Map map;
    public static Dictionary<Tag, List<int>> TagInfDict = new Dictionary<Tag, List<int>>() {
        {Tag.Null, new List<int>(){0,0,0,0, 0,0}},
        {Tag.���,new List<int>(){40,0,0,0,0,0}} ,
        {Tag.���в���,new List<int>(){0,40,0,0,0,0}},
        {Tag.С��ı��,new List<int>(){0,0,40,0,0,0}},
        {Tag.���,new List<int>(){0,0,0,40,0,0}},
        {Tag.���νý�,new List<int>(){0,0,0,0,40,0}},
        {Tag.�����,new List<int>(){0,0,0,0,0,40}},
        {Tag.����,new List<int>(){15,15,15,0,0,0}},
        {Tag.����,new List<int>(){0,0,0,15,15,15}},
        {Tag.�ɷ���,new List<int>(){-20,-20,-20,-20,-20,-20}},
        {Tag.������ı,new List<int>(){0,0,-20,18,0,0}},
        {Tag.��������,new List<int>(){0,-20,18,0,0,0}},
        {Tag.�廨��ͷ,new List<int>(){-20,18,0,0,0,0}},
        {Tag.�����弼,new List<int>(){-20,0,0,0,18,0}},
        {Tag.��������,new List<int>(){18,0,0,0,-20,0}},
        {Tag.��������,new List<int>(){0,0,18,0,0,-20}},
        {Tag.˫Ŀʧ��,new List<int>(){-10,-10,-10,-10,-10,-10}},
        {Tag.����,new List<int>(){0,0,0,-12,-12,-12}},
        {Tag.�մ�,new List<int>(){-20,-20,-20,0,0,0}},
        {Tag.������,new List<int>(){-5,-5,-5,-18,-18,-18}},
        {Tag.���в���,new List<int>(){0,0,0,0,0,0}},
        {Tag.����֢,new List<int>(){0,0,0,22,0,0}},
        {Tag.٪��֢,new List<int>(){22,0,0,0,0,0}},
        {Tag.С�����,new List<int>(){0,0,0,-22,-22,-22}},
        {Tag.Ŀ��ʶ��,new List<int>(){-22,-22,-22,0,0,0}},
        {Tag.����,new List<int>(){0,25,0,0,0,0}},
        {Tag.��ʿ,new List<int>(){0,0,25,0,0,0}},
        {Tag.ɮ��,new List<int>(){25,0,0,0,0,0}},
        {Tag.�Ϲ�,new List<int>(){12,12,12,0,0,0}},
        {Tag.��Ѫ����,new List<int>(){0,0,0,12,12,12}},
        {Tag.��󡹦,new List<int>(){0,0,0,18,18,6}},
        {Tag.����,new List<int>(){6,6,0,-3,0,0}},
        {Tag.��������,new List<int>(){0,0,0,-5,0,0}},
        {Tag.Ӫ������,new List<int>(){0,0,0,0,0,0}},
        {Tag.ҹ������,new List<int>(){0,0,0,0,0,0}},
        {Tag.����,new List<int>(){0,0,0,0,0,0}},
        {Tag.��Ѫ��,new List<int>(){0,0,0,14,28,0}},
        {Tag.����,new List<int>(){0,0,0,28,14,0}},
        {Tag.ϥ�ǽ�Ӳ,new List<int>(){0,0,0,0,0,0}},
        {Tag.ͨ������,new List<int>(){0,0,42,0,0,0}},
        {Tag.�ද֢,new List<int>(){0,0,0,21,0,0}},
        {Tag.��Т��,new List<int>(){0,-12,0,0,0,0}},
        {Tag.��˪����,new List<int>(){0,0,0,40,0,0}},
        {Tag.��������,new List<int>(){0,0,0,90,0,0}},
        {Tag.��ë��,new List<int>(){0,0,0,0,40,0}},
        {Tag.����,new List<int>(){0,0,0,40,0,0}},
        {Tag.����ʿ,new List<int>(){0,0,0,50,50,50}},
        {Tag.�ܸ�����,new List<int>(){0,0,0,0,30,0}},
        {Tag.������,new List<int>(){15,15,0,0,0,0}},
        {Tag.������,new List<int>(){15,15,0,0,0,0}},
        {Tag.ƽƽ����,new List<int>(){1,1,1,1,1,1}},
        {Tag.��,new List<int>(){0,0,0,0,10,0}},
        {Tag.�ȽŲ���,new List<int>(){0,0,0,-20,-20,-20}},
        {Tag.������˥,new List<int>(){0,0,0,-10,-10,-10}},
        {Tag.ϰ��֮��,new List<int>(){0,0,0,10,10,10}},
        {Tag.״Ԫ,new List<int>(){120,0,0,0,0,0}},
        {Tag.ʫ��,new List<int>(){0,120,0,0,0,0}},
        {Tag.����,new List<int>(){0,0,120,0,0,0}},
        {Tag.��ʥ,new List<int>(){0,0,0,120,0,0}},
        {Tag.��Ӱ,new List<int>(){0,0,0,0,120,0}},
        {Tag.��ʯ,new List<int>(){0,0,0,0,0,120}},
        {Tag.��,new List<int>(){40,40,40,0,0,0}},
        {Tag.��,new List<int>(){0,0,0,40,40,40}},
        {Tag.��ͨ����,new List<int>(){80,0,0,0,0,0}},
        {Tag.�Ż�����,new List<int>(){0,80,0,0,0,0}},
        {Tag.�����ļ�,new List<int>(){0,0,80,0,0,0}},
        {Tag.����ɽ��,new List<int>(){0,0,0,80,0,0}},
        {Tag.��û�޳�,new List<int>(){0,0,0,0,80,0}},
        {Tag.����֮��,new List<int>(){0,0,0,0,0,80}},
        {Tag.����˫ȫ,new List<int>(){0,-20,60,60,0,0}},
        {Tag.��ʦ,new List<int>(){60,0,0,-20,60,0}},
        {Tag.���Ŷݼ�,new List<int>(){0,60,0,0,-20,60}},
        {Tag.����ʱ������,new List<int>(){0,0,0,999,0,0}},
        {Tag.�����·�,new List<int>(){0,0,300,-2,-2,-2}},
        {Tag.�˶�֮��,new List<int>(){80,80,80,0,0,0}},
        {Tag.���侫ͨ,new List<int>(){0,0,0,80,80,80}},
        {Tag.����˫ȫ,new List<int>(){50,50,50,50,50,50}},
        {Tag.ֽ��̸��,new List<int>(){180,0,-40,0,0,0}},
        {Tag.ͽ������,new List<int>(){-40,180,0,0,0,0}},
        {Tag.Ͷ��ȡ��,new List<int>(){0,-40,180,0,0,0}},
        {Tag.����ħ��,new List<int>(){0,0,0,180,0,-40}},
        {Tag.�ĺ�����,new List<int>(){0,0,0,0,180,-40}},
        {Tag.��������,new List<int>(){0,0,0,48,0,0}},
        {Tag.����ѧ��,new List<int>(){50,50,50,0,0,0}},
        {Tag.�����ͽ,new List<int>(){30,30,30,30,30,30}},
        {Tag.���Ǵ�,new List<int>(){0,0,0,43,37,0}},
        {Tag.����,new List<int>(){0,0,0,-30,0,0}},
        {Tag.��ϲ��,new List<int>(){40,0,0,0,0,0}},
        {Tag.��ħ��,new List<int>(){0,0,0,28,0,14}},
        {Tag.�⽻��,new List<int>(){50,50,0,0,0,0}},
        {Tag.��Ȼ������,new List<int>(){0,0,0,100,100,100}},
        {Tag.Χ��ʮ��,new List<int>(){0,0,120,0,0,0}},
        {Tag.�ϵ���׳,new List<int>(){0,0,0,32,32,32}},
        {Tag.����,new List<int>(){30,30,30,0,0,0}},
        {Tag.����,new List<int>(){0,0,0,30,30,30}},
        {Tag.�ɵ�,new List<int>(){99,99,99,99,99,99}}
    };
    public static Dictionary<Raitity, List<Tag>> GivenableTagRareDict = new Dictionary<Raitity, List<Tag>>()
        {{ Raitity.SSR, new List<Tag>()
        {
            Tag.״Ԫ,
            Tag.ʫ��,
            Tag.����,
            Tag.��ʥ,
            Tag.��Ӱ,
            Tag.��ʯ
        } },
        { Raitity.R, new List<Tag>()
        {
            Tag.���,
            Tag.���в���,
            Tag.С��ı��,
            Tag.���,
            Tag.���νý�,
            Tag.�����,
            Tag.��󡹦,
            Tag.��Ѫ��,
            Tag.����,
            Tag.ͨ������,
            Tag.��˪����,
            Tag.��ë��,
            Tag.����,
            Tag.�ܸ�����,
            Tag.������,
            Tag.������
        } },
        { Raitity.N, new List<Tag>() {
            Tag.����,
            Tag.����,
            Tag.�ɷ���,
            Tag.������ı,
            Tag.��������,
            Tag.�廨��ͷ,
            Tag.�����弼,
            Tag.��������,
            Tag.��������,
            Tag.˫Ŀʧ��,
            Tag.����,
            Tag.�մ�,
            Tag.������,
            Tag.���в���,
            Tag.����֢,
            Tag.٪��֢,
            Tag.С�����,
            Tag.Ŀ��ʶ��,
            Tag.����,
            Tag.��ʿ,
            Tag.ɮ��,
            Tag.�Ϲ�,
            Tag.��Ѫ����,
            Tag.����,
            Tag.��������,
            Tag.Ӫ������,
            Tag.ҹ������,
            Tag.����,
            Tag.ϥ�ǽ�Ӳ,
            Tag.�ද֢,
            Tag.��Т��,
            Tag.ƽƽ����,
            Tag.��,
            Tag.�ȽŲ���,
            Tag.������˥,
            Tag.ϰ��֮��
        }},
        { Raitity.SR, new List<Tag>() {
            Tag.��,
            Tag.��,
            Tag.��ͨ����,
            Tag.�Ż�����,
            Tag.�����ļ�,
            Tag.����ɽ��,
            Tag.����֮��,
            Tag.����˫ȫ,
            Tag.��ʦ,
            Tag.���Ŷݼ�,
            Tag.��������,
            Tag.����ѧ��,
            Tag.���Ǵ�,
            Tag.�ɵ�,
            Tag.��������,
            Tag.�⽻��,
            Tag.�ϵ���׳
        } },
        { Raitity.UR, new List<Tag>(){
            Tag.����ʱ������,
            Tag.�����·�
        }}
};
    public static Dictionary<Raitity, List<Tag>> MergeableTagRareDict = new Dictionary<Raitity, List<Tag>> { };
    public static Dictionary<List<Tag>, Tag> MergeTagDict = new Dictionary<List<Tag>, Tag>
    {

    };
    public static Dictionary<Raitity, List<Tag>> ItemgiveTagRareDict = new Dictionary<Raitity, List<Tag>>()
    {

    };
    public static Dictionary<ItemName, Tag> ItemToTag = new Dictionary<ItemName, Tag>
    {
        { ItemName.Null, Tag.Null }
    };


    public static Dictionary<Tag, GameObject> TagPrefabDict = new Dictionary<Tag, GameObject> { };






}
