using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HorseCardUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text priceText;
    [SerializeField] private Text blocksText;
    [SerializeField] private Image horseImage;
    [SerializeField] private ConfirmUI ConfirmWindow;

    public ConfirmPhase confirm = ConfirmPhase.Null;

    public static Dictionary<HorseRank, List<int>> HorseKindDict =
        new Dictionary<HorseRank, List<int>>()
        {
            { HorseRank.N, new List<int>(){1, 1 } },
            { HorseRank.R, new List<int>(){2, 2 } },
            { HorseRank.SR, new List<int>(){3, 3 } },
            { HorseRank.SSR, new List<int>(){4, 4 } },
            { HorseRank.UR, new List<int>(){5, 5 } },
        };
    public int price;
    public int block;

    public void SetUp(HorseRank horseRank)
    {
        string spritePath = ("Art/Horses/" + horseRank.ToString()).Replace(" ", string.Empty);
        Debug.Log(spritePath);
        horseImage.sprite = Resources.Load<Sprite>(spritePath);
        price = HorseKindDict[horseRank][0];
        block = HorseKindDict[horseRank][1];
        priceText.text = price + "��";
        blocksText.text = block + "��";
    }

    public void ChooseHorse()
    {
        string currentText = "ȷ��Ҫ����" + price + "�������ƶ�" + block + "��������";
        Confirmation.HoldingMethod holding = MovePlayer;
        StartCoroutine(Confirmation.CreateNewComfirmation(holding, currentText).Confirm());
    }
    private void MovePlayer()
    {
        Map map = FindObjectOfType<Map>();
        map.MoveAStep(block);
        Destroy(FindObjectOfType<BuildingUI>().gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChooseHorse();
    }


}
