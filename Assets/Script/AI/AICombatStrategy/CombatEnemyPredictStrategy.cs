using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyPredictStrategy : IAICombatStrategy
{
    public void MakeDecision(Dictionary<CombatAction, int> targetDic)
    {
        BattleSystem battleSystem = CombatTool.FindBattleSystem();
        List<Character> playerCharacters = battleSystem.PlayerCharacters;
        BattleType battleType = battleSystem.battleType;
        var targetAL = CombatTool.FindHighestValueCharacter(playerCharacters, battleType);
        var characterValueType = (CharacterValueType)targetAL[0];

        if (battleSystem.battleType == BattleType.Combat)
        {
            switch (characterValueType)
            {
                default:
                    break;
                case CharacterValueType.��:
                    targetDic[CombatAction.Attack]++;
                    break;
                case CharacterValueType.��:
                    targetDic[CombatAction.Defence]++;
                    break;
                case CharacterValueType.��:
                    targetDic[CombatAction.Assassin]++;
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
                    targetDic[CombatAction.Attack]++;
                    break;
                case CharacterValueType.��:
                    targetDic[CombatAction.Defence]++;
                    break;
                case CharacterValueType.ı:
                    targetDic[CombatAction.Assassin]++;
                    break;
            }
        }

    }
}
