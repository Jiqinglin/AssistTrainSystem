using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssistTrainSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AssistTrainSystem.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly SystemContext _context;

        public HomeController(SystemContext context)
        {
            this._context = context;
        }
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index()
        {
            //从数据库提取用户
            User user = await _context.User.SingleOrDefaultAsync(m => m.name == User.Identity.Name);
            //从数据库中提取人员基本信息表,
            var bodyAbility = from bb in _context.BodyAbility select bb;
            bodyAbility = bodyAbility.Where(m => m.user_id == User.Identity.Name);
            List<BodyAbility> b = await bodyAbility.AsNoTracking().ToListAsync();

            UserAbility list = new UserAbility(user, b);





            foreach (var x in b)
            {
                list.listtime.Add(x.create_time.Date.ToString("yyyy-MM-dd"));
                List<string> item1 = new List<string>();
                List<List<string>> temp = new List<List<string>>();
                item1.Add(x.bfp.ToString());
                item1.Add(x.bmi.ToString());
                item1.Add((x.weight * 1000000).ToString());
                item1.Add(x.user_id.ToString());
                item1.Add(x.create_time.Date.ToString("yyyy-MM-dd"));

                temp.Add(item1);



                list.series.Add(temp);

            }


            return View(list);
            
        }

        public IActionResult test1()
        {
            return View();
        }
        public IActionResult test2()
        {
            return View();
        }
        public IActionResult test3()
        {
            return View();
        }
        public IActionResult test4()
        {
            return View();
        }
        public IActionResult test5()
        {
            return View();
        }

        public IActionResult test7()
        {
            return View();
        }
        public IActionResult test8()
        {
            return View();
        }
        public IActionResult test9()
        {
            return View();
        }
        public IActionResult test10()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //人员自测首页，需要传送的model
        public class UserAbility
        {
            //当前用户的信息
            public User user;
            //当前用户的历史人员基本信息
            public List<BodyAbility> bodyAbility;
            //测试时间列表
            public List<string> listtime;
            //测试项目
            public List<string> listitem = new List<string> { "hh" };

            public List<List<List<string>>> series;
            public UserAbility(User user, List<BodyAbility> body)
            {
                this.user = user;
                this.bodyAbility = body;
                listtime = new List<string>();
                series = new List<List<List<string>>>(100);
                var i = 0;
                foreach (var s in series)
                {
                    series[i] = new List<List<string>>(100);
                    var j = 0;
                    foreach (var m in series[i])
                    {
                        series[i][j] = new List<string>(100);
                        j++;
                    }
                    i++;
                }
            }
        }
    }
}
