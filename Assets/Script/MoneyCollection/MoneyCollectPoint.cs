using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class MoneyCollectPoint : MonoBehaviour
{
    public static MoneyCollectManager manager => MoneyCollectManager.Instance;
    public static Locale CurrentLocale => LocalizationSettings.SelectedLocale;
    public MCPStateCheckHandler StateChecker;
    public bool OnRoit => StateChecker.onRoit;
    public List<int> collectAmount = new List<int>() { 100, 100, 200, 0 };
    public int Value
    {
        get
        {
            if (OnRoit)
            {
                return (int)(1f - manager.MoneyDecreaseOnRoit) * collectAmount[ChapterCounter.Instance.Chapter];
            }
            return (int)(collectAmount[ChapterCounter.Instance.Chapter] * LevelManager.Instance.currentMultiplier);
        }
    }
    public string Name = "����";
    public string State = "����";
    public Collider2D Trigger;
    public GameObject Wrapper;
    public RoitSpawnRange RoitSpawnRange;
    public RoitSpawnRange[] EffectedRanges;
    public float EffectRoitSpawnRangeRadius = 7f;

    public Text text;
    public void Awake()
    {
        Wrapper.SetActive(false);
        StateChecker = new MCPStateCheckHandler(this);
    }
    private void Start()
    {
        DetectRoit();
    }
    public void OnContact()
    {
        text.text = GetLocaleText();
        Wrapper.SetActive(true);
        var handler = new MoneyCollectAnimationHandler(Wrapper.GetComponent<RectTransform>(), manager.YChange, manager.duration, manager.delay);
        handler.Play();
        if (Value > 0)
            CurrencyInvAnimationManager.Instance?.MoneyChange(Value);
    }
    private string GetLocaleText()
    {
        LocalizedString localString = new LocalizedString
        {
            TableReference = "UI",
            TableEntryReference = $"����_{Name}"
        };
        string localName = localString.GetLocalizedString();
        string localState = State;
        string localText = "";
        string color = OnRoit ? "red" : "green";
        Debug.Log($"CurrentLocale is {CurrentLocale.Formatter}");

        switch (CurrentLocale.Formatter.ToString())
        {
            case "en":
                localState = State == "����" ? "GOOD" : "BAD";
                localText = $"{localName} is running {localState} today.\r\nCollect <color={color}>{Value}</color> silver.";
                break;
            case "zh":
                localState = State = OnRoit ? "���" : "����";
                localText = $"{localName}����Ӫҵ״̬<color={color}>{localState}</color>\r\n����˰��<color={color}>{Value}</color>��";
                break;
            case "ja":

                break;
            case "ge":

                break;
            case "ka":

                break;
            default: break;
        }
        return localText;
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, EffectRoitSpawnRangeRadius);
    }
    public void DetectRoit()
    {
        var list = Physics2D.OverlapCircleAll(transform.position, EffectRoitSpawnRangeRadius);
        EffectedRanges = list.Where(p => p.GetComponent<RoitSpawnRange>() != null).ToArray()
                                                            .Select(x => x.GetComponent<RoitSpawnRange>()).ToArray();
        StateChecker.ranges = EffectedRanges.ToList();
    }
}
