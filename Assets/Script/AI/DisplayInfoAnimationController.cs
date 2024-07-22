using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
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
    public void SetupName(string Name)
    {
        NameText.text = Name;
    }
    public void SetupTags(List<Tag> tags)
    {
        int index = 0;
        foreach (Tag tag in tags)
        {
            TagImages[index].sprite = TagWithDescribetion.GetTagBackground(tag);
            var tagText = Instantiate(new GameObject().AddComponent<Text>(), TagImages[index].transform);
            tagText.text = TagWithDescribetion.GetTagText(tag);
            tagText.fontSize = 15;
            tagText.alignment = TextAnchor.MiddleCenter;
            tagText.gameObject.AddComponent<FontUpdater>();
            var rect = tagText.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.anchorMin = new Vector2(0, 0);
            rect.pivot = new Vector2(0.5f, 0.5f);
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
