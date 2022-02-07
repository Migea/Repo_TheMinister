using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyPredictStrategy : IAICombatStrategy
{
    public void MakeDecision(Dictionary<Action, int> targetDic)
    {
        BattleSystem battleSystem = CombatTool.FindBattleSystem();
        List<Character> playerCharacters = battleSystem.PlayerCharacters;
        BattleType battleType = battleSystem.battleType;
        var targetAL = CombatTool.FindHighestValueCharacter(playerCharacters, battleType);
        var characterValueType = (CharacterValueType)targetAL[0];

        if (battleSystem.battleType == BattleType.Duel)
        {
            switch (characterValueType)
            {
                default:
                    break;
                case CharacterValueType.��:
                    targetDic[Action.Attack]++;
                    break;
                case CharacterValueType.��:
                    targetDic[Action.Defence]++;
                    break;
                case CharacterValueType.��:
                    targetDic[Action.Assassinate]++;
                    break;
            }
        }
        else if (battleSystem.battleType == BattleType.Debate)
        {
            switch (characterValueType)
            {
                default:
                    break;
                case CharacterValueType.��:
                    targetDic[Action.Attack]++;
                    break;
                case CharacterValueType.��:
                    targetDic[Action.Defence]++;
                    break;
                case CharacterValueType.ı:
                    targetDic[Action.Assassinate]++;
                    break;
            }
        }

    }
}
