using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinReturnTags : MonoBehaviour
{

    public static List<Tag> SwapTags = new List<Tag>()
    { Tag.ҩ��,
        Tag.ҩ��,
        Tag.ҩ��,
        Tag.��֫,
        Tag.��֫,
        Tag.����,
        Tag.����,
        Tag.����,
        Tag.���˲���,
        Tag.���˲���,
        Tag.�ȽŲ���,
        Tag.�ȽŲ���,
        Tag.�ȽŲ���,
        Tag.������,
        Tag.������,
        Tag.ͷ��,
        Tag.ͷ��,
        Tag.ϥ�ǽ�Ӳ,
        Tag.ϥ�ǽ�Ӳ,
        Tag.���˴���,
        Tag.��ζ�ӳ�,
    
    };
    
    public static Tag TagAfterAssassin()
    {       
            return SwapTags[Random.Range(0, SwapTags.Count - 1)];
    }

    public static List<Tag> GetTagsAfter()
    {
        List<Tag> AfterTags = new List<Tag>();
        int tagAmount = Random.Range(1, 3);
        for (int i = tagAmount;i >= 1; i --)
        {
            AfterTags.Add(TagAfterAssassin());
        }
        return AfterTags;
    }
    
   

    
}
