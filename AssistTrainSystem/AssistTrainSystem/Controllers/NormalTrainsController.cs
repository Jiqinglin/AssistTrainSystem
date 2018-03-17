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

        public async Task<IActionResult> check(int back_train,int chesk_train,int leg_train,int shoulder_train,int stamina_train,int explosive_train,int arm_train,int abdomen_train)
        {
          
            var normaltrain =  await _context.NormalTrain.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);
            if (normaltrain == null)
            {
                normaltrain = new NormalTrain();
                normaltrain.abdomen_train = 0;
                normaltrain.arm_train = 0;
                normaltrain.back_train = 0;
                normaltrain.chesk_train = 0;
                normaltrain.explosive_train = 0;
                normaltrain.Leg_train = 0;
                normaltrain.shoulder_train = 0;
                normaltrain.stamina_train = 0;
                normaltrain.user_id = User.Identity.Name;
                normaltrain.create_time = DateTime.Now;
                _context.Add(normaltrain);
                _context.SaveChanges();
            }
            else
            {
                if (back_train == 0)
                    normaltrain.back_train = 0;
                else
                    normaltrain.back_train++;

                if (chesk_train == 0)
                    normaltrain.chesk_train = 0;
                else
                    normaltrain.chesk_train++;

                if (leg_train == 0)
                    normaltrain.Leg_train = 0;
                else
                    normaltrain.Leg_train++;

                if (shoulder_train == 0)
                    normaltrain.shoulder_train = 0;
                else
                    normaltrain.shoulder_train++;

                if (stamina_train == 0)
                    normaltrain.stamina_train = 0;
                else
                    normaltrain.stamina_train++;

                if (explosive_train == 0)
                    normaltrain.explosive_train = 0;
                else
                    normaltrain.explosive_train++;

                if (arm_train == 0)
                    normaltrain.arm_train = 0;
                else
                    normaltrain.arm_train++;

                if (abdomen_train == 0)
                    normaltrain.abdomen_train = 0;
                else
                    normaltrain.abdomen_train++;

                normaltrain.create_time = DateTime.Now;
                _context.Update(normaltrain);
                await _context.SaveChangesAsync();
            }

            result res = new result();
            res.back_train = normaltrain.back_train;
            res.chesk_train = normaltrain.chesk_train;
            res.explosive_train = normaltrain.explosive_train;
            res.abdomen_train = normaltrain.abdomen_train;
            res.arm_train = normaltrain.arm_train;
            res.leg_train = normaltrain.Leg_train;
            res.shoulder_train = normaltrain.shoulder_train;
            res.stamina_train = normaltrain.stamina_train;
            JsonResult result = Json(res);


            return result;


        }

        // POST: NormalTrains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,create_time,back_train,chesk_train,Leg_train,shoulder_train,arm_train,abdomen_train,stamina_train,explosive_train")] NormalTrain normalTrain)
        {

            var normaltrain = await _context.NormalTrain.LastOrDefaultAsync(m => m.user_id == User.Identity.Name);

           
            if (normalTrain.back_train == 0)
                normaltrain.back_train = 0;
            else
                normaltrain.back_train++;

            if (normalTrain.chesk_train == 0)
                normaltrain.chesk_train = 0;
            else
                normaltrain.chesk_train++;

            if (normalTrain.Leg_train == 0)
                normaltrain.Leg_train = 0;
            else
                normaltrain.Leg_train++;

            if (normalTrain.shoulder_train == 0)
                normaltrain.shoulder_train = 0;
            else
                normaltrain.shoulder_train++;

            if (normalTrain.stamina_train == 0)
                normaltrain.stamina_train = 0;
            else
                normaltrain.stamina_train++;

            if (normalTrain.explosive_train == 0)
                normaltrain.explosive_train = 0;
            else
                normaltrain.explosive_train++;

            normaltrain.create_time = DateTime.Now;
            _context.Update(normaltrain);
            await _context.SaveChangesAsync();

            result res = new result();
            res.back_train = normaltrain.back_train;
            res.chesk_train = normaltrain.chesk_train;
            res.explosive_train = normaltrain.explosive_train;
            res.leg_train = normaltrain.Leg_train;
            res.shoulder_train = normaltrain.shoulder_train;
            res.stamina_train = normaltrain.stamina_train;
            JsonResult result = Json(res);


            return result;     
                   
        }
        public class result
        {
            //背部训练
            public int back_train;

            public int chesk_train;
            public int leg_train;
            public int abdomen_train;
            public int arm_train;
            public int shoulder_train;
            public int stamina_train;
            public int explosive_train;
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
