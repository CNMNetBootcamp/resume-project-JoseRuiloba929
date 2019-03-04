using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeApp.Data;
using ResumeApp.Models;

namespace ResumeApp.Controllers
{
    public class ProfSummaryController : Controller
    {
        private readonly JobContext _context;

        public ProfSummaryController(JobContext context)
        {
            _context = context;
        }

        // GET: ProfSummary
        public async Task<IActionResult> Index(int Id)
        {
            ViewData["UsrID"] = Id;
            return View(await _context.ProfSummary.ToListAsync());
        }

        // GET: ProfSummary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profSummary = await _context.ProfSummary
                .SingleOrDefaultAsync(m => m.profSummaryID == id);
            if (profSummary == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = profSummary.applicantID;
            return View(profSummary);
        }

        // GET: ProfSummary/Create
        public IActionResult Create(int Id)
        {
            ViewData["UsrID"] = Id;
            return View();
        }

        // POST: ProfSummary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("profSummaryID,applicantID,sortOrder,ProfSum")] ProfSummary profSummary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profSummary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = profSummary.applicantID });
            }
            return ViewComponent(nameof(Index), new { id = profSummary.applicantID });
        }

        // GET: ProfSummary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profSummary = await _context.ProfSummary.SingleOrDefaultAsync(m => m.profSummaryID == id);
            if (profSummary == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = profSummary.applicantID;
            return View(profSummary);
        }

        // POST: ProfSummary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("profSummaryID,applicantID,sortOrder,ProfSum")] ProfSummary profSummary)
        {
            if (id != profSummary.profSummaryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profSummary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfSummaryExists(profSummary.profSummaryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = profSummary.applicantID });
            }
            return ViewComponent(nameof(Index), new { id = profSummary.applicantID });
        }

        // GET: ProfSummary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profSummary = await _context.ProfSummary
                .SingleOrDefaultAsync(m => m.profSummaryID == id);
            if (profSummary == null)
            {
                return NotFound();
            }
            id = profSummary.profSummaryID;
            ViewData["UsrID"] = profSummary.applicantID;
            return View(profSummary);
        }

        // POST: ProfSummary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profSummary = await _context.ProfSummary.SingleOrDefaultAsync(m => m.profSummaryID == id);
            ViewData["UsrID"] = profSummary.applicantID;
            _context.ProfSummary.Remove(profSummary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = profSummary.applicantID });
        }

        private bool ProfSummaryExists(int id)
        {
            return _context.ProfSummary.Any(e => e.profSummaryID == id);
        }
    }
}
