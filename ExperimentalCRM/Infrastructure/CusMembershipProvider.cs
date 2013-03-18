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
        IAuthenticationManager authManager = new AuthenticationManager();
        public override bool ValidateUser(string username, string password)
        {
            bool isValidLogin;
            Admin admin;
            isValidLogin = authManager.IsValidBackEndAdminUser(username, password, out admin);
            if (isValidLogin)
            {
                var token = new CustomPrincipalSerializeModel();
                token.UserId = admin.AdminId;
                token.FullName = admin.FirstName + " " + admin.LastName;
                token.EmailAddress = admin.Email;
                LoginUserData = token;
            }
            return isValidLogin;
        }

        public CustomPrincipalSerializeModel LoginUserData
        {
            get
            {
                if (System.Web.HttpContext.Current == null)
                {
                    return null;
                }
                return System.Web.HttpContext.Current.Session["Token"] as CustomPrincipalSerializeModel;
            }
            set
            {
                if (System.Web.HttpContext.Current != null)
                {
                    System.Web.HttpContext.Current.Session["Token"] = value;
                }
            }
        } 
    }
}