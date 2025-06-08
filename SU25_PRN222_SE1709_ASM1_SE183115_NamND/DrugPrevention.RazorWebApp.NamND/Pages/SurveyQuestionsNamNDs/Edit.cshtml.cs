using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.NamND.Models;
using Microsoft.AspNetCore.Authorization;
using DrugPrevention.Services.NamND;

namespace DrugPrevention.RazorWebApp.NamND.Pages.SurveyQuestionsNamNDs
{
    [Authorize(Roles = "1, 2")]
    public class EditModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        private readonly ISurveyQuestionsNamNDService _surveyQuestionsNamNDService;
        private readonly SurveysNamNDService _surveysNamNDService;

        public EditModel(ISurveyQuestionsNamNDService surveyQuestionsNamNDService, SurveysNamNDService surveysNamNDService)
        {
            _surveyQuestionsNamNDService = surveyQuestionsNamNDService;
            _surveysNamNDService = surveysNamNDService;
        }

        [BindProperty]
        public SurveyQuestionsNamND SurveyQuestionsNamND { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyquestionsnamnd = await _surveyQuestionsNamNDService.GetByIdAsync(id.Value);
            if (surveyquestionsnamnd == null)
            {
                return NotFound();
            }
            SurveyQuestionsNamND = surveyquestionsnamnd;
            
            var surveys = await _surveysNamNDService.GetAllAsync();
            ViewData["SurveyNamNDID"] = new SelectList(surveys, "SurveyNamNDID", "SurveyName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(SurveyQuestionsNamND).State = EntityState.Modified;

            try
            {
                await _surveyQuestionsNamNDService.UpdateAsync(SurveyQuestionsNamND);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyQuestionsNamNDExists(SurveyQuestionsNamND.QuestionNamNDID).Result)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> SurveyQuestionsNamNDExists(int id)
        {
            var surveyQuestions = await _surveyQuestionsNamNDService.GetByIdAsync(id);
            return surveyQuestions != null && surveyQuestions.QuestionNamNDID == id;
        }
    }
}
