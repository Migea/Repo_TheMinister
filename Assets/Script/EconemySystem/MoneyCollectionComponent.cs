using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MoneyCollectionStationType
{
    RoadBlock,
    StartPoint
}
public class MoneyCollectionComponent : MonoBehaviour
{
    public int MoneyAmount = 10;
    public MoneyCollectionStationType stationType = MoneyCollectionStationType.RoadBlock;
    private int salaryAmount = 500;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            CurrencyInventory targetInventory = FindObjectOfType<CurrencyInventory>();
            targetInventory.MoneyAdd(MoneyAmount);
            string path = "PopText/��Ǯ�ռ�Ч��";
            var target = Instantiate(Resources.Load<Text>(path),MainCanvas.FindMainCanvas());
            string outputText = "";
            switch (stationType)
            {
                default:
                    break;
                case MoneyCollectionStationType.RoadBlock:
                    outputText= "˰��\n+" + MoneyAmount;
                    break;
                case MoneyCollectionStationType.StartPoint:
                    int salaryFinal = (int)(targetInventory.Influence/1000 + 1) * salaryAmount;
                    outputText= "ٺ»:\n+" + salaryFinal+"/n˰��:\n+" + MoneyAmount;
                    targetInventory.MoneyAdd(salaryFinal);
                    break;
            }
            target.text = outputText;
        }
    }
}
