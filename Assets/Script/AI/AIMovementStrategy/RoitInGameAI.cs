using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Experimental.GlobalIllumination;
using System;
using System.Linq;

public class RoitInGameAI : DefaultInGameAI
{
    public RoitSpawnRange spawnRange;
    public float moveSpeed = 1f;
    public float stayDuration = 1.5f;
    public PathPoint startPoint;
    public PathPoint endPoint;
    public bool OnStartPoint = true;

    public override void StartAction()
    {
        DontDestroyOnLoad(gameObject);
        GetComponent<CharacterMovement>().modelController.SetSkin("face-angry expression");
    }
    public override void Move()
    {

    }
    //private void OnEnable()
    //{
    //    if (character != null)
    //    {
    //        if (character.hireStage == HireStage.Defeated)
    //        {
    //            StopAllCoroutines();
    //            GetComponent<CharacterMovement>().ModelDieAnimation();
    //        }
    //    }
    //}
    public override void SetLocation()
    {
        try
        {

            transform.position = startPoint.transform.position;
        }
        catch (NullReferenceException)
        {
            Debug.Log(transform == null);
            Debug.Log(startPoint.transform.position);

        }
    }
    public IEnumerator OnStreetRator()
    {
        bool lost = character.hireStage == HireStage.Defeated;
        while (!lost)
        {
            yield return MakeAMoveRator();
            yield return new WaitForSeconds(stayDuration);
        }
    }
    public IEnumerator MakeAMoveRator()
    {
        PathPoint direction = OnStartPoint ? endPoint : startPoint;
        float time = 0;
        float distance = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
        float moveDuration = distance / moveSpeed;
        while (time < moveDuration)
        {
            time += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, direction.transform.position, time / moveDuration);
            yield return null;
        }
        OnStartPoint = !OnStartPoint;
    }
    public void SetupRoitAI(Character character, RoitSpawnRange spawnRange)
    {
        this.character = character;
        if (spawnRange != null)
        {
            this.spawnRange = spawnRange;
            var path = spawnRange.RequestPath();
            startPoint = path.Item1;
            endPoint = path.Item2;
            SetLocation();
            SetConversationDatabase();
            StartCoroutine(OnStreetRator());
        }
        GetComponentInChildren<IndicatorController>().ChangeSelected("attack");
    }
    protected override void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/ս��");
        DSC.Awake();
        npcConversationTriggerGroup.StartGeneral();
    }
    public override void SetConversationDatabase()
    {
        NPCConversationTriggerGroup pref = null;
        switch (spawnRange.Area)
        {
            case 'A':
                pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/�ְ�");
                break;
            case 'B':
                pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/��ͽ");
                break;
            case 'C':
                pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/������");
                break;
            case 'D':
                pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/����");
                break;
        }
        npcConversationTriggerGroup = Instantiate(pref, transform);
        GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var ai = collision.gameObject.GetComponent<DefaultInGameAI>();
    //    if (ai == null) return;
    //    bool canBeKilled = ai.character.characterType == CharacterType.General;
    //    if (canBeKilled)
    //    {
    //        ai.PlayDeathAnimation();
    //    }
    //}
    public DefaultInGameAI DefaultAIAround()
    {
        var list = Physics2D.OverlapCircleAll(transform.position, 10);
        var target = list.FirstOrDefault(x =>
                                                            (x.gameObject.GetComponent<DefaultInGameAI>() != null)
                                                                && (x.GetComponent<RoitInGameAI>() == null));
        if (target == null) return null;
        return target.GetComponent<DefaultInGameAI>();
    }
    public IEnumerator LookingForTarget()
    {
        while (true)
        {
            var target = DefaultAIAround();
            Debug.Log($"looking:{target}");
            if (target == null)
            {
                yield return new WaitForSeconds(0.1f);
                continue;
            }
            else
            {
                yield return AttackRator(target.transform);
                break;
            }
        }
    }
    public IEnumerator AttackRator(Transform target)
    {
        var distance = Vector2.Distance(transform.position, target.position) - 2f;
        Vector3 dir = (target.transform.position - this.transform.position).normalized;
        float moveDuration = distance / moveSpeed;
        float time = 0;
        while (time < moveDuration)
        {
            time += Time.deltaTime;
            transform.Translate(dir * Time.deltaTime * moveSpeed);
            yield return null;
        }
        var roitModel = GetComponent<CharacterMovement>()?.modelController;
        var targetModel = target.GetComponent<CharacterMovement>()?.modelController;
        var roitModelSideChanger = GetComponent<SideChanger>();
        target.GetComponent<SideChanger>().changeSide(!roitModelSideChanger.isFront, !roitModelSideChanger.isRight);
        while (true)
        {
            roitModel?.SetTrigger("Attack");
            targetModel?.SetTrigger("Defence");
            yield return new WaitForSeconds(1f);
            //GetComponent<CharacterMovement>()?.modelController.SetTrigger("Stop");
            //target.GetComponent<CharacterMovement>()?.modelController.SetTrigger("Stop");
        }
    }
    public void DeathAction()
    {
        StopAllCoroutines();
        GetComponentInChildren<IndicatorController>().ChangeSelected("hire");
        GetComponent<CharacterMovement>().modelController.SetSkin("face-crying expression");
        RegularQuestEventHandler.ElimMessage();
    }
}
