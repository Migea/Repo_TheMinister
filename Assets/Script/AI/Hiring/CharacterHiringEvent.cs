using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class CharacterHiringEvent : MonoBehaviour
{
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemalePoestRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1},
                    {ItemName.红花,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1},
                    {ItemName.红花,1},
                    {ItemName.水翁花,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1},
                    {ItemName.红花,1},
                    {ItemName.伤寒杂病论,1},
                    {ItemName.水翁花,1},
                    {ItemName.天机造化丹,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1},
                    {ItemName.红花,1},
                    {ItemName.伤寒杂病论,1},
                    {ItemName.水翁花,1},
                    {ItemName.长袖装,1},
                    {ItemName.天机造化丹,1},
                    {ItemName.和氏璧,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MalePoetRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1},
                    {ItemName.剑,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1},
                    {ItemName.剑,1},
                    {ItemName.货殖列传,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1},
                    {ItemName.剑,1},
                    {ItemName.竹叶青,1},
                    {ItemName.货殖列传,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1},
                    {ItemName.红花,1},
                    {ItemName.伤寒杂病论,1},
                    {ItemName.水翁花,1},
                    {ItemName.长袖装,1},
                    {ItemName.山海经,1},
                    {ItemName.天机造化丹,1},
                    {ItemName.和氏璧,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleBladeUserRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,1},
                    {ItemName.青酒,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,1},
                    {ItemName.青酒,1},
                    {ItemName.大砍刀,1},

                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,1},
                    {ItemName.青酒,1},
                    {ItemName.大砍刀,1},
                    {ItemName.虎骨,1},
                    {ItemName.烈火斩云刀,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,1},
                    {ItemName.青酒,1},
                    {ItemName.大砍刀,1},
                    {ItemName.虎骨,1},
                    {ItemName.烈火斩云刀,1},
                    {ItemName.三味酒,1},
                    {ItemName.百胜刀,1},
                    {ItemName.十全大补丸,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> ElderlyRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,1},
                    {ItemName.杏仁酒,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,1},
                    {ItemName.杏仁酒,1},
                    {ItemName.人参,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,1},
                    {ItemName.杏仁酒,1},
                    {ItemName.人参,1},
                    {ItemName.清炒菜心,1},
                    {ItemName.神气丹,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,1},
                    {ItemName.杏仁酒,1},
                    {ItemName.人参,1},
                    {ItemName.清炒菜心,1},
                    {ItemName.神气丹,1 },
                    {ItemName.美梦酒,1},
                    {ItemName.阴阳玄龙丹,1},
                    {ItemName.长生不老药,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleGovRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1},
                    {ItemName.官宸书,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1},
                    {ItemName.官宸书,1},
                    {ItemName.丝绸,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1},
                    {ItemName.官宸书,1},
                    {ItemName.丝绸,1},
                    {ItemName.金绿宝石,1},
                    {ItemName.龙井竹荪,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1},
                    {ItemName.官宸书,1},
                    {ItemName.丝绸,1},
                    {ItemName.金绿宝石,1},
                    {ItemName.龙井竹荪,1 },
                    {ItemName.云纹袍,2},
                 {ItemName.青织飞鱼袍,1},
                    {ItemName.和氏璧,1}
                 }
            },

    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleFighterRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                   {ItemName.棍子,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1},
                    {ItemName.羊酒,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1},
                    {ItemName.羊酒,1},
                    {ItemName.白银枪,1},
                }
            },

            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1},
                    {ItemName.羊酒,1},
                    {ItemName.白银枪,1},
                    {ItemName.护心镜,1},
                    {ItemName.混元功,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1},
                    {ItemName.羊酒,1},
                    {ItemName.白银枪,1},
                    {ItemName.护心镜,1},
                    {ItemName.混元功,1 },
                    {ItemName.天霸方天戟,1},
                    {ItemName.青龙方戟,1},
                    {ItemName.十全大补丸,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemaleCivilianRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.朱砂脂,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.朱砂脂,1},
                    {ItemName.祖母绿,1},
                    {ItemName.锦绣华服,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.朱砂脂,1},
                    {ItemName.祖母绿,1},
                    {ItemName.锦绣华服,1},
                    {ItemName.玉手镯,1},
                    {ItemName.钻石,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MissionaryRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,1},
                    {ItemName.汤头歌诀,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,1},
                    {ItemName.汤头歌诀,1},
                    {ItemName.木须肉,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,1},
                    {ItemName.汤头歌诀,1},
                    {ItemName.木须肉,1},
                    {ItemName.货殖列传,1},
                    {ItemName.阴阳八卦盘,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,1},
                    {ItemName.汤头歌诀,1},
                    {ItemName.木须肉,1},
                    {ItemName.货殖列传,1},
                    {ItemName.鬼谷子,1},
                    {ItemName.阴阳八卦盘,1},
                    {ItemName.大汗之鹰,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MusicianRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,1},
                    {ItemName.有破损的黄金,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,3},
                    {ItemName.有破损的黄金,2},
                    {ItemName.女儿红,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,1},
                    {ItemName.有破损的黄金,1},
                    {ItemName.女儿红,1},
                    {ItemName.杜康酒,1},
                    {ItemName.长袖装,1 }
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,1},
                    {ItemName.有破损的黄金,1},
                    {ItemName.女儿红,1},
                    {ItemName.杜康酒,1},
                    {ItemName.长袖装,1 },
                    {ItemName.美梦酒,1},
                    {ItemName.仙人醉,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> StorytellerRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,1},
                    {ItemName.洗冤录,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,1},
                    {ItemName.洗冤录,1},
                    {ItemName.货殖列传,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,1},
                    {ItemName.洗冤录,1},
                    {ItemName.货殖列传,1},
                    {ItemName.木须柿子,1},
                    {ItemName.山海经,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,1},
                    {ItemName.洗冤录,1},
                    {ItemName.货殖列传,1},
                    {ItemName.木须柿子,1},
                    {ItemName.山海经,1},
                    {ItemName.鬼谷子,1},
                    {ItemName.仙人醉,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> ChessplayerRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,1},
                    {ItemName.毛笔,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,1},
                    {ItemName.毛笔,1},
                    {ItemName.棋诀,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,1},
                    {ItemName.毛笔,1},
                    {ItemName.棋诀,1},
                    {ItemName.竹叶青,1},
                    {ItemName.云纹袍,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,1},
                    {ItemName.毛笔,1},
                    {ItemName.棋诀,1},
                    {ItemName.竹叶青,1},
                    {ItemName.云纹袍,1},
                    {ItemName.阴阳八卦盘,1},
                    {ItemName.天机造化丹,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> GovernorRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1},
                    {ItemName.毛笔,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1},
                    {ItemName.毛笔,1},
                    {ItemName.金绿宝石,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1},
                    {ItemName.毛笔,1},
                    {ItemName.金绿宝石,1},
                    {ItemName.货殖列传,1},
                    {ItemName.亮云白龙驹,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1},
                    {ItemName.毛笔,1},
                    {ItemName.金绿宝石,1},
                    {ItemName.货殖列传,1},
                    {ItemName.亮云白龙驹,1 },
                    {ItemName.朱户衣,1},
                    {ItemName.龙马,1},
                    {ItemName.长生不老药,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MonkRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1},
                    {ItemName.佛珠,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1},
                    {ItemName.佛珠,1},
                    {ItemName.清炒菜心,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1},
                    {ItemName.佛珠,1},
                    {ItemName.清炒菜心,1},
                    {ItemName.高汤白菜,1},
                   {ItemName.擎天枪,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1},
                    {ItemName.佛珠,1},
                    {ItemName.木须柿子,1},
                    {ItemName.清炒菜心,1},
                    {ItemName.佛手金卷,1 },
                    {ItemName.高汤白菜,1},
                    {ItemName.擎天枪,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> LooterRarityItemRequestDict
= new Dictionary<Rarerity, Dictionary<ItemName, int>>
{
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,1},
                    {ItemName.缺口的宝石,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,1},
                    {ItemName.缺口的宝石,1},
                    {ItemName.祖母绿,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,1},
                    {ItemName.缺口的宝石,1},
                    {ItemName.祖母绿,1},
                    {ItemName.红宝石,1},
                    {ItemName.鸽血红,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,1},
                    {ItemName.缺口的宝石,1},
                    {ItemName.祖母绿,1},
                    {ItemName.红宝石,1},
                    {ItemName.鸽血红,1 },
                    {ItemName.木佐绿,1},
                    {ItemName.钻石,1},
                    {ItemName.和氏璧,1}
                 }
            },
};
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> TaijianRarityItemRequestDict
= new Dictionary<Rarerity, Dictionary<ItemName, int>>
{
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.有破损的黄金,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.有破损的黄金,1},
                    {ItemName.凉州马,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.有破损的黄金,1},
                    {ItemName.凉州马,1},
                    {ItemName.丝绸,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.有破损的黄金,1},
                    {ItemName.凉州马,1},
                    {ItemName.丝绸,1},
                    {ItemName.人参,1},
                    {ItemName.亮云白龙驹,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.有破损的黄金,1},
                    {ItemName.凉州马,1},
                    {ItemName.丝绸,1},
                    {ItemName.人参,1},
                    {ItemName.亮云白龙驹,1 },
                    {ItemName.象虎,1},
                    {ItemName.龙马,1},
                    {ItemName.和氏璧,1}
                 }
            }


};
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> DancerRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.老虎,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.老虎,1},
                    {ItemName.绣花针,1},
                    {ItemName.堕云虎,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.老虎,1},
                    {ItemName.绣花针,1},
                    {ItemName.锦绣华服,1},
                    {ItemName.堕云虎,1},
                    {ItemName.弯月狼,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> BeautyRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.朱砂脂,1},
                    {ItemName.祖母绿,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.东洋词典,1},
                    {ItemName.祖母绿,1},
                    {ItemName.锦绣华服,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1},
                    {ItemName.胭脂,1},
                    {ItemName.朱砂脂,1},
                    {ItemName.祖母绿,1},
                    {ItemName.锦绣华服,1 },
                    {ItemName.玉手镯,1},
                    {ItemName.钻石,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemaleSouthernerItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.金疮药,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.金疮药,1},
                    {ItemName.何首乌,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.金疮药,1},
                    {ItemName.何首乌,1},
                    {ItemName.沉香,1},
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.金疮药,1},
                    {ItemName.何首乌,1},
                    {ItemName.沉香,1},
                    {ItemName.当归,1},
                    {ItemName.养气筑基散,1 },
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.金疮药,1},
                    {ItemName.何首乌,1},
                    {ItemName.沉香,1},
                    {ItemName.当归,1},
                    {ItemName.养气筑基散,1},
                    {ItemName.灵芝,1},
                    {ItemName.阴阳玄龙丹,1},
                    {ItemName.十全大补丸,1}
                 }
            },
    };

    public static Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>> CharacterArtCodeToRarityItemRequestDict
        = new Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>>
        {
            {CharacterArtCode.女诗人, FemalePoestRarityItemRequestDict },
            {CharacterArtCode.男书生, MalePoetRarityItemRequestDict },
            {CharacterArtCode.男刀客, MaleBladeUserRarityItemRequestDict },
            {CharacterArtCode.老者, ElderlyRarityItemRequestDict },
            {CharacterArtCode.男官, MaleGovRarityItemRequestDict },
            {CharacterArtCode.男武, MaleFighterRarityItemRequestDict },
            {CharacterArtCode.女布衣, FemaleCivilianRarityItemRequestDict },
            {CharacterArtCode.传教士, MissionaryRarityItemRequestDict },
            {CharacterArtCode.琴师,MusicianRarityItemRequestDict },
            {CharacterArtCode.说书人, StorytellerRarityItemRequestDict },
            {CharacterArtCode.棋圣, ChessplayerRarityItemRequestDict },
            {CharacterArtCode.方丈, MonkRarityItemRequestDict },
            {CharacterArtCode.官员, GovernorRarityItemRequestDict },
            {CharacterArtCode.拾荒者, LooterRarityItemRequestDict },
            {CharacterArtCode.太监, TaijianRarityItemRequestDict },
            {CharacterArtCode.舞女, DancerRarityItemRequestDict },
            {CharacterArtCode.南疆女, FemaleSouthernerItemRequestDict },
            {CharacterArtCode.花魁, BeautyRarityItemRequestDict },

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
                    LocalizedString itemString = new LocalizedString
                    {
                        TableReference = "UI",
                        TableEntryReference = $"提示_缺少招募道具"
                    };
                    FailedMessage = itemString.GetLocalizedString();
                    return false;
                }
                if (itemDict[item] < requestItems[item])
                {
                    LocalizedString itemString = new LocalizedString
                    {
                        TableReference = "UI",
                        TableEntryReference = $"提示_道具数量不足"
                    };
                    FailedMessage = itemString.GetLocalizedString();
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
