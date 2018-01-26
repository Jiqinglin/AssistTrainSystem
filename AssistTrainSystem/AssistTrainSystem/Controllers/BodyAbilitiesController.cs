using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssistTrainSystem.Models;

namespace AssistTrainSystem.Controllers
{
    public class BodyAbilitiesController : Controller
    {
        private readonly SystemContext _context;

        public BodyAbilitiesController(SystemContext context)
        {
            _context = context;
        }

        // GET: BodyAbilities
        public async Task<IActionResult> Index()
        {
         
            return View();
        }

        public async Task<IActionResult> Index2()
        {

            var bodyAbility = from bb in _context.BodyAbility select bb;
            bodyAbility = bodyAbility.Where(m => m.user_id == User.Identity.Name);
            List<BodyAbility> b = await bodyAbility.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            var lastAbilit = await _context.BodyAbility.OrderBy(m => m.create_time).LastOrDefaultAsync(m => m.user_id == User.Identity.Name);
            BodyList list = new BodyList();
            list.alllist = b;
            list.lastlist = lastAbilit;

            foreach (var x in b)
            {
                list.time.Add(x.create_time.ToString("MM-dd"));
                list.bfp.Add(x.bfp.ToString());
                list.bmi.Add(x.bmi.ToString());
            }
            return View(list);
        }
        public class BodyList
        {
            //用户的所有测试
            public List<BodyAbility> alllist;
            //用户的最后一次测试
           public  BodyAbility lastlist;
            //用户所有测试的时间
            public List<string> time;
            //用户所有测试的体脂率
            public List<string> bfp;
            public List<string> bmi;
            public BodyList(){
                alllist = new List<BodyAbility>();
                lastlist = new BodyAbility();
                time = new List<string>();
                bfp = new List<string>();
                bmi = new List<string>();
            }
        }
        // GET: BodyAbilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyAbility = await _context.BodyAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bodyAbility == null)
            {
                return NotFound();
            }

            return View(bodyAbility);
        }

        // GET: BodyAbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyAbilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public async Task<IActionResult> Create([Bind("user_id,height,weight,age,waist,")] BodyAbility bodyAbility)
        {
           bodyAbility.create_time = DateTime.Now;
                //计算体脂率的公式
                bodyAbility.bfp = (double)(bodyAbility.waist * 0.74 - (bodyAbility.weight * 0.082 + 44.74)) / bodyAbility.weight;
                bodyAbility.bfp = bodyAbility.bfp * 100;
                //计算BMI的公式
                bodyAbility.bmi = (double) bodyAbility.weight / (bodyAbility.height * bodyAbility.height);
                _context.Add(bodyAbility);
                await _context.SaveChangesAsync();

            result res = new result();

            //系统建议的代码，仿照这个代码，在别的类中，同样的位置，试着自己编写
            res.ans = "";
            if (res.bfp < 15)
                res.ans += "您的体脂率比较低,建议多摄入脂肪;";
            else if (res.bfp >= 15 && res.bfp <= 18)
                res.ans += "您的体脂率正常";
            else
                res.ans += "您的体脂率过高，注意多锻炼";

            if (res.bmi < 18.5)
                res.ans += "您的BMI指数偏低，需要多锻炼身体";
            else if (res.bmi >= 18.5 && res.bmi < 23.9)
                res.ans += "您的BMI指数正常";
            else
                res.ans += "您的BMI指数偏高，需要多锻炼";
            
            res.bfp = bodyAbility.bfp;
            res.bmi = bodyAbility.bmi;
            JsonResult result=Json(res);
           

                return result;
          
        }
        public class result
        {
            //返回这个人的体脂率
            public double bfp;
            //返回这个人的bmi
            public double bmi;
            //返回建议
            public string ans;
        }

        // GET: BodyAbilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyAbility = await _context.BodyAbility.SingleOrDefaultAsync(m => m.ID == id);
            if (bodyAbility == null)
            {
                return NotFound();
            }
            return View(bodyAbility);
        }

        // POST: BodyAbilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("ID,user_id,create_time,height,weight,age,waist,bfp")] BodyAbility bodyAbility)
        {
            if (id != bodyAbility.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyAbility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyAbilityExists(bodyAbility.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bodyAbility);
        }

        // GET: BodyAbilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyAbility = await _context.BodyAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bodyAbility == null)
            {
                return NotFound();
            }

            return View(bodyAbility);
        }

        // POST: BodyAbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodyAbility = await _context.BodyAbility.SingleOrDefaultAsync(m => m.ID == id);
            _context.BodyAbility.Remove(bodyAbility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyAbilityExists(int id)
        {
            return _context.BodyAbility.Any(e => e.ID == id);
        }

     
    }
   
}
