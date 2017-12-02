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
            return View(await _context.EnergyAbility.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,horbara_num,horbara_score,horbarb_num,horbarb_score,doubara_num,doubara_score,doubarb_num,doubarb_score,pushup_num,pushup_score,situp_num,situp_score,score")] EnergyAbility energyAbility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(energyAbility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(energyAbility);
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
