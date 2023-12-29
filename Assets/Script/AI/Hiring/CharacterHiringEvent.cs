using System;
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
                    {ItemName.ë��,1},
                    {ItemName.�컨,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,1},
                    {ItemName.�컨,1},
                    {ItemName.ˮ�̻�,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,1},
                    {ItemName.�컨,1},
                    {ItemName.�˺��Ӳ���,1},
                    {ItemName.ˮ�̻�,1},
                    {ItemName.����컯��,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,1},
                    {ItemName.�컨,1},
                    {ItemName.�˺��Ӳ���,1},
                    {ItemName.ˮ�̻�,1},
                    {ItemName.����װ,1},
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
                    {ItemName.ë��,1},
                    {ItemName.��,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,1},
                    {ItemName.��,1},
                    {ItemName.��ֳ�д�,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,1},
                    {ItemName.��,1},
                    {ItemName.��Ҷ��,1},
                    {ItemName.��ֳ�д�,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.ë��,1},
                    {ItemName.�컨,1},
                    {ItemName.�˺��Ӳ���,1},
                    {ItemName.ˮ�̻�,1},
                    {ItemName.����װ,1},
                    {ItemName.ɽ����,1},
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
                    {ItemName.��,1},
                    {ItemName.���,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��,1},
                    {ItemName.���,1},
                    {ItemName.�󿳵�,1},

                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��,1},
                    {ItemName.���,1},
                    {ItemName.�󿳵�,1},
                    {ItemName.����,1},
                    {ItemName.�һ�ն�Ƶ�,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��,1},
                    {ItemName.���,1},
                    {ItemName.�󿳵�,1},
                    {ItemName.����,1},
                    {ItemName.�һ�ն�Ƶ�,1},
                    {ItemName.��ζ��,1},
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
                    {ItemName.���������,1},
                    {ItemName.���ʾ�,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���������,1},
                    {ItemName.���ʾ�,1},
                    {ItemName.�˲�,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���������,1},
                    {ItemName.���ʾ�,1},
                    {ItemName.�˲�,1},
                    {ItemName.�峴����,1},
                    {ItemName.������,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���������,1},
                    {ItemName.���ʾ�,1},
                    {ItemName.�˲�,1},
                    {ItemName.�峴����,1},
                    {ItemName.������,1 },
                    {ItemName.���ξ�,1},
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
                    {ItemName.�Ĺ�״,1},
                    {ItemName.�����,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,1},
                    {ItemName.�����,1},
                    {ItemName.˿��,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,1},
                    {ItemName.�����,1},
                    {ItemName.˿��,1},
                    {ItemName.���̱�ʯ,1},
                    {ItemName.������ݥ,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,1},
                    {ItemName.�����,1},
                    {ItemName.˿��,1},
                    {ItemName.���̱�ʯ,1},
                    {ItemName.������ݥ,1 },
                    {ItemName.������,2},
                 {ItemName.��֯������,1},
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
                    {ItemName.����,1},
                    {ItemName.���,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.���,1},
                    {ItemName.����ǹ,1},
                }
            },

            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.���,1},
                    {ItemName.����ǹ,1},
                    {ItemName.���ľ�,1},
                    {ItemName.��Ԫ��,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.���,1},
                    {ItemName.����ǹ,1},
                    {ItemName.���ľ�,1},
                    {ItemName.��Ԫ��,1 },
                    {ItemName.��Է����,1},
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
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.��ɰ֬,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.��ɰ֬,1},
                    {ItemName.��ĸ��,1},
                    {ItemName.���廪��,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.��ɰ֬,1},
                    {ItemName.��ĸ��,1},
                    {ItemName.���廪��,1},
                    {ItemName.������,1},
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
                    {ItemName.����,1},
                    {ItemName.��ͷ���,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.��ͷ���,1},
                    {ItemName.ľ����,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.��ͷ���,1},
                    {ItemName.ľ����,1},
                    {ItemName.��ֳ�д�,1},
                    {ItemName.����������,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.��ͷ���,1},
                    {ItemName.ľ����,1},
                    {ItemName.��ֳ�д�,1},
                    {ItemName.�����,1},
                    {ItemName.����������,1},
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
                    {ItemName.���ֵ�����,1},
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
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���ֵ�����,1},
                    {ItemName.������Ļƽ�,1},
                    {ItemName.Ů����,1},
                    {ItemName.�ſ���,1},
                    {ItemName.����װ,1 }
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.���ֵ�����,1},
                    {ItemName.������Ļƽ�,1},
                    {ItemName.Ů����,1},
                    {ItemName.�ſ���,1},
                    {ItemName.����װ,1 },
                    {ItemName.���ξ�,1},
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
                    {ItemName.��Ա����������,1},
                    {ItemName.ϴԩ¼,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��Ա����������,1},
                    {ItemName.ϴԩ¼,1},
                    {ItemName.��ֳ�д�,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��Ա����������,1},
                    {ItemName.ϴԩ¼,1},
                    {ItemName.��ֳ�д�,1},
                    {ItemName.ľ������,1},
                    {ItemName.ɽ����,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��Ա����������,1},
                    {ItemName.ϴԩ¼,1},
                    {ItemName.��ֳ�д�,1},
                    {ItemName.ľ������,1},
                    {ItemName.ɽ����,1},
                    {ItemName.�����,1},
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
                    {ItemName.����,1},
                    {ItemName.ë��,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.ë��,1},
                    {ItemName.���,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.ë��,1},
                    {ItemName.���,1},
                    {ItemName.��Ҷ��,1},
                    {ItemName.������,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.ë��,1},
                    {ItemName.���,1},
                    {ItemName.��Ҷ��,1},
                    {ItemName.������,1},
                    {ItemName.����������,1},
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
                    {ItemName.�Ĺ�״,1},
                    {ItemName.ë��,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,1},
                    {ItemName.ë��,1},
                    {ItemName.���̱�ʯ,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,1},
                    {ItemName.ë��,1},
                    {ItemName.���̱�ʯ,1},
                    {ItemName.��ֳ�д�,1},
                    {ItemName.���ư�����,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.�Ĺ�״,1},
                    {ItemName.ë��,1},
                    {ItemName.���̱�ʯ,1},
                    {ItemName.��ֳ�д�,1},
                    {ItemName.���ư�����,1 },
                    {ItemName.�컧��,1},
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
                    {ItemName.����,1},
                    {ItemName.����,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.����,1},
                    {ItemName.�峴����,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.����,1},
                    {ItemName.�峴����,1},
                    {ItemName.�����ײ�,1},
                   {ItemName.����ǹ,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����,1},
                    {ItemName.����,1},
                    {ItemName.ľ������,1},
                    {ItemName.�峴����,1},
                    {ItemName.���ֽ��,1 },
                    {ItemName.�����ײ�,1},
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
                    {ItemName.����ı�ʯ,1},
                    {ItemName.ȱ�ڵı�ʯ,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����ı�ʯ,1},
                    {ItemName.ȱ�ڵı�ʯ,1},
                    {ItemName.��ĸ��,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����ı�ʯ,1},
                    {ItemName.ȱ�ڵı�ʯ,1},
                    {ItemName.��ĸ��,1},
                    {ItemName.�챦ʯ,1},
                    {ItemName.��Ѫ��,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.����ı�ʯ,1},
                    {ItemName.ȱ�ڵı�ʯ,1},
                    {ItemName.��ĸ��,1},
                    {ItemName.�챦ʯ,1},
                    {ItemName.��Ѫ��,1 },
                    {ItemName.ľ����,1},
                    {ItemName.��ʯ,1},
                    {ItemName.�����,1}
                 }
            },
};
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> TaijianRarityItemRequestDict
= new Dictionary<Rarerity, Dictionary<ItemName, int>>
{
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.������Ļƽ�,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.������Ļƽ�,1},
                    {ItemName.������,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.������Ļƽ�,1},
                    {ItemName.������,1},
                    {ItemName.˿��,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.������Ļƽ�,1},
                    {ItemName.������,1},
                    {ItemName.˿��,1},
                    {ItemName.�˲�,1},
                    {ItemName.���ư�����,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.������Ļƽ�,1},
                    {ItemName.������,1},
                    {ItemName.˿��,1},
                    {ItemName.�˲�,1},
                    {ItemName.���ư�����,1 },
                    {ItemName.��,1},
                    {ItemName.����,1},
                    {ItemName.�����,1}
                 }
            }


};
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> DancerRarityItemRequestDict
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
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.�ϻ�,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.�ϻ�,1},
                    {ItemName.�廨��,1},
                    {ItemName.���ƻ�,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.�ϻ�,1},
                    {ItemName.�廨��,1},
                    {ItemName.���廪��,1},
                    {ItemName.���ƻ�,1},
                    {ItemName.������,1},
                    {ItemName.�����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> BeautyRarityItemRequestDict
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
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.��ɰ֬,1},
                    {ItemName.��ĸ��,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.����ʵ�,1},
                    {ItemName.��ĸ��,1},
                    {ItemName.���廪��,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ֽ,1},
                    {ItemName.��֬,1},
                    {ItemName.��ɰ֬,1},
                    {ItemName.��ĸ��,1},
                    {ItemName.���廪��,1 },
                    {ItemName.������,1},
                    {ItemName.��ʯ,1},
                    {ItemName.�����,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemaleSouthernerItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ҩ,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ҩ,1},
                    {ItemName.������,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ҩ,1},
                    {ItemName.������,1},
                    {ItemName.����,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ҩ,1},
                    {ItemName.������,1},
                    {ItemName.����,1},
                    {ItemName.����,1},
                    {ItemName.��������ɢ,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.��ҩ,1},
                    {ItemName.������,1},
                    {ItemName.����,1},
                    {ItemName.����,1},
                    {ItemName.��������ɢ,1},
                    {ItemName.��֥,1},
                    {ItemName.����������,1},
                    {ItemName.ʮȫ����,1}
                 }
            },
    };

    public static Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>> CharacterArtCodeToRarityItemRequestDict
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
            {CharacterArtCode.̫��, TaijianRarityItemRequestDict },
            {CharacterArtCode.��Ů, DancerRarityItemRequestDict },
            {CharacterArtCode.�Ͻ�Ů, FemaleSouthernerItemRequestDict },
            {CharacterArtCode.����, BeautyRarityItemRequestDict },

        };

    public Character character;
    public Dictionary<ItemName, int> requestItems;
    public string FailedMessage;
    public Canvas targetCanvas;
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

        //Rarerity rarerity = Rarerity.N;
        //foreach (Tag tag in character.tag)
        //{
        //    if ((int)Player.AllTagRareDict[tag] > (int)rarerity)
        //    {
        //        rarerity = (Rarerity)Player.AllTagRareDict[tag];
        //    }
        //}
        requestItems = CharacterArtCodeToRarityItemRequestDict[character.characterArtCode][character.rarerity];
    }
    public IEnumerator HiringRator()
    {
        var UIobject = Resources.Load<CharacterHiringUI>("Hiring/HireUI");
        Transform canvas = targetCanvas != null ? targetCanvas.transform : MainCanvas.FindMainCanvas();
        var currentUI = Instantiate(UIobject, canvas);
        SetRequest();
        currentUI.Setup(character, requestItems);
        if (character.hireStage == HireStage.Defeated)
        {
            currentUI.OnDefeated();
        }
        else if (character.hireStage == HireStage.Committed)
        {
            currentUI.OnCommitted();
        }
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
                    ReciveCharacter.TakeCharacter(character);
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
        if (targetCanvas == null)
        {
            Destroy(gameObject);
        }
    }
    public bool TryHiring()
    {
        var itemInventory = FindObjectOfType<ItemInventory>();
        var itemDict = itemInventory.ItemDict;
        if (character.hireStage == HireStage.Defeated || character.hireStage == HireStage.Committed)
        {
            return true;
        }
        else
        {
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
            return true;
        }
    }
}
