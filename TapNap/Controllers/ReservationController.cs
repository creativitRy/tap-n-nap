﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TapNap.Areas.Identity.Data;
using TapNap.Models;

namespace TapNap.Controllers
{
    public class ReservationController : Controller
    {
        private readonly TapNapContext _context;
        private readonly UserManager<TapNapUser> _userManager;

        public ReservationController(TapNapContext context, UserManager<TapNapUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public class Reservation
        {
            public int id { get; set; }
            public string picture { get; set; }
            public string address { get; set; }
            public string time { get; set; }
            public string phone { get; set; }
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View(null);
            }

            var reserved = await _context.Renteds
                .Include(r => r.Bed).ThenInclude(b => b.User)
                .Include(r => r.Bed).ThenInclude(b => b.Pictures)
                .Where(r => r.UserID == user.Id)
                .Select(r => new Reservation
                {
                    picture = r.Bed.Pictures.First().Src,
                    address = r.Bed.Address,
                    time = $"{r.StartTime:MMM dd h:mm tt} - {r.EndTime:MMM dd h:mm tt}",
                    phone = r.Bed.User.PhoneNumber,
                    id = r.Bed.BedID
                })
                .ToListAsync();

            return View(reserved);
        }
    }
}
