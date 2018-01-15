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
    public class NormalTrainsController : Controller
    {
        private readonly SystemContext _context;

        public NormalTrainsController(SystemContext context)
        {
            _context = context;
        }

        // GET: NormalTrains
        public async Task<IActionResult> Index()
        {
            return View(await _context.NormalTrain.ToListAsync());
        }

        // GET: NormalTrains/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normalTrain = await _context.NormalTrain
                .SingleOrDefaultAsync(m => m.ID == id);
            if (normalTrain == null)
            {
                return NotFound();
            }

            return View(normalTrain);
        }

        // GET: NormalTrains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NormalTrains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,back_train,chesk_train,Leg_train,shoulder_train,arm_train,abdomen_train,stamina_train,explosive_train")] NormalTrain normalTrain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(normalTrain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(normalTrain);
        }

        // GET: NormalTrains/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normalTrain = await _context.NormalTrain.SingleOrDefaultAsync(m => m.ID == id);
            if (normalTrain == null)
            {
                return NotFound();
            }
            return View(normalTrain);
        }

        // POST: NormalTrains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,user_id,create_time,back_train,chesk_train,Leg_train,shoulder_train,arm_train,abdomen_train,stamina_train,explosive_train")] NormalTrain normalTrain)
        {
            if (id != normalTrain.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(normalTrain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NormalTrainExists(normalTrain.ID))
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
            return View(normalTrain);
        }

        // GET: NormalTrains/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normalTrain = await _context.NormalTrain
                .SingleOrDefaultAsync(m => m.ID == id);
            if (normalTrain == null)
            {
                return NotFound();
            }

            return View(normalTrain);
        }

        // POST: NormalTrains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var normalTrain = await _context.NormalTrain.SingleOrDefaultAsync(m => m.ID == id);
            _context.NormalTrain.Remove(normalTrain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NormalTrainExists(string id)
        {
            return _context.NormalTrain.Any(e => e.ID == id);
        }
    }
}
