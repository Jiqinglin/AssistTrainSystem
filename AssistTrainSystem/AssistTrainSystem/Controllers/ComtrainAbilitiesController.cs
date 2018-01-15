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
    public class ComtrainAbilitiesController : Controller
    {
        private readonly SystemContext _context;

        public ComtrainAbilitiesController(SystemContext context)
        {
            _context = context;
        }

        // GET: ComtrainAbilities
        public async Task<IActionResult> Index()
        {
           var  comtrainAbility = from  bb in _context.ComtrainAbilities select bb;

            comtrainAbility = comtrainAbility.Where(m => m.user_id == User.Identity.Name);

            List<ComtrainAbilities> b = await comtrainAbility.AsNoTracking().ToListAsync();

            ComtrainList comtrainList = new ComtrainList();

            comtrainList.lastComtrain = await _context.ComtrainAbilities.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            comtrainList.list = b;

            foreach(var x in b)
            {
                comtrainList.gunhurdlescore.Add(x.gunhurdle_score.ToString());
                comtrainList.twohurdlescore.Add(x.twohurdle_score.ToString());
                comtrainList.threehurdlescore.Add(x.threehurdle_score.ToString());
                comtrainList.threeoffroadscore.Add(x.threeoffroad_score.ToString());
                comtrainList.time.Add(x.create_time.ToString("MM-dd"));

            }

            return View(comtrainList);
        }
        public class ComtrainList
        {
            //上一次测试
            public  ComtrainAbilities lastComtrain;
            //所有测试
            public List<ComtrainAbilities> list;
            //时间
            public List<string> time;
            //分数
            public List<string> gunhurdlescore;
            public List<string> threeoffroadscore;
            public List<string> twohurdlescore;
            public List<string> threehurdlescore;

            public ComtrainList()
            {
                list = new List<ComtrainAbilities>();
                time = new List<string>();
                gunhurdlescore = new List<string>();
                threeoffroadscore = new List<string>();
                twohurdlescore = new List<string>();
                threehurdlescore = new List<string>();
            }
        }

        // GET: ComtrainAbilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comtrainAbilities = await _context.ComtrainAbilities
                .SingleOrDefaultAsync(m => m.ID == id);
            if (comtrainAbilities == null)
            {
                return NotFound();
            }

            return View(comtrainAbilities);
        }

        // GET: ComtrainAbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComtrainAbilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,age,gunhurdle_time,gunhurdle_score,threeoffroad_time,threeoffroad_score,twohurdle_time,twohurdle_score,threehurdle_time,threehurdle_score")] ComtrainAbilities comtrainAbilities,string type)
        {

            comtrainAbilities.create_time = DateTime.Now;
            comtrainAbilities.gunhurdle_score = (int)comtrainAbilities.gunhurdle_time * 10;
            comtrainAbilities.threehurdle_score = (int)comtrainAbilities.threehurdle_time * 10;
            comtrainAbilities.threeoffroad_score = (int)comtrainAbilities.threeoffroad_time * 10;
            comtrainAbilities.twohurdle_score = (int)comtrainAbilities.twohurdle_time * 10;

            if (type == "yes")
            {
                _context.Add(comtrainAbilities);
                await _context.SaveChangesAsync();
            }

            Result res = new Result();

            res.gunhurdlescore = comtrainAbilities.gunhurdle_score.ToString();
            res.threehurdlescore = comtrainAbilities.threehurdle_score.ToString();
            res.twohurdlescore = comtrainAbilities.twohurdle_score.ToString();
            res.threeoffroadscore = comtrainAbilities.threeoffroad_score.ToString();

            JsonResult result = Json(res);

            return result;
        
        }

        public class Result
        {
            //系统建议
            public string ans;
            public string gunhurdlescore;
            public string threeoffroadscore;
            public string twohurdlescore;
            public string threehurdlescore;
        }

        // GET: ComtrainAbilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comtrainAbilities = await _context.ComtrainAbilities.SingleOrDefaultAsync(m => m.ID == id);
            if (comtrainAbilities == null)
            {
                return NotFound();
            }
            return View(comtrainAbilities);
        }

        // POST: ComtrainAbilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,user_id,create_time,age,gunhurdle_time,gunhurdle_score,threeoffroad_time,threeoffroad_score,twohurdle_time,twohurdle_score,threehurdle_time,threehurdle_score")] ComtrainAbilities comtrainAbilities)
        {
            if (id != comtrainAbilities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comtrainAbilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComtrainAbilitiesExists(comtrainAbilities.ID))
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
            return View(comtrainAbilities);
        }

        // GET: ComtrainAbilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comtrainAbilities = await _context.ComtrainAbilities
                .SingleOrDefaultAsync(m => m.ID == id);
            if (comtrainAbilities == null)
            {
                return NotFound();
            }

            return View(comtrainAbilities);
        }

        // POST: ComtrainAbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comtrainAbilities = await _context.ComtrainAbilities.SingleOrDefaultAsync(m => m.ID == id);
            _context.ComtrainAbilities.Remove(comtrainAbilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComtrainAbilitiesExists(int id)
        {
            return _context.ComtrainAbilities.Any(e => e.ID == id);
        }
    }
}
