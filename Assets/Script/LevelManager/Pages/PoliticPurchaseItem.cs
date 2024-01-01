using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GovernorType 
{
    ����,
    ����,
    ��,
    ����,
    ����,
    ��
};
public class PoliticPurchaseItem : MonoBehaviour
{
    public static Dictionary<ItemName, int> LoyaltyShopPrice = new Dictionary<ItemName, int>()
    {
        {ItemName.�Ĺ�״, 2},
        {ItemName.���״, 2},
        {ItemName.��������, 1},
        {ItemName.�����ӡ, 1 }
    };

    public static Dictionary<GovernorType, List<ItemName>> GovernorShop = new Dictionary<GovernorType, List<ItemName>>()
    {
        {GovernorType.����, new List<ItemName>(){ItemName.�Ĺ�״,
                                                                                         ItemName.��������,}
        },
        {GovernorType.����,new List<ItemName>(){ItemName.�Ĺ�״,
                                                                                        ItemName.��������} },
        {GovernorType.��,new List<ItemName>(){ItemName.�Ĺ�״,
                                                                                        ItemName.��������} },
        {GovernorType.����,new List<ItemName>(){ItemName.���״,
                                                                                        ItemName.�����ӡ} },
        {GovernorType.����,new List<ItemName>(){ItemName.���״,
                                                                                        ItemName.�����ӡ} },
        {GovernorType.��,new List<ItemName>(){ItemName.���״,
                                                                                        ItemName.�����ӡ} },
    };
}
