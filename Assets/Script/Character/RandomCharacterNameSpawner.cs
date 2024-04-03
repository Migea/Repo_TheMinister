using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public static class RandomCharacterNameSpawner
{
    public static string[] firstNames = new string[]
          {
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "Ҷ",
            "��",
            "Ǯ",
            "��"
          };
    public static string[] maleLastNames = new string[]
    {
            "��",
            "��",
            "ʤ",
            "ǫ",
            "��",
            "չ",
            "�",
            "��",
            "��",
            "��",
            "��",
            "��",
            "ΰ",
            "��",
            "��",
            "��",
            "��",
            "��",
            "ǿ",
            "��",
            "��",
            "��",
            "����",
            "����",
            "˼Զ",
            "�⻪",
            "����",
            "����",
            "����",
            "�Ա�",
            "һ",
            "��",
            "��",
            "��",
            "��",
            "����",
            "С��",
            "��",
            "��",
            "��",
            "���",
            "��Ω",
            "һ��",
            "�",
            "����",
            "�ؾ�",
            "��",
            "��",
            "Ȩ",
    };
    public static string[] femaleLastNames = new string[]
    {
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "��",
            "ѩ",
            "����",
            "����",
            "ݼݼ",
            "����",
            "��ѩ",
            "����",
            "����",
            "˼��",
            "��",
            "Ȼ",
            "��",
            "��",
            "��",
            "��",
            "ͮ",
            "ʫ˼",
            "ʫ��",
            "ʫ��",
            "ʫ��",
            "ʫ��",
            "ʫ��",
            "����",
            "����",
            "ѩ��",
            "��ѩ",
            "ܰ��",
            "��ܰ",
            "ܰ��",
            "ܰ��",
            "����",
            "����",
            "����",
            "����",
            "����",
            "����",
            "���",
            "����"
    };
    public static string maleName => firstNames[Random.Range(0, firstNames.Length - 1)] + maleLastNames[Random.Range(0, maleLastNames.Length - 1)];
    public static string femaleName => firstNames[Random.Range(0, firstNames.Length - 1)] + femaleLastNames[Random.Range(0, femaleLastNames.Length - 1)];
    public static List<CharacterArtCode> maleCharacterArtCode = new List<CharacterArtCode>
        {
            CharacterArtCode.������,
            CharacterArtCode.����,
            CharacterArtCode.�е���,
            CharacterArtCode.�й�,
            CharacterArtCode.�й�,
            CharacterArtCode.����,
            CharacterArtCode.��ʦ,
            CharacterArtCode.˵����,
            CharacterArtCode.��ʥ,
            CharacterArtCode.����,
            CharacterArtCode.��Ա,
            CharacterArtCode.ʰ����,
            CharacterArtCode.̫��
        };
    public static string SpawnCharacterName(CharacterArtCode characterArtCode)
    {
        if (maleCharacterArtCode.Contains(characterArtCode))
        {
            return maleName;
        }
        else
        {
            return femaleName;
        }
    }
}
