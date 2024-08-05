using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayName
{
    唐僧大战白骨精,
    宋江打虎,
    十面埋伏,
    天上掉下张翼德,
    骂王朗,
    剧名,
    西门庆与潘金莲,
}

public static class PlayList
{
    public static Dictionary<PlayName, ArrayList> PlayListDict
        = new Dictionary<PlayName, ArrayList>()
    {
            {
                PlayName.唐僧大战白骨精,
                new ArrayList()
                {
                    "唐僧大战白骨精！",
                    "只见那唐僧用金箍棒哼哼哈嘿，三下五除二得制服了白骨精。",
                    new List<Tag>()
                    {
                        Tag.鹰之力,
                        Tag.老戏骨
                    }
                }
            },
            {
                PlayName.宋江打虎,
                new ArrayList()
                {
                    "宋江打虎",
                    "宋江呼保义上梁山时，路遇猛虎，指顾从容，只见他从怀中取出一壶酒喝了一大口后直奔虎口，三拳两脚就把猛虎制服。",
                    new List<Tag>()
                    {
                        Tag.虎猛
                    }
                }
            },
            {
                PlayName.十面埋伏,
                new ArrayList()
                {
                    "十面埋伏",
                    "楚汉相争，汉王刘邦携数十万大军把项羽团团困住，只见胜利在望一只大雕却突然从空中俯冲而下，那项羽竟然抓住了大雕脱身而去，大笑道：“没想到吧！这才是我的逃跑路线！”",
                    new List<Tag>()
                    {
                        Tag.霸王,
                        Tag.戟
                    }
                }

            },
            {
                PlayName.天上掉下张翼德,
                new ArrayList()
                {
                    "天上掉下张翼德",
                    "这日贾宝玉偷偷溜出书房在一凉亭赏花，忽闻一身巨响从亭顶传来，接着传来人滚落的声音。宝玉上前查看，发现竟是一壮汉，豹头环眼，燕颌虎须。",
                    new List<Tag>()
                    {
                        Tag.调皮鬼,
                        Tag.花言巧语
                    }
                }

            },
            {
                PlayName.骂王朗,
                new ArrayList()
                {
                    "骂王朗",
                    "诸葛亮率兵攻打曹魏，王朗于阵前游说其退兵。诸葛亮大骂王朗为无耻老贼，并从未见过如此厚颜无耻之人，王朗气急攻心坠于马下，死去。",
                    new List<Tag>()
                    {
                        Tag.小有谋略,
                        Tag.偃师,
                    }
                }
            },
            {
                PlayName.剧名,
                new ArrayList()
                {
                    "剧名",
                    "如果你看完了这场剧，那你就看完了这场剧。如果你看到了这剧的结局，那么你就看到了结局。",
                    new List<Tag>()
                    {
                        Tag.文化沙漠,
                    }
                }
            },
            {
                PlayName.西门庆与潘金莲,
                new ArrayList()
                {
                    "西门庆与潘金莲",
                    "哥哥，你一直来找我姐姐们不会生气吧。",
                    new List<Tag>()
                    {
                        Tag.故事王,
                        Tag.珠光宝气
                    }
                }
                
            }
    };
}