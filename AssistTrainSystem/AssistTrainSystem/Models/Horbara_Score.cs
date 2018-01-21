using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    public class Horbara_Score
    {
        [Key]
        public int ID { get; set; }
        public int age { get; set; }
        public int num { get; set; }
        public int score { get; set; }

    }
}
