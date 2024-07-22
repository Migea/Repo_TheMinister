using Language.Lua;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagTest : MonoBehaviour
{
    TagWithDescribetion tagWithDescribetion;
    public string tagString;
    private void Awake()
    {
        tagWithDescribetion = GetComponent<TagWithDescribetion>();
    }

    public void OnEnable()
    {
        Enum.TryParse(tagString, out Tag tag);
        tagWithDescribetion.Setup(tag);
    }
}
