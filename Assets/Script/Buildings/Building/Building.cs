using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public enum BuildingType
{
    ���,
    ����,
    �����,
    ������,
    ����԰,
    �ӻ���,
    �ٻ���,
    ����¥,
    ����,
    ������,
    ����,
    �鱦��,
    ������Ʒ,
    ��֬��,
    �����,
    ������,
    ������,
    ���ظ�,
    ���¥,
    �����,
    ��֯��,
    ��֯��,
    ����֯��,
    ��װ��,
    �������,
    Ϸ��,
    ��¥,
    ���˹�,
    ϷԺ,
    ��ɪ¥,
    ҩ��,
    ����,
    �ɶ�̨,
    ҽԺ,
    �о�Ժ,
    �ƹ�,
    �Ƶ�,
    ��¥,
    ����,
    ��ջ,
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
    public int MaxPersonHere = 5;

    public int recordDay = -1;
    public int currentDay = 0;

    public Transform BuildingCharacterSlot;

    public List<List<ItemName>> ShopList = new List<List<ItemName>>()
    {  new List<ItemName> (), new List<ItemName> (), new List<ItemName>()};
    public List<int> shopMaxSpawn = new List<int>(4);

    [SerializeField] private BuildingUI buildingUI;
    private BuildingUI currentUI;
    private List<HorseRank> horseList;

    public List<ItemName> CraftingList = new List<ItemName>();

    public PlayName currentPlay;

    private void Awake()
    {
        UpdateType();
    }
    public void UpdateType()
    {
        string FolderPath = ("FinalBuildingUI/" + buildingType.ToString()).Replace(" ", string.Empty);
        buildingUI = Resources.Load<BuildingUI>(FolderPath);
    }
    public void UpdateType(BuildingType buildingType)
    {
        this.buildingType = buildingType;
        UpdateType();
    }

    public void CreateUI()
    {
        Debug.Log(buildingUI == null);
        currentUI = Instantiate(buildingUI, MainCanvas.FindMainCanvas());
        currentUI.UpdateUI(this);
    }

    public void Upgrade(BuildingType upGradeType)
    {
        buildingType = upGradeType;
    }

    public void OpenMenu()
    {
        //if (charactersHere.Count <= 0)
        //{
        //    SetPersonHere();
        //}
        if (currentUI != null&& !NewDay())
        {
            currentUI.gameObject.SetActive(true);
            return;
        }
        CreateUI();
        UpdateType();
        shopRefSetUp();
        recordDay = FindObjectOfType<Map>().Day;
    }

    public void shopRefSetUp()
    {
        var target = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        switch (buildingType)
        {
            case BuildingType.���:
                target.horseRent.GetComponent<HorseRentUI>().SetUp(horseList);
                break;
            case BuildingType.�ӻ���:
                SpawnItemBasedOnType(BuildingType.�ӻ���, 0);
                target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[0]);
                break;
            case BuildingType.��֯��:
            case BuildingType.����֯��:
                target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[0]);
                SetupCraft();
                break;
            case BuildingType.����:
                target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[0]);
                break;
            case BuildingType.������Ʒ:
                SetupCraft();
                target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[2]);
                break;
            case BuildingType.ҩ��:
                target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[0]);
                SetupCraft();
                break;
            case BuildingType.������:
                target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[1]);
                SetupCraft();
                break;
            case BuildingType.�ƹ�:
                if (NewDay())
                    SetPersonHere();
                target.DatingUI.GetComponent<DatingInterfaceUI>().Setup(charactersHere);
                target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[0]);
                break;
            case BuildingType.��¥:
                if (NewDay())
                    SetPersonHere();
                SpawnItemBasedOnType(BuildingType.��¥, 0);
                target.BanquetUI.GetComponent<BanquetUI>().Setup(this);
                target.BigBanquatUI.GetComponent<BanquetUI>().Setup(this);
                target.DatingUI.GetComponent<DatingInterfaceUI>().Setup(charactersHere);
                target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[0]);
                break;
            case BuildingType.Ϸ��:
                target.CinemaUI.GetComponent<CinemaUI>().Setup(currentPlay);
                break;
        }
    }
    public void SetupCraft()
    {
        var target = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        var currentTarget = target.CraftingUI.GetComponent<CraftingUI>();
        currentTarget.Setup(CraftingList);
        if (CraftingList.Count > 0) target.CraftingUI.GetComponent<CraftingUI>().Setup(CraftingList[0]);
    }
    public void SetPersonHere()
    {
        charactersHere = new List<Character>();
        InGameCharacterStorage inGameCharacterStorage =
            GameObject.FindGameObjectWithTag("InGameCharacterInventory")
            .GetComponent<InGameCharacterStorage>();
        charactersHere.AddRange(inGameCharacterStorage.SelectCharacterForBuilding(MaxPersonHere));
    }
    public List<ItemName> SpawnItemBasedOnType(BuildingType type, int shopIndex = -1)
    {
        int outputAmount = Random.Range(1, shopMaxSpawn[shopIndex]);
        List<ItemName> outputItems = new List<ItemName>();
        for (int i = 0; i < outputAmount; i++)
        {
            if (shopIndex == -1) return null;
            var targetList = SOItem.BuildingVendorDict[type];
            int randomTypeIndex = Random.Range(0, targetList.Count);
            var targetItem = targetList[randomTypeIndex];
            outputItems.Add(targetItem);
        }
        return outputItems;
    }
    public bool NewDay()
    {
        var map = FindObjectOfType<Map>();
        if (recordDay != map.Day) return true;
        else return false;
    }
    public void SetUpHorseRent()
    {
        var targetRef = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        var horserent = targetRef.horseRent.GetComponent<HorseRentUI>();
        horseList = new List<HorseRank>();
        for (int i = 0; i < horserent.numberOfSpawn; i++)
        {
            horseList.Add(horserent.RandomHorse());
        }
    }
    public void AddCraftingToBuilding(ItemName item)
    {
        CraftingList.Add(item);
    }

    public void SetupNewCinemaPlay()
    {
        var keyList = PlayList.PlayListDict.Keys.ToList<PlayName>();
        int i = Random.Range(0, keyList.Count);
        currentPlay = keyList[i];
    }
}
