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
    public class SkillSetController : Controller
    {
        private readonly JobContext _context;

        public SkillSetController(JobContext context)
        {
            _context = context;
        }

        // GET: SkillSet
        public async Task<IActionResult> Index(int id)
        {
            ViewData["UsrID"] = id;
            return View(await _context.SkillSets.ToListAsync());
        }

        // GET: SkillSet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillSet = await _context.SkillSets
                .SingleOrDefaultAsync(m => m.skillsetID == id);
            ViewData["UsrID"] = skillSet.applicantID;
            if (skillSet == null)
            {
                return NotFound();
            }

            return View(skillSet);
        }

        // GET: SkillSet/Create
        public IActionResult Create(int id)
        {
            ViewData["UsrID"] = id;
            return View();
        }

        // POST: SkillSet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("skillsetID,applicantID,skillsetType,skillSetRecord")] SkillSet skillSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = skillSet.applicantID });
            }
            return ViewComponent("skillSet", new { id = skillSet.applicantID });
        }

        // GET: SkillSet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillSet = await _context.SkillSets.SingleOrDefaultAsync(m => m.skillsetID == id);
            if (skillSet == null)
            {
                return NotFound();
            }
            @ViewData["UsrID"] = skillSet.applicantID;
            return View(skillSet);
        }

        // POST: SkillSet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("skillsetID,applicantID,skillsetType,skillSetRecord")] SkillSet skillSet)
        {
            ViewData["UsrID"] = skillSet.applicantID;
            if (id != skillSet.skillsetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillSetExists(skillSet.skillsetID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(Index), new { id = skillSet.applicantID });
            }
            return ViewComponent("skillSet", new { id = skillSet.applicantID });
        }

        // GET: SkillSet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillSet = await _context.SkillSets
                .SingleOrDefaultAsync(m => m.skillsetID == id);
            if (skillSet == null)
            {
                return NotFound();
            }
            ViewData["UsrID"] = skillSet.applicantID;
            id = skillSet.skillsetID;
            return View(skillSet);
        }

        // POST: SkillSet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillSet = await _context.SkillSets.SingleOrDefaultAsync(m => m.skillsetID == id);
            _context.SkillSets.Remove(skillSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = skillSet.applicantID });
        }

        private bool SkillSetExists(int id)
        {
            return _context.SkillSets.Any(e => e.skillsetID == id);
        }
    }
}
