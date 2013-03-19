using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using DevOne.Security.Cryptography.BCrypt;
using ExperimentalCMS.Repositories;
using ExperimentalCMS.Domain.Utility;

namespace ExperimentalCMS.Domain.Managers
{
    public class AdminManager : IAdminManager
    {
        private UnitOfWork uOW = new UnitOfWork();
        public Admin CreateNewAdminAccount(Admin newAdmin)
        {
            try
            {
                if (newAdmin.DateCreated == DateTime.MinValue)
                    newAdmin.DateCreated = DateTime.Now;

                newAdmin.Activated = true;
                newAdmin = uOW.AdminRepo.Insert(newAdmin);
                uOW.Save();
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

        public Admin GetAdminByUserName(string userName)
        {
            try
            {
                return uOW.AdminRepo.Get(u => u.UserName == userName).SingleOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IsDuplicatedUsername(string userName, int currentUserId)
        {
            Admin resultAdmin;
            if (currentUserId > 0)
            {
                resultAdmin = uOW.AdminRepo.Get(u => string.Compare(u.UserName , userName, true) == 0 && u.AdminId != currentUserId).SingleOrDefault();
            }
            else
            {
                resultAdmin = uOW.AdminRepo.Get(u => string.Compare(u.UserName, userName, true) == 0).SingleOrDefault();
            }
            return resultAdmin != null;
        }

        public bool IsDuplicatedEmail(string email, int currentUserId)
        {
            Admin resultAdmin;
            if (currentUserId > 0)
            {
                resultAdmin = uOW.AdminRepo.Get(u => string.Compare(u.Email, email, true) == 0 && u.AdminId != currentUserId).SingleOrDefault();
            }
            else
            {
                resultAdmin = uOW.AdminRepo.Get(u => string.Compare(u.Email, email, true) == 0).SingleOrDefault();
            }
            return resultAdmin != null;
        }
    }
}
