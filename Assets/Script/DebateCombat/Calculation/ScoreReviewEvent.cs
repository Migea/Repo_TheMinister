using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReviewEvent : MonoBehaviour
{
    public DebateTopic topic;
    public List<Character[]> characters;
    public int[] finalScore = new int[2] { 0, 0 };
    public ScoreReviewUI scoreReviewUI;
    public int playerIndex;
    public DebatePointCollector[] debatePointCollectors = new DebatePointCollector[] { };

    public static void NewReview(ScoreReviewUI scoreReviewUI, List<Character[]> characters, DebateTopic topic, int playerIndex)
    {
        ScoreReviewEvent review = new GameObject("ScoreReviewEvent").AddComponent<ScoreReviewEvent>();
        review.scoreReviewUI = scoreReviewUI;
        review.characters = characters;
        review.topic = topic;
        review.playerIndex = playerIndex;
        review.StartReview();
        review.StartCoroutine(review.StartUpdateUI());
    }
    private IEnumerator StartUpdateUI()
    {
        foreach (DebatePointCollector debatePointCollector in debatePointCollectors)
        {
            yield return StartCoroutine(scoreReviewUI.NextPointCollecter(debatePointCollector));
            yield return new WaitForSeconds(0.1f);
        }
        yield return scoreReviewUI.FinishAnimation();
        yield return WaitForMouseDown();
        Destroy(gameObject);
    }
    private IEnumerator WaitForMouseDown()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                yield break;
            }
            yield return null;
        }
    }
    private void StartReview()
    {
        var otherPlayerCharacters = characters.FindAll(x => x != characters[playerIndex]);
        var playerCharacres = characters[playerIndex];
        TryGetPoints(DebatePointCollector.��ҹ���, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��ҹ���, topic, playerCharacres, null));
        if (!debatePointCollectors.Contains(DebatePointCollector.��ҹ���))
            TryGetPoints(DebatePointCollector.����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.�����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�����, topic, playerCharacres, null));
        if (!debatePointCollectors.Contains(DebatePointCollector.�����))
            TryGetPoints(DebatePointCollector.����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����, topic, playerCharacres, null));
        foreach (Tag tag in topic.tagRequest)
        {
            TryGetPoints(DebatePointCollector.�����о�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�����о�, topic, playerCharacres, tag));
        }
        if (debatePointCollectors.Contains(DebatePointCollector.�����о�))
            TryGetPoints(DebatePointCollector.��ͬ����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��ͬ����, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.��λ��Ȼ, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��λ��Ȼ, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.����ֱ�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��λ��Ȼ, topic, playerCharacres, null));
        foreach (CharacterValueType valueType in topic.characterValue)
        {
            TryGetPoints(DebatePointCollector.Ȩ��, TopicPointsCalculator.CalculatPoints(DebatePointCollector.Ȩ��, topic, playerCharacres, new ArrayList() { valueType, otherPlayerCharacters }));
            TryGetPoints(DebatePointCollector.�ʲ��԰�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�ʲ��԰�, topic, playerCharacres, otherPlayerCharacters));
        }
        if (debatePointCollectors.Contains(DebatePointCollector.Ȩ��))
        {
            TryGetPoints(DebatePointCollector.��ѹ����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��ѹ����, topic, playerCharacres, otherPlayerCharacters));
            TryGetPoints(DebatePointCollector.��ʿ��˫, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��ʿ��˫, topic, playerCharacres, null));
        }
        TryGetPoints(DebatePointCollector.�Ҽ�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�Ҽ�, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.һ֦����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.һ֦����, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.����λ, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����λ, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����, topic, playerCharacres, CharacterValueType.��));
        TryGetPoints(DebatePointCollector.����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����, topic, playerCharacres, CharacterValueType.��));
        TryGetPoints(DebatePointCollector.����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����, topic, playerCharacres, CharacterValueType.ı));
        foreach (Character[] otherCharacters in otherPlayerCharacters)
        {
            TryGetPoints(DebatePointCollector.����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����, topic, playerCharacres, otherCharacters));
        }
        if (debatePointCollectors.Contains(DebatePointCollector.����))
            TryGetPoints(DebatePointCollector.�����ٳ�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�����ٳ�, topic, playerCharacres, otherPlayerCharacters));
        else
        {
            if (topic.characterValue.Contains(CharacterValueType.ı))
                TryGetPoints(DebatePointCollector.����ı��, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����ı��, topic, playerCharacres, otherPlayerCharacters));
            else
                TryGetPoints(DebatePointCollector.��Ļ, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��Ļ, topic, playerCharacres, otherPlayerCharacters));
        }
        TryGetPoints(DebatePointCollector.����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.�廨��ͷ, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�廨��ͷ, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.�Ӳ���, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�Ӳ���, topic, playerCharacres, null));
        if (!debatePointCollectors.Contains(DebatePointCollector.һ֦����))
            TryGetPoints(DebatePointCollector.���ڵй�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.���ڵй�, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.���Ͻ߽�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.���Ͻ߽�, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.����֮��, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����֮��, topic, playerCharacres, null));
        TryGetPoints(DebatePointCollector.ǿ����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.ǿ����, topic, playerCharacres, otherPlayerCharacters));
    }

    private void TryGetPoints(DebatePointCollector collector, int[] points)
    {
        if (points == null)
            return;
        if (points[0] == 0 && points[1] == 0)
            return;
        finalScore[0] += points[0];
        finalScore[1] += points[1];
        debatePointCollectors.Append(collector);
    }
}
