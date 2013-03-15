using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using DevOne.Security.Cryptography.BCrypt;

namespace ExperimentalCMS.Domain.Managers
{
    public class AdminManager : IAdminManager
    {
        public Admin CreateNewAdminAccount(Admin newAdmin)
        {
            return null;
        }

        public bool EditAdmin(Admin admin)
        {
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
