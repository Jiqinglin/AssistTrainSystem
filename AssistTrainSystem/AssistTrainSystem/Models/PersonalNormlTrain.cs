using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    //个人日常训练
    public class PersonalNormlTrain
    {
        //主键
        public string ID { get; set; }
        //用户id
        public string user_id { get; set; }
        //背部训练次数
        public int back_train { get; set; }
        //胸部训练次数
        public int chesk_train { get; set; }
        //腿部部训练次数
        public int Leg_train { get; set; }
        //肩部训练次数
        public int shoulder_train { get; set; }
        //臂部训练次数
        public int arm_train { get; set; }
        //腹部训练次数
        public int abdomen_train { get; set; }
        //耐力训练次数
        public int stamina_train { get; set; }
        //爆发力训练连续训练次数
        public int explosive_train { get; set; }
    }
}
