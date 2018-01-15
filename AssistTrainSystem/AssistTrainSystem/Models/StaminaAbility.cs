using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    public class StaminaAbility
    {
        //主键
        [key]
        public string ID { get; set; }
        public string user_id { get; set; }
        //测试时间
        public DateTime create_time { get; set; }
        //用户年龄
        public int age { get; set; }
        //400米跑时间
        public double fourrun_time { get; set; }
        //400米跑的级别，，1表示优秀，2表示良好，3表示及格
        public int fourrun_score { get; set; }
        //3000米跑时间
        public double threerun_time { get; set; }
        //3000米跑的级别 ，1表示优秀，2表示良好，3表示及格
        public int threerun_score { get; set; }
        //总分数
        public int score { get; set; }
    }
}
