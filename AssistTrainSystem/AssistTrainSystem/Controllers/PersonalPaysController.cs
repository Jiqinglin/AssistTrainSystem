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
    public class PersonalPaysController : Controller
    {
        private readonly SystemContext _context;

        public PersonalPaysController(SystemContext context)
        {
            _context = context;
        }

        // GET: PersonalPays
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalPay.ToListAsync());
        }

        // GET: PersonalPays/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalPay = await _context.PersonalPay
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personalPay == null)
            {
                return NotFound();
            }

            return View(personalPay);
        }

        // GET: PersonalPays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalPays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,income,pay")] PersonalPay personalPay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalPay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalPay);
        }

        // GET: PersonalPays/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalPay = await _context.PersonalPay.SingleOrDefaultAsync(m => m.ID == id);
            if (personalPay == null)
            {
                return NotFound();
            }
            return View(personalPay);
        }

        // POST: PersonalPays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,user_id,create_time,income,pay")] PersonalPay personalPay)
        {
            if (id != personalPay.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalPay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalPayExists(personalPay.ID))
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
            return View(personalPay);
        }

        // GET: PersonalPays/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalPay = await _context.PersonalPay
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personalPay == null)
            {
                return NotFound();
            }

            return View(personalPay);
        }

        // POST: PersonalPays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personalPay = await _context.PersonalPay.SingleOrDefaultAsync(m => m.ID == id);
            _context.PersonalPay.Remove(personalPay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalPayExists(string id)
        {
            return _context.PersonalPay.Any(e => e.ID == id);
        }
    }
}
