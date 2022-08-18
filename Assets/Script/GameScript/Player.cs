using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Map map;
    public static Dictionary<Tag, List<int>> TagInfDict = new Dictionary<Tag, List<int>>() {
        {Tag.Null, new List<int>(){0,0,0,0, 0,0}},
        {Tag.南无加特林,new List<int>(){0,0,0,12,0,0}},
        {Tag.弈星下凡,new List<int>(){0,0,12,0,0,0}},
        {Tag.钜子,new List<int>(){4,0,0,-4,12,0}},
        {Tag.文武双全,new List<int>(){6,6,6,6,6,6}},
        {Tag.成道,new List<int>(){10,10,10,10,10,10}},
        {Tag.长生不老,new List<int>(){12,0,0,0,0,0}},
        {Tag.生死肉骨,new List<int>(){0,0,0,0,0,12}},
        {Tag.碧血丹心,new List<int>(){0,12,0,0,0,0}},
        {Tag.黯然销魂掌,new List<int>(){-6,-5,-6,9,9,9}},
        {Tag.围棋十段,new List<int>(){0,0,10,0,0,0}},
        {Tag.状元,new List<int>(){8,0,0,0,0,0}},
        {Tag.诗仙,new List<int>(){0,8,0,0,0,0}},
        {Tag.卧龙,new List<int>(){0,0,8,0,0,0}},
        {Tag.八斗之才,new List<int>(){7,7,7,-3,-4,-4}},
        {Tag.武圣,new List<int>(){0,0,0,8,0,0}},
        {Tag.无影,new List<int>(){0,0,0,0,8,0}},
        {Tag.磐石,new List<int>(){0,0,0,0,0,8}},
        {Tag.诸武精通,new List<int>(){-4,-4,-3,7,7,7}},
        {Tag.纸上谈兵,new List<int>(){10,0,-1,0,0,0}},
        {Tag.徒有虚名,new List<int>(){-1,10,0,0,0,0}},
        {Tag.投机取巧,new List<int>(){0,-1,10,0,0,0}},
        {Tag.混世魔王,new List<int>(){0,0,0,10,0,-1}},
        {Tag.心狠手辣,new List<int>(){0,0,0,0,10,-1}},
        {Tag.墨守成规,new List<int>(){0,0,0,0,-1,10}},
        {Tag.巧夺天工,new List<int>(){3,0,-1,0,0,8}},
        {Tag.悬壶济世,new List<int>(){10,7,0,-3,-2,-2}},
        {Tag.墨者,new List<int>(){7,-3,0,-4,10,0}},
        {Tag.穿日,new List<int>(){0,0,0,4,5,0}},
        {Tag.无声,new List<int>(){0,0,0,0,9,0}},
        {Tag.青龙,new List<int>(){0,0,0,9,0,0}},
        {Tag.必胜,new List<int>(){0,0,0,5,0,4}},
        {Tag.撑天,new List<int>(){0,0,0,0,0,9}},
        {Tag.龙之力,new List<int>(){0,0,0,0,4,5}},
        {Tag.火力压制,new List<int>(){0,0,0,-1,11,-1}},
        {Tag.醉生梦死,new List<int>(){0,5,0,5,0,0}},
        {Tag.金光闪闪,new List<int>(){0,0,0,-1,-1,11}},
        {Tag.光碎,new List<int>(){0,0,0,0,0,0}},
        {Tag.龙马精神,new List<int>(){0,0,0,0,0,0}},
        {Tag.鹰之力,new List<int>(){0,0,0,0,4,4}},
        {Tag.窥得天机,new List<int>(){0,0,10,0,0,0}},
        {Tag.百毒不侵,new List<int>(){5,0,0,0,5,0}},
        {Tag.嘤嘤狂吠,new List<int>(){0,0,0,3,0,6}},
        {Tag.波纹行走,new List<int>(){0,0,0,3,6,0}},
        {Tag.象虎之力,new List<int>(){0,0,0,6,0,3}},
        {Tag.文,new List<int>(){3,3,3,-1,0,-1}},
        {Tag.武,new List<int>(){-1,-1,0,3,3,3}},
        {Tag.书通二酉,new List<int>(){5,0,0,0,0,0}},
        {Tag.才华横溢,new List<int>(){0,5,0,0,0,0}},
        {Tag.工于心计,new List<int>(){0,0,5,0,0,0}},
        {Tag.力拔山兮,new List<int>(){0,0,0,5,0,0}},
        {Tag.出没无常,new List<int>(){0,0,0,0,5,0}},
        {Tag.广厦之荫,new List<int>(){0,0,0,0,0,5}},
        {Tag.智勇双全,new List<int>(){0,-4,5,5,0,0}},
        {Tag.偃师,new List<int>(){5,0,0,-4,5,0}},
        {Tag.奇门遁甲,new List<int>(){0,5,0,0,-4,5}},
        {Tag.天生神力,new List<int>(){0,0,-1,8,0,0}},
        {Tag.阳明学派,new List<int>(){4,4,4,-2,-2,-1}},
        {Tag.吸星大法,new List<int>(){0,0,0,37,43,0}},
        {Tag.巫妖领主,new List<int>(){0,0,0,7,0,0}},
        {Tag.龙骑士,new List<int>(){-2,0,-3,4,4,4}},
        {Tag.外交官,new List<int>(){4,4,0,-1,0,0}},
        {Tag.老当益壮,new List<int>(){0,-3,0,2,2,6}},
        {Tag.炼金术师,new List<int>(){6,-5,0,0,6,0}},
        {Tag.近战精通,new List<int>(){-4,-4,0,5,5,5}},
        {Tag.古神转世,new List<int>(){8,-25,4,8,4,8}},
        {Tag.理财大师,new List<int>(){0,2,3,0,0,0}},
        {Tag.纵横家,new List<int>(){0,2,5,0,0,0}},
        {Tag.大锤,new List<int>(){0,0,-1,0,0,8}},
        {Tag.戏精,new List<int>(){0,3,3,0,0,0}},
        {Tag.黄帝内经,new List<int>(){8,5,0,-6,0,0}},
        {Tag.本草纲目,new List<int>(){7,0,0,0,0,0}},
        {Tag.御马监,new List<int>(){0,0,0,0,0,5}},
        {Tag.驯兽大师,new List<int>(){0,0,0,0,3,3}},
        {Tag.朝奉,new List<int>(){0,3,4,0,0,0}},
        {Tag.百步穿杨,new List<int>(){0,0,0,0,6,0}},
        {Tag.刀王,new List<int>(){0,0,0,6,0,0}},
        {Tag.雷电法王,new List<int>(){-2,-1,0,6,3,0}},
        {Tag.皇家血统,new List<int>(){0,0,0,0,0,6}},
        {Tag.霸王,new List<int>(){-2,-2,-2,6,0,6}},
        {Tag.气功达人,new List<int>(){1,0,0,0,6,0}},
        {Tag.诗兴大发,new List<int>(){0,5,0,0,0,0}},
        {Tag.如醉如狂,new List<int>(){0,0,0,5,0,0}},
        {Tag.氪金战士,new List<int>(){2,2,2,2,2,2}},
        {Tag.把素持斋,new List<int>(){5,0,0,0,0,0}},
        {Tag.盛食厉兵,new List<int>(){0,0,0,0,5,0}},
        {Tag.固若金汤,new List<int>(){0,0,0,0,0,5}},
        {Tag.妙手丹心,new List<int>(){3,3,0,0,0,0}},
        {Tag.侵略如火,new List<int>(){0,0,0,3,3,0}},
        {Tag.仁人君子,new List<int>(){0,6,0,0,0,0}},
        {Tag.宝马良驹,new List<int>(){6,0,0,0,0,0}},
        {Tag.虎猛,new List<int>(){0,0,0,5,0,3}},
        {Tag.独狼,new List<int>(){0,0,2,3,5,-2}},
        {Tag.忠贞之志,new List<int>(){0,0,0,2,0,5}},
        {Tag.景星庆云,new List<int>(){0,0,6,0,0,0}},
        {Tag.长袖善舞,new List<int>(){1,6,0,0,0,0}},
        {Tag.金钱镖,new List<int>(){0,0,0,0,7,0}},
        {Tag.袖袍,new List<int>(){2,0,0,0,6,0}},
        {Tag.血滴子,new List<int>(){0,0,0,0,8,0}},
        {Tag.文正,new List<int>(){2,2,2,-1,-1,0}},
        {Tag.武忠,new List<int>(){-1,-1,0,2,2,2}},
        {Tag.书痴,new List<int>(){3,0,0,0,0,0}},
        {Tag.略有才名,new List<int>(){0,3,0,0,0,0}},
        {Tag.小有谋略,new List<int>(){0,0,3,0,0,0}},
        {Tag.武痴,new List<int>(){0,0,0,3,0,0}},
        {Tag.身形矫健,new List<int>(){0,0,0,0,3,0}},
        {Tag.老罴当道,new List<int>(){0,0,0,0,0,3}},
        {Tag.法外狂徒,new List<int>(){0,-4,4,0,4,0}},
        {Tag.蛤蟆功,new List<int>(){0,-2,-2,2,2,4}},
        {Tag.欢喜佛,new List<int>(){4,0,0,0,0,0}},
        {Tag.恶魔人,new List<int>(){0,0,0,2,1,1}},
        {Tag.通晓天文,new List<int>(){0,0,4,0,0,0}},
        {Tag.冰霜宝剑,new List<int>(){0,0,0,4,0,0}},
        {Tag.飞毛腿,new List<int>(){0,0,0,0,2,0}},
        {Tag.火炮,new List<int>(){0,0,0,0,0,3}},
        {Tag.东洋语,new List<int>(){2,1,0,0,0,0}},
        {Tag.能歌善舞,new List<int>(){0,0,0,0,2,0}},
        {Tag.西洋语,new List<int>(){2,1,0,0,0,0}},
        {Tag.毒师,new List<int>(){0,0,0,0,3,0}},
        {Tag.离经叛道,new List<int>(){2,0,0,0,0,0}},
        {Tag.外乡人,new List<int>(){0,0,1,0,2,0}},
        {Tag.疯子,new List<int>(){-1,-1,-1,3,0,2}},
        {Tag.棋道,new List<int>(){0,0,3,0,0,0}},
        {Tag.心算,new List<int>(){0,2,0,0,0,0}},
        {Tag.经济学,new List<int>(){0,0,2,0,0,0}},
        {Tag.小锤,new List<int>(){0,0,0,0,0,4}},
        {Tag.郎中,new List<int>(){2,1,0,0,0,0}},
        {Tag.老戏骨,new List<int>(){0,0,3,0,0,0}},
        {Tag.驯兽术,new List<int>(){0,0,0,0,3,0}},
        {Tag.御马司,new List<int>(){0,0,0,0,0,3}},
        {Tag.牧民,new List<int>(){0,0,0,0,0,2}},
        {Tag.兼爱,new List<int>(){0,0,0,0,0,0}},
        {Tag.货郎,new List<int>(){0,2,0,0,0,0}},
        {Tag.非攻,new List<int>(){5,0,0,-1,0,0}},
        {Tag.箭无虚发,new List<int>(){0,0,0,0,2,2}},
        {Tag.根骨清奇,new List<int>(){0,0,0,3,0,0}},
        {Tag.一点寒芒,new List<int>(){0,0,0,0,1,3}},
        {Tag.买瓜人,new List<int>(){0,0,2,2,0,0}},
        {Tag.武艺精湛,new List<int>(){0,0,0,2,1,1}},
        {Tag.登堂入室,new List<int>(){0,1,0,3,0,0}},
        {Tag.走火入魔,new List<int>(){-3,-2,-1,4,4,2}},
        {Tag.素餐,new List<int>(){2,0,0,0,0,0}},
        {Tag.荤菜,new List<int>(){0,0,0,2,0,0}},
        {Tag.鸿运当头,new List<int>(){0,0,3,0,0,0}},
        {Tag.丝绸,new List<int>(){0,2,0,0,0,0}},
        {Tag.护心,new List<int>(){0,0,0,0,0,4}},
        {Tag.皮甲,new List<int>(){0,0,0,0,4,0}},
        {Tag.铁甲,new List<int>(){0,0,0,4,0,0}},
        {Tag.辟邪安正,new List<int>(){0,0,0,1,0,1}},
        {Tag.珠光宝气,new List<int>(){1,1,0,0,0,0}},
        {Tag.家室美满,new List<int>(){1,1,-1,1,-1,1}},
        {Tag.文贞,new List<int>(){1,1,1,-1,0,-1}},
        {Tag.武勇,new List<int>(){-1,-1,0,1,1,1}},
        {Tag.有勇无谋,new List<int>(){0,0,-2,1,0,0}},
        {Tag.花言巧语,new List<int>(){0,-2,1,0,0,0}},
        {Tag.绣花枕头,new List<int>(){-2,1,0,0,0,0}},
        {Tag.梧鼠五技,new List<int>(){-2,0,0,0,1,0}},
        {Tag.自是三公,new List<int>(){1,0,0,0,-2,0}},
        {Tag.敝帚自珍,new List<int>(){0,0,1,0,0,-2}},
        {Tag.不孕不育,new List<int>(){0,0,0,0,0,0}},
        {Tag.巨人症,new List<int>(){0,0,0,1,0,0}},
        {Tag.侏儒症,new List<int>(){1,0,0,0,0,0}},
        {Tag.儒生,new List<int>(){0,1,0,0,0,0}},
        {Tag.道士,new List<int>(){0,0,1,0,0,0}},
        {Tag.僧人,new List<int>(){1,0,0,0,0,0}},
        {Tag.讼师,new List<int>(){0,0,1,0,0,0}},
        {Tag.冷血无情,new List<int>(){-3,0,0,1,2,1}},
        {Tag.阉人,new List<int>(){0,0,0,-1,1,-1}},
        {Tag.吸血鬼,new List<int>(){0,-2,0,1,2,0}},
        {Tag.狼人,new List<int>(){0,0,-2,2,0,1}},
        {Tag.膝盖僵硬,new List<int>(){0,0,0,0,-1,0}},
        {Tag.多动症,new List<int>(){0,0,0,1,-1,0}},
        {Tag.平平无奇,new List<int>(){0,0,0,0,0,0}},
        {Tag.雕,new List<int>(){-1,-2,0,0,2,2}},
        {Tag.习武之人,new List<int>(){0,-2,0,1,1,1}},
        {Tag.丹童,new List<int>(){2,0,0,-1,-1,0}},
        {Tag.弓,new List<int>(){0,0,0,0,2,-1}},
        {Tag.剑,new List<int>(){0,0,0,1,0,0}},
        {Tag.枪,new List<int>(){0,0,0,1,-1,1}},
        {Tag.贪污狼藉,new List<int>(){-1,-1,2,0,0,0}},
        {Tag.演员,new List<int>(){0,1,0,0,0,0}},
        {Tag.六根不净,new List<int>(){-1,0,0,0,0,0}},
        {Tag.刀,new List<int>(){0,0,0,0,0,1}},
        {Tag.戟,new List<int>(){0,0,0,0,-1,2}},
        {Tag.医术,new List<int>(){2,1,0,-2,0,0}},
        {Tag.马倌,new List<int>(){0,0,0,0,0,0}},
        {Tag.厄运缠身,new List<int>(){0,0,-4,0,0,0}},
        {Tag.不孝子,new List<int>(){0,-3,0,0,0,0}},
        {Tag.腿脚不便,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.年老体衰,new List<int>(){1,0,0,-2,-2,-2}},
        {Tag.醉酒,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.身世悲苦,new List<int>(){-5,-5,2,1,1,2}},
        {Tag.精神病,new List<int>(){-2,-2,-2,2,0,0}},
        {Tag.近视,new List<int>(){0,0,0,-3,0,0}},
        {Tag.嗜甜如命,new List<int>(){0,0,0,-2,0,0}},
        {Tag.营养不良,new List<int>(){0,0,0,-2,0,0}},
        {Tag.糖尿病,new List<int>(){0,0,0,-5,0,0}},
        {Tag.夜不能寐,new List<int>(){0,0,0,-3,-3,2}},
        {Tag.干饭人,new List<int>(){-1,-1,-1,-1,-1,-1}},
        {Tag.双目失明,new List<int>(){0,0,0,-2,0,-3}},
        {Tag.独臂,new List<int>(){0,0,0,-1,-2,-2}},
        {Tag.痴呆,new List<int>(){-2,-2,-2,1,0,0}},
        {Tag.身怀六甲,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.小儿麻痹,new List<int>(){0,0,-1,-2,-1,-1}},
        {Tag.目不识丁,new List<int>(){-2,-2,-1,0,0,0}},
        {Tag.得寸进尺,new List<int>(){0,-2,-4,0,0,0}},
        {Tag.无能狂怒,new List<int>(){0,0,0,-4,0,-2}},
        {Tag.头疼,new List<int>(){-2,-2,-4,0,0,0}},
        {Tag.半身不遂,new List<int>(){0,0,0,-5,0,0}},
        {Tag.磕巴,new List<int>(){0,-4,0,0,0,0}},
        {Tag.惹人嫌,new List<int>(){-1,-1,-1,0,0,0}},
        {Tag.调皮鬼,new List<int>(){0,0,0,0,0,-2}},
        {Tag.天生恶感,new List<int>(){0,-2,0,0,0,0}},
        {Tag.干呕,new List<int>(){0,0,0,0,-5,0}},
        {Tag.身体孱弱,new List<int>(){1,1,1,-3,-3,-2}},
        {Tag.肥胖症,new List<int>(){0,0,0,-3,-4,2}},
        {Tag.长短腿,new List<int>(){0,0,0,-4,-1,0}},
        {Tag.义肢,new List<int>(){0,0,0,-3,2,-2}},
        {Tag.仙人之躯,new List<int>(){0,0,0,7,7,7}},
        {Tag.五味杂陈,new List<int>(){-1,3,-1,0,1,0}},
        {Tag.好酒之人,new List<int>(){0,1,0,0,0,1}},
        {Tag.匠人,new List<int>(){3,1,0,-1,0,0}},
        {Tag.饱腹,new List<int>(){0,0,0,1,0,0}},
        {Tag.鸠工庀材,new List<int>(){0,0,0,0,0,0}},
        {Tag.体态端正,new List<int>(){0,0,0,0,0,1}},
        {Tag.杂七杂八,new List<int>(){1,-1,0,-1,1,0}},
        {Tag.毛发旺盛,new List<int>(){0,0,0,0,-1,1}},
        {Tag.药毒,new List<int>(){0,0,0,-2,-2,-2}},
        {Tag.衣不蔽体,new List<int>(){-1,-1,-1,-1,-1,-1}},
        {Tag.无伤大雅,new List<int>(){0,0,0,0,0,0}},
        {Tag.潜光隐耀,new List<int>(){0,0,0,0,0,10}},
        {Tag.深仁厚泽,new List<int>(){8,2,0,0,0,0}},
        {Tag.平步青云,new List<int>(){0,3,7,0,0,0}},
        {Tag.主教,new List<int>(){5,2,0,0,0,0}},
        {Tag.珠圆玉润,new List<int>(){0,7,0,0,0,0}},
        {Tag.故事王,new List<int>(){1,1,0,0,0,0}},
        {Tag.琴师,new List<int>(){0,2,0,0,1,0}},
        {Tag.醉拳,new List<int>(){0,0,0,3,0,0}},
        {Tag.无用之人,new List<int>(){0,0,0,1,-1,0}},
        {Tag.文化沙漠,new List<int>(){-1,-1,-1,3,3,3}},
        {Tag.武功小成,new List<int>(){0,0,0,5,0,2}}


    };
    public static Dictionary<Rarerity, List<Tag>> GivenableTagRareDict = new Dictionary<Rarerity, List<Tag>>()
        {
        {Rarerity.B,new List<Tag>()
        {
        Tag.厄运缠身,
        Tag.腿脚不便,
        Tag.年老体衰,
        Tag.身世悲苦,
        Tag.精神病,
        Tag.近视,
        Tag.嗜甜如命,
        Tag.干饭人,
        Tag.双目失明,
        Tag.独臂,
        Tag.痴呆,
        Tag.小儿麻痹,
        Tag.目不识丁,
        Tag.得寸进尺,
        Tag.无能狂怒,
        Tag.头疼,
        Tag.半身不遂,
        Tag.磕巴,
        Tag.惹人嫌,
        Tag.调皮鬼,
        Tag.天生恶感,
        Tag.干呕,
        Tag.身体孱弱,
        Tag.肥胖症,
        Tag.长短腿,
        Tag.义肢,
    }},

        {Rarerity.R,new List<Tag>()
        {
        Tag.书痴,
        Tag.略有才名,
        Tag.小有谋略,
        Tag.武痴,
        Tag.身形矫健,
        Tag.老罴当道,
        Tag.离经叛道,
        Tag.外乡人,
        Tag.疯子,
        Tag.棋道,
        Tag.郎中,
        Tag.货郎
    }},
        {Rarerity.N,new List<Tag>()
       {
        Tag.有勇无谋,
        Tag.自是三公,
        Tag.敝帚自珍,
        Tag.巨人症,
        Tag.侏儒症,
        Tag.儒生,
        Tag.道士,
        Tag.僧人,
        Tag.冷血无情,
        Tag.近视,
        Tag.营养不良,
        Tag.膝盖僵硬,
        Tag.多动症,
        Tag.平平无奇,
        Tag.习武之人,
        Tag.弓,
        Tag.刀,
        Tag.枪,
        Tag.剑,
        Tag.戟,
        Tag.身世悲苦,
        Tag.贪污狼藉,
        Tag.六根不净,
        Tag.吸血鬼,
        Tag.狼人
    }},
        {Rarerity.SR,new List<Tag>()
       {
        Tag.才华横溢,
        Tag.工于心计,
        Tag.力拔山兮,
        Tag.广厦之荫,
        Tag.智勇双全,
    }},
        {Rarerity.SSR,new List<Tag>()
       {
        Tag.状元,
        Tag.诗仙,
        Tag.卧龙,
        Tag.武圣,
        Tag.无影,
        Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
       {}}

};
    public static Dictionary<Rarerity, List<Tag>> MergeableTagRareDict = new Dictionary<Rarerity, List<Tag>> {
        {Rarerity.B,new List<Tag>()
        {
        Tag.糖尿病
    }},

        {Rarerity.R,new List<Tag>()
        {
        Tag.文正,
        Tag.武忠,
        Tag.法外狂徒,
        Tag.欢喜佛,
        Tag.恶魔人,
        Tag.老戏骨,
        Tag.牧民

    }},
        {Rarerity.N,new List<Tag>()
       {
           }},
        {Rarerity.SR,new List<Tag>()
       {
        Tag.文,
        Tag.武,
        Tag.天生神力,
        Tag.阳明学派,
        Tag.吸星大法,
        Tag.巫妖领主,
        Tag.龙骑士,
        Tag.外交官,
        Tag.老当益壮,
        Tag.炼金术师,
        Tag.近战精通,
        Tag.古神转世,
        Tag.理财大师,
        Tag.戏精,
        Tag.御马监,
        Tag.驯兽大师,
        Tag.朝奉
    }},
        {Rarerity.SSR,new List<Tag>()
       {
        Tag.黯然销魂掌,
        Tag.围棋十段,
        Tag.八斗之才,
        Tag.诸武精通,
        Tag.纸上谈兵,
        Tag.徒有虚名,
        Tag.投机取巧,
        Tag.混世魔王,
        Tag.心狠手辣,
        Tag.墨守成规,
        Tag.巧夺天工,
        Tag.悬壶济世,
        Tag.墨者

    }},
        {Rarerity.UR,new List<Tag>()
       {
        Tag.南无加特林,
        Tag.弈星下凡,
        Tag.钜子,
        Tag.文武双全,
        Tag.长生不老,
        Tag.生死肉骨,
        Tag.碧血丹心,
        Tag.陆地神仙
}}

};
    public static Dictionary<Tag, Rarerity> AllTagRareDict = new Dictionary<Tag, Rarerity>
    {
        {Tag.厄运缠身,Rarerity.B},
        {Tag.不孝子,Rarerity.B},
        {Tag.腿脚不便,Rarerity.B},
        {Tag.年老体衰,Rarerity.B},
        {Tag.醉酒,Rarerity.B},
        {Tag.身世悲苦,Rarerity.B},
        {Tag.精神病,Rarerity.B},
        {Tag.近视,Rarerity.B},
        {Tag.嗜甜如命,Rarerity.B},
        {Tag.营养不良,Rarerity.B},
        {Tag.糖尿病,Rarerity.B},
        {Tag.夜不能寐,Rarerity.B},
        {Tag.干饭人,Rarerity.B},
        {Tag.双目失明,Rarerity.B},
        {Tag.独臂,Rarerity.B},
        {Tag.痴呆,Rarerity.B},
        {Tag.身怀六甲,Rarerity.B},
        {Tag.小儿麻痹,Rarerity.B},
        {Tag.目不识丁,Rarerity.B},
        {Tag.得寸进尺,Rarerity.B},
        {Tag.无能狂怒,Rarerity.B},
        {Tag.头疼,Rarerity.B},
        {Tag.半身不遂,Rarerity.B},
        {Tag.磕巴,Rarerity.B},
        {Tag.惹人嫌,Rarerity.B},
        {Tag.调皮鬼,Rarerity.B},
        {Tag.天生恶感,Rarerity.B},
        {Tag.干呕,Rarerity.B},
        {Tag.身体孱弱,Rarerity.B},
        {Tag.肥胖症,Rarerity.B},
        {Tag.长短腿,Rarerity.B},
        {Tag.义肢,Rarerity.B},
        {Tag.药毒,Rarerity.B},
        {Tag.衣不蔽体,Rarerity.B},
        {Tag.文贞,Rarerity.N},
        {Tag.武勇,Rarerity.N},
        {Tag.有勇无谋,Rarerity.N},
        {Tag.花言巧语,Rarerity.N},
        {Tag.绣花枕头,Rarerity.N},
        {Tag.梧鼠五技,Rarerity.N},
        {Tag.自是三公,Rarerity.N},
        {Tag.敝帚自珍,Rarerity.N},
        {Tag.不孕不育,Rarerity.N},
        {Tag.巨人症,Rarerity.N},
        {Tag.侏儒症,Rarerity.N},
        {Tag.儒生,Rarerity.N},
        {Tag.道士,Rarerity.N},
        {Tag.僧人,Rarerity.N},
        {Tag.讼师,Rarerity.N},
        {Tag.冷血无情,Rarerity.N},
        {Tag.阉人,Rarerity.N},
        {Tag.吸血鬼,Rarerity.N},
        {Tag.狼人,Rarerity.N},
        {Tag.膝盖僵硬,Rarerity.N},
        {Tag.多动症,Rarerity.N},
        {Tag.平平无奇,Rarerity.N},
        {Tag.雕,Rarerity.N},
        {Tag.习武之人,Rarerity.N},
        {Tag.丹童,Rarerity.N},
        {Tag.弓,Rarerity.N},
        {Tag.剑,Rarerity.N},
        {Tag.枪,Rarerity.N},
        {Tag.贪污狼藉,Rarerity.N},
        {Tag.演员,Rarerity.N},
        {Tag.六根不净,Rarerity.N},
        {Tag.刀,Rarerity.N},
        {Tag.戟,Rarerity.N},
        {Tag.医术,Rarerity.N},
        {Tag.马倌,Rarerity.N},
        {Tag.饱腹,Rarerity.N},
        {Tag.无伤大雅,Rarerity.N},
        {Tag.鸠工庀材,Rarerity.N},
        {Tag.体态端正,Rarerity.N},
        {Tag.杂七杂八,Rarerity.N},
        {Tag.毛发旺盛,Rarerity.N},
        {Tag.无用之人,Rarerity.N},
        {Tag.文正,Rarerity.R},
        {Tag.武忠,Rarerity.R},
        {Tag.书痴,Rarerity.R},
        {Tag.五味杂陈,Rarerity.R},
        {Tag.好酒之人,Rarerity.R},
        {Tag.匠人,Rarerity.R},
        {Tag.略有才名,Rarerity.R},
        {Tag.小有谋略,Rarerity.R},
        {Tag.武痴,Rarerity.R},
        {Tag.身形矫健,Rarerity.R},
        {Tag.老罴当道,Rarerity.R},
        {Tag.法外狂徒,Rarerity.R},
        {Tag.蛤蟆功,Rarerity.R},
        {Tag.欢喜佛,Rarerity.R},
        {Tag.恶魔人,Rarerity.R},
        {Tag.通晓天文,Rarerity.R},
        {Tag.冰霜宝剑,Rarerity.R},
        {Tag.飞毛腿,Rarerity.R},
        {Tag.火炮,Rarerity.R},
        {Tag.东洋语,Rarerity.R},
        {Tag.能歌善舞,Rarerity.R},
        {Tag.西洋语,Rarerity.R},
        {Tag.毒师,Rarerity.R},
        {Tag.离经叛道,Rarerity.R},
        {Tag.外乡人,Rarerity.R},
        {Tag.疯子,Rarerity.R},
        {Tag.棋道,Rarerity.R},
        {Tag.心算,Rarerity.R},
        {Tag.经济学,Rarerity.R},
        {Tag.小锤,Rarerity.R},
        {Tag.老戏骨,Rarerity.R},
        {Tag.郎中,Rarerity.R},
        {Tag.驯兽术,Rarerity.R},
        {Tag.御马司,Rarerity.R},
        {Tag.牧民,Rarerity.R},
        {Tag.兼爱,Rarerity.R},
        {Tag.货郎,Rarerity.R},
        {Tag.非攻,Rarerity.R},
        {Tag.箭无虚发,Rarerity.R},
        {Tag.根骨清奇,Rarerity.R},
        {Tag.一点寒芒,Rarerity.R},
        {Tag.买瓜人,Rarerity.R},
        {Tag.武艺精湛,Rarerity.R},
        {Tag.登堂入室,Rarerity.R},
        {Tag.走火入魔,Rarerity.R},
        {Tag.素餐,Rarerity.R},
        {Tag.荤菜,Rarerity.R},
        {Tag.鸿运当头,Rarerity.R},
        {Tag.丝绸,Rarerity.R},
        {Tag.护心,Rarerity.R},
        {Tag.皮甲,Rarerity.R},
        {Tag.铁甲,Rarerity.R},
        {Tag.辟邪安正,Rarerity.R},
        {Tag.珠光宝气,Rarerity.R},
        {Tag.家室美满,Rarerity.R},
        {Tag.醉拳,Rarerity.R},
        {Tag.琴师,Rarerity.R},
        {Tag.故事王,Rarerity.R},
        {Tag.文,Rarerity.SR},
        {Tag.武,Rarerity.SR},
        {Tag.书通二酉,Rarerity.SR},
        {Tag.才华横溢,Rarerity.SR},
        {Tag.工于心计,Rarerity.SR},
        {Tag.力拔山兮,Rarerity.SR},
        {Tag.出没无常,Rarerity.SR},
        {Tag.广厦之荫,Rarerity.SR},
        {Tag.智勇双全,Rarerity.SR},
        {Tag.偃师,Rarerity.SR},
        {Tag.奇门遁甲,Rarerity.SR},
        {Tag.天生神力,Rarerity.SR},
        {Tag.阳明学派,Rarerity.SR},
        {Tag.吸星大法,Rarerity.SR},
        {Tag.巫妖领主,Rarerity.SR},
        {Tag.龙骑士,Rarerity.SR},
        {Tag.外交官,Rarerity.SR},
        {Tag.老当益壮,Rarerity.SR},
        {Tag.炼金术师,Rarerity.SR},
        {Tag.近战精通,Rarerity.SR},
        {Tag.古神转世,Rarerity.SR},
        {Tag.理财大师,Rarerity.SR},
        {Tag.纵横家,Rarerity.SR},
        {Tag.大锤,Rarerity.SR},
        {Tag.戏精,Rarerity.SR},
        {Tag.黄帝内经,Rarerity.SR},
        {Tag.本草纲目,Rarerity.SR},
        {Tag.御马监,Rarerity.SR},
        {Tag.驯兽大师,Rarerity.SR},
        {Tag.朝奉,Rarerity.SR},
        {Tag.百步穿杨,Rarerity.SR},
        {Tag.刀王,Rarerity.SR},
        {Tag.雷电法王,Rarerity.SR},
        {Tag.皇家血统,Rarerity.SR},
        {Tag.霸王,Rarerity.SR},
        {Tag.气功达人,Rarerity.SR},
        {Tag.诗兴大发,Rarerity.SR},
        {Tag.如醉如狂,Rarerity.SR},
        {Tag.氪金战士,Rarerity.SR},
        {Tag.把素持斋,Rarerity.SR},
        {Tag.盛食厉兵,Rarerity.SR},
        {Tag.固若金汤,Rarerity.SR},
        {Tag.妙手丹心,Rarerity.SR},
        {Tag.侵略如火,Rarerity.SR},
        {Tag.仁人君子,Rarerity.SR},
        {Tag.宝马良驹,Rarerity.SR},
        {Tag.珠圆玉润,Rarerity.SR},
        {Tag.文化沙漠,Rarerity.SR},
        {Tag.武功小成,Rarerity.SR},
        {Tag.仙人之躯,Rarerity.SSR},
        {Tag.虎猛,Rarerity.SR},
        {Tag.独狼,Rarerity.SR},
        {Tag.忠贞之志,Rarerity.SR},
        {Tag.景星庆云,Rarerity.SR},
        {Tag.长袖善舞,Rarerity.SR},
        {Tag.金钱镖,Rarerity.SR},
        {Tag.袖袍,Rarerity.SR},
        {Tag.血滴子,Rarerity.SR},
        {Tag.主教,Rarerity.SR},
        {Tag.黯然销魂掌,Rarerity.SSR},
        {Tag.围棋十段,Rarerity.SSR},
        {Tag.状元,Rarerity.SSR},
        {Tag.诗仙,Rarerity.SSR},
        {Tag.卧龙,Rarerity.SSR},
        {Tag.八斗之才,Rarerity.SSR},
        {Tag.武圣,Rarerity.SSR},
        {Tag.无影,Rarerity.SSR},
        {Tag.磐石,Rarerity.SSR},
        {Tag.诸武精通,Rarerity.SSR},
        {Tag.纸上谈兵,Rarerity.SSR},
        {Tag.徒有虚名,Rarerity.SSR},
        {Tag.投机取巧,Rarerity.SSR},
        {Tag.混世魔王,Rarerity.SSR},
        {Tag.心狠手辣,Rarerity.SSR},
        {Tag.墨守成规,Rarerity.SSR},
        {Tag.巧夺天工,Rarerity.SSR},
        {Tag.悬壶济世,Rarerity.SSR},
        {Tag.墨者,Rarerity.SSR},
        {Tag.穿日,Rarerity.SSR},
        {Tag.无声,Rarerity.SSR},
        {Tag.青龙,Rarerity.SSR},
        {Tag.必胜,Rarerity.SSR},
        {Tag.撑天,Rarerity.SSR},
        {Tag.龙之力,Rarerity.SSR},
        {Tag.火力压制,Rarerity.SSR},
        {Tag.醉生梦死,Rarerity.SSR},
        {Tag.金光闪闪,Rarerity.SSR},
        {Tag.光碎,Rarerity.SSR},
        {Tag.龙马精神,Rarerity.SSR},
        {Tag.鹰之力,Rarerity.SSR},
        {Tag.窥得天机,Rarerity.SSR},
        {Tag.百毒不侵,Rarerity.SSR},
        {Tag.嘤嘤狂吠,Rarerity.SSR},
        {Tag.波纹行走,Rarerity.SSR},
        {Tag.象虎之力,Rarerity.SSR},
        {Tag.潜光隐耀,Rarerity.SSR},
        {Tag.深仁厚泽,Rarerity.SSR},
        {Tag.平步青云,Rarerity.SSR},
        {Tag.南无加特林,Rarerity.UR},
        {Tag.弈星下凡,Rarerity.UR},
        {Tag.钜子,Rarerity.UR},
        {Tag.文武双全,Rarerity.UR},
        {Tag.成道,Rarerity.UR},
        {Tag.长生不老,Rarerity.UR},
        {Tag.生死肉骨,Rarerity.UR},
        {Tag.碧血丹心,Rarerity.UR},
   };
    public readonly static Dictionary<Tag, List<Tag>> MergeTagDict = new Dictionary<Tag, List<Tag>>
    {
        {Tag.文正,new List<Tag>(){Tag.文贞,Tag.文贞}},
        {Tag.武忠,new List<Tag>(){Tag.武勇,Tag.武勇}},
        {Tag.文,new List<Tag>(){Tag.文正,Tag.文正}},
        {Tag.武,new List<Tag>(){Tag.武忠,Tag.武忠}},
        {Tag.弈星下凡,new List<Tag>(){Tag.围棋十段,Tag.纵横家}},
        {Tag.黯然销魂掌,new List<Tag>(){Tag.独臂,Tag.雕,Tag.平平无奇}},
        {Tag.八斗之才,new List<Tag>(){Tag.书通二酉,Tag.才华横溢,Tag.工于心计} },
        {Tag.诸武精通,new List<Tag>(){Tag.刀,Tag.枪,Tag.剑,Tag.戟,Tag.弓}},
        {Tag.文武双全,new List<Tag>(){Tag.文,Tag.武}},
        {Tag.纸上谈兵,new List<Tag>(){Tag.工于心计,Tag.书痴,Tag.自是三公}},
        {Tag.徒有虚名,new List<Tag>(){Tag.才华横溢,Tag.略有才名,Tag.绣花枕头}},
        { Tag.投机取巧,new List<Tag>(){Tag.工于心计,Tag.小有谋略,Tag.花言巧语}},
        {Tag.混世魔王, new List<Tag>(){Tag.力拔山兮,Tag.武痴,Tag.法外狂徒}},
        {Tag.心狠手辣,new List<Tag>(){Tag.冷血无情,Tag.出没无常}},
        {Tag.墨守成规,new List<Tag>(){Tag.老罴当道,Tag.广厦之荫,Tag.火炮}},
        {Tag.才华横溢,new List<Tag>(){Tag.略有才名,Tag.儒生}},
        {Tag.工于心计,new List<Tag>(){Tag.经济学,Tag.棋道}},
        {Tag.力拔山兮,new List<Tag>(){Tag.武痴,Tag.巨人症}},
        {Tag.广厦之荫,new List<Tag>(){Tag.老罴当道,Tag.火炮}},
        {Tag.智勇双全,new List<Tag>(){Tag.小有谋略,Tag.武痴}},
        {Tag.天生神力,new List<Tag>(){Tag.巨人症,Tag.侏儒症}},
        {Tag.阳明学派,new List<Tag>(){Tag.儒生,Tag.道士,Tag.僧人}},
        {Tag.吸星大法,new List<Tag>(){Tag.蛤蟆功,Tag.年老体衰}},
        {Tag.巫妖领主,new List<Tag>(){Tag.冰霜宝剑,Tag.不孝子}},
        {Tag.龙骑士,new List<Tag>(){Tag.火炮,Tag.飞毛腿}},
        {Tag.外交官,new List<Tag>(){Tag.东洋语,Tag.西洋语}},
        {Tag.老当益壮,new List<Tag>() { Tag.习武之人,Tag.年老体衰} },
        {Tag.炼金术师,new List<Tag>(){Tag.丹童,Tag.毒师,Tag.离经叛道}},
        {Tag.近战精通,new List<Tag>(){Tag.弓,Tag.剑}},
        {Tag.古神转世,new List<Tag>(){Tag.膝盖僵硬,Tag.外乡人,Tag.疯子}},
        {Tag.理财大师,new List<Tag>(){Tag.经济学,Tag.心算}},
        {Tag.戏精,new List<Tag>(){Tag.演员,Tag.精神病}},
        {Tag.御马监,new List<Tag>(){Tag.御马司,Tag.马倌}},
        {Tag.驯兽大师,new List<Tag>(){Tag.牧民,Tag.驯兽术}},
        {Tag.老戏骨,new List<Tag>(){Tag.演员,Tag.年老体衰}},
        {Tag.牧民,new List<Tag>(){Tag.马倌,Tag.驯兽术}},
        {Tag.糖尿病,new List<Tag>(){Tag.营养不良,Tag.嗜甜如命}},
        {Tag.钜子,new List<Tag>(){Tag.墨者,Tag.兼爱}},
        {Tag.巧夺天工,new List<Tag>(){Tag.大锤,Tag.小锤}},
        {Tag.悬壶济世,new List<Tag>(){Tag.医术,Tag.郎中,Tag.本草纲目,Tag.黄帝内经}},
        {Tag.墨者,new List<Tag>(){Tag.偃师,Tag.非攻}}

    };
    public static Dictionary<Rarerity, List<Tag>> ItemgiveTagRareDict = new Dictionary<Rarerity, List<Tag>>()
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.不孝子,
            Tag.醉酒,
            Tag.夜不能寐,
            Tag.身怀六甲
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.蛤蟆功,
            Tag.通晓天文,
            Tag.冰霜宝剑,
            Tag.飞毛腿,
            Tag.火炮,
            Tag.东洋语,
            Tag.能歌善舞,
            Tag.西洋语,
            Tag.毒师,
            Tag.心算,
            Tag.经济学,
            Tag.小锤,
            Tag.驯兽术,
            Tag.御马司,
            Tag.兼爱,
            Tag.非攻

    }},
        {Rarerity.N,new List<Tag>()
       {
            Tag.文贞,
            Tag.武勇,
            Tag.花言巧语,
            Tag.绣花枕头,
            Tag.梧鼠五技,
            Tag.不孕不育,
            Tag.讼师,
            Tag.阉人,
            Tag.雕,
            Tag.丹童,
            Tag.演员,
            Tag.医术,
            Tag.马倌
           }},
        {Rarerity.SR,new List<Tag>()
       {
            Tag.书通二酉,
            Tag.偃师,
            Tag.奇门遁甲,
            Tag.纵横家,
            Tag.大锤,
            Tag.黄帝内经,
            Tag.本草纲目
    }},
        {Rarerity.SSR,new List<Tag>()
       {

    }},
        {Rarerity.UR,new List<Tag>()
       {
}}
    };
    public static Dictionary<ItemName, Tag> ItemToTag = new Dictionary<ItemName, Tag>
    {
        {ItemName.落日神弓,Tag.穿日},
        {ItemName.暴雨梨花针,Tag.无声},
        {ItemName.青龙方戟,Tag.青龙},
        {ItemName.百胜刀,Tag.必胜},
        {ItemName.擎天枪,Tag.撑天},
        {ItemName.龙源剑,Tag.龙之力},
        {ItemName.浪击连弩,Tag.火力压制},
        {ItemName.仙人醉,Tag.醉生梦死},
        {ItemName.黄金甲,Tag.金光闪闪},
        {ItemName.钻石,Tag.光碎 },
        {ItemName.龙马,Tag.龙马精神},
        {ItemName.大汗之鹰,Tag.鹰之力},
        {ItemName.天机造化丹,Tag.窥得天机},
        {ItemName.阴阳玄龙丹,Tag.百毒不侵},
        {ItemName.犬,Tag.嘤嘤狂吠},
        {ItemName.豹子,Tag.波纹行走},
        {ItemName.象虎,Tag.象虎之力},
        {ItemName.山海经,Tag.书通二酉},
        {ItemName.机关残卷,Tag.偃师},
        {ItemName.阴阳八卦盘,Tag.奇门遁甲},
        {ItemName.鬼谷子,Tag.纵横家},
        {ItemName.欧冶子的大锤,Tag.大锤},
        {ItemName.黄帝内经,Tag.黄帝内经},
        {ItemName.本草纲目,Tag.本草纲目},
        {ItemName.穿石烈风弓,Tag.百步穿杨},
        {ItemName.烈火斩云刀,Tag.刀王},
        {ItemName.紫木雷电枪,Tag.雷电法王},
        {ItemName.美梦酒,Tag.诗兴大发},
        {ItemName.三味酒,Tag.如醉如狂},
        {ItemName.皇之剑,Tag.皇家血统},
        {ItemName.天霸方天戟,Tag.霸王},
        {ItemName.混元功,Tag.气功达人},
        {ItemName.高汤白菜,Tag.把素持斋},
        {ItemName.龙井竹荪,Tag.把素持斋},
        {ItemName.八宝野鸭,Tag.盛食厉兵},
        {ItemName.佛手金卷,Tag.盛食厉兵},
        {ItemName.医圣的药箱,Tag.妙手丹心},
        {ItemName.鸽血红,Tag.侵略如火},
        {ItemName.木佐绿,Tag.仁人君子},
        {ItemName.撕风赤兔马,Tag.宝马良驹},
        {ItemName.亮云白龙驹,Tag.宝马良驹},
        {ItemName.堕云虎,Tag.虎猛},
        {ItemName.弯月狼,Tag.独狼},
        {ItemName.朱户衣,Tag.忠贞之志},
        {ItemName.云纹袍,Tag.景星庆云},
        {ItemName.长袖装,Tag.长袖善舞},
        {ItemName.金钱镖,Tag.金钱镖},
        {ItemName.袖炮,Tag.袖袍},
        {ItemName.血滴子,Tag.血滴子},
        {ItemName.灵芝,Tag.妙手丹心},
        {ItemName.锦绣华服,Tag.理财大师},
        {ItemName.木须柿子,Tag.素餐},
        {ItemName.酸菜粉条,Tag.素餐},
        {ItemName.红烧茄子,Tag.素餐},
        {ItemName.清炒菜心,Tag.素餐},
        {ItemName.蒜薹炒肉,Tag.荤菜},
        {ItemName.木须肉,Tag.荤菜},
        {ItemName.沸腾散,Tag.疯子},
        {ItemName.龙虎丹,Tag.武艺精湛},
        {ItemName.洗髓丹,Tag.根骨清奇},
        {ItemName.蛤蟆功秘籍,Tag.蛤蟆功},
        {ItemName.浑天仪,Tag.通晓天文},
        {ItemName.冰霜宝剑,Tag.冰霜宝剑},
        {ItemName.黄金弓,Tag.箭无虚发},
        {ItemName.白银枪,Tag.一点寒芒},
        {ItemName.大砍刀,Tag.买瓜人},
        {ItemName.铁片戟,Tag.武艺精湛},
        {ItemName.九阳真经,Tag.登堂入室},
        {ItemName.九阴真经,Tag.走火入魔},
        {ItemName.金绿宝石,Tag.鸿运当头},
        {ItemName.火炮,Tag.火炮},
        {ItemName.东洋词典,Tag.东洋语},
        {ItemName.西洋词典,Tag.西洋语},
        {ItemName.丝绸,Tag.丝绸},
        {ItemName.护心镜,Tag.护心},
        {ItemName.皮甲,Tag.皮甲},
        {ItemName.铁甲,Tag.铁甲},
        {ItemName.人参,Tag.辟邪安正},
        {ItemName.当归,Tag.辟邪安正},
        {ItemName.沉香,Tag.辟邪安正},
        {ItemName.水翁花,Tag.辟邪安正},
        {ItemName.虎骨,Tag.辟邪安正},
        {ItemName.守宫,Tag.辟邪安正},
        {ItemName.羽衣,Tag.能歌善舞},
        {ItemName.红宝石,Tag.珠光宝气},
        {ItemName.紫水晶,Tag.珠光宝气},
        {ItemName.蛋白石,Tag.珠光宝气},
        {ItemName.祖母绿,Tag.珠光宝气},
        {ItemName.墨子非攻,Tag.非攻},
        {ItemName.墨子兼爱,Tag.兼爱},
        {ItemName.御马官印,Tag.御马司},
        {ItemName.毒经,Tag.毒师},
        {ItemName.唯物论,Tag.离经叛道},
        {ItemName.毒奶瓶,Tag.厄运缠身},
        {ItemName.棋诀,Tag.棋道},
        {ItemName.竹叶青,Tag.好酒之人},
        {ItemName.杜康酒,Tag.好酒之人},
        {ItemName.女儿红,Tag.好酒之人},
        {ItemName.货殖列传,Tag.经济学},
        {ItemName.欧冶子的小锤,Tag.小锤},
        {ItemName.伤寒杂病论,Tag.郎中},
        {ItemName.五香粉,Tag.五味杂陈},
        {ItemName.活泼的快马,Tag.飞毛腿},
        {ItemName.吵闹的鹦鹉,Tag.花言巧语},
        {ItemName.老虎,Tag.驯兽术},
        {ItemName.狼,Tag.驯兽术},
        {ItemName.锤子,Tag.匠人},
        {ItemName.绣花针,Tag.匠人},
        {ItemName.朱砂脂,Tag.珠光宝气},
        {ItemName.刻刀,Tag.匠人},
        {ItemName.大宛马,Tag.飞毛腿},
        {ItemName.蒙古马,Tag.飞毛腿},
        {ItemName.凉州马,Tag.飞毛腿},
        {ItemName.峨眉刺,Tag.身形矫健},
        {ItemName.袖箭,Tag.箭无虚发},
        {ItemName.小刀,Tag.毒师},
        {ItemName.背剑,Tag.武艺精湛},
        {ItemName.文官状,Tag.文贞},
        {ItemName.武官状,Tag.武勇},
        {ItemName.蓑衣,Tag.平平无奇},
        {ItemName.布衣,Tag.平平无奇},
        {ItemName.青酒,Tag.醉酒},
        {ItemName.黄酒,Tag.醉酒},
        {ItemName.羊酒,Tag.醉酒},
        {ItemName.芦酒,Tag.醉酒},
        {ItemName.杏仁酒,Tag.醉酒},
        {ItemName.银条酒,Tag.醉酒},
        {ItemName.零落的宝石,Tag.敝帚自珍},
        {ItemName.缺口的宝石,Tag.敝帚自珍},
        {ItemName.有破损的黄金,Tag.敝帚自珍},
        {ItemName.良姜,Tag.无伤大雅},
        {ItemName.谷芽,Tag.无伤大雅},
        {ItemName.陈皮,Tag.无伤大雅},
        {ItemName.羊乳,Tag.无伤大雅},
        {ItemName.红花,Tag.无伤大雅},
        {ItemName.官宸书,Tag.绣花枕头},
        {ItemName.杂技,Tag.梧鼠五技},
        {ItemName.奉子丹,Tag.身怀六甲},
        {ItemName.麝香,Tag.不孕不育},
        {ItemName.洗冤录,Tag.讼师},
        {ItemName.咖啡,Tag.夜不能寐},
        {ItemName.剪刀,Tag.阉人},
        {ItemName.长脚马,Tag.飞毛腿},
        {ItemName.短尾马,Tag.飞毛腿},
        {ItemName.孝经,Tag.不孝子},
        {ItemName.雕,Tag.雕},
        {ItemName.毛笔,Tag.儒生},
        {ItemName.拂尘,Tag.道士},
        {ItemName.佛珠,Tag.僧人},
        {ItemName.马经,Tag.马倌},
        {ItemName.药材大全,Tag.丹童},
        {ItemName.弓,Tag.弓},
        {ItemName.刀,Tag.刀},
        {ItemName.枪,Tag.枪},
        {ItemName.剑,Tag.剑},
        {ItemName.戟,Tag.戟},
        {ItemName.演员的自我修养,Tag.演员},
        {ItemName.汤头歌诀,Tag.医术},
        {ItemName.飞蝗石,Tag.梧鼠五技},
        {ItemName.树叶,Tag.梧鼠五技},
        {ItemName.何首乌,Tag.毛发旺盛},
        {ItemName.金疮药,Tag.习武之人},
        {ItemName.糖,Tag.嗜甜如命},
        {ItemName.止血膏,Tag.习武之人},
        {ItemName.舒服的椅子 ,Tag.体态端正},
        {ItemName.清炒豆芽,Tag.饱腹},
        {ItemName.拍黄瓜,Tag.饱腹},
        {ItemName.蛋炒饭,Tag.饱腹},
        {ItemName.清蒸白萝卜,Tag.饱腹},
        {ItemName.铁矿,Tag.鸠工庀材},
        {ItemName.铜矿,Tag.鸠工庀材},
        {ItemName.银矿,Tag.鸠工庀材},
        {ItemName.布匹,Tag.鸠工庀材},
        {ItemName.木头,Tag.鸠工庀材},
        {ItemName.皮革,Tag.鸠工庀材},
        {ItemName.铆钉,Tag.鸠工庀材},
        {ItemName.硬木,Tag.鸠工庀材},
        {ItemName.唇纸,Tag.绣花枕头},
        {ItemName.胭脂,Tag.绣花枕头},
        {ItemName.油,Tag.杂七杂八},
        {ItemName.绳子,Tag.杂七杂八},
        {ItemName.酱油,Tag.杂七杂八},
        {ItemName.醋,Tag.杂七杂八},
        {ItemName.盐,Tag.杂七杂八},
        {ItemName.乌桕子,Tag.药毒},
        {ItemName.铁苋,Tag.药毒},
        {ItemName.八角莲,Tag.药毒},
        {ItemName.黄芪,Tag.药毒},
        {ItemName.罗汉果,Tag.药毒},
        {ItemName.血风藤,Tag.药毒},
        {ItemName.黄精,Tag.药毒},
        {ItemName.白花蛇舌草,Tag.药毒},
        {ItemName.水酒,Tag.头疼},
        {ItemName.毒酒,Tag.身体孱弱},
        {ItemName.有缺口的武器,Tag.无能狂怒},
        {ItemName.烂衣服,Tag.衣不蔽体},
        {ItemName.肥马,Tag.肥胖症},
        {ItemName.三七,Tag.药毒},
        {ItemName.轻粉,Tag.药毒},
        {ItemName.核桃粉,Tag.杂七杂八},
        {ItemName.星辰花,Tag.药毒},
        {ItemName.过山龙,Tag.药毒},
        {ItemName.祈天玄衣,Tag.潜光隐耀},
        {ItemName.步辇袍衫,Tag.深仁厚泽},
        {ItemName.青织飞鱼袍,Tag.平步青云},
        {ItemName.玉手镯,Tag.珠圆玉润},
        {ItemName.酒葫芦,Tag.醉拳},
        {ItemName.木佛像,Tag.僧人},
        {ItemName.蚕丝,Tag.鸠工庀材},
        {ItemName.皮毛,Tag.鸠工庀材},
        {ItemName.麻布,Tag.鸠工庀材},
        {ItemName.棍子,Tag.无用之人},

    };
    public static Dictionary<Tag, GameObject> TagPrefabDict = new Dictionary<Tag, GameObject> { };


    private static Dictionary<Rarerity, List<Tag>> FemalePoestTagPool =
        new Dictionary<Rarerity, List<Tag>>
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢,
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.贪污狼藉,
            Tag.六根不净,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
        };
    private static Dictionary<Rarerity, List<Tag>> FemaleCivilianTagPool =
    new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢,
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.习武之人,
            Tag.弓,
            Tag.剑,
            Tag.枪,
            Tag.贪污狼藉,
            Tag.六根不净,
            Tag.刀,
            Tag.戟

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,
            Tag.力拔山兮,
            Tag.出没无常,
            Tag.广厦之荫,
            Tag.智勇双全
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,
            Tag.武圣,
            Tag.无影,
            Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
    };
    private static Dictionary<Rarerity, List<Tag>> MaleScholarTagPool =
       new Dictionary<Rarerity, List<Tag>>
       {
           {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.贪污狼藉,
            Tag.六根不净,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
       };
    private static Dictionary<Rarerity, List<Tag>> MaleBladeuserTagPool =
       new Dictionary<Rarerity, List<Tag>>
   {
        {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.目不识丁,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.习武之人,
            Tag.弓,
            Tag.剑,
            Tag.枪,
            Tag.贪污狼藉,
            Tag.六根不净,
            Tag.刀,
            Tag.戟

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.力拔山兮,
            Tag.出没无常,
            Tag.广厦之荫,
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.武圣,
            Tag.无影,
            Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
       };
    private static Dictionary<Rarerity, List<Tag>> MaleFighterTagPool =
      new Dictionary<Rarerity, List<Tag>>
   {
        {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.目不识丁,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.贪污狼藉,
            Tag.六根不净,

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.力拔山兮,
            Tag.出没无常,
            Tag.广厦之荫,
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.武圣,
            Tag.无影,
            Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
      };
    private static Dictionary<Rarerity, List<Tag>> MusicianTagPool =
       new Dictionary<Rarerity, List<Tag>>
       {
           {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.贪污狼藉,
            Tag.六根不净,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
       };

    private static Dictionary<Rarerity, List<Tag>> MalePoliticianTagPool =
   new Dictionary<Rarerity, List<Tag>>
   {
           {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.文贞,
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.习武之人,
            Tag.弓,
            Tag.剑,
            Tag.枪,
            Tag.贪污狼藉,
            Tag.六根不净,
            Tag.刀,
            Tag.戟

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,
            Tag.力拔山兮,
            Tag.出没无常,
            Tag.广厦之荫,
            Tag.智勇双全
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,
            Tag.武圣,
            Tag.无影,
            Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
   };

    private static Dictionary<Rarerity, List<Tag>> ElderlyTagPool =
        new Dictionary<Rarerity, List<Tag>>
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.目不识丁,
            Tag.年老体衰,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.习武之人,
            Tag.弓,
            Tag.剑,
            Tag.枪,
            Tag.贪污狼藉,
            Tag.六根不净,
            Tag.刀,
            Tag.戟

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,
            Tag.力拔山兮,
            Tag.出没无常,
            Tag.广厦之荫,
            Tag.智勇双全
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,
            Tag.武圣,
            Tag.无影,
            Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
        };
    private static Dictionary<Rarerity, List<Tag>> MonkTagPool =
  new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.目不识丁,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.外乡人,
            Tag.疯子,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.僧人,
            Tag.冷血无情,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.习武之人,
            Tag.枪,
            Tag.贪污狼藉,
            Tag.戟

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.力拔山兮,
            Tag.出没无常,
            Tag.广厦之荫,
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.武圣,
            Tag.无影,
            Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
  };
    private static Dictionary<Rarerity, List<Tag>> GovernorTagPool =
  new Dictionary<Rarerity, List<Tag>>
  {
            {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.文正,
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.文贞,
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.贪污狼藉,
            Tag.六根不净,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,

    }},
        {Rarerity.UR,new List<Tag>()
        {
  }}
};
    private static Dictionary<Rarerity, List<Tag>> ChessplayerTagPool =
        new Dictionary<Rarerity, List<Tag>>
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.目不识丁,
            Tag.年老体衰,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.习武之人,
            Tag.弓,
            Tag.剑,
            Tag.枪,
            Tag.贪污狼藉,
            Tag.六根不净,
            Tag.刀,
            Tag.戟

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,
            Tag.力拔山兮,
            Tag.出没无常,
            Tag.广厦之荫,
            Tag.智勇双全
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,
            Tag.武圣,
            Tag.无影,
            Tag.磐石,
            Tag.纵横家
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
        };
    private static Dictionary<Rarerity, List<Tag>> StorytellerTagPool =
       new Dictionary<Rarerity, List<Tag>>
       {
           {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.贪污狼藉,
            Tag.六根不净,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
       };
    private static Dictionary<Rarerity, List<Tag>> LooterTagPool =
   new Dictionary<Rarerity, List<Tag>>
{
        {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.目不识丁,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.习武之人,
            Tag.弓,
            Tag.剑,
            Tag.枪,
            Tag.贪污狼藉,
            Tag.六根不净,
            Tag.刀,
            Tag.戟

    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.力拔山兮,
            Tag.出没无常,
            Tag.广厦之荫,
    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.武圣,
            Tag.无影,
            Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
   };
    private static Dictionary<Rarerity, List<Tag>> MissionaryTagPool =
   new Dictionary<Rarerity, List<Tag>>
   {
           {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.贪污狼藉,
            Tag.六根不净,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
   };
    private static Dictionary<Rarerity, List<Tag>> MCTagPool =
   new Dictionary<Rarerity, List<Tag>>
   {
           {Rarerity.B,new List<Tag>()
        {
            Tag.厄运缠身,
            Tag.腿脚不便,
            Tag.身世悲苦,
            Tag.精神病,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.干饭人,
            Tag.双目失明,
            Tag.独臂,
            Tag.小儿麻痹,
            Tag.近视,
            Tag.得寸进尺,
            Tag.无能狂怒,
            Tag.头疼,
            Tag.半身不遂,
            Tag.磕巴,
            Tag.惹人嫌,
            Tag.调皮鬼,
            Tag.天生恶感,
            Tag.干呕,
            Tag.身体孱弱,
            Tag.肥胖症,
            Tag.长短腿,
            Tag.义肢
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.离经叛道,
            Tag.外乡人,
            Tag.疯子,
            Tag.棋道,
            Tag.郎中,
            Tag.货郎

    }},
        {Rarerity.N,new List<Tag>()
        {
            Tag.有勇无谋,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.冷血无情,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.平平无奇,
            Tag.贪污狼藉,
            Tag.六根不净,


    }},
        {Rarerity.SR,new List<Tag>()
        {
            Tag.才华横溢,
            Tag.工于心计,

    }},
        {Rarerity.SSR,new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,

    }},
        {Rarerity.UR,new List<Tag>()
        {
}}
   };


    public static Dictionary<CharacterArtCode, Dictionary<Rarerity, List<Tag>>> CharacterFinalTagPool =
        new Dictionary<CharacterArtCode, Dictionary<Rarerity, List<Tag>>>()
        {
            {CharacterArtCode.女诗人, FemalePoestTagPool },
            {CharacterArtCode.男书生, MaleScholarTagPool },
            {CharacterArtCode.男刀客, MaleBladeuserTagPool },
            //{CharacterArtCode.男布衣, MaleCivilianTagPool },
            //{CharacterArtCode.男皮甲, MaleLeatherArmorTagPool },
            //{CharacterArtCode.男富, MaleWealthyTagPool },
            {CharacterArtCode.男官, MalePoliticianTagPool },
            {CharacterArtCode.男武, MaleFighterTagPool },
            //{CharacterArtCode.男老, MaleElderlyTagPool },
            //{CharacterArtCode.女武, FemaleFighterTagPool },
            {CharacterArtCode.女布衣, FemaleCivilianTagPool },
            {CharacterArtCode.老者, ElderlyTagPool },
            {CharacterArtCode.方丈, MonkTagPool },
            {CharacterArtCode.官员, GovernorTagPool },
            {CharacterArtCode.棋圣, ChessplayerTagPool },
            {CharacterArtCode.琴师, MusicianTagPool},
            {CharacterArtCode.说书人, StorytellerTagPool},
            {CharacterArtCode.拾荒者, LooterTagPool},
            {CharacterArtCode.传教士, MissionaryTagPool },
            {CharacterArtCode.李袁陌, MCTagPool }

        };

    public static Dictionary<TagType, List<Tag>> TagTypes =
        new Dictionary<TagType, List<Tag>>()
        {
            {TagType.全才, new List<Tag>()
            {
                Tag.文武双全,
                Tag.成道,
                Tag.长生不老,
                Tag.生死肉骨,
                Tag.碧血丹心,
                Tag.陆地神仙
            } },
            {TagType.持械, new List<Tag>()
            {
                Tag.南无加特林,
                Tag.穿日,
                Tag.无声,
                Tag.青龙,
                Tag.必胜,
                Tag.撑天,
                Tag.龙之力,
                Tag.火力压制,
                Tag.百步穿杨,
                Tag.刀王,
                Tag.雷电法王,
                Tag.皇家血统,
                Tag.霸王,
                Tag.金钱镖,
                Tag.袖袍,
                Tag.血滴子,
                Tag.冰霜宝剑,
                Tag.火炮,
                Tag.箭无虚发,
                Tag.根骨清奇,
                Tag.一点寒芒,
                Tag.弓,
                Tag.剑,
                Tag.枪,
                Tag.刀,
                Tag.戟
            } },
            {TagType.文才, new List<Tag>()
            {
                Tag.弈星下凡,
                Tag.围棋十段,
                Tag.状元,
                Tag.诗仙,
                Tag.卧龙,
                Tag.八斗之才,
                Tag.纸上谈兵,
                Tag.徒有虚名,
                Tag.投机取巧,
                Tag.醉生梦死,
                Tag.窥得天机,
                Tag.书通二酉,
                Tag.才华横溢,
                Tag.工于心计,
                Tag.阳明学派,
                Tag.炼金术师,
                Tag.纵横家,
                Tag.戏精,
                Tag.诗兴大发,
                Tag.把素持斋,
                Tag.仁人君子,
                Tag.主教,
                Tag.书痴,
                Tag.略有才名,
                Tag.小有谋略,
                Tag.欢喜佛,
                Tag.通晓天文,
                Tag.兼爱,
                Tag.非攻,
                Tag.儒生,
                Tag.道士,
                Tag.僧人,
                Tag.深仁厚泽,
            } },
            {TagType.武略, new List<Tag>()
            {
                Tag.钜子,
                Tag.黯然销魂掌,
                Tag.武圣,
                Tag.无影,
                Tag.磐石,
                Tag.诸武精通,
                Tag.混世魔王,
                Tag.心狠手辣,
                Tag.墨守成规,
                Tag.仙人之躯,
                Tag.力拔山兮,
                Tag.出没无常,
                Tag.广厦之荫,
                Tag.智勇双全,
                Tag.偃师,
                Tag.奇门遁甲,
                Tag.天生神力,
                Tag.巫妖领主,
                Tag.龙骑士,
                Tag.老当益壮,
                Tag.近战精通,
                Tag.古神转世,
                Tag.气功达人,
                Tag.如醉如狂,
                Tag.氪金战士,
                Tag.盛食厉兵,
                Tag.固若金汤,
                Tag.侵略如火,
                Tag.忠贞之志,
                Tag.武痴,
                Tag.身形矫健,
                Tag.老罴当道,
                Tag.法外狂徒,
                Tag.蛤蟆功,
                Tag.武艺精湛,
                Tag.登堂入室,
                Tag.走火入魔,
                Tag.习武之人,
                Tag.潜光隐耀,
                Tag.武功小成,
                Tag.文化沙漠,
                Tag.醉拳,

            } },
            {TagType.良工, new List<Tag>()
            {
                Tag.巧夺天工,
                Tag.大锤,
                Tag.小锤,
                Tag.匠人
            } },
            {TagType.妙手, new List<Tag>()
            {
                Tag.悬壶济世,
                Tag.黄帝内经,
                Tag.本草纲目,
                Tag.妙手丹心,
                Tag.郎中,
                Tag.丹童,
                Tag.医术
            } },
            {TagType.商贾, new List<Tag>()
            {
                Tag.理财大师,
                Tag.朝奉,
                Tag.长袖善舞,
                Tag.心算,
                Tag.经济学,
                Tag.货郎
            } },
            {TagType.官职, new List<Tag>()
            {
                Tag.文,
                Tag.武,
                Tag.外交官,
                Tag.御马监,
                Tag.文正,
                Tag.武忠,
                Tag.御马司,
                Tag.文贞,
                Tag.武勇,
                Tag.马倌
            } },
            {TagType.御兽, new List<Tag>()
            {
                Tag.鹰之力,
                Tag.嘤嘤狂吠,
                Tag.波纹行走,
                Tag.象虎之力,
                Tag.驯兽大师,
                Tag.宝马良驹,
                Tag.虎猛,
                Tag.独狼,
                Tag.飞毛腿,
                Tag.驯兽术,
                Tag.雕
            } },
            {TagType.富贵, new List<Tag>()
            {
                Tag.光碎,
                Tag.龙马精神,
                Tag.景星庆云,
                Tag.珠圆玉润,
                Tag.鸿运当头,
                Tag.丝绸,
                Tag.辟邪安正,
                Tag.珠光宝气,

            } },
            {TagType.通常, new List<Tag>()
            {
                Tag.恶魔人,
                Tag.东洋语,
                Tag.能歌善舞,
                Tag.西洋语,
                Tag.毒师,
                Tag.离经叛道,
                Tag.外乡人,
                Tag.疯子,
                Tag.老戏骨,
                Tag.牧民,
                Tag.买瓜人,
                Tag.素餐,
                Tag.荤菜,
                Tag.家室美满,
                Tag.五味杂陈,
                Tag.好酒之人,
                Tag.故事王,
                Tag.琴师,
                Tag.有勇无谋,
                Tag.花言巧语,
                Tag.绣花枕头,
                Tag.梧鼠五技,
                Tag.自是三公,
                Tag.敝帚自珍,
                Tag.不孕不育,
                Tag.巨人症,
                Tag.侏儒症,
                Tag.讼师,
                Tag.冷血无情,
                Tag.阉人,
                Tag.吸血鬼,
                Tag.狼人,
                Tag.平平无奇,
                Tag.贪污狼藉,
                Tag.演员,
                Tag.六根不净,
                Tag.饱腹,
                Tag.无伤大雅,
                Tag.鸠工庀材,
                Tag.体态端正,
                Tag.杂七杂八,
                Tag.毛发旺盛,
                Tag.年老体衰,
                Tag.醉酒,
                Tag.近视,
                Tag.嗜甜如命,
                Tag.营养不良,
                Tag.干饭人,
                Tag.身怀六甲,
                Tag.得寸进尺,
                Tag.无能狂怒,
                Tag.磕巴,
                Tag.惹人嫌,
                Tag.调皮鬼,
                Tag.身体孱弱
            } },
            {TagType.甲胄, new List<Tag>()
            {
                Tag.金光闪闪,
                Tag.护心,
                Tag.皮甲,
                Tag.铁甲
            } },
            {TagType.穷困, new List<Tag>()
            {
                Tag.无用之人,
                Tag.厄运缠身,
                Tag.身世悲苦,
                Tag.目不识丁,
                Tag.天生恶感,
                Tag.衣不蔽体
            } },
            {TagType.沉疴, new List<Tag>()
            {
                Tag.膝盖僵硬,
                Tag.多动症,
                Tag.不孝子,
                Tag.腿脚不便,
                Tag.精神病,
                Tag.糖尿病,
                Tag.夜不能寐,
                Tag.双目失明,
                Tag.独臂,
                Tag.痴呆,
                Tag.小儿麻痹,
                Tag.头疼,
                Tag.半身不遂,
                Tag.干呕,
                Tag.肥胖症,
                Tag.长短腿,
                Tag.义肢,
                Tag.药毒

            } },

        };
}
