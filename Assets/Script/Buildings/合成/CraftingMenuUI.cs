using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public class CraftingMenuUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDetailAble
{
    public ItemName ItemName;
    public Image ItemIcon;
    public Text ItemNameText;
    public CraftingUI parentUI;


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetupParent);
    }
    public void SetupParent()
    {
        parentUI.Setup(ItemName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOnDetail(ItemName.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemNameText.color = Color.white;
        SetOffDetail();
    }

    public void SetUp(ItemName item)
    {
        ItemName = item;
        string path = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        ItemIcon.sprite = Resources.Load<Sprite>(path);
        LocalizedString ItemNameString = new LocalizedString
        {
            TableReference = "Item",
            TableEntryReference = $"{item}"
        };
        ItemNameText.text = ItemNameString.GetLocalizedString();
        if (ItemNameText.GetComponentInChildren<FontUpdater>() == null)
            ItemNameText.gameObject.AddComponent<FontUpdater>();
    }

    public void SetOnDetail(string target)
    {
        ItemDetailUI.Show(ItemName.ToString(), this.gameObject);
    }

    public void SetOffDetail()
    {
        ItemDetailUI.Hide();
    }
}
