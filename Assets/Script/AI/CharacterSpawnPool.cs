using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawnPool : MonoBehaviour
{
    public static Dictionary<BattleType, List<Character>> FemalePoestDict
        = new Dictionary<BattleType, List<Character>>()
        {
            { BattleType.Combat,
                new List<Character>() { }
            }
            ,
            { BattleType.Debate,
                new List<Character>() { }
            }
        };
    public static Dictionary<BattleType, List<Character>> MalePoetDict
        = new Dictionary<BattleType, List<Character>>()
        {
            { BattleType.Combat,
                new List<Character>() { }
            }
            ,
            { BattleType.Debate,
                new List<Character>() { }
            }
        };
    public static Dictionary<BattleType, List<Character>> MaleBladeUserDict
        = new Dictionary<BattleType, List<Character>>()
        {
                { BattleType.Combat,
                    new List<Character>() { }
                }
                ,
                { BattleType.Debate,
                    new List<Character>() { }
                }
        };
    public static Dictionary<BattleType, List<Character>> ElderlyDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MaleFighterDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MaleGovDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> FemaleCivilianDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MissionaryDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MucisianDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> StorytellerDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> ChessplayerDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MonkDict
    = new Dictionary<BattleType, List<Character>>()
    {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
    };
    public static Dictionary<BattleType, List<Character>> GovernorDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> ScavengerDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> EunuchDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>(){ }
                    }
                    ,
                    {BattleType.Debate,
                        new List<Character>(){ }
                    }
        };
    public static Dictionary<CharacterArtCode, Dictionary<BattleType, List<Character>>> CharacterSpawnPoolDict
        = new Dictionary<CharacterArtCode, Dictionary<BattleType, List<Character>>>()
        {
            {CharacterArtCode.Ůʫ��, FemalePoestDict },
            {CharacterArtCode.������, MalePoetDict},
            {CharacterArtCode.�е���, MaleBladeUserDict },
            {CharacterArtCode.����, ElderlyDict },
            {CharacterArtCode.�й�, MaleGovDict },
            {CharacterArtCode.����, MaleFighterDict },
            {CharacterArtCode.Ů����, FemaleCivilianDict },
            {CharacterArtCode.����ʿ, MissionaryDict},
            {CharacterArtCode.��ʦ, MucisianDict },
            {CharacterArtCode.˵����, StorytellerDict },
            {CharacterArtCode.��ʥ, ChessplayerDict },
            {CharacterArtCode.����, MonkDict },
            {CharacterArtCode.��Ա, GovernorDict },
            {CharacterArtCode.ʰ����, ScavengerDict },
            {CharacterArtCode.̫��, EunuchDict }
        };
    public void RotateAllCharacters()
    {
        foreach (CharacterArtCode characterArtCode in Enum.GetValues(typeof(CharacterArtCode)))
        {
            if (characterArtCode == CharacterArtCode.��Ԭİ) continue;
            RotateCharacters(characterArtCode);
        }
    }
    public void RotateCharacters(CharacterArtCode characterArtCode)
    {
        List<Character> newCombatList = new List<Character>();
        for (int i = 0; i < 2; i++)
        {
            var newCharacter = new GameObject().AddComponent<Character>();
            Rarerity[] rarerities = new Rarerity[] { Rarerity.N, Rarerity.R, Rarerity.SR };
            int index = UnityEngine.Random.Range(0, rarerities.Length);
            newCharacter.rarerity = rarerities[index];
            newCharacter.hireStage = HireStage.NotInMap;
            newCharacter.transform.parent = this.transform;
            newCombatList.Add(newCharacter);
        }
        try
        {
            CharacterSpawnPoolDict[characterArtCode][BattleType.Combat] = newCombatList;
        }
        catch (KeyNotFoundException)
        {
            Debug.LogError($"{characterArtCode} not found in CharacterSpawnPoolDict");
        }
        int numberOfDebate = UnityEngine.Random.Range(3, 8);
        var newDebateList = new List<Character>();
        for (int i = 0; i < numberOfDebate; i++)
        {
            var newCharacter = new GameObject().AddComponent<Character>();
            Rarerity[] rarerities = new Rarerity[] { Rarerity.N, Rarerity.R, Rarerity.SR };
            int index = UnityEngine.Random.Range(0, rarerities.Length);
            newCharacter.rarerity = rarerities[index];
            newCharacter.hireStage = HireStage.NotInMap;
            newCharacter.transform.parent = this.transform;            
            newDebateList.Add(newCharacter);
        }
        CharacterSpawnPoolDict[characterArtCode][BattleType.Debate]
            = newDebateList;
    }
}