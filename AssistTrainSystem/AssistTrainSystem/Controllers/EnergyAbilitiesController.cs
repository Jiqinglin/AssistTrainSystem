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
    public class EnergyAbilitiesController : Controller
    {
        private readonly SystemContext _context;

        public EnergyAbilitiesController(SystemContext context)
        {
            _context = context;
        }

        // GET: EnergyAbilities
        public async Task<IActionResult> Index()
        {
            var energyAbility = from ee in _context.EnergyAbility select ee;
            energyAbility = energyAbility.Where(m => m.user_id == User.Identity.Name);

            List<EnergyAbility> e = await energyAbility.AsNoTracking().ToListAsync();

            var lastEnergy = await _context.EnergyAbility.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            EnergyList energyList = new EnergyList();

            energyList.lastlist = lastEnergy;
            energyList.list = e;

            foreach(var x in e)
            {
                energyList.timelist.Add(x.create_time.ToString("MM-dd"));
            }

            return View(energyList);
        }

        public class EnergyList
        {
            //最后一次力量测试
            public EnergyAbility lastlist;
            //所有的力量测试
            public List<EnergyAbility> list;
            //所有的力量测试时间
            public List<String> timelist;

            public EnergyList()
            {
                lastlist = new EnergyAbility();
                list = new List<EnergyAbility>();
                timelist = new List<string>();

            }
        }

        // GET: EnergyAbilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyAbility = await _context.EnergyAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (energyAbility == null)
            {
                return NotFound();
            }

            return View(energyAbility);
        }

        // GET: EnergyAbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnergyAbilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,horbara_num,horbarb_num,doubara_num,doubarb_num,pushup_num,situp_num")] EnergyAbility energyAbility,string type)
        {

            energyAbility.create_time = DateTime.Now;
            energyAbility.horbara_score = energyAbility.horbara_num * 20;
            energyAbility.horbarb_score = energyAbility.horbarb_num * 20;
            energyAbility.doubara_score = energyAbility.doubara_num * 20;
            energyAbility.doubarb_score = energyAbility.doubarb_num * 20;
            energyAbility.pushup_score = energyAbility.pushup_num * 20;
            energyAbility.situp_score = energyAbility.situp_num * 20;

            if (type=="yes")
            {
                _context.Add(energyAbility);
                await _context.SaveChangesAsync();
            }

            Result result = new Result();

            result.horbara = energyAbility.horbara_score;
            result.horbarb = energyAbility.horbarb_score;
            result.doubara = energyAbility.doubara_score;
            result.doubarb = energyAbility.doubarb_score;
            result.pushup = energyAbility.pushup_score;
            result.situp = energyAbility.situp_score;
            JsonResult res = Json(result);

            return res;

        }

        public class Result
        {
            //单杠一的分数
            public int horbara;
            //单杠二的分数
            public int horbarb;
            //双杠一的分数
            public int doubara;
            //双杠二的分数
            public int doubarb;
            //俯卧撑
            public int pushup;
            //仰卧起坐
            public int situp;
            //系统建议
            public string ans;
        }

        // GET: EnergyAbilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyAbility = await _context.EnergyAbility.SingleOrDefaultAsync(m => m.ID == id);
            if (energyAbility == null)
            {
                return NotFound();
            }
            return View(energyAbility);
        }

        // POST: EnergyAbilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,user_id,create_time,horbara_num,horbara_score,horbarb_num,horbarb_score,doubara_num,doubara_score,doubarb_num,doubarb_score,pushup_num,pushup_score,situp_num,situp_score,score")] EnergyAbility energyAbility)
        {
            if (id != energyAbility.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(energyAbility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnergyAbilityExists(energyAbility.ID))
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
            return View(energyAbility);
        }

        // GET: EnergyAbilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyAbility = await _context.EnergyAbility
                .SingleOrDefaultAsync(m => m.ID == id);
            if (energyAbility == null)
            {
                return NotFound();
            }

            return View(energyAbility);
        }

        // POST: EnergyAbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var energyAbility = await _context.EnergyAbility.SingleOrDefaultAsync(m => m.ID == id);
            _context.EnergyAbility.Remove(energyAbility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnergyAbilityExists(int id)
        {
            return _context.EnergyAbility.Any(e => e.ID == id);
        }
    }
}
