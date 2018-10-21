using System;
using System.Collections.Generic;
using System.Diagnostics;
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
//            Client.DefaultRequestHeaders.Accept.Add(
//                new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", Startup.ImgurAPI);
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
                .Include(b => b.Pictures)
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

        public class BedModel
        {
            public string Address { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public List<IFormFile> Files { get; set; }
        }

        // POST: Beds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bed bed)
        {   
            var rand = new Random();
            var files = Directory.GetFiles("wwwroot/imageAssets/beds", "*.jpg");
            var src = files[rand.Next(files.Length)];
            var pic = new Picture() { Bed = bed, Src= src.Substring(8) };
            bed.Pictures = new[] {pic};

            if (ModelState.IsValid)
            {
                _context.Add(bed);
                await _context.SaveChangesAsync();
//                var pictures = new List<Picture>();
//                foreach (var file in bed.Files)
//                {
//                    var newPicture = new Picture() { Bed = newBed };
//                    var stream = file.OpenReadStream();
//                    var form = new MultipartFormDataContent();
//                    var content = new StreamContent(stream);
//                    form.Add(content);
//                    var response = await Client.PostAsJsonAsync("image", form);
//                    var responseContent = await response.Content.ReadAsStringAsync();
//                    var details = JObject.Parse(responseContent);
//                    var temp = details["data"]["link"];
//                    //TODO: might be broken
//                    newPicture.Src = (string)temp;
//                    pictures.Add(newPicture);
//                }
//
//                _context.AddRange(pictures);
//                await _context.SaveChangesAsync();

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
