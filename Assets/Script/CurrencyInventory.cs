using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyInventory : MonoBehaviour
{
    public int Money = 250;
    public int Influence = 200;
    public int Prestige = 200;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void MoneyAdd(int add)
    {
        Money += add;
        FindObjectOfType<MainUI>().SetupMoney(Money);
    }
    public void InfluenceAdd(int add)
    {
        Influence += add;
        FindObjectOfType<MainUI>().SetupInfluence(Influence);
    }
    public void PrestigeAdd(int add)
    {
        Prestige += add;
        FindObjectOfType<MainUI>().SetupPrestige(Prestige);
    }
    public void MoneySpend(int spend)
    {
        Money -= spend;
        FindObjectOfType<MainUI>().SetupMoney(Money);
    }
}
