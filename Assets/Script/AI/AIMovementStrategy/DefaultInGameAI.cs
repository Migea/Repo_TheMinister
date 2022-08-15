using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Spine.Unity;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;

public enum AIInteractType
{
    Combat,
    Hire,
    Trade,
    Gobang,
    Debate,
    Talk
}
public enum TimeInDay
{
    Morning,
    Noon,
    Evening,
}
public class DefaultInGameAI : MonoBehaviour, IAIMovementStrategy, IObserver
{
    private Map map;
    public string Name = "";
    [SerializeField] private List<AIInteractType> types;
    public int NightBlock;
    public int DayMaxBlock, DayMinBlock;
    public bool inner = true;
    public int CurrentLocation;
    public int NextBlockToMove;
    public int TargetLocation;
    public Character character;
    public NPCPopUI npcPopUI;

    [SerializeField] private bool OnNight => map ? map.DayTime == 2 : false;
    public Animator animator;
    //private string NPCJsonPath = "JSON/AIOnMapMovement";
    public Grid movementGrid;
    public NPCConversationTriggerGroup npcConversationTriggerGroup;
    private void Awake()
    {
        movementGrid = FindObjectOfType<MovementGrid>().GetComponent<Grid>();
        inner = Random.Range(0, 2) == 0 ? false : true;
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
        map = FindObjectOfType<Map>();

    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            Move();
        }
    }
    public void Setup(Character character)
    {
        this.character = character;
        SkeletonDataAsset asset = Resources.Load<SkeletonDataAsset>
            ($"{ReturnAssetPath.ReturnSpineAssetPath(character.characterArtCode, true)}");
        animator.GetComponent<SkeletonMecanim>().skeletonDataAsset = asset;
        string controllerPath = $"{ReturnAssetPath.ReturnSpineControllerPath(character.characterArtCode, true)}";
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(controllerPath);
        animator.GetComponent<SkeletonMecanim>().Initialize(true);
        NightBlock = Random.Range(0, map.mapCount);
        int tryMax = NightBlock + (Random.Range(0, 1) == 0 ? -1 : 1) * Random.Range(4, 10) % map.mapCount;
        if (tryMax < 0)
        {
            DayMaxBlock = tryMax + map.mapCount;
        }
        else if (tryMax > map.mapCount)
        {
            DayMaxBlock -= map.mapCount;
        }
        int tryMin = DayMinBlock - Random.Range(3, 10);
        DayMinBlock = (tryMin < 0) ? tryMin + map.mapCount : tryMin;
        CurrentLocation = OnNight ? NightBlock : Random.Range(DayMinBlock, DayMaxBlock);
        transform.position = movementGrid.GetCellCenterWorld(MovementGrid.GetAIBlock(this, CurrentLocation));
        SetConversationDatabase();
        if (npcConversationTriggerGroup == null)
        {
            Debug.Log(character.characterArtCode);
        }
    }
    public void Move()
    {
        //int steps;
        if (OnNight)
        {
            TargetLocation = NightBlock;
        }
        else
        {
            TargetLocation = Random.Range(DayMinBlock, DayMaxBlock + 1);
        }
        var movement = GetComponent<CharacterMovement>();
        movement.finalBlock = TargetLocation;
        StartCoroutine(movement.MoveToLocation());
        //StartCoroutine(MoveManyStep(steps));
    }

    protected void OnMouseDown()
    {
        StartConmunicate();
    }
    protected virtual void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/{character.characterArtCode.ToString()}");
        DSC.Awake();
        npcConversationTriggerGroup.StartGeneral();
    }

    public void SetInner(bool inner)
    {
        this.inner = inner;
    }

    public virtual void SetConversationDatabase()
    {
        //npcConversationTriggerGroup.Setup(character.characterArtCode.ToString());
        var pref = Resources.Load<NPCConversationTriggerGroup>($"{ReturnAssetPath.ReturnNPCConversationTriggerGroupPath(character.characterArtCode.ToString())}");
        npcConversationTriggerGroup = Instantiate<NPCConversationTriggerGroup>(pref, transform);
        GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
        //GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
        //GetComponentInChildren<EventAfterConversation>().EnemyUnitACardList[0] =(character);
    }
}