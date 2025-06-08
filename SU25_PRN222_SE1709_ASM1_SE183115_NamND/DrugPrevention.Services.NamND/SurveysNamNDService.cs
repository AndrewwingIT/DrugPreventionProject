using DrugPrevention.Repositories.NamND;
using DrugPrevention.Repositories.NamND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.NamND
{
    public class SurveysNamNDService
    {
        private readonly SurveysNamNDRepository _repository;

        public SurveysNamNDService() => _repository ??= new SurveysNamNDRepository();

        public async Task<List<SurveysNamND>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
