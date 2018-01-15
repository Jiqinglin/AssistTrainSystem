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
    public class FourhurdleAbilitiesController : Controller
    {
        private readonly SystemContext _context;

        public FourhurdleAbilitiesController(SystemContext context)
        {
            _context = context;
        }

        // GET: FourhurdleAbilities
        public async Task<IActionResult> Index()
        {
            var fourhurdleability = from bb in _context.FourhurdleAbilities select bb;

            fourhurdleability = fourhurdleability.Where(m => m.user_id == User.Identity.Name);

            FourhurdleList list = new FourhurdleList();

            list.lastFourhurdle = await _context.FourhurdleAbilities.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            list.list = await fourhurdleability.AsNoTracking().ToListAsync();

            foreach (var x in list.list)
            {
                list.timelist.Add(x.create_time.ToString("MM-dd"));
                list.numlist.Add(x.fourhurdle_score.ToString());
            }
            return View(list);
           
        }

        public class FourhurdleList
        {
            //上一次测试结果
            public FourhurdleAbilities lastFourhurdle;


            //历史所有测试
            public List<FourhurdleAbilities> list;

            //系统建议
            public string ans;

            //时间
            public List<string> timelist;
            //距离
            public List<string> numlist;

            public FourhurdleList()
            {
                this.lastFourhurdle = new FourhurdleAbilities();

                this.list = new List<FourhurdleAbilities>();

                this.timelist = new List<string>();

                this.numlist = new List<string>();
            }
        }

        // GET: FourhurdleAbilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fourhurdleAbilities = await _context.FourhurdleAbilities
                .SingleOrDefaultAsync(m => m.ID == id);
            if (fourhurdleAbilities == null)
            {
                return NotFound();
            }

            return View(fourhurdleAbilities);
        }

        // GET: FourhurdleAbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FourhurdleAbilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,age,fourhurdle_time")] FourhurdleAbilities fourhurdleAbilities,string type)
        {
            fourhurdleAbilities.create_time = DateTime.Now;
            fourhurdleAbilities.fourhurdle_score = (Int32) fourhurdleAbilities.fourhurdle_time * 10;

            if(type=="yes")
            {
                _context.Add(fourhurdleAbilities);
                await _context.SaveChangesAsync();

            }

            Result res = new Result();

            res.num = fourhurdleAbilities.fourhurdle_score.ToString();

            JsonResult result = Json(res);
            return result;

            
            
        }

        public class Result
        {
            //系统的建议
            public string ans;
            //当前测试的分数
            public string num;
        }

        // GET: FourhurdleAbilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fourhurdleAbilities = await _context.FourhurdleAbilities.SingleOrDefaultAsync(m => m.ID == id);
            if (fourhurdleAbilities == null)
            {
                return NotFound();
            }
            return View(fourhurdleAbilities);
        }

        // POST: FourhurdleAbilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,user_id,create_time,age,fourhurdle_time,fourhurdle_score")] FourhurdleAbilities fourhurdleAbilities)
        {
            if (id != fourhurdleAbilities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fourhurdleAbilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FourhurdleAbilitiesExists(fourhurdleAbilities.ID))
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
            return View(fourhurdleAbilities);
        }

        // GET: FourhurdleAbilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fourhurdleAbilities = await _context.FourhurdleAbilities
                .SingleOrDefaultAsync(m => m.ID == id);
            if (fourhurdleAbilities == null)
            {
                return NotFound();
            }

            return View(fourhurdleAbilities);
        }

        // POST: FourhurdleAbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fourhurdleAbilities = await _context.FourhurdleAbilities.SingleOrDefaultAsync(m => m.ID == id);
            _context.FourhurdleAbilities.Remove(fourhurdleAbilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FourhurdleAbilitiesExists(int id)
        {
            return _context.FourhurdleAbilities.Any(e => e.ID == id);
        }
    }
}
