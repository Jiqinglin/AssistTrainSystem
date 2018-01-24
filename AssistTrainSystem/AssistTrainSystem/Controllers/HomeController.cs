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
        public async Task<IActionResult> test5()
        {


            var last = await _context.PersonalPay.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);
            if(last == null||!last.create_time.ToString("MM-dd").Equals(DateTime.Now.ToString("MM-dd")))
            {

                 var pay = new PersonalPay();
                pay.user_id = User.Identity.Name;
                pay.create_time = DateTime.Now;
                pay.breakfirset_income = 0;
                pay.lunch_income = 0;
                pay.dinner_income = 0;
                pay.all_income = pay.breakfirset_income + pay.lunch_income + pay.dinner_income;
                _context.Add(pay);
                _context.SaveChanges();
                last = pay;
            }
         
            return View(last);
        }
        public IActionResult test4()
        {
            return View();
        }
        public IActionResult breakfirst()
        {
            return View();
        }
        public IActionResult lunch()
        {
            return View();
        }
        public IActionResult dinner()
        {
            return View();
        }

        public IActionResult test7()
        {
            return View();
        }
        public async Task<IActionResult> test8()
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
        public async Task<IActionResult> test9()
        {
            BaseAbility baseAbility = new BaseAbility();
            //从数据库中
            var flexibleability = from bb in _context.FlexiableAbility select bb;

            flexibleability = flexibleability.Where(m => m.user_id == User.Identity.Name);

            baseAbility.flexiblelist = await flexibleability.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            var energyability = from bb in _context.EnergyAbility select bb;
            energyability = energyability.Where(m => m.user_id == User.Identity.Name);
            baseAbility.energylist = await energyability.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            var speedability = from bb in _context.SpeedAbility select bb;
            speedability = speedability.Where(m => m.user_id == User.Identity.Name);
            baseAbility.speedlist = await speedability.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            var staminability = from bb in _context.StaminaAbility select bb;
            staminability = staminability.Where(m => m.user_id == User.Identity.Name);
            baseAbility.staminalist = await staminability.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();
            int len = baseAbility.energylist.Count;
            int j = 0;
            for (int i = len - 1; i >= 0 && j <= 3; i--,j++)
            {
                baseAbility.horbara += baseAbility.energylist[i].horbara_score;
                baseAbility.horbrab += baseAbility.energylist[i].horbarb_score;
                baseAbility.doubara += baseAbility.energylist[i].doubara_score;
                baseAbility.doubrab += baseAbility.energylist[i].doubarb_score;
                baseAbility.pushup += baseAbility.energylist[i].pushup_score;
                baseAbility.situp += baseAbility.energylist[i].situp_score;

            }
            baseAbility.horbara /= j;
            baseAbility.horbrab /= j;
            baseAbility.doubara /= j;
            baseAbility.doubrab /= j;
            baseAbility.pushup /= j;
            baseAbility.situp /= j;

            len = baseAbility.flexiblelist.Count;
            j = 0;
            for (int i = len - 1; i >= 0 && j <= 3; i--,j++)
            {
                baseAbility.flexible += baseAbility.flexiblelist[i].flexible_score;
            }
            baseAbility.flexible /= j;

            len = baseAbility.speedlist.Count;
            j = 0;
            for (int i = len - 1; i >= 0 && j <= 3; i--, j++)
            {
                baseAbility.grun += baseAbility.speedlist[i].Gunrun_score;
                baseAbility.trun += baseAbility.speedlist[i].Trun_score;
            }

            baseAbility.grun /= j;
            baseAbility.trun /= j;

            len = baseAbility.staminalist.Count;
            j = 0;
            for (int i = len - 1; i >= 0 && j <= 3; i--, j++)
            {
                baseAbility.four += baseAbility.staminalist[i].fourrun_score;
                baseAbility.three += baseAbility.staminalist[i].threerun_score;
            }

            baseAbility.four /= j;
            baseAbility.three /= j;


            foreach (var s in baseAbility.energylist)
            {
                baseAbility.timelist.Add(s.create_time.ToString("MM-dd"));

            }
            return View(baseAbility);
        }
        public class BaseAbility
        {
            public List<string> timelist = new List<string>();
            //力量训练
            public List<EnergyAbility> energylist;
            //柔韧训练
            public List<FlexibleAbility> flexiblelist;
            //速度训练
            public List<SpeedAbility> speedlist;
            //耐力训练
            public List<StaminaAbility> staminalist;

            //预测分数
            public int horbara=0;
            public int horbrab=0;
            public int doubara=0;

            public int doubrab=0;
            public int pushup=0;
            public int situp=0;

            public double flexible=0;
            public int trun=0;
            public int grun=0;

            public int four=0;
            public int three=0;
        }
        public async Task<IActionResult> test10()
        {
            TrainAbility trainAbility = new TrainAbility();

            var fourhurdle = from bb in _context.FourhurdleAbilities select bb;
            fourhurdle = fourhurdle.Where(m => m.user_id == User.Identity.Name);
            trainAbility.fourhurdle = await fourhurdle.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            var fiveoffroad = from bb in _context.FiveoffroadAbilities select bb;
            fiveoffroad = fiveoffroad.Where(m => m.user_id == User.Identity.Name);
            trainAbility.fiveoffroad = await fiveoffroad.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            var comtrain = from bb in _context.ComtrainAbilities select bb;
            comtrain = comtrain.Where(m => m.user_id == User.Identity.Name);
            trainAbility.comtrain = await comtrain.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            int len = trainAbility.fourhurdle.Count;
            int j = 0;
            for (int i = len - 1; i >= 0 && j <= 3; i--, j++)
            {
                trainAbility.four += trainAbility.fourhurdle[i].fourhurdle_score;
            }
            trainAbility.four /= j;

            len = trainAbility.fiveoffroad.Count;
            j = 0;
            for (int i = len - 1; i >= 0 && j <= 3; i--, j++)
            {
                trainAbility.five += trainAbility.fiveoffroad[i].fiveoffroad_score;
            }
            trainAbility.five /= j;

            len = trainAbility.comtrain.Count;
            j = 0;
            for (int i = len - 1; i >= 0 && j <= 3; i--, j++)
            {
                trainAbility.gunhurdle += trainAbility.comtrain[i].gunhurdle_score;
                trainAbility.threehurdle += trainAbility.comtrain[i].threehurdle_score;
                trainAbility.threeoffroad += trainAbility.comtrain[i].threehurdle_score;
                trainAbility.twohurdle += trainAbility.comtrain[i].twohurdle_score; 
            }
            trainAbility.gunhurdle /= j;
            trainAbility.threehurdle /= j;
            trainAbility.threeoffroad /= j;
            trainAbility.twohurdle /= j;
            foreach (var x in trainAbility.comtrain)
            {
                trainAbility.timelist.Add(x.create_time.ToString("MM-dd"));
            }

            return View(trainAbility);
        }

        public class TrainAbility
        {
            public List<string> timelist = new List<string>();
            //400米
            public List<FourhurdleAbilities> fourhurdle;
            //五公里
            public List<FiveoffroadAbilities> fiveoffroad;
            //综合应用训练
            public List<ComtrainAbilities> comtrain;
            //预测分数
            public int four;

            public int five;

            public int gunhurdle;

            public int threeoffroad;

            public int twohurdle;

            public int threehurdle;



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
