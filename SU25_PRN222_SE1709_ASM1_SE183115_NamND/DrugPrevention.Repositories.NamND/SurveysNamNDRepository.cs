using DrugPrevention.Repositories.NamND.Basic;
using DrugPrevention.Repositories.NamND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.NamND
{
    public class SurveysNamNDRepository : GenericRepository<SurveysNamND>
    {
        public SurveysNamNDRepository() { }

        public SurveysNamNDRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;
    }
}
