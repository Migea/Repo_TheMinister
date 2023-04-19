using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoitSpawnRange : MonoBehaviour
{
    public MoneyCollectPoint[] EffectMoneyCollectPoints;
    public PathPoint[] pathPoints;
    public List<PathPoint> takenStartPoint = new List<PathPoint>();
    public List<Character> roitCharacters = new List<Character>();
    public int MaxRoit => 3;
    public int CurrentRoit => roitCharacters.Count;
    public float PathPointRadius = 1f;
    public float EffectMoneyCollectPointsRadius = 1f;
    public char Area = 'B';
    internal bool onRoit;
    public void Start()
    {

    }
    public void OnEnable()
    {
        DetectRangeVariable();
    }
    public void DetectRangeVariable()
    {
        var list = Physics2D.OverlapCircleAll(transform.position, PathPointRadius);
        EffectMoneyCollectPoints = list.Where(p => p.tag == "MoneyCollectPoint").ToArray()
                                                            .Select(x => x.GetComponent<MoneyCollectPoint>()).ToArray();
        pathPoints = list.Where(p => p.tag == "PathPoint").ToArray()
                                    .Select(x => x.GetComponent<PathPoint>()).ToArray();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PathPointRadius);
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, EffectMoneyCollectPointsRadius);
    }
    public (PathPoint, PathPoint) RequestPath()
    {
        var startChoice = pathPoints.Except(takenStartPoint).ToArray();
        if (startChoice.Length <= 0)
        {
            return (null, null);
        }
        var starPoint = startChoice[Random.Range(0, startChoice.Length)];
        takenStartPoint.Add(starPoint);
        var endChoices = new List<PathPoint>(pathPoints).Remove(starPoint);
        var endPoint = startChoice[Random.Range(0, startChoice.Length)];
        return (starPoint, endPoint);
    }
    public void SpawnRoit()
    {
        if (CurrentRoit >= MaxRoit)
        {
            return;
        }
        RoitCharacter roitCharacter = Instantiate(new GameObject().AddComponent<RoitCharacter>(), this.transform);
        roitCharacter.Setup(this);
        foreach(RoitCharacter otherCharacter in roitCharacters)
        {
            var targetEAC = otherCharacter.InGameAI.npcConversationTriggerGroup.GetComponent<EventAfterConversation>();
            if (targetEAC.EnemyUnitB == null)
                targetEAC.EnemyUnitB = roitCharacter;
            else if (targetEAC.EnemyUnitC == null)
                targetEAC.EnemyUnitC = roitCharacter;

            var currentEAC =  roitCharacter.InGameAI.npcConversationTriggerGroup.GetComponent<EventAfterConversation>();
            if (currentEAC.EnemyUnitB == null)
                currentEAC.EnemyUnitB = otherCharacter;
            else if (currentEAC.EnemyUnitC == null)
                currentEAC.EnemyUnitC = otherCharacter;
        }
        roitCharacters.Add(roitCharacter);
    }
}

