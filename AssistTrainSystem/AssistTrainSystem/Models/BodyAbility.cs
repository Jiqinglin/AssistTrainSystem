using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    //基本人员信息录入
    public class BodyAbility
    {
        //主键
        [Key]
        public int ID { get; set; }
        //用户id
        public string user_id { get; set; }
        //测试时间
        public DateTime create_time { get; set; }
        //身高
        public double height { get; set; }
        //体重
        public double weight { get; set; }
        //年龄
        public int age { get; set; }
        //腰围
        public double waist { get; set; }
        //体脂率
        public double bfp { get; set; }
        //身体质量指数
        public double bmi { get; set; }
    }
}
