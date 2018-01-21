using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistTrainSystem.Models
{
    public class pushupscore
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public int age { get; set; }
        public int num { get; set; }
        public int score { get; set; }
    }
}
