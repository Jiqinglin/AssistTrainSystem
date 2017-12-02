using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    public class EnergyAbility
    {
        public EnergyAbility()
        {
        }
        //主键
        [Key]
        public int ID { get; set; }
        //用户id
        public string user_id { get; set; }
        //测试时间
        public DateTime create_time { get; set; }
        //单杠一
        public int horbara_num { get; set; }
        //单杠一，分数
        public int horbara_score { get; set; }
        //单杠二
        public int horbarb_num { get; set; }
        //单杠二，分数
        public int horbarb_score { get; set; }
        //双杠一
        public int doubara_num { get; set; }
        //双杠一，分数
        public int doubara_score { get; set; }
        //双杠二
        public int doubarb_num { get; set; }
        //双杠二，分数
        public int doubarb_score { get; set; }
        //俯卧撑
        public int pushup_num { get; set; }
        //俯卧撑分数
        public int pushup_score { get; set; }
        //仰卧起坐
        public int situp_num { get; set; }
        //仰卧起坐分数
        public int situp_score { get; set; }
        //总分数
        public int score { get; set; }

    }
}
