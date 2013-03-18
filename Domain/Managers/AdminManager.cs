using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using DevOne.Security.Cryptography.BCrypt;
using ExperimentalCMS.Repositories;

namespace ExperimentalCMS.Domain.Managers
{
    public class AdminManager : IAdminManager
    {
        private UnitOfWork uOW = new UnitOfWork();
        public Admin CreateNewAdminAccount(Admin newAdmin)
        {
            try
            {
                newAdmin = uOW.AdminRepo.Insert(newAdmin);
            }

            catch(Exception ex)
            {
                return null;
            }

            if (newAdmin.AdminId > 0)
            {
                return newAdmin;
            }
            return null;
        }

        public bool EditAdmin(Admin admin)
        {
            try
            {
                uOW.AdminRepo.Update(admin);
            }

            catch(Exception ex)
            {
                return false;
            }
           
            return true;
        }

        public IEnumerable<Admin> GetAllAdminList()
        {
            return null;
        }
        public Admin GetAdminById(int id)
        {
            return null;
        }
        public bool DeleteAdminById(int id)
        {
            return true;
        }
    }
}
