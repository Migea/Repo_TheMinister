using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScoreReviewEvent : MonoBehaviour
{
    public DebateTopic topic;
    public List<Character[]> characters;
    public int[] finalScore = new int[2] { 0, 0 };
    public ScoreReviewUI scoreReviewUI;
    public int playerIndex = 0;
    public List<DebatePointCollector> debatePointCollectors = new List<DebatePointCollector>();
    List<CharacterArtCode> idleImage;
    public float ReviewShiftDuration = 0.5f;
    public List<DebateUnit> loseOrder = new List<DebateUnit>();
    public static void NewReview(List<Character[]> characters,
                                                    DebateTopic topic, List<CharacterArtCode> idleImage)
    {
        GameObject.FindObjectOfType<BlinkEffect>().gameObject.SetActive(false);
        GameObject.FindObjectOfType<DebateConfirm>().gameObject.SetActive(false);
        ScoreReviewEvent review = new GameObject("ScoreReviewEvent").AddComponent<ScoreReviewEvent>();
        review.characters = characters;
        review.topic = topic;
        review.playerIndex = 0;
        review.idleImage = idleImage;
        review.StartCoroutine(review.ShowReview());

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
    public IEnumerator ShowReview()
    {
        List<int> Result = new List<int>() { 0, 0, 0, 0 };
        scoreReviewUI = Resources.Load<ScoreReviewUI>("DebateScene/ScoreReviewUI");
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].Length == 0)
            {
                continue;
            }
            StartReview();
            var currentUI = Instantiate(scoreReviewUI, MainCanvas.FindMainCanvas());
            currentUI.Setup(idleImage[playerIndex], characters[playerIndex], debatePointCollectors);
            var currentRect = currentUI.GetComponent<RectTransform>();
            currentRect.localPosition = new Vector2(900, 0);
            yield return new WaitForSeconds(ReviewShiftDuration * 0.5f);
            currentRect.DOAnchorPosX(0, ReviewShiftDuration);
            yield return currentUI.StartReviewAnimation();
            Result[i] = currentUI.totalScore;
            currentRect.DOAnchorPosX(-900, ReviewShiftDuration);
            playerIndex++;
        }
        yield return new WaitForSeconds(ReviewShiftDuration);
        var effectAnimation = FindObjectOfType<DebateEffectAnimationController>();
        var damageList = effectAnimation.Setup(Result);
        yield return effectAnimation.StartCoroutine(effectAnimation.PlayRoutine());
        GameObject.FindObjectOfType<BlinkEffect>().gameObject.SetActive(true);
        GameEndCheck();
    }
    public void GameEndCheck()
    {
        var allUnits = FindObjectsOfType<DebateUnit>();
        var GET = FindObjectOfType<GeneralEventTrigger>();
        bool playerHaveTopScore = true;
        int playerScore = allUnits.First(x => x.isPlayer).Points;
        foreach (var unit in allUnits)
        {
            if (unit.Points > playerScore)
            {
                playerHaveTopScore = false;
                break;
            }
        }
        if (FindObjectOfType<DebateMainEventManager>().topicPool.Count == 0)
        {
            var endCtrl = FindObjectOfType<CombatEndingAnimationController>();
            if (playerHaveTopScore) endCtrl.Win(); else endCtrl.Lose();
            Debug.Log("EndByOutOfTopic");
            return;
        }
        foreach (var unit in allUnits)
        {
            if (unit.Points <= 0)
            {
                if (unit.index == 0)
                {
                    var endCtrl = FindObjectOfType<CombatEndingAnimationController>();
                    if (playerHaveTopScore) endCtrl.Win(); else endCtrl.Lose();
                    Debug.Log("EndByLostEnemy");
                    return;
                }
                else
                {
                    SetLoseCharacterOnCommitted(unit);
                    loseOrder.Add(unit);
                    characters[unit.index] = new Character[0] { };
                    unit.UnitDown();
                }
            }
            if (loseOrder.Count >= allUnits.Length - 1)
            {
                var endCtrl = FindObjectOfType<CombatEndingAnimationController>();
                if (playerHaveTopScore) endCtrl.Win(); else endCtrl.Lose();
            }
        }
    }
    public void SetLoseCharacterOnCommitted(DebateUnit unit)
    {
        if (unit.isPlayer) return;
        foreach (Character character in unit.characters)
        {
            if (character.InGameAI == null)
            {
                Destroy(character.gameObject);
                continue;
            }
            character.hireStage = HireStage.Committed;
            character.loyalty = 20;
        }
    }
    public static int TestReview(List<Character[]> characters, DebateTopic topic)
    {
        var output = 0;
        var review = new ScoreReviewEvent();
        review.playerIndex = 0;
        review.characters = characters;
        review.topic = topic;
        review.StartReview();
        int point = 0, multi = 0;
        foreach (DebatePointCollector collector in review.debatePointCollectors)
        {
            var sample = TopicPointsCalculator.CollectorToPoints[collector];
            point += sample[1];
            multi += sample[0];
        }
        output = point * multi;
        Destroy(review);
        return output;
    }
    private void StartReview()
    {
        finalScore[0] = 0;
        finalScore[1] = 0;
        debatePointCollectors = new List<DebatePointCollector>() { };
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
            TryGetPoints(DebatePointCollector.��ͬ����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��ͬ����, topic, playerCharacres, topic.tagRequest));
        TryGetPoints(DebatePointCollector.��λ��Ȼ, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��λ��Ȼ, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.����ֱ�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��λ��Ȼ, topic, playerCharacres, null));
        foreach (CharacterValueType valueType in topic.characterValue)
        {
            TryGetPoints(DebatePointCollector.Ȩ��, TopicPointsCalculator.CalculatPoints(DebatePointCollector.Ȩ��, topic, playerCharacres, new ArrayList { valueType, otherPlayerCharacters }));
            TryGetPoints(DebatePointCollector.�ʲ��԰�, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�ʲ��԰�, topic, playerCharacres, valueType));
        }
        if (debatePointCollectors.Contains(DebatePointCollector.Ȩ��))
        {
            TryGetPoints(DebatePointCollector.��ѹ����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��ѹ����, topic, playerCharacres, otherPlayerCharacters));
            TryGetPoints(DebatePointCollector.��ʿ��˫, TopicPointsCalculator.CalculatPoints(DebatePointCollector.��ʿ��˫, topic, playerCharacres, new ArrayList { otherPlayerCharacters, topic.tagRequest, topic.rarerity }));
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
        TryGetPoints(DebatePointCollector.����, TopicPointsCalculator.CalculatPoints(DebatePointCollector.����, topic, playerCharacres, otherPlayerCharacters));
        TryGetPoints(DebatePointCollector.�廨��ͷ, TopicPointsCalculator.CalculatPoints(DebatePointCollector.�廨��ͷ, topic, playerCharacres, otherPlayerCharacters));
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
        debatePointCollectors.Add(collector);
    }
}
