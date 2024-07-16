using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    public ItemName itemName;
    private static Dictionary<ItemName, string> ItemDescription => SOItem.ItemDescription;
    public Text Name;
    public Text description;
    public Text stat;
    public Vector2 offset = new Vector2(15, -15);  // Offset from the mouse position
    private RectTransform imageRectTransform;
    private RectTransform canvasRectTransform;
    public ItemFromWhere itemFromWhere;
    public ItemToWhere itemToWhere;
    public GameObject dependent = null;
    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        canvasRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    public void SetItemDetail()
    {
        LocalizedString itemString = new LocalizedString
        {
            TableReference = "Item",
            TableEntryReference = $"{itemName.ToString()}"
        };
        Name.text = itemString.GetLocalizedString();
        description.text = ItemDescription[itemName];
        stat.text = ItemStatPrinter.PrintAllStats(itemName);
        itemFromWhere.Setup(itemName);
        itemToWhere.Setup(itemName);
    }
    private void OnEnable()
    {
        if (Name.text != itemName.ToString()) SetItemDetail();
        LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
    }
    private void Update()
    {
        SetPositionNextToMouse();
        if (dependent == null || dependent.activeSelf == false)
        {
            Hide();
        }
    }
    public void SetPositionNextToMouse()
    {
        // Convert mouse position to canvas space
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform,
            Input.mousePosition,
            null,
            out mousePos);

        // Add the offset to the mouse position
        mousePos += offset;

        // Set the anchored position based on mouse
        imageRectTransform.anchoredPosition = mousePos;

        // Clamp the position so the UI stays within the screen bounds
        Vector2 clampedPosition = imageRectTransform.anchoredPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -canvasRectTransform.sizeDelta.x / 2 + imageRectTransform.sizeDelta.x / 2, canvasRectTransform.sizeDelta.x / 2 - imageRectTransform.sizeDelta.x / 2);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -canvasRectTransform.sizeDelta.y / 2 + imageRectTransform.sizeDelta.y / 2, canvasRectTransform.sizeDelta.y / 2 - imageRectTransform.sizeDelta.y / 2);
        imageRectTransform.anchoredPosition = clampedPosition;
    }
    public static void Show(string target, GameObject dependent)
    {
        var ui = GameObject.FindObjectOfType<ItemDetailUI>(true);
        ui.itemName = (ItemName)Enum.Parse(typeof(ItemName), target);
        ui.dependent = dependent;
        ui.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        GameObject.FindObjectOfType<ItemDetailUI>(true).gameObject.SetActive(false);
        var ui = GameObject.FindObjectOfType<ItemDetailUI>(true);
        ui.dependent = null;
    }
}

public interface IDetailAble
{
    public void SetOnDetail(string target);
    public void SetOffDetail();
}