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
    public class DeleteModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        private readonly ISurveyQuestionsNamNDService _surveyQuestionsNamNDService;

        public DeleteModel(ISurveyQuestionsNamNDService surveyQuestionsNamNDService)
        {
            _surveyQuestionsNamNDService = surveyQuestionsNamNDService;
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
            else
            {
                SurveyQuestionsNamND = surveyquestionsnamnd;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyquestionsnamnd = await _surveyQuestionsNamNDService.GetByIdAsync(id.Value);
            if (surveyquestionsnamnd != null)
            {
                /***
                 If not set await before _service..DeleteAsync(id.Value) 
                 */
                var result = await _surveyQuestionsNamNDService.DeleteAsync(id.Value);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
