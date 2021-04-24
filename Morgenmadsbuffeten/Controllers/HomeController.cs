using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Morgenmadsbuffeten.Data;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Authorize("IsReceptionist")]
        public async Task<IActionResult> AddGuestsToBreakfast()
        {
            return View(await _context.DataFromRestaurant.ToListAsync());
        }

        [Authorize("IsWaiter")]
        public IActionResult CheckGuestsIn()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Overview()
        {
            var dataFromRestaurantList = await _context.DataFromRestaurant.ToListAsync();
            var dataFromReceptionList = await _context.DataFromReception.Where(r => r.Date == DateTime.Now.Date).ToListAsync();

            int checkedInAdults = 0;
            int checkedInChildren = 0;
            int notCheckedInAdults = 0;
            int notCheckedInChildren = 0;

            foreach (var item in dataFromRestaurantList)
            {
                checkedInAdults += item.NumbersOfAdults;

                checkedInChildren += item.NumbersOfChildren;
            }

            foreach (var item in dataFromReceptionList)
            {
                notCheckedInAdults += item.NumbersOfAdults;
                notCheckedInChildren += item.NumbersOfChildren;
            }
                
            notCheckedInAdults = notCheckedInAdults - checkedInAdults;
            if (notCheckedInAdults < 0)
            {
                notCheckedInAdults = 0;
            }
            notCheckedInChildren = notCheckedInChildren - checkedInChildren;
            if (notCheckedInChildren < 0)
            {
                notCheckedInChildren = 0;
            }

            ViewData["checkedInAdults"] = checkedInAdults;
            ViewData["checkedInChildren"] = checkedInChildren;

            ViewData["notCheckedInAdults"] = notCheckedInAdults;
            ViewData["notCheckedInChildren"] = notCheckedInChildren;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
