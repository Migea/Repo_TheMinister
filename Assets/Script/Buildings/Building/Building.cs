using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public enum BuildingType
{
    ���,
    ����,
    �����,
    ������,
    ����԰,
    ����,
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
        currentPlay = new List<PlayName>() { PlayName.�����𼧰�, PlayName.�����𼧰� };
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
            case BuildingType.���:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.���, 0);
                //Debug.Log(ShopList[0].Count);
                target.horseRent.GetComponent<HorseRentUI>().Setup(ShopList[0], buildingType);
                break;
            case BuildingType.����:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.����, 0);
                target.horseRent.GetComponent<HorseRentUI>().Setup(ShopList[0], buildingType);
                break;
            case BuildingType.�����:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.�����, 0);
                target.horseRent.GetComponent<HorseRentUI>().Setup(ShopList[0], buildingType);
                break;
            case BuildingType.������:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.������, 0);
                break;
            case BuildingType.����:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.����, 0);
                break;
            case BuildingType.������:
                Debug.Log("���");
                ShopList[0] = SpawnItemBasedOnType(BuildingType.������, 0);
                break;
            case BuildingType.�ٻ���:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.�ٻ���, 0);
                break;
            case BuildingType.����¥:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.����¥, 0);
                break;
            case BuildingType.��֯��:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.��֯��, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.��֯��, 1);
                break;
            case BuildingType.��֯��:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.��֯��, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.��֯��, 1);
                SetupCraft();
                break;
            case BuildingType.����֯��:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.����֯��, 0);
                SetupCraft();
                break;
            case BuildingType.��װ��:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.��װ��, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.��װ��, 1);
                break;
            case BuildingType.����:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.����, 0);
                break;
            case BuildingType.��֬��:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.��֬��, 0);
                break;
            case BuildingType.�����:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.�����, 0);
                break;
            case BuildingType.�鱦��:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.�鱦��, 0);
                SetupCraft();
                break;
            case BuildingType.������Ʒ:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.�鱦��, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.������Ʒ, 1);
                break;
            case BuildingType.ҩ��:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.ҩ��, 0);
                SetupCraft();
                break;
            case BuildingType.ҽԺ:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.����, 0);
                break;
            case BuildingType.����:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.����, 0);
                SetupCraft();
                break;
            case BuildingType.�ɶ�̨:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.�ɶ�̨, 0);
                SetupCraft();
                break;
            case BuildingType.������:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.������, 0);
                SetupCraft();
                break;
            case BuildingType.������:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.������, 0);
                SetupCraft();
                break;
            case BuildingType.���ظ�:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.������, 0);
                ShopList[1] = SpawnItemBasedOnType(BuildingType.���ظ�, 1);
                SetupCraft();
                break;
            case BuildingType.���¥:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.���¥, 0);
                SetupCraft();
                break;
            case BuildingType.�ƹ�:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.�ƹ�, 0);
                SetPersonHere();
                target.DatingUI.GetComponent<DatingInterfaceUI>().Setup(charactersHere);
                //target.AllShops[0].GetComponent<IShopUI>().Setup(ShopList[0]);
                break;
            case BuildingType.����:
                SetPersonHere();
                ShopList[0] = SpawnItemBasedOnType(BuildingType.����, 0);
                target.HotelUI.GetComponent<HotelUI>().Setup();
                break;
            case BuildingType.��ջ:
                SetPersonHere();
                ShopList[0] = SpawnItemBasedOnType(BuildingType.�ƹ�, 0);
                target.HotelUI.GetComponent<HotelUI>().Setup();
                break;
            case BuildingType.��¥:
                SetPersonHere();
                ShopList[0] = SpawnItemBasedOnType(BuildingType.��¥, 0);
                target.BanquetUI.GetComponent<BanquetUI>().Setup(this);
                target.BigBanquatUI.GetComponent<BanquetUI>().Setup(this);
                target.DatingUI.GetComponent<DatingInterfaceUI>().Setup(charactersHere);
                break;
            case BuildingType.Ϸ��:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.Ϸ��, 0);
                currentPlay[0] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                target.AllCinema[0].GetComponent<CinemaUI>().Setup(currentPlay[0]);
                break;
            case BuildingType.ϷԺ:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.ϷԺ, 0);
                currentPlay[0] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                currentPlay[1] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                target.AllCinema[0].GetComponent<CinemaUI>().Setup(currentPlay[0]);
                target.AllCinema[1].GetComponent<CinemaUI>().Setup(currentPlay[1]);
                break;
            case BuildingType.��¥:
                ShopList[0] = SpawnItemBasedOnType(BuildingType.��¥, 0);
                currentPlay[0] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                target.AllCinema[0].GetComponent<CinemaUI>().Setup(currentPlay[0]);
                if (charactersHere != null)
                {
                    CharacterShopPriceAndList.ReturnSomeGirls(charactersHere);
                }
                charactersHere = CharacterShopPriceAndList.GetSomeGirls(MaxPersonHere);
                target.CharacterShopUI.GetComponent<CharacterShopUI>().Setup(charactersHere);
                break;
            case BuildingType.���˹�:
                currentPlay[0] = (PlayName)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                target.AllCinema[0].GetComponent<CinemaUI>().Setup(currentPlay[0]);
                if (charactersHere != null)
                {
                    CharacterShopPriceAndList.ReturnSomeGirls(charactersHere);
                }
                charactersHere = CharacterShopPriceAndList.GetSomeGirls(MaxPersonHere);
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
            outputAmount = UnityEngine.Random.Range(1, shop.itemUIs.Count);
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
        if (buildingType == BuildingType.��� || buildingType == BuildingType.���� || buildingType == BuildingType.�����)
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
