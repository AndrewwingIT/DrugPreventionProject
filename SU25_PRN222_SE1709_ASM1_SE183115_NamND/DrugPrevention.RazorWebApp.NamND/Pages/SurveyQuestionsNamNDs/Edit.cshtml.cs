using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.NamND.Models;

namespace DrugPrevention.RazorWebApp.NamND.Pages.SurveyQuestionsNamNDs
{
    public class EditModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        //public EditModel(DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context)
        //{
        //    _context = context;
        //}

        [BindProperty]
        public SurveyQuestionsNamND SurveyQuestionsNamND { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var surveyquestionsnamnd =  await _context.SurveyQuestionsNamNDs.FirstOrDefaultAsync(m => m.QuestionNamNDID == id);
        //    if (surveyquestionsnamnd == null)
        //    {
        //        return NotFound();
        //    }
        //    SurveyQuestionsNamND = surveyquestionsnamnd;
        //   ViewData["SurveyNamNDID"] = new SelectList(_context.SurveysNamNDs, "SurveyNamNDID", "SurveyName");
        //    return Page();
        //}

        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(SurveyQuestionsNamND).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SurveyQuestionsNamNDExists(SurveyQuestionsNamND.QuestionNamNDID))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        //private bool SurveyQuestionsNamNDExists(int id)
        //{
        //    return _context.SurveyQuestionsNamNDs.Any(e => e.QuestionNamNDID == id);
        //}
    }
}
