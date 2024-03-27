using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
using UnityEngine.Events;

public class GeneralEventTrigger : MonoBehaviour
{
    public static GeneralEventTrigger CurrentGET = null;
    public BattleType battleType = BattleType.Combat;
    //rewards
    public int moneyRewards = 0;
    public int pressureRewards = 0;

    public int moneyPunishment = -100;
    public int pressurePunishment = 10;
    public List<ItemName> itemRewards = new List<ItemName>();
    public List<string> itemNames = new List<string>();
    public List<Character> playerCharacters = new List<Character>();
    public List<Character> enemyCharacters = new List<Character>();
    // {CharacterUnit, Cards}
    public List<Character[]> enemyCharactersCardsList = new List<Character[]>();
    public GameTracker gameTracker = null;
    private int scene = 1;
    public List<Character> LostCharacters = new List<Character>();
    public EndGamePannel endGamePannel;
    public bool dontPopEndGamePannel = false;
    public EventAfterCombatBasedOnResult EventAC;
    public UnityEvent NoDebateEvent = new UnityEvent();
    public bool canSurrender = true;
    private void Awake()
    {
        var pannelPath = "CombatScene/VictoryUI";
        endGamePannel = Resources.Load<EndGamePannel>(pannelPath);
    }
    public void TriggerEvent()
    {
        DontDestroyOnLoad(gameObject);
        CurrentGET = this;
        switch (battleType)
        {
            case BattleType.Combat:
                playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Combat);
                scene = 2;
                break;
            case BattleType.Debate:
                Debug.Log(enemyCharactersCardsList.Count);
                playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Debate);
                if (playerCharacters.Count == 0)
                {
                    if (NoDebateEvent != null) NoDebateEvent.Invoke();
                }
                scene = 3;
                break;
            case BattleType.GoBang:
                playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Gobang);
                scene = 4;
                break;
            default:
                break;
        }
        gameTracker = GameTracker.NewGameTracker
                                                            (moneyRewards, pressureRewards, itemRewards);
        StartCoroutine(JumpToScene(scene));

    }
    public void TriggerEnd(int result)
    {
        CurrencyInventory currencyInventory = FindObjectOfType<CurrencyInventory>();
        gameTracker.gameWin = result > 0;
        if (gameTracker != null)
        {
            //Win
            if (gameTracker.gameWin)
            {
                Debug.Log(string.Join(",", itemRewards));
                scene = 1;
                StartCoroutine(JumpToScene(scene));
                currencyInventory.MoneyAdd(moneyRewards);
                PressureEventHandler.OnPressureChange(pressureRewards);
                if (itemNames.Count > 0)
                {
                    itemRewards = new List<ItemName>();
                    foreach (var itemName in itemNames)
                    {
                        itemRewards.Add((ItemName)Enum.Parse(typeof(ItemName), itemName));
                    }
                    ItemInventory itemInventory = FindObjectOfType<ItemInventory>();
                    Debug.Log(string.Join(",", itemRewards));
                    itemInventory.AddItem(itemRewards);
                }
                else if (itemRewards.Count > 0)
                {
                    ItemInventory itemInventory = FindObjectOfType<ItemInventory>();
                    Debug.Log(string.Join(",", itemRewards));
                    itemInventory.AddItem(itemRewards);
                }
            }
            //Lose
            else
            {
                scene = 1;
                StartCoroutine(JumpToScene(scene));
                currencyInventory.MoneyAdd(moneyPunishment);
                PressureEventHandler.OnPressureChange(pressurePunishment);
                foreach (var character in playerCharacters)
                {
                    if (character != null && character.health > 0)
                    {
                        character.loyalty -= 5;
                    }
                }
            }
        }
    }
    private IEnumerator JumpToScene(int scene)
    {
        //Debug.Log("Start SceneChangeAnimation");
        string path = $"SceneTransPrefab/{(SceneType)scene}/{(SceneType)scene}Animation";
        var canvas = Instantiate(Resources.Load<Canvas>("SceneTransPrefab/Canvas"));
        DontDestroyOnLoad(canvas);
        var animation = Instantiate(Resources.Load<SceneTransController>(path), canvas.transform);
        animation.transDelegate = NextStep;
        animation.Close();
        yield return null;
    }
    IEnumerator NextStep()
    {
        var animation = FindObjectOfType<SceneTransController>();
        yield return new WaitUntil(() => animation.transition.GetCurrentAnimatorStateInfo(0).IsName("Wait"));
        SceneManager.LoadScene(scene);
        yield return WaitUntilSceneLoad.WaitUntilScene(scene);
        animation.Open();
        //AfterEvent
        if (scene == 1)
        {
            while (SceneManager.GetActiveScene().buildIndex != 1)
            {
                yield return null;
            }
            //Extra Event After Combat
            if (EventAC == null)
                TryGetComponent(out EventAC);
            if (EventAC != null)
            {
                EventAC.trigger = this;
                EventAC.RunEventBasedOnResult();
            }
            //resultPanel
            FindObjectOfType<MainUI>(true).transform.parent.gameObject.SetActive(true);
            Transform canvas = MainCanvas.FindMainCanvas();
            if (canvas != null)
            {
                if (!dontPopEndGamePannel)
                {
                    var pannel = Instantiate(endGamePannel, canvas);
                    pannel.Setup(this);
                }
            }
            foreach (var ch in LostCharacters)
            {
                if (ch.hireStage == HireStage.Hired)
                {
                    ch.TryDeath();
                }
            }
        }
    }
    public void JumpToSceneTest(int scene)
    {
        StartCoroutine(JumpToScene(scene));
    }
}
