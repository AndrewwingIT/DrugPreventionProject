using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrugPrevention.Repositories.NamND.Models;

namespace DrugPrevention.RazorWebApp.NamND.Pages.SurveyQuestionsNamNDs
{
    public class CreateModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        //public CreateModel(DrugPrevention.Repositories.NamND.Models.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context)
        //{
        //    _context = context;
        //}

        //public IActionResult OnGet()
        //{
        //ViewData["SurveyNamNDID"] = new SelectList(_context.SurveysNamNDs, "SurveyNamNDID", "SurveyName");
        //    return Page();
        //}

        [BindProperty]
        public SurveyQuestionsNamND SurveyQuestionsNamND { get; set; } = default!;

        //// For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.SurveyQuestionsNamNDs.Add(SurveyQuestionsNamND);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
