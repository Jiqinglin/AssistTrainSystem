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
    public class FiveoffroadAbilitiesController : Controller
    {
        private readonly SystemContext _context;

        public FiveoffroadAbilitiesController(SystemContext context)
        {
            _context = context;
        }

        // GET: FiveoffroadAbilities
        public async Task<IActionResult> Index()
        {
            var fiveoffroadability = from bb in _context.FiveoffroadAbilities select bb;

            fiveoffroadability = fiveoffroadability.Where(m => m.user_id == User.Identity.Name);
            FiveoffroadList list = new FiveoffroadList();

            list.lastFiveoffroad = await _context.FiveoffroadAbilities.OrderBy(m => m.create_time).LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            list.list = await fiveoffroadability.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            foreach (var x in list.list)
            {
                list.timelist.Add(x.create_time.ToString("MM-dd"));
                list.numlist.Add(x.fiveoffroad_score.ToString());
            }
            return View(list);
           
        }

        public class FiveoffroadList
        {
            //上一次测试结果
            public FiveoffroadAbilities lastFiveoffroad;


            //历史所有测试
            public List<FiveoffroadAbilities> list;

            //系统建议
            public string ans;

            //时间
            public List<string> timelist;
            //距离
            public List<string> numlist;

            public FiveoffroadList()
            {
                this.lastFiveoffroad = new FiveoffroadAbilities();

                this.list = new List<FiveoffroadAbilities>();

                this.timelist = new List<string>();

                this.numlist = new List<string>();
            }
        }


        // GET: FiveoffroadAbilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiveoffroadAbilities = await _context.FiveoffroadAbilities
                .SingleOrDefaultAsync(m => m.ID == id);
            if (fiveoffroadAbilities == null)
            {
                return NotFound();
            }

            return View(fiveoffroadAbilities);
        }

        // GET: FiveoffroadAbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FiveoffroadAbilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,age,fiveoffroad_time")] FiveoffroadAbilities fiveoffroadAbilities,string type)
        {
            fiveoffroadAbilities.create_time = DateTime.Now;

            var s =await  _context.Fiveoffroad_Score.SingleOrDefaultAsync(m => m.age == fiveoffroadAbilities.age && m.num == fiveoffroadAbilities.fiveoffroad_time);

            fiveoffroadAbilities.fiveoffroad_score = s.score*20+40;

            if (type == "yes")
            {

                _context.Add(fiveoffroadAbilities);
                await _context.SaveChangesAsync();
            }

            Result res = new Result();

            res.num = fiveoffroadAbilities.fiveoffroad_score.ToString();

            JsonResult result= Json(res);

            return result;
         
        }

        public class Result
        {
            //系统建议
            public string ans;
            //分数
            public string num;
        }

        // GET: FiveoffroadAbilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiveoffroadAbilities = await _context.FiveoffroadAbilities.SingleOrDefaultAsync(m => m.ID == id);
            if (fiveoffroadAbilities == null)
            {
                return NotFound();
            }
            return View(fiveoffroadAbilities);
        }

        // POST: FiveoffroadAbilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,user_id,create_time,age,fiveoffroad_time,fiveoffroad_score")] FiveoffroadAbilities fiveoffroadAbilities)
        {
            if (id != fiveoffroadAbilities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fiveoffroadAbilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiveoffroadAbilitiesExists(fiveoffroadAbilities.ID))
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
            return View(fiveoffroadAbilities);
        }

        // GET: FiveoffroadAbilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiveoffroadAbilities = await _context.FiveoffroadAbilities
                .SingleOrDefaultAsync(m => m.ID == id);
            if (fiveoffroadAbilities == null)
            {
                return NotFound();
            }

            return View(fiveoffroadAbilities);
        }

        // POST: FiveoffroadAbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fiveoffroadAbilities = await _context.FiveoffroadAbilities.SingleOrDefaultAsync(m => m.ID == id);
            _context.FiveoffroadAbilities.Remove(fiveoffroadAbilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiveoffroadAbilitiesExists(int id)
        {
            return _context.FiveoffroadAbilities.Any(e => e.ID == id);
        }
    }
}
