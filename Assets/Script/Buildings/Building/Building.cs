using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public enum BuildingType
{
    马厩,
    御马场,
    天马阁,
    奇兽堂,
    百兽园,
    五金店,
    百货店,
    万仙楼,
    当铺,
    拍卖行,
    商行,
    珠宝店,
    西域珍品,
    胭脂铺,
    万香阁,
    铁匠铺,
    武器铺,
    机关阁,
    武侯楼,
    万兵阁,
    纺织铺,
    梭织坊,
    长安织造,
    服装店,
    玉服华裳,
    戏馆,
    青楼,
    红人馆,
    戏院,
    鼓瑟楼,
    药铺,
    丹房,
    仙鼎台,
    医院,
    研究院,
    酒馆,
    酒店,
    酒楼,
    馆驿,
    客栈,
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
    public List<string> charactersAlwaysHere;

    public int MaxPersonHere = 5;

    public int recordDay = -1;
    public int currentDay = 0;

    public Transform BuildingCharacterSlot;
    public List<List<ItemName>> ShopList = new List<List<ItemName>>()
    {  new List<ItemName> (), new List<ItemName> (), new List<ItemName>()};
    public List<int> shopMaxSpawn = new List<int>(4);

    [SerializeField] private BuildingUI buildingUI;
    public BuildingUI currentUI;
    private List<ItemName> horseList;

    public List<ItemName> CraftingList = new List<ItemName>();
    public List<PlayName> currentPlay;

    private void Awake()
    {
        UpdateType();
        currentPlay = new List<PlayName>() { PlayName.唐僧大战白骨精, PlayName.唐僧大战白骨精 };
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
        if (NewDay())
        {
            if (currentUI != null)
            {
                Destroy(currentUI.gameObject);
            }
        }
        if (currentUI != null)
        {
            currentUI.gameObject.SetActive(true);
            return;
        }
        recordDay = FindObjectOfType<Map>().Day;
        CreateUI();
        UpdateType();
        shopRefSetUp();
    }

    public void shopRefSetUp()
    {
        Debug.Log(buildingType);
        var target = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        Array values = Enum.GetValues(typeof(PlayName));
        switch (buildingType)
        {
            case BuildingType.马厩:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.马厩, 0);
                //Debug.Log(ShopList[0].Count);
                target.horseRent.GetComponent<HorseRentUI>().Setup(ShopList[0], buildingType);
                break;
            case BuildingType.御马场:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.御马场, 0);
                target.horseRent.GetComponent<HorseRentUI>().Setup(ShopList[0], buildingType);
                break;
            case BuildingType.天马阁:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.天马阁, 0);
                target.horseRent.GetComponent<HorseRentUI>().Setup(ShopList[0], buildingType);
                break;
            case BuildingType.奇兽堂:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.奇兽堂, 0);
                break;
            case BuildingType.五金店:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.五金店, 0);
                break;
            case BuildingType.拍卖行:
                Debug.Log("五金");
                ShopList[0] = SpawnItemBasedOnType(BuildingType.拍卖行, 0);
                break;
            case BuildingType.百货店:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.百货店, 0);
                break;
            case BuildingType.万仙楼:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.万仙楼, 0);
                break;
            case BuildingType.纺织铺:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.纺织铺, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.纺织铺, 1);
                break;
            case BuildingType.梭织坊:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.纺织铺, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.梭织坊, 1);
                SetupCraft();
                break;
            case BuildingType.长安织造:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.长安织造, 0);
                SetupCraft();
                break;
            case BuildingType.服装店:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.服装店, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.服装店, 1);
                break;
            case BuildingType.商行:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.商行, 0);
                break;
            case BuildingType.胭脂铺:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.胭脂铺, 0);
                break;
            case BuildingType.万香阁:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.万香阁, 0);
                break;
            case BuildingType.珠宝店:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.珠宝店, 0);
                SetupCraft();
                break;
            case BuildingType.西域珍品:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.珠宝店, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.西域珍品, 1);
                break;
            case BuildingType.药铺:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.药铺, 0);
                SetupCraft();
                break;
            case BuildingType.医院:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.丹房, 0);
                break;
            case BuildingType.丹房:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.丹房, 0);
                SetupCraft();
                break;
            case BuildingType.仙鼎台:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.仙鼎台, 0);
                SetupCraft();
                break;
            case BuildingType.铁匠铺:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.铁匠铺, 0);
                SetupCraft();
                break;
            case BuildingType.武器铺:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.武器铺, 0);
                SetupCraft();
                break;
            case BuildingType.机关阁:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.铁匠铺, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.机关阁, 1);
                SetupCraft();
                break;
            case BuildingType.武侯楼:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.武侯楼, 0);
                SetupCraft();
                break;
            case BuildingType.酒馆:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.酒馆, 0);
                SetPersonHere();
                target.DatingUI.GetComponent<DatingInterfaceUI>().Setup(charactersHere);
                //target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[0]);
                break;
            case BuildingType.馆驿:
                SetPersonHere();
                ShopList[0] = SpawnItemBasedOnType(BuildingType.馆驿, 0);
                target.HotelUI.GetComponent<HotelUI>().Setup();
                break;
            case BuildingType.客栈:
                SetPersonHere();
                ShopList[0] = SpawnItemBasedOnType(BuildingType.酒馆, 0);
                target.HotelUI.GetComponent<HotelUI>().Setup();
                break;
            case BuildingType.酒楼:
                SetPersonHere();
                ShopList[0] = SpawnItemBasedOnType(BuildingType.酒楼, 0);
                target.DatingUI.GetComponent<DatingInterfaceUI>().Setup(charactersHere);
                break;
            case BuildingType.戏馆:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.戏馆, 0);
                currentPlay[0] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                target.AllCinema[0].GetComponent<CinemaUI>().Setup(currentPlay[0]);
                break;
            case BuildingType.戏院:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.戏院, 0);
                currentPlay[0] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                currentPlay[1] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                target.AllCinema[0].GetComponent<CinemaUI>().Setup(currentPlay[0]);
                target.AllCinema[1].GetComponent<CinemaUI>().Setup(currentPlay[1]);
                break;
            case BuildingType.青楼:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.青楼, 0);
                currentPlay[0] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                target.AllCinema[0].GetComponent<CinemaUI>().Setup(currentPlay[0]);
                if (charactersHere != null)
                {
                    CharacterShopPriceAndList.ReturnSomeGirls(charactersHere);
                }
                charactersHere = CharacterShopPriceAndList.GetSomeGirls(MaxPersonHere);
                target.CharacterShopUI.GetComponent<CharacterShopUI>().Setup(charactersHere);
                break;
            case BuildingType.红人馆:
                currentPlay[0] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                target.AllCinema[0].GetComponent<CinemaUI>().Setup(currentPlay[0]);
                //if (charactersHere != null)
                //{
                //    CharacterShopPriceAndList.ReturnSomeGirls(charactersHere);
                //}
                charactersHere.AddRange(CharacterShopPriceAndList.GetSomeGirls(MaxPersonHere - charactersHere.Count));
                Debug.Log(charactersHere.Count);
                //if (charactersAlwaysHere != null)
                //{
                //    charactersHere.Add(CharacterShopPriceAndList.OuputTopCharacter(charactersAlwaysHere[0]));
                //}
                target.CharacterShopUI.GetComponent<CharacterShopUI>().Setup(charactersHere);
                break;
        }
    }
    public void SetupCraft()
    {
        var target = currentUI.GetComponent<ShopRef>();
        var currentTarget = target.CraftingUI.GetComponent<CraftingUI>();
        currentTarget.Setup(SOItem.BuildingCraftDict[buildingType]);
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
        var target = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        var shop = target.AllShops[shopIndex].GetComponent<IShopUI>() as ConvenienceStore;
        int outputAmount;
        if (shop != null)
        {
            outputAmount = shop.itemUIs.Count;
        }
        else
        {
            outputAmount = UnityEngine.Random.Range(1, 5);
        }
        List<ItemName> outputItems = new List<ItemName>();
        for (int i = 0; i < outputAmount; i++)
        {
            if (shopIndex == -1) return null;
            var targetList = SOItem.BuildingVendorDict[type];
            int randomTypeIndex = UnityEngine.Random.Range(0, targetList.Count);
            var targetItem = targetList[randomTypeIndex];
            outputItems.Add(targetItem);
        }
        if (buildingType == BuildingType.马厩 || buildingType == BuildingType.御马场 || buildingType == BuildingType.天马阁)
        {
            return outputItems;
        }
        shop.buildingType = buildingType;
        string debugString = "outputItems:\n";
        foreach (var item in outputItems)
        {
            debugString += item.ToString() + "\n";
        }
        shop.Setup(outputItems);
        //Debug.Log("Shop " + shopIndex + " has " + outputItems.Count + " items");
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

    }
    public void AddCraftingToBuilding(ItemName item)
    {
        CraftingList.Add(item);
    }
}
