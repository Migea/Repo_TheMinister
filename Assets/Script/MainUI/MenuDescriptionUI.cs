using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class MenuDescriptionUI : MonoBehaviour
{
    public string Target = string.Empty;
    public SOGameDescription gameDescription;
    public Text description;
    public Vector2 offset = new Vector2(15, -15);  // Offset from the mouse position
    private RectTransform imageRectTransform;
    private RectTransform canvasRectTransform;
    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        canvasRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    private void Update()
    {
        SetPositionNextToMouse();
    }

    public void SetDescription()
    {
        LocalizedString DescriptionString = new LocalizedString
        {
            TableReference = "Describe",
            TableEntryReference = $"√Ë ˆ_{Target}"
        };
        description.text = DescriptionString.GetLocalizedString();
        //Rebuild();
    }
    private void OnEnable()
    {
        Rebuild();
    }
    public void Rebuild()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(imageRectTransform);
        var child = imageRectTransform.GetComponentInChildren<RectTransform>(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(child);
        var grandChild = child.GetComponentInChildren<RectTransform>(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(grandChild);
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
    public static void Show(string target)
    {
        var ui = GameObject.FindObjectOfType<MenuDescriptionUI>(true);
        if (ui.Target != target)
        {
            ui.Target = target;
            ui.SetDescription();
        }
        ui.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        GameObject.FindObjectOfType<MenuDescriptionUI>(true).gameObject.SetActive(false);
    }
}
