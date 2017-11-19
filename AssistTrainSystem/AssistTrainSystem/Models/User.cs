using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssistTrainSystem.Models
{
    public class User
    {
        [Key]
        public string ID {get;set;}
        //用户姓名
        public string name { get; set; }
        //用户密码
        public string password { get; set; }
    }
}
