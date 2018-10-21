using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TapNap.Models;

namespace TapNap.Controllers
{
    public class BedsController : Controller
    {
        private readonly TapNapContext _context;
        private readonly HttpClient Client;

        public BedsController(TapNapContext context)
        {
            _context = context;
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://api.imgur.com/3/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("clientId", Startup.ImgurAPI);

        }

        // GET: Beds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beds.ToListAsync());
        }

        // GET: Beds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bed = await _context.Beds
                .FirstOrDefaultAsync(m => m.BedID == id);
            if (bed == null)
            {
                return NotFound();
            }

            return View(bed);
        }

        // GET: Beds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bed bed, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bed);
                await _context.SaveChangesAsync();

                var pictures = files.Select(f => new Picture(){Bed=bed, BedID=bed.BedID}).ToList();
                for (int i = 0; i < pictures.Count; i++)
                {
                    var stream = files[i].OpenReadStream();
                    var response = await Client.PostAsJsonAsync("image", stream);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var details = JObject.Parse(responseContent);
                    var temp = details["data"]["link"];
                    //TODO: might be broken
                    pictures[i].Src = (string) temp;
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(bed);
        }

        // GET: Beds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bed = await _context.Beds.FindAsync(id);
            if (bed == null)
            {
                return NotFound();
            }
            return View(bed);
        }

        // POST: Beds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BedID,Address,Description,PricePerHour")] Bed bed)
        {
            if (id != bed.BedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BedExists(bed.BedID))
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
            return View(bed);
        }

        // GET: Beds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bed = await _context.Beds
                .FirstOrDefaultAsync(m => m.BedID == id);
            if (bed == null)
            {
                return NotFound();
            }

            return View(bed);
        }

        // POST: Beds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bed = await _context.Beds.FindAsync(id);
            _context.Beds.Remove(bed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BedExists(int id)
        {
            return _context.Beds.Any(e => e.BedID == id);
        }
    }
}
