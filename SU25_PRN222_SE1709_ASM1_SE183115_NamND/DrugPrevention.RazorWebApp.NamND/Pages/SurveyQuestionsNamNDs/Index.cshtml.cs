using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.NamND.Models;
using DrugPrevention.Services.NamND;

namespace DrugPrevention.RazorWebApp.NamND.Pages.SurveyQuestionsNamNDs
{
    public class IndexModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        private readonly ISurveyQuestionsNamNDService _surveyQuestionsNamNDService;
        public IndexModel(ISurveyQuestionsNamNDService surveyQuestionsNamNDService)
        {
            _surveyQuestionsNamNDService = surveyQuestionsNamNDService;
        }

        public IList<SurveyQuestionsNamND> SurveyQuestionsNamND { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SurveyQuestionsNamND = await _surveyQuestionsNamNDService.GetAllAsync();
        }
    }
}
