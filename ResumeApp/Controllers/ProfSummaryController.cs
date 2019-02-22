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
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfSummaries.ToListAsync());
        }

        // GET: ProfSummary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profSummary = await _context.ProfSummaries
                .SingleOrDefaultAsync(m => m.profSummaryID == id);
            if (profSummary == null)
            {
                return NotFound();
            }

            return View(profSummary);
        }

        // GET: ProfSummary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfSummary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("profSummaryID,applicantID,ProfSum")] ProfSummary profSummary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profSummary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profSummary);
        }

        // GET: ProfSummary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profSummary = await _context.ProfSummaries.SingleOrDefaultAsync(m => m.profSummaryID == id);
            if (profSummary == null)
            {
                return NotFound();
            }
            return View(profSummary);
        }

        // POST: ProfSummary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("profSummaryID,applicantID,ProfSum")] ProfSummary profSummary)
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
                return RedirectToAction(nameof(Index));
            }
            return View(profSummary);
        }

        // GET: ProfSummary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profSummary = await _context.ProfSummaries
                .SingleOrDefaultAsync(m => m.profSummaryID == id);
            if (profSummary == null)
            {
                return NotFound();
            }

            return View(profSummary);
        }

        // POST: ProfSummary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profSummary = await _context.ProfSummaries.SingleOrDefaultAsync(m => m.profSummaryID == id);
            _context.ProfSummaries.Remove(profSummary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfSummaryExists(int id)
        {
            return _context.ProfSummaries.Any(e => e.profSummaryID == id);
        }
    }
}
