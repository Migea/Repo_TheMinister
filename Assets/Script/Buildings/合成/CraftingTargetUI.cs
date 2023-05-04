using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTargetUI : MonoBehaviour
{
    public Image itemIcon;
    public Image itemFrame;

    public void SetUp(ItemName item)
    {
        string path = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        itemIcon.sprite = Resources.Load<Sprite>(path);
        var rare = Player.AllTagRareDict[SOItem.ItemMap[item]];
        if (rare < Rarerity.N) rare = Rarerity.N;
        string FramePath = $"Art/BuildingUI/�ӻ���/���������/��Ʒ��/��Ʒ��-{rare}";
        itemFrame.sprite = Resources.Load<Sprite>(FramePath);
    }
}
