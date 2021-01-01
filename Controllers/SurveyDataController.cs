using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AGsite.Data;
using AGsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace AGsite.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("/Admin/Survey")]
    public class SurveyDataController : Controller
    {
        private readonly SurveyDataContext _context;

        public SurveyDataController(SurveyDataContext context)
        {
            _context = context;
        }

        // GET: SurveyData
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SurveyAnswers.ToListAsync());
        }

        // GET: SurveyData/Details/5
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyData = await _context.SurveyAnswers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surveyData == null)
            {
                return NotFound();
            }

            return View(surveyData);
        }

        // GET: SurveyData/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SurveyData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,YearsHere,Answer")] SurveyData surveyData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveyData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(surveyData);
        }

        // GET: SurveyData/Edit/5
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyData = await _context.SurveyAnswers.FindAsync(id);
            if (surveyData == null)
            {
                return NotFound();
            }
            return View(surveyData);
        }

        // POST: SurveyData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,YearsHere,Answer")] SurveyData surveyData)
        {
            if (id != surveyData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveyData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyDataExists(surveyData.Id))
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
            return View(surveyData);
        }

        // GET: SurveyData/Delete/5
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyData = await _context.SurveyAnswers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surveyData == null)
            {
                return NotFound();
            }

            return View(surveyData);
        }

        // POST: SurveyData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveyData = await _context.SurveyAnswers.FindAsync(id);
            _context.SurveyAnswers.Remove(surveyData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyDataExists(int id)
        {
            return _context.SurveyAnswers.Any(e => e.Id == id);
        }
    }
}
