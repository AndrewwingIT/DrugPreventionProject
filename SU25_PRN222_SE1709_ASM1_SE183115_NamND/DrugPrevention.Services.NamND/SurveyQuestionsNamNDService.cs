using DrugPrevention.Repositories.NamND;
using DrugPrevention.Repositories.NamND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.NamND
{
    /*
    public interface ISurveysNamNdService
    {
    // Define methods that will be implemented in the service class
    }
    */

    public class SurveyQuestionsNamNDService : ISurveyQuestionsNamNDService
    {
        private readonly SurveyQuestionsNamNDRepository _repository;

        public SurveyQuestionsNamNDService() => _repository ??= new SurveyQuestionsNamNDRepository();

        public async Task<List<SurveyQuestionsNamND>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SurveyQuestionsNamND> GetByIdAsync(int code)
        {
            return await _repository.GetByIdAsync(code);
        }

        public async Task<List<SurveyQuestionsNamND>> SearchAsync(int questionNamNDID, string questionText, string surveyName)
        {
            return await _repository.SearchAsync(questionNamNDID, questionText, surveyName);
        }
        public async Task<int> CreateAsync(SurveyQuestionsNamND surveyQuestion)
        {
            return await _repository.CreateAsync(surveyQuestion);
        }

        public async Task<int> UpdateAsync(SurveyQuestionsNamND surveyQuestion)
        {
            return await _repository.UpdateAsync(surveyQuestion);
        }

        public async Task<bool> DeleteAsync(int code)
        {
            var surveyQuestion = await _repository.GetByIdAsync(code);
            if (surveyQuestion != null)
            {
                return await _repository.RemoveAsync(surveyQuestion);
            }
            return false;
        }
    }
}
