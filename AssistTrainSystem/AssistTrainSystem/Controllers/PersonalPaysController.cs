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
        public async Task<IActionResult> outcome(string outcome)
        {
            double outcome2 = Convert.ToDouble(outcome);
         
            var pay = await _context.PersonalPay.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            string last = pay.create_time.ToString("MM-dd");

            string time = DateTime.Now.ToString("MM-dd");
            if (time.Equals(last))
            {
                pay.pay = outcome2;
                _context.Update(pay);
                _context.SaveChanges();
            }
            else
            {
                var pay2 = new PersonalPay();
                pay2.create_time = DateTime.Now;
                pay2.user_id = User.Identity.Name;
                pay.pay = outcome2;
                _context.Add(pay2);
                _context.SaveChanges();
                ;
            }

            result res = new result();
            res.ok = "ok";
            var ans = Json(res);

            return ans;
        }

        class result
        {
            public string ok;
        }

        
        [HttpPost]
        public async Task<IActionResult> breakfirst(string  income,string breakfirst)
        {
            double income2 = Convert.ToDouble(income);
            Console.WriteLine(income2);
            var pay = await _context.PersonalPay.OrderBy(m => m.create_time).LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            string last = pay.create_time.ToString("MM-dd");

            string time = DateTime.Now.ToString("MM-dd");
            if(time.Equals(last))
            {
                pay.breakfirset_income = income2;
                pay.breakfirst = breakfirst;
                pay.all_income = pay.breakfirset_income + pay.lunch_income + pay.dinner_income;
                _context.Update(pay);
                _context.SaveChanges();
            }
            else
            {
                var pay2 = new PersonalPay();
                pay2.create_time = DateTime.Now;
                pay2.user_id = User.Identity.Name;
                pay2.breakfirset_income = income2;
                pay2.breakfirst = breakfirst;
                pay2.all_income = pay2.breakfirset_income + pay2.lunch_income + pay2.dinner_income;
                _context.Add(pay2);
                _context.SaveChanges();
;            }

            return RedirectToAction("test5", "Home");



        }

        public async Task<IActionResult> lunch(string income,string lunch)
        {

            double income2 = Convert.ToDouble(income);
            var pay = await _context.PersonalPay.OrderBy(m => m.create_time).LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            string last = pay.create_time.ToString("MM-dd");

            string time = DateTime.Now.ToString("MM-dd");
            if (time.Equals(last))
            {
                pay.lunch_income = income2;
                pay.lunch = lunch;
                pay.all_income = pay.breakfirset_income + pay.lunch_income + pay.dinner_income;
                _context.Update(pay);
                _context.SaveChanges();
            }
            else
            {
                var pay2 = new PersonalPay();
                pay2.create_time = DateTime.Now;
                pay2.user_id = User.Identity.Name;
                pay2.lunch_income = income2;
                pay2.all_income = pay2.breakfirset_income + pay2.lunch_income + pay2.dinner_income;
                pay2.lunch = lunch;
                _context.Add(pay2);
                _context.SaveChanges();
               
            }

            return RedirectToAction("test5", "Home");

        }

        public async Task<IActionResult> dinner(string income,string dinner)
        {
            double income2 = Convert.ToDouble(income);
            var pay = await _context.PersonalPay.OrderBy(m => m.create_time).LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

            string last = pay.create_time.ToString("MM-dd");

            string time = DateTime.Now.ToString("MM-dd");
            if (time.Equals(last))
            {
                pay.dinner_income = income2;
                pay.dinner = dinner;
                pay.all_income = pay.breakfirset_income + pay.lunch_income + pay.dinner_income;
                _context.Update(pay);
                _context.SaveChanges();
            }
            else
            {
                var pay2 = new PersonalPay();
                pay2.create_time = DateTime.Now;
                pay2.user_id = User.Identity.Name;
                pay2.dinner_income = income2;
                pay2.dinner = dinner;
                pay2.all_income = pay2.breakfirset_income + pay2.lunch_income + pay2.dinner_income;

                _context.Add(pay2);
                _context.SaveChanges();
                
            }

            return RedirectToAction("test5", "Home");
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
        public async Task<IActionResult> Create()
        {
            var pay = await _context.PersonalPay.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);
            return View(pay);
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
