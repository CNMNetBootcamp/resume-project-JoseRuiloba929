﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeApp.Data;
using ResumeApp.Models;

namespace ResumeApp.Controllers
{
    public class EducationController : Controller
    {
        private readonly JobContext _context;

        public EducationController(JobContext context)
        {
            _context = context;
        }

        // GET: Education
        [Authorize]
        public async Task<IActionResult> Index(int id)
        {
            ViewData["UsrID"] = id;
            return View(await _context.Educations.ToListAsync());
        }

        // GET: Education/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .SingleOrDefaultAsync(m => m.educationID == id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = education.applicantID;
            return View(education);
        }

        // GET: Education/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            ViewData["UsrID"] = id;
            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("educationID,applicantID,schoolName,schoolCity,schoolState,educationlevelId,fieldofStudy,startdate,enddate")] Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                ViewData["UsrID"] = education.applicantID;
                return RedirectToAction(nameof(Index), new { id = education.applicantID });
            }
            return ViewComponent(nameof(Index), new { id = education.applicantID });
        }

        // GET: Education/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.SingleOrDefaultAsync(m => m.educationID == id);
            
            if (education == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = education.applicantID;
            return View(education);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("educationID,applicantID,schoolName,schoolCity,schoolState,educationlevelId,fieldofStudy,startdate,enddate")] Education education)
        {
            if (id != education.educationID)
            {
                return NotFound();
            }
            ViewData["UsrID"] = education.applicantID;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.educationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = education.applicantID });
            }
            return ViewComponent(nameof(Index), new { id = education.applicantID });
        }

        // GET: Education/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .SingleOrDefaultAsync(m => m.educationID == id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = education.applicantID;
            id = education.educationID;
            return View(education);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.SingleOrDefaultAsync(m => m.educationID == id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = education.applicantID });
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.educationID == id);
        }
    }
}
