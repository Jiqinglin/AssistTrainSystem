using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    //个人支出和收入
    public class PersonalPay
    {
        //主键
        public string ID{ get; set; }
        //用户
        public string user_id { get; set; }
        //创建日期
        public DateTime create_time { get; set; }
        //早饭摄入
        public double breakfirset_income { get; set; }
        //午饭摄入
        public double lunch_income { get; set; }
        //晚饭摄入
        public double dinner_income { get; set; }
        //总摄入
        public double all_income { get; set; }

        //早饭吃的什么
        public string breakfirst { get; set; }
        //午饭吃的什么
        public string lunch { get; set; }
        //晚饭吃的什么
        public string dinner { get; set; }
        
        //当日支出
        public double pay { get; set; }
    }
}
