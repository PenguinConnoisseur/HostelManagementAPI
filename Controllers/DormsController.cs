using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HostelManagementAPI.Data;
using HostelManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostelManagementAPI.Controllers
{
    [Route("[controller]")]
    public class DormsController : Controller
    {
        private readonly HostelManagementContext _context;

        public DormsController(HostelManagementContext context)
        {
            _context = context;
        }

        // GET: Dorms
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dorms = await _context.Dorms.ToListAsync();
            return View(dorms); // Returns the list view of dorms
        }

        // GET: Dorms/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var dorm = await _context.Dorms.FindAsync(id);
            if (dorm == null)
            {
                return NotFound();
            }

            return View(dorm); // Returns the details view of a specific dorm
        }

        // GET: Dorms/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new dorm
        }

        // POST: Subjects/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dorm dorm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dorm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the dorm list
            }
            return View(dorm);
        }

        // GET: Dorms/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var dorm = await _context.Dorms.FindAsync(id);
            if (dorm == null)
            {
                return NotFound();
            }
            return View(dorm); // Returns the edit view for a specific dorm
        }

        // POST: Dorms/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Dorm dorm)
        {
            if (id != dorm.DormID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dorm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DormExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the dorm list
            }
            return View(dorm);
        }

        // GET: Dorms/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dorm = await _context.Dorms.FindAsync(id);
            if (dorm == null)
            {
                return NotFound();
            }

            return View(dorm); // Returns the delete confirmation view
        }

        // POST: Dorms/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dorm = await _context.Dorms.FindAsync(id);
            if (dorm != null)
            {
                _context.Dorms.Remove(dorm);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the dorm list
        }

        private bool DormExists(int id)
        {
            return _context.Dorms.Any(e => e.DormID == id);
        }
    }
}
