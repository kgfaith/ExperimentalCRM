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
        bool IsDuplicatedUsername(string userName, int currentUserId);
        bool IsDuplicatedEmail(string email, int currentUserId);
        bool ChangeAdminPassword(int adminId, string newPassword);
    }
}
