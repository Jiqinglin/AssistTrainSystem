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
                item1.Add((x.weight*1000000).ToString());
                item1.Add(x.user_id.ToString());
                item1.Add(x.create_time.Date.ToString("yyyy-MM-dd"));

                temp.Add(item1);

               

                list.series.Add(temp);
          
            }
          
          
            return View(list);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,height,weight,age,waist,bmi,bfp")] BodyAbility bodyAbility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodyAbility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodyAbility);
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

        //人员自测首页，需要传送的model
        public class UserAbility
        {
            //当前用户的信息
            public User user;
            //当前用户的历史人员基本信息
            public List<BodyAbility>  bodyAbility;
            //测试时间列表
            public List<string> listtime;
            //测试项目
            public List<string> listitem = new List<string>{ "hh" };

            public List<List<List<string>>> series;
            public UserAbility(User user, List<BodyAbility> body)
            {
                this.user = user;
                this.bodyAbility = body;
                listtime = new List<string>();
                series = new List<List<List<string>>>(100);
                var i = 0;
                foreach(var s in series)
                {
                    series[i] = new List<List<string>>(100);
                    var j = 0;
                    foreach(var m in series[i])
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
