using DrugPrevention.Repositories.NamND.Basic;
using DrugPrevention.Repositories.NamND.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.NamND
{
    public class SurveyQuestionsNamNDRepository : GenericRepository<SurveyQuestionsNamND>
    {
        public SurveyQuestionsNamNDRepository() { }

        public SurveyQuestionsNamNDRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;

        public async Task<List<SurveyQuestionsNamND>> GetAllAsync()
        {
            var surveyQuestions = await _context.SurveyQuestionsNamNDs.Include(s => s.SurveyNamND).ToListAsync();
            return surveyQuestions ?? new List<SurveyQuestionsNamND>();
        }

        public async Task<SurveyQuestionsNamND> GetByIdAsync(int code)
        {
            var surveyQuestion = await _context.SurveyQuestionsNamNDs
                .Include(s => s.SurveyNamND)
                .FirstOrDefaultAsync(s => s.QuestionNamNDID == code);
            return surveyQuestion ?? new SurveyQuestionsNamND();
        }

        public async Task<List<SurveyQuestionsNamND>> SearchAsync(int questionNamNDID, string questionText, string surveyName)
        {
            var surveys = await _context.SurveyQuestionsNamNDs
                .Include(s => s.SurveyNamND)
                .Where(s =>
                    (s.QuestionNamNDID == questionNamNDID || questionNamNDID == 0) &&
                    (s.QuestionText.Contains(questionText) || string.IsNullOrEmpty(questionText)) &&
                    (s.SurveyNamND.SurveyName.Contains(surveyName) || string.IsNullOrEmpty(surveyName)))
                .ToListAsync();

            return surveys ?? new List<SurveyQuestionsNamND>();
        }
    }
}
