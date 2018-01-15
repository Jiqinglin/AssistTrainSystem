using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    //400米障碍
    public class FourhurdleAbilities
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
        //400米障碍时间
        public double fourhurdle_time { get; set; }
        //分数
        public int fourhurdle_score { get; set; }
    }
}
