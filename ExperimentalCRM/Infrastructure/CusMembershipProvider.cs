using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ExperimentalCMS.Domain.DataAccess;
using ExperimentalCMS.Model;
using WebMatrix.WebData;
using WebMatrix.Data;
using ExperimentalCMS.Repositories;

namespace ExperimentalCMS.Web.BackEnd.Infrastructure
{
    public class CusMembershipProvider : SimpleMembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            bool isValidLogin;
            using (UnitOfWork UOW = new UnitOfWork())
            {
                isValidLogin = UOW.AdminRepo.IsValidAdminLogin(username, password);
            }
            return isValidLogin;
        }
    }
}