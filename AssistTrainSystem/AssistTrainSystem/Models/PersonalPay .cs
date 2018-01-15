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
        //当日摄入
        public double income { get; set; }
        //当日支出
        public double pay { get; set; }
    }
}
