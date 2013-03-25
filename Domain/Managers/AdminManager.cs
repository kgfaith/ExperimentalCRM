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
    public class AdminManager : IAdminManager, IDisposable
    {
        private UnitOfWork uOW = new UnitOfWork();

        public AdminManager()
        {

        }

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

        public DomainResponse<BooleanResult> EditAdmin(Admin admin)
        {
            var response = new DomainResponse<BooleanResult>();
            if (IsDuplicatedEmail(admin.Email, admin.AdminId))
            {
                return response.ReturnFailResponse(new[] { "This email address is already existed on the system. Please choose another one." }
                       , "This email address is already existed on the system. Please choose another one."
                       , new BooleanResult { Success = false });
            }

            try
            {
                var adminData = uOW.AdminRepo.GetByID(admin.AdminId);
                adminData.FirstName = admin.FirstName;
                adminData.LastName = admin.LastName;
                adminData.Email = admin.Email;
                uOW.AdminRepo.Update(adminData);
                uOW.Save();
            }

            catch (Exception ex)
            {
                return response.ReturnFailResponse( new[] { ex.Message }
                       , "There is an error trying to update data"
                       , new BooleanResult { Success = false });
            }

            return response.ReturnSuccessResponse(new BooleanResult { Success = true }
                    , new[] { "Admin data has been successfully updated." }
                    , "Admin data has been successfully updated.");
        }

        public IEnumerable<Admin> GetAllAdminList()
        {
            return null;
        }
        public DomainResponse<Admin> GetAdminById(int id)
        {
            var response = new DomainResponse<Admin>();
            try
            {
                response.Result = uOW.AdminRepo.GetByID(id);
            }
            catch (Exception ex)
            {
                return response.ReturnFailResponse(new[] { ex.Message }
                       , "There is an error trying to retrieve data", null);
            }

            if (response.Result != null)
                return response.ReturnSuccessResponse(response.Result, null, null);
            else
                return response.ReturnFailResponse(new [] { string.Format("Error occur whilte retrieving data for admingId {0}", id) }
                    , "There is an error trying to retrieve data", null);
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

        public DomainResponse<BooleanResult> ChangeAdminPassword(int adminId, string newPassword)
        {
            var response = new DomainResponse<BooleanResult>();
            if (adminId <= 0)
                return response.ReturnFailResponse(new []{"Data cannot be retrieve with AdminId NULL"}
                    ,"There is an error trying to retrieve data"
                    ,new BooleanResult { Success = false });

            var resultAdmin = uOW.AdminRepo.Get(u => u.AdminId == adminId).SingleOrDefault();
            resultAdmin.Password = newPassword;
            try
            {
                uOW.AdminRepo.Update(resultAdmin); 
                uOW.Save();
            }
            catch(Exception ex)
            {
                return response.ReturnFailResponse( new[] { ex.Message }
                    , "There is an error trying to retrieve data"
                    , new BooleanResult { Success = false });
            }

            return response.ReturnSuccessResponse(new BooleanResult { Success = true }
                    , new[] { "Password has been successfully updated." }
                    , "Password has been successfully updated.");
        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        public void Dispose()
        {
            uOW.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
