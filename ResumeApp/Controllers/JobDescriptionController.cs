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
    public class JobDescriptionController : Controller
    {
        private readonly JobContext _context;

        public JobDescriptionController(JobContext context)
        {
            _context = context;
        }

        // GET: JobDescription
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobDescriptions.ToListAsync());
        }

        // GET: JobDescription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDescription = await _context.JobDescriptions
                .SingleOrDefaultAsync(m => m.jobDescriptionId == id);
            if (jobDescription == null)
            {
                return NotFound();
            }

            return View(jobDescription);
        }

        // GET: JobDescription/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("jobDescriptionId,jobExperience")] JobDescription jobDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobDescription);
        }

        // GET: JobDescription/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDescription = await _context.JobDescriptions.SingleOrDefaultAsync(m => m.jobDescriptionId == id);
            if (jobDescription == null)
            {
                return NotFound();
            }
            return View(jobDescription);
        }

        // POST: JobDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("jobDescriptionId,jobExperience")] JobDescription jobDescription)
        {
            if (id != jobDescription.jobDescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobDescriptionExists(jobDescription.jobDescriptionId))
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
            return View(jobDescription);
        }

        // GET: JobDescription/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDescription = await _context.JobDescriptions
                .SingleOrDefaultAsync(m => m.jobDescriptionId == id);
            if (jobDescription == null)
            {
                return NotFound();
            }

            return View(jobDescription);
        }

        // POST: JobDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobDescription = await _context.JobDescriptions.SingleOrDefaultAsync(m => m.jobDescriptionId == id);
            _context.JobDescriptions.Remove(jobDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobDescriptionExists(int id)
        {
            return _context.JobDescriptions.Any(e => e.jobDescriptionId == id);
        }
    }
}
