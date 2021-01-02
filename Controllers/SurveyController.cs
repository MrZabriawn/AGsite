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
    [Route("/Survey")]
    public class SurveyController : Controller
    {
        private readonly SurveyDataContext _context;

        public SurveyController(SurveyDataContext context)
        {
            _context = context;
        }

        [Route("")]
        [Route("Survey")]
        public async Task<IActionResult> Survey()
        {
            ViewBag.Petition = await _context.SurveyAnswers.ToListAsync();
            return View(new SurveyData());
        }

        // POST: Survey/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,YearsHere,Answer")] SurveyData surveyData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveyData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Survey));
            }
            return View(surveyData);
        }

        private bool SurveyDataExists(int id)
        {
            return _context.SurveyAnswers.Any(e => e.Id == id);
        }
    }
}
