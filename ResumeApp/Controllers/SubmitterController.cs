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
    public class SubmitterController : Controller
    {
        private readonly JobContext _context;

        public SubmitterController(JobContext context)
        {
            _context = context;
        }

        // GET: Submitter
        public async Task<IActionResult> Index()
        {
            return View(await _context.Submitters.ToListAsync());
        }

        // GET: Submitter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitter = await _context.Submitters
                .SingleOrDefaultAsync(m => m.submitterID == id);
            if (submitter == null)
            {
                return NotFound();
            }

            return View(submitter);
        }

        // GET: Submitter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Submitter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("submitterID,firstName,midInitial,lastName,city,state")] Submitter submitter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(submitter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(submitter);
        }

        // GET: Submitter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitter = await _context.Submitters.SingleOrDefaultAsync(m => m.submitterID == id);
            if (submitter == null)
            {
                return NotFound();
            }
            return View(submitter);
        }

        // POST: Submitter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("submitterID,firstName,midInitial,lastName,city,state")] Submitter submitter)
        {
            if (id != submitter.submitterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submitter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmitterExists(submitter.submitterID))
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
            return View(submitter);
        }

        // GET: Submitter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitter = await _context.Submitters
                .SingleOrDefaultAsync(m => m.submitterID == id);
            if (submitter == null)
            {
                return NotFound();
            }

            return View(submitter);
        }

        // POST: Submitter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submitter = await _context.Submitters.SingleOrDefaultAsync(m => m.submitterID == id);
            _context.Submitters.Remove(submitter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmitterExists(int id)
        {
            return _context.Submitters.Any(e => e.submitterID == id);
        }
    }
}
