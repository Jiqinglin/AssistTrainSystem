using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    public class FlexibleAbility
    {
        //主键
        public string ID { get; set; }
        //用户id
        public string user_id { get; set; }
        //创建时间
        public DateTime create_time { get; set; }
        //用户年龄
        public int age { get; set; }
        //坐位体前屈的距离
        public double flexible_num { get; set; }
        //坐位体前的级别
        public double flexible_score { get; set; }

    }
}
