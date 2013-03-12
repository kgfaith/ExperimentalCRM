using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ExperimentalCMS.Domain.DataAccess;
using ExperimentalCMS.Model;
using WebMatrix.WebData;
using WebMatrix.Data;

namespace ExperimentalCMS.Web.BackEnd.Infrastructure
{
    public class CusMembershipProvider : SimpleMembershipProvider
    {
        private ExCMSContext db = new ExCMSContext();

        public override bool ValidateUser(string username, string password)
        {
            return true;
        }
    }
}