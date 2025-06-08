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
    public class System_UserAccountRepository : GenericRepository<System_UserAccount>
    {
        public System_UserAccountRepository() { }
        public System_UserAccountRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;
        
        public async Task<System_UserAccount> GetUserAccount(string userName, string password)
        {
            //return await _context.SystemUserAccounts
            //    .FirstOrDefaultAsync(u => u.Email == userName && u.Password == password && u.IsActive == true);
            return await _context.System_UserAccounts
                .FirstOrDefaultAsync(u => u.UserName== userName 
                                    && u.Password == password
                                    && u.IsActive == true);
            //return await _context.SystemUserAccounts
            //    .FirstOrDefaultAsync(u => u.Phone == userName && u.Password == password);
            //return await _context.SystemUserAccounts
            //    .FirstOrDefaultAsync(u => u.EmployeeCode == userName && u.Password == password);
        }
    }
}
