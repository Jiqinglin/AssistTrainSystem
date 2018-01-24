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
    public class StaminaAbilitiesController : Controller
    {
        private readonly SystemContext _context;

        public StaminaAbilitiesController(SystemContext context)
        {
            _context = context;
        }

        // GET: StaminaAbilities
        public async Task<IActionResult> Index()
        {

            var staminaAbility = from ee in _context.StaminaAbility select ee;
            staminaAbility = staminaAbility.Where(m => m.user_id == User.Identity.Name);

            List<StaminaAbility> e = await staminaAbility.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            var lastStamina = await _context.StaminaAbility.OrderBy(m => m.create_time).LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            StaminaList staminaList = new StaminaList();

            staminaList.laststamina= lastStamina;
            staminaList.list = e;

            foreach (var x in e)
            {
                staminaList.time.Add(x.create_time.ToString("MM-dd"));
                staminaList.Fourtime.Add(x.fourrun_score.ToString());
                staminaList.Threetime.Add(x.threerun_score.ToString());

            }

            return View(staminaList);
            
        }

        public class StaminaList
        {
            //最后一次测试
            public StaminaAbility laststamina;
            //s所有的测试
            public List<StaminaAbility> list;
            //测试时间
            public List<string> time;
            //T型跑时间
            public List<string> Fourtime;
            //持枪跑时间
            public List<string> Threetime;

            public StaminaList()
            {
                laststamina = new StaminaAbility();
                list = new List<StaminaAbility>();
                time = new List<string>();
                Fourtime = new List<string>();
                Threetime = new List<string>();
            }
        }

        // GET: StaminaAbilities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staminaAbility = await _context.StaminaAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (staminaAbility == null)
            {
                return NotFound();
            }

            return View(staminaAbility);
        }

        // GET: StaminaAbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaminaAbilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,age,fourrun_time,fourrun_score,threerun_time,threerun_score,score")] StaminaAbility staminaAbility,string type)
        {
            staminaAbility.create_time = DateTime.Now;
            var s = await _context.Fourrun_Score.SingleOrDefaultAsync(m => m.age == staminaAbility.age && m.num == staminaAbility.fourrun_time);

            staminaAbility.fourrun_score = s.score*20+40;

          
            staminaAbility.threerun_score =(int)(staminaAbility.threerun_time * 2 + 55.4);
            staminaAbility.score = (staminaAbility.fourrun_score + staminaAbility.threerun_score) / 2;
            if (type == "yes")
            {
                _context.Add(staminaAbility);
                await _context.SaveChangesAsync();
            }

            Result res = new Result();

            res.Fournum = staminaAbility.fourrun_score.ToString();
            res.Threenum = staminaAbility.threerun_score.ToString();

            JsonResult result = Json(res);

            return result;
           
        }

        public class Result
        {
            //系统建议
            public string ans;
            //num
            public string Fournum;

            public string Threenum;
        }

        // GET: StaminaAbilities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staminaAbility = await _context.StaminaAbility.SingleOrDefaultAsync(m => m.ID == id);
            if (staminaAbility == null)
            {
                return NotFound();
            }
            return View(staminaAbility);
        }

        // POST: StaminaAbilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,user_id,create_time,age,fourrun_time,fourrun_score,threerun_time,threerun_score,score")] StaminaAbility staminaAbility)
        {
            if (id != staminaAbility.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staminaAbility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaminaAbilityExists(staminaAbility.ID))
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
            return View(staminaAbility);
        }

        // GET: StaminaAbilities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staminaAbility = await _context.StaminaAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (staminaAbility == null)
            {
                return NotFound();
            }

            return View(staminaAbility);
        }

        // POST: StaminaAbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var staminaAbility = await _context.StaminaAbility.SingleOrDefaultAsync(m => m.ID == id);
            _context.StaminaAbility.Remove(staminaAbility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaminaAbilityExists(string id)
        {
            return _context.StaminaAbility.Any(e => e.ID == id);
        }
    }
}
