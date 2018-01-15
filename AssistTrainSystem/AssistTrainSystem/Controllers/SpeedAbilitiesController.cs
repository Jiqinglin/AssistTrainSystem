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
    public class SpeedAbilitiesController : Controller
    {
        private readonly SystemContext _context;

        public SpeedAbilitiesController(SystemContext context)
        {
            _context = context;
        }

        // GET: SpeedAbilities
        public async Task<IActionResult> Index()
        {


            var speedAbility = from ee in _context.SpeedAbility select ee;
            speedAbility = speedAbility.Where(m => m.user_id == User.Identity.Name);

            List<SpeedAbility> e = await speedAbility.AsNoTracking().ToListAsync();

            var lastSpeed = await _context.SpeedAbility.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            SpeedList speedList = new SpeedList();

            speedList.lastspeed= lastSpeed;
            speedList.list = e;

            foreach (var x in e)
            {
                speedList.time.Add(x.create_time.ToString("MM-dd"));
                speedList.Truntime.Add(x.Trun_time.ToString());
                speedList.Gruntime.Add(x.Gunrun_time.ToString());

            }

            return View(speedList);

          
        }

        public class SpeedList
        {
            //最后一次测试
            public SpeedAbility lastspeed;
            //s所有的测试
            public List<SpeedAbility> list;
            //测试时间
            public List<string> time;
            //T型跑时间
            public List<string> Truntime;
            //持枪跑时间
            public List<string> Gruntime;

            public SpeedList()
            {
                lastspeed = new SpeedAbility();
                list = new List<SpeedAbility>();
                time = new List<string>();
                Truntime = new List<string>();
                Gruntime = new List<string>();
            }
        }
        // GET: SpeedAbilities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speedAbility = await _context.SpeedAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (speedAbility == null)
            {
                return NotFound();
            }

            return View(speedAbility);
        }

        // GET: SpeedAbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpeedAbilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,Trun_time,Trun_score,Gunrun_time,Gunrun_score,score")] SpeedAbility speedAbility,string type)
        {

            speedAbility.create_time = DateTime.Now;
            speedAbility.Trun_score = (int)speedAbility.Trun_time * 10;
            speedAbility.Gunrun_score = (int)speedAbility.Gunrun_time * 10;

            if (type == "yes")
            {
                _context.Add(speedAbility);
                await _context.SaveChangesAsync();
            }

            Result res = new Result();

            res.Trunnum = speedAbility.Trun_time.ToString();
            res.Gunrunnum = speedAbility.Gunrun_time.ToString();

            JsonResult result = Json(res);

            return result ;
        }

        public class Result
        {
            //系统建议
            public string ans;
            //num
            public string Trunnum;

            public string Gunrunnum;
        }

        // GET: SpeedAbilities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speedAbility = await _context.SpeedAbility.SingleOrDefaultAsync(m => m.ID == id);
            if (speedAbility == null)
            {
                return NotFound();
            }
            return View(speedAbility);
        }

        // POST: SpeedAbilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,user_id,create_time,Trun_time,Trun_score,Gunrun_time,Gunrun_score,score")] SpeedAbility speedAbility)
        {
            if (id != speedAbility.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speedAbility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeedAbilityExists(speedAbility.ID))
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
            return View(speedAbility);
        }

        // GET: SpeedAbilities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speedAbility = await _context.SpeedAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (speedAbility == null)
            {
                return NotFound();
            }

            return View(speedAbility);
        }

        // POST: SpeedAbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var speedAbility = await _context.SpeedAbility.SingleOrDefaultAsync(m => m.ID == id);
            _context.SpeedAbility.Remove(speedAbility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeedAbilityExists(string id)
        {
            return _context.SpeedAbility.Any(e => e.ID == id);
        }
    }
}
