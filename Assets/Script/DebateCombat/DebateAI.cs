using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateAI : MonoBehaviour
{
    public static DebateCharacterCard MakeDecision(DebateUnit unit, DebateTopic topic)
    {
        List<DebateCharacterCard> output = new List<DebateCharacterCard>();
        List<Character> characters = unit.characters;
        List<DebateCharacterCard> characterCards = unit.characterCards;
        int currentMax = 0;
        DebateCharacterCard currentCard = null;
        foreach (DebateCharacterCard characterCard in characterCards)
        {
            if (characterCard.character.loyalty > characterCard.UseCount)
            {
                var testValue = ScoreReviewEvent.TestReview(new List<Character[]>() { new Character[] { characterCard.character } }, topic);
                if (testValue > currentMax)
                {
                    currentMax = testValue;
                    currentCard = characterCard;
                }
            }
        }
        return currentCard;
    }
}
