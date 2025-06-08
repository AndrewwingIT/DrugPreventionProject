using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrugPrevention.Repositories.NamND.Models;
using DrugPrevention.Services.NamND;

namespace DrugPrevention.RazorWebApp.NamND.Pages.SurveyQuestionsNamNDs
{
    public class CreateModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        private readonly ISurveyQuestionsNamNDService _surveyQuestionsNamNDService;
        public readonly SurveysNamNDService _surveysNamNDService;
        public CreateModel(ISurveyQuestionsNamNDService surveyQuestionsNamNDService, SurveysNamNDService surveysNamNDService)
        {
            _surveyQuestionsNamNDService = surveyQuestionsNamNDService;
            _surveysNamNDService = surveysNamNDService;
        }

        public async Task<IActionResult> OnGet()
        {
            var surveys = await _surveysNamNDService.GetAllAsync();
            ViewData["SurveyNamNDID"] = new SelectList(surveys, "SurveyNamNDID", "SurveyName");
            return Page();
        }

        [BindProperty]
        public SurveyQuestionsNamND SurveyQuestionsNamND { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _surveyQuestionsNamNDService.CreateAsync(SurveyQuestionsNamND);

            return RedirectToPage("./Index");
        }
    }
}
