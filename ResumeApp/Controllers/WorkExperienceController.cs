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
    public class WorkExperienceController : Controller
    {
        private readonly JobContext _context;

        public WorkExperienceController(JobContext context)
        {
            _context = context;
        }

        // GET: WorkExperience
        public async Task<IActionResult> Index(int id)
        {
            var jobContext = _context.WorkExperiences.Include(w => w.Submitter);
            ViewData["UsrID"] = id;
            return View(await jobContext.ToListAsync());
        }

        // GET: WorkExperience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences
                .Include(w => w.Submitter)
                .SingleOrDefaultAsync(m => m.workID == id);
            if (workExperience == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = workExperience.applicantID;
            return View(workExperience);
        }

        // GET: WorkExperience/Create
        public IActionResult Create(int id)
        {
            ViewData["UsrID"] = id;
            return View();
        }

        // POST: WorkExperience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("workID,applicantID,employer,startDate,endDate,city,state,jobTitle,isStillEmployed")] WorkExperience workExperience)
        {
            ViewData["UsrID"] = workExperience.applicantID;
            if (ModelState.IsValid)
            {
                _context.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = workExperience.applicantID });
            }
            return ViewComponent(nameof(Index), new { id = workExperience.applicantID });
        }

        // GET: WorkExperience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences.SingleOrDefaultAsync(m => m.workID == id);
            if (workExperience == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = workExperience.applicantID;
            return View(workExperience);
        }

        // POST: WorkExperience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("workID,applicantID,employer,startDate,endDate,city,state,jobTitle,isStillEmployed")] WorkExperience workExperience)
        {
            if (id != workExperience.workID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExperienceExists(workExperience.workID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = workExperience.applicantID });
            }
            ViewData["UsrID"] = workExperience.applicantID;
            return View(workExperience);
        }

        // GET: WorkExperience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences
                .Include(w => w.Submitter)
                .SingleOrDefaultAsync(m => m.workID == id);
            if (workExperience == null)
            {
                return NotFound();
            }
            id = workExperience.workID;
            ViewData["UsrID"] = workExperience.applicantID;
            return View(workExperience);
        }

        // POST: WorkExperience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperiences.SingleOrDefaultAsync(m => m.workID == id);
            ViewData["UsrID"] = workExperience.applicantID;
            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = workExperience.applicantID });
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperiences.Any(e => e.workID == id);
        }
    }
}
