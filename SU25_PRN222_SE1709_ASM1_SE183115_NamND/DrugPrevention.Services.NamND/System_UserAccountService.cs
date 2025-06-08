using DrugPrevention.Repositories.NamND;
using DrugPrevention.Repositories.NamND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.NamND
{
    public class System_UserAccountService
    {
        private readonly System_UserAccountRepository _repository;

        public System_UserAccountService() => _repository = new System_UserAccountRepository();

        public async Task<System_UserAccount> GetUserAccount(string userName, string password)
        {
            return await _repository.GetUserAccount(userName, password);
        }
    }
}
