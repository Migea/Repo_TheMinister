using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagDescriptionUI : MonoBehaviour
{
    public Image tagImage;
    public Text tagText;
    public Text tagStats;
    private Tag currentTag = Tag.Null;
    public Vector2 offset = new Vector2(15, -15);  // Offset from the mouse position
    private RectTransform imageRectTransform;
    private RectTransform canvasRectTransform;
    public TagMergeUnitUI mergeUnitUITemp = null;
    public Transform mergeInfoHolder = null;
    public TagFromWhere tagFromWhere = null;
    public GameObject timeLeftGO = null;
    public Text timeLeftText = null;

    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        canvasRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    public static void Show(string tag)
    {
        var ui = FindObjectOfType<TagDescriptionUI>(true);
        ui.Setup(tag);
        ui.SetPositionNextToMouse();
        ui.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        FindObjectOfType<TagDescriptionUI>().gameObject.SetActive(false);
    }
    private void Setup(string tag)
    {
        var targetTag = (Tag)Enum.Parse(typeof(Tag), tag);
        if (currentTag != targetTag)
        {
            currentTag = targetTag;
            tagImage.sprite = TagWithDescribetion.GetTagBackground(targetTag);
            tagText.text = TagWithDescribetion.GetTagText(targetTag);
            tagStats.text = ItemStatPrinter.PrintAllStats(currentTag);
            SetMergeInfo(targetTag);
            tagFromWhere.Setup(targetTag);
            timeLeftGO.SetActive(false);
        }
    }
    public static void ShowTemp(string tag, int timeLeft)
    {
        var ui = FindObjectOfType<TagDescriptionUI>(true);
        ui.SetupTemp(tag, timeLeft);
        ui.SetPositionNextToMouse();
        ui.gameObject.SetActive(true);
    }
    private void SetupTemp(string tag, int timeLeft)
    {
        var targetTag = (Tag)Enum.Parse(typeof(Tag), tag);

        currentTag = targetTag;
        tagImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnTagPath(currentTag));
        tagStats.text = ItemStatPrinter.PrintAllStats(currentTag);
        timeLeftGO.SetActive(true);
        timeLeftText.text = timeLeft.ToString();
        tagFromWhere.Setup(targetTag);
        SetMergeInfo(targetTag);
    }
    public void ResetMergeInfo()
    {
        foreach (Transform child in mergeInfoHolder)
        {
            Destroy(child.gameObject);
        }
    }
    private void SetMergeInfo(Tag tag)
    {
        ResetMergeInfo();
        Dictionary<Tag, List<Tag>> outputMergeTagDict = new Dictionary<Tag, List<Tag>>();
        foreach (var suspect in Player.MergeTagDict)
        {
            if (suspect.Value.Contains(tag))
            {
                outputMergeTagDict.Add(suspect.Key, suspect.Value);
            }
        }
        foreach (var target in outputMergeTagDict)
        {
            var clone = Instantiate(mergeUnitUITemp, mergeInfoHolder);
            clone.Setup(target.Key);
        }
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
}
