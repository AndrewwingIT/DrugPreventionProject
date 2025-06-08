using DrugPrevention.Repositories.NamND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.NamND
{
    public interface ISurveyQuestionsNamNDService
    {
        Task<List<SurveyQuestionsNamND>> GetAllAsync();

        Task<SurveyQuestionsNamND> GetByIdAsync(int code);

        Task<List<SurveyQuestionsNamND>> SearchAsync(int questionNamNDID, string questionText, string surveyName);

        Task<int> CreateAsync(SurveyQuestionsNamND surveyQuestion);

        Task<int> UpdateAsync(SurveyQuestionsNamND surveyQuestion);

        Task<bool> DeleteAsync(int code);
    }
}
