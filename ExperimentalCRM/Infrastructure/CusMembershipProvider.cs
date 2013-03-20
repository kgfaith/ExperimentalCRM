using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ExperimentalCMS.Repositories.DataAccess;
using ExperimentalCMS.Model;
using WebMatrix.WebData;
using WebMatrix.Data;
using ExperimentalCMS.Repositories;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Domain.Managers;
using ExperimentalCMS.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Infrastructure
{
    public class CusMembershipProvider : SimpleMembershipProvider
    {
        //TODO: decouple auth manager.
        
        public override bool ValidateUser(string username, string password)
        {
            IAuthenticationManager authManager = new AuthenticationManager();
            bool isValidLogin;
            Admin admin;
            isValidLogin = authManager.IsValidBackEndAdminUser(username, password, out admin);
            authManager.Dispose();
           
            return isValidLogin;
        }
    }
}