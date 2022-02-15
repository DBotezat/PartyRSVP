using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyRSVP.Models;
using System.Diagnostics;

namespace PartyRSVP.Controllers
{
    
     

        public class CustomerRespondController : Controller
{
            private readonly MyContext _context;

            public CustomerRespondController(MyContext context)
            {
                _context = context;
            }

            // GET: GuestResponds
            public async Task<IActionResult> Index()
            {
                return View(await _context.CustomerResponds.ToListAsync());
            }

            // GET: GuestResponds/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var guestRespond = await _context.CustomerResponds
                    .FirstOrDefaultAsync(m => m.GuestRespondId == id);
                if (guestRespond == null)
                {
                    return NotFound();
                }

                return View(guestRespond);
            }

            // GET: GuestResponds/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: GuestResponds/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("GuestRespondId,Name,Email,Phone,Attend")] CustomerRespond guestRespond)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(guestRespond);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(guestRespond);
            }

            // GET: GuestResponds/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var guestRespond = await _context.CustomerResponds.FindAsync(id);
                if (guestRespond == null)
                {
                    return NotFound();
                }
                return View(guestRespond);
            }

            // POST: GuestResponds/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerRespond guestRespond)
            {
                _context.Update(guestRespond);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

            // GET: GuestResponds/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var guestRespond = await _context.CustomerResponds
                    .FirstOrDefaultAsync(m => m.GuestRespondId == id);
                if (guestRespond == null)
                {
                    return NotFound();
                }

                return View(guestRespond);
            }

            // POST: GuestResponds/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
        /*      public IActionResult DeleteConfirmed(int? id)
          {
              var guestRespond = _context.CustomerResponds.Find(id);
              _context.CustomerResponds.Remove(guestRespond);
              _context.SaveChanges();
              return RedirectToAction(nameof(Index));
          }*/
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var guestRespond = await _context.CustomerResponds.FindAsync(id);
            _context.CustomerResponds.Remove(guestRespond);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestRespondExists(int id)
            {
                return _context.CustomerResponds.Any(e => e.GuestRespondId == id);
            }
        }
    }
 
