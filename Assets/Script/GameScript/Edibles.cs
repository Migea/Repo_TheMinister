using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdiblesItems : MonoBehaviour
{

    public enum EdibleType
    {
        ��ҩ,
        ��ҩ,
        ����,
        ����,
        ��ʳ,
        ��ʳ
    };
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
}
