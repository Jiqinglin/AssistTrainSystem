using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    public class ComtrainAbilities
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
        //携枪100米障碍时间
        public double gunhurdle_time { get; set; }
        //分数
        public int gunhurdle_score { get; set; }
        //三公里越野时间
        public double threeoffroad_time { get; set; }
        //分数
        public int threeoffroad_score { get; set; }
        //200米障碍时间
        public double twohurdle_time { get; set; }
        //分数
        public int twohurdle_score { get; set; }
        //300米障碍时间
        public double threehurdle_time { get; set; }
        //300米障碍分数
        public int threehurdle_score { get; set; }
        //总分数
        public int score { get; set; }
    }
}
