using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Contracts
{
    public interface IAdminManager
    {
        Admin CreateNewAdminAccount(Admin newAdmin);
        bool EditAdmin(Admin admin);
        IEnumerable<Admin> GetAllAdminList();
        Admin GetAdminById(int id);
        bool DeleteAdminById(int id);
        Admin GetAdminByUserName(string userName);
    }
}
