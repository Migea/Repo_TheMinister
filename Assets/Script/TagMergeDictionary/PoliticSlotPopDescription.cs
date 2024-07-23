using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class PoliticSlotPopDescription : MonoBehaviour
{
    public Text who;
    public Text serveTo;
    public Text tagNeeds;
    public Text variableNeeds;
    public Vector2 offset = new Vector2(85, -35);  // Offset from the mouse position
    private RectTransform imageRectTransform;
    private RectTransform canvasRectTransform;
    public TagFromWhere tagFromWherePref;
    public Transform tagSourceParent;
    public void Setup(PoliticSlot slot)
    {
        string whoString = "在职人员：";
        bool nobodyHere = false;
        bool ServeYou = false;
        if (slot.GateHolder != null)
        {
            whoString += slot.GateHolder.CharacterName;
            if (slot.GateHolder.bribed == true)
            {
                ServeYou = true;
            }
        }
        else if (slot.characterOnHold != null)
        {
            whoString += slot.characterOnHold.CharacterName;
            ServeYou = true;
        }
        else
        {
            whoString += "无";
            nobodyHere = true;
        }
        who.text = whoString;
        var tagList = slot.requestTagsInString;
        SetupTagFromWhere(tagList);
        if (nobodyHere)
        {
            serveTo.gameObject.SetActive(false);
            tagNeeds.gameObject.SetActive(true);
            variableNeeds.gameObject.SetActive(true);
            string tagNeedsText = "需要词条:";
            foreach (var tag in tagList)
            {
                tagNeedsText += $"\n {tag}";
            }
            tagNeeds.text = tagNeedsText;
            string variableNeedsText = "需要词条:";
            if (slot.Wisdom != Rarerity.Null) variableNeedsText += $"智 >= {slot.Wisdom}";
            if (slot.Writing != Rarerity.Null) variableNeedsText += $"才 >= {slot.Writing}";
            if (slot.Strategy != Rarerity.Null) variableNeedsText += $"谋 >= {slot.Strategy}";
            if (slot.Strength != Rarerity.Null) variableNeedsText += $"武 >= {slot.Strength}";
            if (slot.Defense != Rarerity.Null) variableNeedsText += $"守 >= {slot.Defense}";
            if (slot.Sneak != Rarerity.Null) variableNeedsText += $"刺 >= {slot.Sneak}";
            variableNeeds.text = variableNeedsText;
            if (variableNeedsText == "需要词条:") variableNeeds.gameObject.SetActive(false);

        }
        else
        {
            tagNeeds.gameObject.SetActive(false);
            serveTo.gameObject.SetActive(true);
            variableNeeds.gameObject.SetActive(false);
            LocalizedString loyalTo = new LocalizedString
            {
                TableReference = "UI",
                TableEntryReference = $"设置_效忠于"
            };
            if (ServeYou)
            {
                LocalizedString you = new LocalizedString
                {
                    TableReference = "Party",
                    TableEntryReference = $"你"
                };
                serveTo.text = $"{loyalTo}{you.GetLocalizedString()}";
            }
            else
            {
                LocalizedString factionTypeString = new LocalizedString
                {
                    TableReference = "Party",
                    TableEntryReference = $"{slot.GateHolder.FactionType}"
                };
                serveTo.text = $"{loyalTo}{factionTypeString.GetLocalizedString()}";
            }
        }
        if (gameObject.activeSelf)
        {
            OnEnable();
        }
    }
    private void OnEnable()
    {
        StartCoroutine(WaitToRebuildLayout(GetComponent<RectTransform>()));
        if (tagSourceParent.childCount != 0)
        {
            StartCoroutine(WaitToRebuildLayout(tagSourceParent.GetComponent<RectTransform>()));
        }
        foreach (Transform child in tagSourceParent)
        {
            StartCoroutine(WaitToRebuildLayout(child.GetComponent<RectTransform>()));
        }
        if (tagNeeds.gameObject.activeSelf)
        {
            StartCoroutine(WaitToRebuildLayout(tagNeeds.GetComponent<RectTransform>()));
        }

    }
    public void SetupTagFromWhere(List<string> tags)
    {
        TransformEx.Clear(tagSourceParent.transform);
        foreach (var tag in tags)
        {
            var clone = Instantiate(tagFromWherePref, tagSourceParent);

            clone.Setup((Tag)Enum.Parse(typeof(Tag), tag));
            //StartCoroutine(WaitToRebuildLayout(clone.GetComponent<RectTransform>()));
        }
    }
    IEnumerator WaitToRebuildLayout(RectTransform rectTransform)
    {
        yield return new WaitUntil(() => rectTransform.gameObject.activeSelf == true);
        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        canvasRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    private void Update()
    {
        SetPositionNextToMouse();
    }
    public void SetPositionNextToMouse()
    {
        if (imageRectTransform == null) return;
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
    public static void Show(PoliticSlot slot)
    {
        var ui = FindObjectOfType<PoliticSlotPopDescription>(true);
        ui.Setup(slot);
        ui.SetPositionNextToMouse();
        ui.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        FindObjectOfType<PoliticSlotPopDescription>()?.gameObject.SetActive(false);
    }
}
