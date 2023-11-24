using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterShopPriceAndList : MonoBehaviour
{
    public static Dictionary<string, ArrayList> CharacterPool = new Dictionary<string, ArrayList>()
    {
        //������{�Ƿ����̵����ļ�ˣ�Ĭ��false����artCode��ӵ�е�tag,�۸�{��Ǯ��������������û��д0��}}
        {"��С", new ArrayList(){false,CharacterArtCode.Ů����, new  List<Tag>() { Tag.�Ż�����, Tag.С��ı��, Tag.������, Tag.�ܸ�����, Tag.���в��� }, new List<int>(){100,0,0} } },
        {"ʫ����", new ArrayList(){false, CharacterArtCode.��Ů, new  List<Tag>() { Tag.��������, Tag.ͨ������, Tag.�뾭�ѵ�, Tag.��Ա, Tag.��̬���� }, new List<int>(){100,0,0} } },
        {"�ι�ѩ", new ArrayList(){false, CharacterArtCode.��Ů, new  List<Tag>() { Tag.���ֵ���, Tag.С��ı��, Tag.������, Tag.��Ա, Tag.���в��� }, new List<int>(){100,0,0} } },
        {"ʫ����", new ArrayList(){false, CharacterArtCode.��Ů, new  List<Tag>() { Tag.ͨ������, Tag.������, Tag.�ܸ�����, Tag.��̬����, Tag.���в��� }, new List<int>(){100,0,0} } },
        {"��������", new ArrayList(){false, CharacterArtCode.��Ů, new  List<Tag>() { Tag.���в���, Tag.��������, Tag.���, Tag.��������, Tag.��̬���� }, new List<int>(){100,0,0} } },
        {"˫�Ͼ�", new ArrayList(){false, CharacterArtCode.��Ů, new  List<Tag>() { Tag.��������, Tag.����, Tag.�뾭�ѵ�, Tag.��Ա, Tag.��̬���� }, new List<int>(){100,0,0} } },
        {"ѩ����", new ArrayList(){false, CharacterArtCode.��Ů, new  List<Tag>() { Tag.��������, Tag.��ʦ, Tag.������, Tag.��ⱦ��, Tag.��а���� }, new List<int>(){100,0,0} } },
    };
    public static Dictionary<string, ArrayList> UnSelectedCharacters
        => CharacterPool.Where(x => (bool)x.Value[0] == false).ToDictionary(x => x.Key, x => x.Value);
    
    public static Dictionary<string, ArrayList> TopCharacterPool = new Dictionary<string, ArrayList>()
    {
        {"��ǧѩ", new ArrayList(){false,CharacterArtCode.Ů����, new  List<Tag>() { Tag.һ�㺮â, Tag.���в���, Tag.��Т��, Tag.��֫, Tag.�����}, new List<int>(){100,0,0} } },
        {"������", new ArrayList(){false, CharacterArtCode.Ů����, new  List<Tag>() { Tag.һ�㺮â, Tag.���в���, Tag.��Т��, Tag.��֫, Tag.�����}, new List<int>(){100,0,0} } },
    };
    public static Dictionary<string, ArrayList> UnSelectedTopCharacters
    => TopCharacterPool.Where(x => (bool)x.Value[0] == false).ToDictionary(x => x.Key, x => x.Value);
    public static List<Character> GetSomeGirls(int count)
    {
        var output = new List<Character>();
        int total = UnSelectedCharacters.Count > count ? count : UnSelectedCharacters.Count;
        for (int i = 0; i < total; i++)
        {
            var random = Random.Range(0, UnSelectedCharacters.Count);
            var key = UnSelectedCharacters.Keys.ToList()[random];
            output.Add(OuputCharacter(key));
        }
        return output;
    }
    public static Character OuputCharacter(string key)
    {
        var value = UnSelectedCharacters[key];
        var character = Instantiate(Resources.Load<Character>("CharacterPrefab/Character"));
        character.hireStage = HireStage.NotInMap;
        DontDestroyOnLoad(character);
        CharacterPool[key][0] = true;
        character.CharacterName = key;
        character.characterArtCode = (CharacterArtCode)value[1];
        character.tagList = value[2] as List<Tag>;
        character.UpdateVariables();
        return character;
    }
    public static Character OuputTopCharacter(string key)
    {
        var value = TopCharacterPool[key];
        var character = Instantiate(Resources.Load<Character>("CharacterPrefab/Character"));
        character.hireStage = HireStage.NotInMap;
        DontDestroyOnLoad(character);
        TopCharacterPool[key][0] = true;
        character.CharacterName = key;
        character.characterArtCode = (CharacterArtCode)value[1];
        character.tagList = value[2] as List<Tag>;
        character.UpdateVariables();
        return character;
    }
    public static List<int> ReturnPrice(string name)
    {
        return CharacterPool[name][3] as List<int>;
    }
    public static void ReturnSomeGirls(List<Character> characters)
    {
        foreach (var character in characters)
        {
            CharacterPool[character.CharacterName][0] = false;
            Destroy(character.gameObject);
        }
    }
    public static void DeleteSomeGirls(List<string> names)
    {
        foreach (var name in names)
        {
            CharacterPool.Remove(name);
        }
    }
}
