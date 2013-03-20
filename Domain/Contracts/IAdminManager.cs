using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Utility;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Contracts
{
    public interface IAdminManager
    {
        Admin CreateNewAdminAccount(Admin newAdmin);
        DomainResponse<BooleanResult> EditAdmin(Admin admin);
        IEnumerable<Admin> GetAllAdminList();
        DomainResponse<Admin> GetAdminById(int id);
        bool DeleteAdminById(int id);
        Admin GetAdminByUserName(string userName);
        bool IsDuplicatedUsername(string userName, int currentUserId);
        bool IsDuplicatedEmail(string email, int currentUserId);
        DomainResponse<BooleanResult> ChangeAdminPassword(int adminId, string newPassword);
    }
}
