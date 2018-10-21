using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TapNap.Areas.Identity.Data;
using TapNap.Models;

namespace TapNap.Controllers
{
    public class ApiController : Controller
    {
        private readonly TapNapContext _context;
        private readonly UserManager<TapNapUser> _userManager;

        public ApiController(TapNapContext context, UserManager<TapNapUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<JsonResult> GetBeds()
        {
            var data = await _context.Beds
                .Select(b => new
                {
                    id = b.BedID,
                    center = new {lat = b.Latitude, lng = b.Longitude}
                })
                .ToListAsync();
            return Json(data);
        }

        public async Task<IActionResult> GetDetails(int? id)
        {
            if (id == null)
                return NotFound();
            
            var bed = await _context.Beds
                .Include(b => b.User)
                .Include(b => b.BedRatings)
                .Include(b => b.Pictures)
                .Where(b => b.BedID == id).Select(b => new
                {
                    pictures = b.Pictures.Select(p => p.Src),
                    rating = b.BedRatings.Select(r => r.Rating).Average(), // at least 1 rating needed
                    price = b.PricePerHour,
                    address = b.Address,
                    description = b.Description,
                    phone = b.User.PhoneNumber
                }).FirstOrDefaultAsync();
            if (bed == null)
                return NotFound();

            return Json(bed);
        }

        public async Task<IActionResult> GetReserved()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var reserved = await _context.Renteds
                .Include(r => r.Bed).ThenInclude(b => b.User)
                .Include(r => r.Bed).ThenInclude(b => b.Pictures)
                .Where(r => r.UserID == user.Id)
                .Select(r => new{
                    picture = r.Bed.Pictures.First().Src,
                    address = r.Bed.Address,
                    time = $"{r.StartTime:MMM dd h:mm tt} - {r.EndTime:MMM dd h:mm tt}",
                    phone = r.Bed.User.PhoneNumber
                })
                .ToListAsync();

            return Json(reserved);
        }

        public async Task<IActionResult> GetPosts()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var posts = await _context.Beds
                .Include(b => b.TimePeriods)
                .Include(b => b.Renteds)
                .Include(b => b.BedRatings)
                .Include(b => b.Pictures)
                .Where(b => b.UserID == user.Id)
                .Select(b => new
                {
                    pictures = b.Pictures.Select(p => p.Src),
                    //rating = b.BedRatings.Select(r => r.Rating).Average(), // at least 1 rating needed
                    price = b.PricePerHour,
                    address = b.Address,
                    description = b.Description,
                    times = b.TimePeriods.Select(t => $"{t.StartTime:MMM dd h:mm tt} - {t.EndTime:MMM dd h:mm tt}")
                })
                .ToListAsync();

            return Json(posts);
        }

        public async Task<IActionResult> AddSelf(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var bed = await _context.Beds.FindAsync(id);
            if (bed == null)
                return NotFound();

            if (await _context.Renteds.Where(r => r.BedID == id && r.UserID == user.Id).AnyAsync())
                return Ok();

            var reserve = new Rented {Bed = bed, User = user, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1)};
            _context.Add(reserve);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}