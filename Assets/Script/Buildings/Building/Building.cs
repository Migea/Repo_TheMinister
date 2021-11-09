using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BuildingType
{
    ���
}

public enum BuildingLevel
{
    LevelOne,
    LevelTwo,
    LevelThree,
}
public class Building : MonoBehaviour, IPointerClickHandler
{
    public BuildingType buildingType;
    public List<Character> charactersHere;

    public Transform BuildingCharacterSlot;

    [SerializeField] private BuildingUI buildingUI;

    private void Awake()
    {
        UpdateType();
    }

    public void UpdateType()
    {
        string FolderPath = ("BuildingUI/" + buildingType.ToString()).Replace(" ", string.Empty);
        buildingUI = Resources.Load<BuildingUI>(FolderPath);
    }
    public void UpdateType(BuildingType buildingType)
    {
        this.buildingType = buildingType;
        UpdateType();
    }

    public void CreateUI()
    {
        BuildingUI targetUI = Instantiate(buildingUI,GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        targetUI.UpdateUI(this);
    }

    public void Upgrade(BuildingType upGradeType)
    {
        buildingType = upGradeType;
    }

    public void OpenMenu()
    {
        if (charactersHere.Count <= 0)
        {
            WhoLiveInHere();
        }
        
        switch (buildingType)
        {
            default:
            case BuildingType.���:  
                break;
        }
        UpdateType();
        CreateUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenMenu();
    }


    public void WhoLiveInHere()
    {
        InGameCharacterStorage inGameCharacterStorage = 
            GameObject.FindGameObjectWithTag("InGameCharacterInventory")
            .GetComponent<InGameCharacterStorage>();
        charactersHere.AddRange(inGameCharacterStorage.SelectCharacterForBuilding(5));
    }
}
