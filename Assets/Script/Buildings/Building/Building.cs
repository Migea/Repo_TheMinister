using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BuildingType
{
    ���,
    �ӻ���,
    ����,
    ������,
    ��֯��,
    Ϸ��,
    ҩ��,
    �ƹ�
}

public enum BuildingLevel
{
    LevelOne,
    LevelTwo,
    LevelThree
}
public class Building : MonoBehaviour
{
    public BuildingType buildingType;
    public List<Character> charactersHere;

    public int MaxBuildingQuest = 3;

    public int recordWeek = -1;

    public Transform BuildingCharacterSlot;

    public List<ItemName> ShopList;

    [SerializeField] private BuildingUI buildingUI;
    public List<QuestLineAgent> questLineList = new List<QuestLineAgent>();
    private List<HorseRank> horseList;

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

    public void UpdateQuests()
    {
        QuestMapAgent questMapAgent =
        GameObject
        .FindGameObjectWithTag("GameFiles")
        .GetComponentInChildren<QuestMapAgent>();

        questLineList = new List<QuestLineAgent>();
        var targetLine = questMapAgent.LoadShopQuest(buildingType);
        targetLine.InUse = true;
        questLineList.Add(targetLine);
    }

    public void CreateUI()
    {
        BuildingUI targetUI = Instantiate(buildingUI, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
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
            SetPersonHere();
        }
        UpdateType();
        CreateUI();
        if (RecordWeekCheck())
        {
            SpawnItems();
            recordWeek = Map.Week;
        }
        shopRefSetUp();
    }

    public void shopRefSetUp()
    {
        var target = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        switch (buildingType)
        {
            case BuildingType.���:
                target.horseRent.GetComponent<HorseRent>().SetUp(horseList);
                break;
            case BuildingType.�ӻ���:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.��֯��:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.����:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.ҩ��:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.������:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.�ƹ�:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.Ϸ��:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
        }
    }

    public void SetPersonHere()
    {
        InGameCharacterStorage inGameCharacterStorage =
            GameObject.FindGameObjectWithTag("InGameCharacterInventory")
            .GetComponent<InGameCharacterStorage>();

        charactersHere.AddRange(inGameCharacterStorage.SelectCharacterForBuilding(5));
    }

    public List<ItemType> ShopType()
    {
        switch (buildingType)
        {
            case BuildingType.�ӻ���:
                return new List<ItemType>() { ItemType.�ӻ�, ItemType.ҩ�� };
            case BuildingType.�ƹ�:
                return new List<ItemType>() { };
            case BuildingType.ҩ��:
                return new List<ItemType>() { };
            case BuildingType.����:
                return new List<ItemType>() { ItemType.�鼮, ItemType.��Ʒ };
            case BuildingType.������:
                return new List<ItemType>() { };
            case BuildingType.��֯��:
                return new List<ItemType>() { };
            case BuildingType.���:
                SetUpHorseRent();
                return null;
        }
        return new List<ItemType>() { };
    }

    public void SpawnItemBasedOnType(List<ItemType> inputTypes)
    {
        int outputAmount = Random.Range(5, 10);
        List<ItemName> outputItems = new List<ItemName>();
        for (int i = 0; i < outputAmount; i++)
        {
            if (inputTypes.Count < 1) return;
            int randomTypeIndex = Random.Range(0, inputTypes.Count);
            ItemName currentItem = SOItem.ItemTypeDict[inputTypes[randomTypeIndex]][0];
            outputItems.Add(currentItem);
        }
        ShopList = outputItems;
    }

    public void SpawnItems()
    {
        var result = ShopType();
        if (result != null)
        {
            SpawnItemBasedOnType(result);
        }
    }

    public bool RecordWeekCheck()
    {
        if (recordWeek < Map.Week) return true;
        else return false;
    }

    public void SetUpHorseRent()
    {
        var targetRef = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        var horserent = targetRef.horseRent.GetComponent<HorseRent>();
        horseList = new List<HorseRank>();
        for (int i = 0; i < horserent.numberOfSpawn; i++)
        {
            horseList.Add(horserent.RandomHorse());
        }
    }
}
