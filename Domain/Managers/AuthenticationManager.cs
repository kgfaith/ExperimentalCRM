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
        private IUnitOfWork _uOW = new UnitOfWork();

        //public AuthenticationManager()
        //{
        //}

        //public AuthenticationManager(IUnitOfWork uow)
        //{
        //    _uOW = uow;
        //}

        public bool IsValidBackEndAdminUser(string username, string password, out Admin admin)
        {
            admin = null;
            try
            {
                var result = _uOW.AdminRepo.Get(u => u.UserName == username);
                if (!result.Any())
                    return false;

                admin = result.FirstOrDefault();
                if (admin != null && BCryptHelper.CheckPassword(password, admin.PasswordHash))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public void Dispose()
        {
            _uOW.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
