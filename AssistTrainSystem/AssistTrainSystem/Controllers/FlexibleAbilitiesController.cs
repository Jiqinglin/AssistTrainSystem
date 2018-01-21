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
    public class FlexibleAbilitiesController : Controller
    {
        private readonly SystemContext _context;

        public FlexibleAbilitiesController(SystemContext context)
        {
            _context = context;
        }

        // GET: FlexibleAbilities
        public async Task<IActionResult> Index()
        {
            var flexibleability = from bb in _context.FlexiableAbility select bb;

            flexibleability = flexibleability.Where(m => m.user_id == User.Identity.Name);
            FlexibleList list = new FlexibleList();

            list.lastFlexible = await _context.FlexiableAbility.OrderBy(m => m.create_time).LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            list.list = await flexibleability.OrderBy(m => m.create_time).AsNoTracking().ToListAsync();

            foreach(var x in list.list)
            {
                list.timelist.Add(x.create_time.ToString("MM-dd"));
                list.numlist.Add(x.flexible_score.ToString());
            }
            return View(list);
        }

        public class FlexibleList
        {
            //上一次测试结果
            public FlexibleAbility lastFlexible;
          
           
            //历史所有测试
            public List<FlexibleAbility> list;

            //系统建议
            public string ans;

            //时间
            public List<string> timelist;
            //距离
            public List<string> numlist;

            public FlexibleList()
            {
                this.lastFlexible = new FlexibleAbility();
               
                this.list = new List<FlexibleAbility>();

                this.timelist = new List<string>();

                this.numlist = new List<string>();
            }
        }

        // GET: FlexibleAbilities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flexibleAbility = await _context.FlexiableAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (flexibleAbility == null)
            {
                return NotFound();
            }

            return View(flexibleAbility);
        }

        // GET: FlexibleAbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlexibleAbilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,flexible_num")] FlexibleAbility flexibleAbility)
        {
            flexibleAbility.flexible_score = flexibleAbility.flexible_num * 4 + 60;
         
           
              
            flexibleAbility.create_time = DateTime.Now;
                _context.Add(flexibleAbility);
                await _context.SaveChangesAsync();

            Result res = new Result();

            res.num = flexibleAbility.flexible_score.ToString();

            JsonResult result = Json(res);
            return result;
           
        }

        public class Result
        {
            //系统建议
            public string ans;
            //距离
            public string num;
        }

        // GET: FlexibleAbilities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flexibleAbility = await _context.FlexiableAbility.SingleOrDefaultAsync(m => m.ID == id);
            if (flexibleAbility == null)
            {
                return NotFound();
            }
            return View(flexibleAbility);
        }

        // POST: FlexibleAbilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,user_id,create_time,age,flexible_num")] FlexibleAbility flexibleAbility)
        {
            if (id != flexibleAbility.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flexibleAbility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlexibleAbilityExists(flexibleAbility.ID))
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
            return View(flexibleAbility);
        }

        // GET: FlexibleAbilities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flexibleAbility = await _context.FlexiableAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (flexibleAbility == null)
            {
                return NotFound();
            }

            return View(flexibleAbility);
        }

        // POST: FlexibleAbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var flexibleAbility = await _context.FlexiableAbility.SingleOrDefaultAsync(m => m.ID == id);
            _context.FlexiableAbility.Remove(flexibleAbility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlexibleAbilityExists(string id)
        {
            return _context.FlexiableAbility.Any(e => e.ID == id);
        }
    }
}
