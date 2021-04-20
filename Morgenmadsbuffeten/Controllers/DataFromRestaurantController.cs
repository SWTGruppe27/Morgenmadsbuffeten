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
    public class DataFromRestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataFromRestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DataFromRestaurant
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataFromRestaurant.ToListAsync());
        }

        // GET: DataFromRestaurant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataFromRestaurant = await _context.DataFromRestaurant
                .FirstOrDefaultAsync(m => m.DataFromRestaurantId == id);
            if (dataFromRestaurant == null)
            {
                return NotFound();
            }

            return View(dataFromRestaurant);
        }

        // GET: DataFromRestaurant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataFromRestaurant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataFromRestaurantId,RoomNumber,NumbersOfAdults,NumbersOfChildren")] DataFromRestaurant dataFromRestaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataFromRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataFromRestaurant);
        }

        // GET: DataFromRestaurant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataFromRestaurant = await _context.DataFromRestaurant.FindAsync(id);
            if (dataFromRestaurant == null)
            {
                return NotFound();
            }
            return View(dataFromRestaurant);
        }

        // POST: DataFromRestaurant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataFromRestaurantId,RoomNumber,NumbersOfAdults,NumbersOfChildren")] DataFromRestaurant dataFromRestaurant)
        {
            if (id != dataFromRestaurant.DataFromRestaurantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataFromRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataFromRestaurantExists(dataFromRestaurant.DataFromRestaurantId))
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
            return View(dataFromRestaurant);
        }

        // GET: DataFromRestaurant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataFromRestaurant = await _context.DataFromRestaurant
                .FirstOrDefaultAsync(m => m.DataFromRestaurantId == id);
            if (dataFromRestaurant == null)
            {
                return NotFound();
            }

            return View(dataFromRestaurant);
        }

        // POST: DataFromRestaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataFromRestaurant = await _context.DataFromRestaurant.FindAsync(id);
            _context.DataFromRestaurant.Remove(dataFromRestaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataFromRestaurantExists(int id)
        {
            return _context.DataFromRestaurant.Any(e => e.DataFromRestaurantId == id);
        }
    }
}
