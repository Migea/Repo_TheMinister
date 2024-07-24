using PixelCrushers.QuestMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using TMPro;
using Language.Lua;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.Localization.Settings;

public class InteractAsset : MonoBehaviour, IDetailAble
{
    private Building building;
    private LocalizedString localizedString;
    public bool Active = false;
    public Material defaultMaterial;
    public Material highlightMaterial;
    public Material unreachMaterial;
    public TextMeshPro BuildingName;
    public TMP_FontAsset fontAsset;
    public string buildingNameText = "";
    public Color ReachableColor;
    public Color UnreachableColor;
    private void Awake()
    {

        building = GetComponent<Building>();
        GetComponent<Renderer>().material = defaultMaterial;
        BuildingName = GetComponentInChildren<TextMeshPro>(true);
        BuildingName.font = fontAsset;
        buildingNameText = building.buildingType.ToString();
        SetLocaleStoreText();
        BuildingName.renderer.sortingOrder = 100;
        BuildingName.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        AudioManager.Play("°´Å¥");
        if (Active == false) return;
        if (ChapterCounter.Instance.Chapter == 3 && building.buildingType != BuildingType.ÎäÆ÷ÆÌ && building.buildingType != BuildingType.Ìú½³ÆÌ && building.buildingType != BuildingType.ÏÉ¶¦Ì¨) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            //Debug.Log("Clicked on UI");
            return;
        }
        building.OpenMenu();
    }
    private void SetLocaleStoreText()
    {
        BuildingName.fontSize = 40f;
        localizedString = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = $"½¨ÖþÀàÐÍ_{building.buildingType.ToString()}"
        };
        BuildingName.text = localizedString.GetLocalizedString();
    }
    private void SetTooFar()
    {
        SetLocaleStoreText();
        BuildingName.fontSize = 20f;
        BuildingName.color = UnreachableColor;
        var tooFarString = new LocalizedString
        {
            TableReference = "sofar",
            TableEntryReference = $"Ì«Ô¶ÁË"
        };
        BuildingName.text = $"{BuildingName.text}\n ({tooFarString.GetLocalizedString()})";
    }
    private void OnMouseEnter()
    {
        BuildingName.renderer.sortingOrder = 100;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            //Debug.Log("OverUI");
            return;
        }
        SetOnDetail(building.buildingType.ToString());
        if (ChapterCounter.Instance.Chapter == 3)
        {
            if (building.buildingType == BuildingType.ÎäÆ÷ÆÌ)
            {

            }
            else if (building.buildingType == BuildingType.Ìú½³ÆÌ)
            {

            }
            else if (building.buildingType == BuildingType.ÏÉ¶¦Ì¨)
            {

            }
            else
            {
                GetComponent<Renderer>().material = unreachMaterial;
                BuildingName.fontSize = 30f;
                BuildingName.color = UnreachableColor;
                localizedString = new LocalizedString
                {
                    TableReference = "UI",
                    TableEntryReference = $"ÎÞÈËÓªÒµ"
                };
                BuildingName.text = localizedString.GetLocalizedString();
                BuildingName.gameObject.SetActive(true);
                return;
            }
        }
        if (Active == false)
        {
            GetComponent<Renderer>().material = unreachMaterial;
            SetTooFar();
            BuildingName.gameObject.SetActive(true);
            return;
        }
        GetComponent<Renderer>().material = highlightMaterial;
        BuildingName.fontSize = 40f;
        BuildingName.color = ReachableColor;
        SetLocaleStoreText();
        BuildingName.gameObject.SetActive(true);
    }
    private void OnMouseOver()
    {
        if (IsPointerOver.IsPointerOverUIObject() && BuildingName.gameObject.activeSelf == true)
        {
            OnMouseExit();
        }
        else
        {
            if (BuildingName.gameObject.activeSelf == false)
            {
                OnMouseEnter();
            }
        }
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = defaultMaterial;
        BuildingName.gameObject.SetActive(false);
        SetOffDetail();
        if (Active == false) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            return;
        }
    }
    IEnumerator HideUIUntilClose()
    {
        var hud = FindObjectOfType<UnityUIQuestHUD>();
        hud.Hide();
        yield return new WaitUntil(() => building.currentUI.gameObject.activeSelf == false);
        hud.Show();
    }

    public void SetOffDetail()
    {
        MenuDescriptionUI.Hide();
    }
    public void SetOnDetail(string target)
    {
        MenuDescriptionUI.Show(target);
    }
}