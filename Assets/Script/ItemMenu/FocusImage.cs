using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class FocusImage : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private Text Name;
    [SerializeField] private Text Info;

    public void Setup(ItemName itemName)
    {
        Image.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnItemPath(itemName));
        LocalizedString itemString = new LocalizedString
        {
            TableReference = "Item",
            TableEntryReference = $"{itemName.ToString()}"
        };
        Name.text = itemString.GetLocalizedString();
        LocalizedString ItemDescriptionString = new LocalizedString
        {
            TableReference = "itemdescribe",
            TableEntryReference = $"{itemName.ToString()}"
        };
        Info.text = ItemDescriptionString.GetLocalizedString();
    }
}
