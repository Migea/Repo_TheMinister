using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Animations;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class DisplayInfoAnimationController : MonoBehaviour
{
    public Animator animator;
    public Text NameText;
    public List<Image> TagImages;

    public bool FakeData = false;
    public List<string> FakeTags;
    public string FakeName;
    public bool setDone = false;

    public void Start()//change to enable
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
        StartupSettings();
    }
    public void StartupSettings()
    {
        if (FakeData)
        {
            List<Tag> tags = new List<Tag>();
            foreach (string tag in FakeTags)
            {
                tags.Add((Tag)Enum.Parse(typeof(Tag), tag));
            }
            SetupTags(tags);
            SetupName(FakeName);
            return;
        }
        else
        {
            var ai = GetComponent<DefaultInGameAI>();
            if (ai != null)
            {
                SetupTags(ai.character.tagList);
                SetupName(ai.character.CharacterName);
            }
        }
    }
    private void OnEnable()
    {
        if (FakeData && setDone == false)
        {
            List<Tag> tags = new List<Tag>();
            foreach (string tag in FakeTags)
            {
                tags.Add((Tag)Enum.Parse(typeof(Tag), tag));
            }
            SetupTags(tags);
            SetupName(FakeName);
            return;
        }
    }
    private void OnDestroy()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }
    private void OnLocaleChanged(Locale locale)
    {
        StartupSettings();
    }
    public void SetupName(string Name)
    {
        LocalizedString firstNameString = new LocalizedString
        {
            TableReference = "FirstName",
            TableEntryReference = $"{Name[0]}"
        };
        var LastName = Name.Substring(1);
        LocalizedString lasNameString = new LocalizedString
        {
            TableReference = "LastName",
            TableEntryReference = $"{LastName}"
        };
        NameText.text = firstNameString.GetLocalizedString() + lasNameString.GetLocalizedString();

    }
    public void SetupTags(List<Tag> tags)
    {
        int index = 0;
        foreach (Tag tag in tags)
        {
            TagImages[index].sprite = TagWithDescribetion.GetTagBackground(tag);
            if (TagImages[index].GetComponentInChildren<Text>() == false)
            {
                var tagText = new GameObject().AddComponent<Text>();
                tagText.transform.parent = TagImages[index].transform;
                tagText.name = "TagText";
                tagText.fontSize = 60;
                tagText.alignment = TextAnchor.MiddleCenter;
                tagText.gameObject.AddComponent<FontUpdater>();
                tagText.lineSpacing = 0.4f;
                ColorUtility.TryParseHtmlString("#323232", out Color myColor);
                tagText.color = myColor;
                var rect = tagText.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(0, 0);
                rect.anchorMax = new Vector2(1, 1);
                rect.anchorMin = new Vector2(0, 0);
                rect.pivot = new Vector2(0.5f, 0.5f);
                rect.localScale = new Vector3(1, 1, 1);
                rect.rotation = TagImages[index].transform.rotation;
            }
            TagImages[index].GetComponentInChildren<Text>().text = TagWithDescribetion.GetDisplayTagText(tag);

            index++;
        }
    }
    public void Show()
    {
        animator.Play("Show");
        NameText.gameObject.SetActive(true);
    }
    public void Hide()
    {
        animator.Play("Hide");
        NameText.gameObject.SetActive(false);
    }
    public void OnMouseEnter()
    {
        if (IsPointerOver.IsPointerOverUIObject())
        {
            //Debug.Log("OverUI");
            return;
        }
        Show();
    }
    public void OnMouseExit()
    {
        Hide();
    }
}
