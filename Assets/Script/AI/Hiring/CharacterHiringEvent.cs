using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHiringEvent : MonoBehaviour
{
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemalePoestRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,2},
                    {ItemName.�컨,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,3},
                    {ItemName.�컨,2},
                    {ItemName.�˺��Ӳ���,1},
                    {ItemName.ˮ�̻�,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,4},
                    {ItemName.�컨,3},
                    {ItemName.�˺��Ӳ���,2},
                    {ItemName.ˮ�̻�,2},
                    {ItemName.����װ,1 },
                    {ItemName.����컯��,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,5},
                    {ItemName.�컨,4},
                    {ItemName.�˺��Ӳ���,3},
                    {ItemName.ˮ�̻�,3},
                    {ItemName.����װ,2},
                    {ItemName.����컯��,1},
                    {ItemName.�����,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MalePoetRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,2},
                    {ItemName.��,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,3},
                    {ItemName.��,2},
                    {ItemName.��ֳ�д�,1},
                    {ItemName.��Ҷ��,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,4},
                    {ItemName.��,3},
                    {ItemName.��ֳ�д�,2},
                    {ItemName.��Ҷ��,2},
                    {ItemName.����װ,1 },
                    {ItemName.ɽ����,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,5},
                    {ItemName.�컨,4},
                    {ItemName.�˺��Ӳ���,3},
                    {ItemName.ˮ�̻�,3},
                    {ItemName.����װ,2},
                    {ItemName.ɽ����,2},
                    {ItemName.����컯��,1},
                    {ItemName.�����,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleBladeUserRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��,2},
                    {ItemName.���,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��,3},
                    {ItemName.���,2},
                    {ItemName.�󿳵�,1},
                    {ItemName.����,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��,4},
                    {ItemName.���,3},
                    {ItemName.�󿳵�,2},
                    {ItemName.����,2},
                    {ItemName.�һ�ն�Ƶ�,1 },
                    {ItemName.��ζ��,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��,5},
                    {ItemName.���,4},
                    {ItemName.�󿳵�,3},
                    {ItemName.����,3},
                    {ItemName.�һ�ն�Ƶ�,2 },
                    {ItemName.��ζ��,2},
                    {ItemName.��ʤ��,1},
                    {ItemName.ʮȫ����,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> ElderlyRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���������,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���������,2},
                    {ItemName.���ʾ�,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���������,3},
                    {ItemName.���ʾ�,2},
                    {ItemName.�˲�,1},
                    {ItemName.�峴����,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���������,4},
                    {ItemName.���ʾ�,3},
                    {ItemName.�˲�,2},
                    {ItemName.�峴����,2},
                    {ItemName.������,1 },
                    {ItemName.���ξ�,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���������,5},
                    {ItemName.���ʾ�,4},
                    {ItemName.�˲�,3},
                    {ItemName.�峴����,3},
                    {ItemName.������,2 },
                    {ItemName.���ξ�,2},
                    {ItemName.����������,1},
                    {ItemName.��������ҩ,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleGovRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,2},
                    {ItemName.�����,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,3},
                    {ItemName.�����,2},
                    {ItemName.˿��,1},
                    {ItemName.���̱�ʯ,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,4},
                    {ItemName.�����,3},
                    {ItemName.˿��,2},
                    {ItemName.���̱�ʯ,2},
                    {ItemName.������ݥ,1 },
                    {ItemName.������,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,5},
                    {ItemName.�����,4},
                    {ItemName.˿��,3},
                    {ItemName.���̱�ʯ,3},
                    {ItemName.������ݥ,2 },
                    {ItemName.������,2},
 //                 {ItemName.��֯������,1},
                    {ItemName.�����,1}
                 }
            },

    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleFighterRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                   {ItemName.����,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,2},
                    {ItemName.���,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,3},
                    {ItemName.���,2},
                    {ItemName.����ǹ,1},
                    {ItemName.���ľ�,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,4},
                    {ItemName.���,3},
                    {ItemName.����ǹ,2},
                    {ItemName.���ľ�,2},
                    {ItemName.��Ԫ��,1 },
                    {ItemName.��Է����,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,5},
                    {ItemName.���,4},
                    {ItemName.����ǹ,3},
                    {ItemName.���ľ�,3},
                    {ItemName.��Ԫ��,2 },
                    {ItemName.��Է����,2},
                    {ItemName.�������,1},
                    {ItemName.ʮȫ����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemaleCivilianRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,2},
                    {ItemName.��֬,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,3},
                    {ItemName.��֬,2},
                    {ItemName.��ɰ֬,1},
                    {ItemName.��ĸ��,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,4},
                    {ItemName.��֬,3},
                    {ItemName.��ɰ֬,2},
                    {ItemName.��ĸ��,2},
                    {ItemName.���廪��,1 },
                    {ItemName.������,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,5},
                    {ItemName.��֬,4},
                    {ItemName.��ɰ֬,3},
                    {ItemName.��ĸ��,3},
                    {ItemName.���廪��,2 },
                    {ItemName.������,2},
                    {ItemName.��ʯ,1},
                    {ItemName.�����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MissionaryRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,2},
                    {ItemName.��ͷ���,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,3},
                    {ItemName.��ͷ���,2},
                    {ItemName.ľ����,1},
                    {ItemName.��ֳ�д�,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,4},
                    {ItemName.��ͷ���,3},
                    {ItemName.ľ����,2},
                    {ItemName.��ֳ�д�,2},
                    {ItemName.�����,1 },
                    {ItemName.����������,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,5},
                    {ItemName.��ͷ���,4},
                    {ItemName.ľ����,3},
                    {ItemName.��ֳ�д�,3},
                    {ItemName.�����,2 },
                    {ItemName.����������,2},
                    {ItemName.��֮ӥ,1},
                    {ItemName.�����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MusicianRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���ֵ�����,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���ֵ�����,2},
                    {ItemName.������Ļƽ�,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���ֵ�����,3},
                    {ItemName.������Ļƽ�,2},
                    {ItemName.Ů����,1},
                    {ItemName.�ſ���,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���ֵ�����,4},
                    {ItemName.������Ļƽ�,3},
                    {ItemName.Ů����,2},
                    {ItemName.�ſ���,2},
                    {ItemName.����װ,1 },
                    {ItemName.���ξ�,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���ֵ�����,5},
                    {ItemName.������Ļƽ�,4},
                    {ItemName.Ů����,3},
                    {ItemName.�ſ���,3},
                    {ItemName.����װ,2 },
                    {ItemName.���ξ�,2},
                    {ItemName.������,1},
                    {ItemName.�����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> StorytellerRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��Ա����������,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��Ա����������,2},
                    {ItemName.ϴԩ¼,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��Ա����������,3},
                    {ItemName.ϴԩ¼,2},
                    {ItemName.��ֳ�д�,1},
                    {ItemName.ľ������,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��Ա����������,4},
                    {ItemName.ϴԩ¼,3},
                    {ItemName.��ֳ�д�,2},
                    {ItemName.ľ������,2},
                    {ItemName.ɽ����,1 },
                    {ItemName.�����,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��Ա����������,5},
                    {ItemName.ϴԩ¼,4},
                    {ItemName.��ֳ�д�,3},
                    {ItemName.ľ������,3},
                    {ItemName.ɽ����,2 },
                    {ItemName.�����,2},
                    {ItemName.������,1},
                    {ItemName.�����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> ChessplayerRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,2},
                    {ItemName.ë��,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,3},
                    {ItemName.ë��,2},
                    {ItemName.���,1},
                    {ItemName.��Ҷ��,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,4},
                    {ItemName.ë��,3},
                    {ItemName.���,2},
                    {ItemName.��Ҷ��,2},
                    {ItemName.������,1 },
                    {ItemName.����������,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,5},
                    {ItemName.ë��,4},
                    {ItemName.���,3},
                    {ItemName.��Ҷ��,3},
                    {ItemName.������,2 },
                    {ItemName.����������,2},
                    {ItemName.����컯��,1},
                    {ItemName.�����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> GovernorRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,2},
                    {ItemName.ë��,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,3},
                    {ItemName.ë��,2},
                    {ItemName.���̱�ʯ,1},
                    {ItemName.��ֳ�д�,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,4},
                    {ItemName.ë��,3},
                    {ItemName.���̱�ʯ,2},
                    {ItemName.��ֳ�д�,2},
                    {ItemName.���ư�����,1 },
                    {ItemName.�컧��,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,5},
                    {ItemName.ë��,4},
                    {ItemName.���̱�ʯ,3},
                    {ItemName.��ֳ�д�,3},
                    {ItemName.���ư�����,2 },
                    {ItemName.�컧��,2},
                    {ItemName.����,1},
                    {ItemName.��������ҩ,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MonkRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,2},
                    {ItemName.����,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,3},
                    {ItemName.����,2},
                    {ItemName.ľ������,1},
                    {ItemName.�峴����,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,4},
                    {ItemName.����,3},
                    {ItemName.ľ������,2},
                    {ItemName.�峴����,2},
                    {ItemName.���ֽ��,1 },
                    {ItemName.�����ײ�,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,5},
                    {ItemName.����,4},
                    {ItemName.ľ������,3},
                    {ItemName.�峴����,3},
                    {ItemName.���ֽ��,2 },
                    {ItemName.�����ײ�,2},
                    {ItemName.����ǹ,1},
                    {ItemName.�����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> LooterRarityItemRequestDict
= new Dictionary<Rarerity, Dictionary<ItemName, int>>
{
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����ı�ʯ,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����ı�ʯ,2},
                    {ItemName.ȱ�ڵı�ʯ,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����ı�ʯ,3},
                    {ItemName.ȱ�ڵı�ʯ,2},
                    {ItemName.��ĸ��,1},
                    {ItemName.�챦ʯ,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����ı�ʯ,4},
                    {ItemName.ȱ�ڵı�ʯ,3},
                    {ItemName.��ĸ��,2},
                    {ItemName.�챦ʯ,2},
                    {ItemName.��Ѫ��,1 },
                    {ItemName.ľ����,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����ı�ʯ,5},
                    {ItemName.ȱ�ڵı�ʯ,4},
                    {ItemName.��ĸ��,3},
                    {ItemName.�챦ʯ,3},
                    {ItemName.��Ѫ��,2 },
                    {ItemName.ľ����,2},
                    {ItemName.��ʯ,1},
                    {ItemName.�����,1}
                 }
            },
};

    private static Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>> CharacterArtCodeToRarityItemRequestDict
        = new Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>>
        {
            {CharacterArtCode.Ůʫ��, FemalePoestRarityItemRequestDict },
            {CharacterArtCode.������, MalePoetRarityItemRequestDict },
            {CharacterArtCode.�е���, MaleBladeUserRarityItemRequestDict },
            {CharacterArtCode.����, ElderlyRarityItemRequestDict },
            {CharacterArtCode.�й�, MaleGovRarityItemRequestDict },
            {CharacterArtCode.����, MaleFighterRarityItemRequestDict },
            {CharacterArtCode.Ů����, FemaleCivilianRarityItemRequestDict },
            {CharacterArtCode.����ʿ, MissionaryRarityItemRequestDict },
            {CharacterArtCode.��ʦ,MusicianRarityItemRequestDict },
            {CharacterArtCode.˵����, StorytellerRarityItemRequestDict },
            {CharacterArtCode.��ʥ, ChessplayerRarityItemRequestDict },
            {CharacterArtCode.����, MonkRarityItemRequestDict },
            {CharacterArtCode.��Ա, GovernorRarityItemRequestDict },
            {CharacterArtCode.ʰ����, LooterRarityItemRequestDict },

        };

    public Character character;
    public Dictionary<ItemName, int> requestItems;
    public string FailedMessage;
    private void Awake()
    {

    }

    public void StartHiring()
    {
        if (character == null)
        {
            return;
        }
        StartCoroutine(HiringRator());
    }
    public void SetRequest()
    {
        Rarerity rarerity = Rarerity.N;
        foreach (Tag tag in character.tag)
        {
            if ((int)Player.AllTagRareDict[tag] > (int)rarerity)
            {
                rarerity = (Rarerity)Player.AllTagRareDict[tag];
            }
        }
        requestItems = CharacterArtCodeToRarityItemRequestDict[character.characterArtCode][rarerity];
    }
    public IEnumerator HiringRator()
    {
        var UIobject = Resources.Load<CharacterHiringUI>("Hiring/HireUI");
        var currentUI = Instantiate(UIobject, MainCanvas.FindMainCanvas());
        SetRequest();
        currentUI.Setup(character, requestItems);
        bool NeverFalse = true;
        while (NeverFalse)
        {
            if (currentUI == null)
            {
                NeverFalse = false;
                break;
            }
            if (currentUI.TryHire == true)
            {
                if (TryHiring() == true)
                {
                    break;
                }
                currentUI.TryHire = false;
                var sampleText = Resources.Load<Text>("Hiring/Message");
                var message = Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
                message.text = FailedMessage;
            }
            yield return null;
        }
        if (currentUI != null)
        {
            Destroy(currentUI.gameObject);
        }
        Destroy(gameObject);
    }
    public bool TryHiring()
    {
        var itemInventory = FindObjectOfType<ItemInventory>();
        var itemDict = itemInventory.ItemDict;
        foreach (ItemName item in requestItems.Keys)
        {
            if (itemDict.ContainsKey(item) == false)
            {
                FailedMessage = "ȱ����ļ����";
                return false;
            }
            if (itemDict[item] < requestItems[item])
            {
                FailedMessage = "������������";
                return false;
            }
        }
        foreach (ItemName item in requestItems.Keys)
        {
            for (int i = 0; i < requestItems[item]; i++)
            {
                itemInventory.RemoveItem(item);
            }
        }
        character.hireStage = HireStage.Hired;
        character.transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
        return true;
    }
}
