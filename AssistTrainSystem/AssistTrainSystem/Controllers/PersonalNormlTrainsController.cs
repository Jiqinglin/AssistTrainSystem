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
    public class PersonalNormlTrainsController : Controller
    {
        private readonly SystemContext _context;

        public PersonalNormlTrainsController(SystemContext context)
        {
            _context = context;
        }

        // GET: PersonalNormlTrains
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalNormlTrain.ToListAsync());
        }

        // GET: PersonalNormlTrains/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalNormlTrain = await _context.PersonalNormlTrain
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personalNormlTrain == null)
            {
                return NotFound();
            }

            return View(personalNormlTrain);
        }

        // GET: PersonalNormlTrains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalNormlTrains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,back_train,chesk_train,Leg_train,shoulder_train,arm_train,abdomen_train,stamina_train,explosive_train")] PersonalNormlTrain personalNormlTrain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalNormlTrain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalNormlTrain);
        }

        // GET: PersonalNormlTrains/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalNormlTrain = await _context.PersonalNormlTrain.SingleOrDefaultAsync(m => m.ID == id);
            if (personalNormlTrain == null)
            {
                return NotFound();
            }
            return View(personalNormlTrain);
        }

        // POST: PersonalNormlTrains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,user_id,back_train,chesk_train,Leg_train,shoulder_train,arm_train,abdomen_train,stamina_train,explosive_train")] PersonalNormlTrain personalNormlTrain)
        {
            if (id != personalNormlTrain.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalNormlTrain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalNormlTrainExists(personalNormlTrain.ID))
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
            return View(personalNormlTrain);
        }

        // GET: PersonalNormlTrains/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalNormlTrain = await _context.PersonalNormlTrain
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personalNormlTrain == null)
            {
                return NotFound();
            }

            return View(personalNormlTrain);
        }

        // POST: PersonalNormlTrains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personalNormlTrain = await _context.PersonalNormlTrain.SingleOrDefaultAsync(m => m.ID == id);
            _context.PersonalNormlTrain.Remove(personalNormlTrain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalNormlTrainExists(string id)
        {
            return _context.PersonalNormlTrain.Any(e => e.ID == id);
        }
    }
}
