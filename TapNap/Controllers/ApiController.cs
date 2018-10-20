using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TapNap.Models;

namespace TapNap.Controllers
{
    public class ApiController : Controller
    {
        private readonly TapNapContext _context;

        public ApiController(TapNapContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> GetBeds()
        {
            var data = await _context.Beds
                .Select(b => new {id = b.BedID, center = new {lat = b.Latitude, lng = b.Longitude}}).ToListAsync();
            return Json(data);
        }

        public async Task<IActionResult> GetDetails(int? id)
        {
            if (id == null)
                return NotFound();

            // todo
            var bed = await _context.Beds.Where(b => b.BedID == id).Select(b => new { }).FirstOrDefaultAsync();
            if (bed == null)
                return NotFound();

            return Json(bed);
        }
    }
}