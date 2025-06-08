using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.NamND.Models;
using DrugPrevention.Services.NamND;
using Microsoft.AspNetCore.Authorization;

namespace DrugPrevention.RazorWebApp.NamND.Pages.SurveyQuestionsNamNDs
{
    [Authorize (Roles ="1, 2")]
    public class DetailsModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        private readonly ISurveyQuestionsNamNDService _surveyQuestionsNamNDService;

        public DetailsModel(ISurveyQuestionsNamNDService surveyQuestionsNamNDService)
        {
            _surveyQuestionsNamNDService = surveyQuestionsNamNDService;
        }

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
            else
            {
                SurveyQuestionsNamND = surveyquestionsnamnd;
            }
            return Page();
        }
    }
}
