using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ExperimentalCMS.Web.BackEnd.Infrastructure
{
    public class CusRoleProvider: RoleProvider
    {
        //public IAccountRepository AccountRepository { get; set; }

        public CusRoleProvider()
        {
            //AccountRepository = new AccountRepository();
        }
        
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        //GET ROLES FOR USER//

        public override string[] GetRolesForUser(string id)
        {
            return new string[] { "Admin" };//AccountRepository.GetRolesForUser(id);
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}