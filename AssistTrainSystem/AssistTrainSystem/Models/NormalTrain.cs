using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    //日常训练
    public class NormalTrain
    {
        //主键
        public string ID { get; set; }
        //用户id
        public string user_id { get; set; }
        //创建时间
        public DateTime create_time { get; set; }
        //是否训练项目
        //背部训练
        public int back_train { get; set; }
        //胸部训练
        public int chesk_train { get; set; }
        //腿部部训练
        public int Leg_train { get; set; }
        //肩部训练
        public int shoulder_train { get; set; }
        //臂部训练
        public int arm_train { get; set; }
        //腹部训练
        public int abdomen_train { get; set; }
        //耐力训练
        public int stamina_train { get; set; }
        //爆发力训练
        public int explosive_train { get; set; }


    }
}
