using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    public class SpeedAbility
    {
        [key]
        public string ID { get; set; }
        //用户id
        public string user_id { get; set; }
        //测试时间
        public DateTime create_time { get; set; }
        //T型跑时间
        public double Trun_time { get; set; }
        //T型跑级别，1表示优秀，2表示良好，3表示及格
        public int Trun_score { get; set; }
        //持枪跑时间
        public double Gunrun_time { get; set; }
        //持枪跑分数，1表示优秀，2表示良好，3表示及格
        public int Gunrun_score { get; set; }
        //总分数
        public int score { get; set; }


    }
}
