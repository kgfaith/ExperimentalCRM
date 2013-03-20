using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories;

namespace ExperimentalCMS.Domain.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private UnitOfWork uOW = new UnitOfWork();
        public bool IsValidBackEndAdminUser(string username, string password, out Admin admin)
        {
            admin = uOW.AdminRepo.Get(u => u.UserName == username).SingleOrDefault();
            if (admin != null && BCryptHelper.CheckPassword(password, admin.PasswordHash))
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            uOW.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
