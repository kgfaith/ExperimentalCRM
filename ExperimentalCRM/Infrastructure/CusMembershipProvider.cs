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
        public MembershipUser CreateUser(Admin admin, string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var result = base.CreateUser(username, password, email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out status);

            return result;
        }
    }
}