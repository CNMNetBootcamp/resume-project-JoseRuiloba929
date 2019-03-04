using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeApp.Data;
using ResumeApp.Models;
using ResumeApp.Models.ResumeViewModels;

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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Submitter.ToListAsync());
        }

        // GET: Submitter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitter = await _context.Submitter
                .SingleOrDefaultAsync(m => m.applicantID == id);
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
        public async Task<IActionResult> Create([Bind("applicantID,firstName,midInitial,lastName,city,state,submitterPhone,submitterEmail")] Submitter submitter)
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

            var submitter = await _context.Submitter.SingleOrDefaultAsync(m => m.applicantID == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("applicantID,firstName,midInitial,lastName,city,state,submitterPhone,submitterEmail")] Submitter submitter)
        {
            if (id != submitter.applicantID)
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
                    if (!SubmitterExists(submitter.applicantID))
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

            var submitter = await _context.Submitter
                .SingleOrDefaultAsync(m => m.applicantID == id);
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
            var submitter = await _context.Submitter.SingleOrDefaultAsync(m => m.applicantID == id);
            _context.Submitter.Remove(submitter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Submitter/Resume/5
        public IActionResult Resume()
        {
            var resumeData = _context.Submitter
                .Include(m => m.ProfSummaries)
                .Include(m => m.SkillSets)
                .Include(m => m.WorkExperiences)
                    .ThenInclude(m => m.jobDescriptions)
                .Include(m => m.Educations)
                .Include(m => m.References)
                .AsNoTracking()
                .FirstOrDefault(Submitters => Submitters.applicantID == 1);

            return View(resumeData);
        }

        private bool SubmitterExists(int id)
        {
            return _context.Submitter.Any(e => e.applicantID == id);
        }
    }
}
