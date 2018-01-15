using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    //五公里越野
    public class FiveoffroadAbilities
    {
        //主键
        [Key]
        public int ID { get; set; }
        //用户id
        public string user_id { get; set; }
        //测试时间
        public DateTime create_time { get; set; }
        //用户年龄
        public int age { get; set; }
        //五公里越野时间
        public double fiveoffroad_time { get; set; }
        //分数
        public int fiveoffroad_score { get; set; }
    }
}
