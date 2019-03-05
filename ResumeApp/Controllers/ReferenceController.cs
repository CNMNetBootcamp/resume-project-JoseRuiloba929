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

namespace ResumeApp.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly JobContext _context;

        public ReferenceController(JobContext context)
        {
            _context = context;
        }

        // GET: Reference
        [Authorize]
        public async Task<IActionResult> Index(int Id)
        {
            ViewData["UsrID"] = Id;
            return View(await _context.References.ToListAsync());
        }

        // GET: Reference/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .SingleOrDefaultAsync(m => m.referenceID == id);
            if (reference == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = reference.applicantID;
            return View(reference);
        }

        // GET: Reference/Create
        [Authorize]
        public IActionResult Create(int Id)
        {
            ViewData["UsrID"] = Id;
            return View();
        }

        // POST: Reference/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("referenceID,applicantID,referenceName,referencePhone,referenceEmail,firstMet,relationshipType,yrsKnown")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = reference.applicantID });
            }
            return ViewComponent(nameof(Create), new { id = reference.applicantID });
        }

        // GET: Reference/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References.SingleOrDefaultAsync(m => m.referenceID == id);
            if (reference == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = reference.applicantID;
            return View(reference);
        }

        // POST: Reference/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("referenceID,applicantID,referenceName,referencePhone,referenceEmail,firstMet,relationshipType,yrsKnown")] Reference reference)
        {
            if (id != reference.referenceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceExists(reference.referenceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = reference.applicantID });
            }
            return ViewComponent(nameof(Index), new { id = reference.applicantID });
        }

        // GET: Reference/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .SingleOrDefaultAsync(m => m.referenceID == id);
            if (reference == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = reference.applicantID;
            id = reference.referenceID;
            return View(reference);
        }

        // POST: Reference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reference = await _context.References.SingleOrDefaultAsync(m => m.referenceID == id);
            _context.References.Remove(reference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = reference.applicantID });
        }

        private bool ReferenceExists(int id)
        {
            return _context.References.Any(e => e.referenceID == id);
        }
    }
}
