using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Controllers
{
    public class DataFromReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataFromReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DataFromReception
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataFromReception.ToListAsync());
        }

        // GET: DataFromReception/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataFromReception = await _context.DataFromReception
                .FirstOrDefaultAsync(m => m.DataFromReceptionId == id);
            if (dataFromReception == null)
            {
                return NotFound();
            }

            return View(dataFromReception);
        }

        // GET: DataFromReception/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataFromReception/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataFromReceptionId,Date,NumbersOfAdults,NumbersOfChildren")] DataFromReception dataFromReception)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataFromReception);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataFromReception);
        }

        // GET: DataFromReception/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataFromReception = await _context.DataFromReception.FindAsync(id);
            if (dataFromReception == null)
            {
                return NotFound();
            }
            return View(dataFromReception);
        }

        public async Task<IActionResult> ListAllGuetstsByDate(DateTime? date)
        {
            if (date == null)
            {
                return NotFound();
            }

            var list = await _context.DataFromReception.Where(x => x.Date.Date == date).ToListAsync();

            int total = 0;
            int totalAdults = 0;
            int totalChildren = 0;

            foreach(var item in list)
            {

                total += item.NumbersOfAdults + item.NumbersOfChildren;



                totalAdults += item.NumbersOfAdults;


                totalChildren += item.NumbersOfChildren;
                ViewData["date"] = item.Date.ToString("d");
            }

            ViewData["total"] = total;
            ViewData["totalAdults"] = totalAdults;
            ViewData["totalChildren"] = totalChildren;
            

            return View(list);
        }

        // POST: DataFromReception/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataFromReceptionId,Date,NumbersOfAdults,NumbersOfChildren")] DataFromReception dataFromReception)
        {
            if (id != dataFromReception.DataFromReceptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataFromReception);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataFromReceptionExists(dataFromReception.DataFromReceptionId))
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
            return View(dataFromReception);
        }

        // GET: DataFromReception/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataFromReception = await _context.DataFromReception
                .FirstOrDefaultAsync(m => m.DataFromReceptionId == id);
            if (dataFromReception == null)
            {
                return NotFound();
            }

            return View(dataFromReception);
        }

        // POST: DataFromReception/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataFromReception = await _context.DataFromReception.FindAsync(id);
            _context.DataFromReception.Remove(dataFromReception);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataFromReceptionExists(int id)
        {
            return _context.DataFromReception.Any(e => e.DataFromReceptionId == id);
            
        }

    }
}
