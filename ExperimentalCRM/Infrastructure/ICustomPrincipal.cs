using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ExperimentalCMS.Web.BackEnd.Infrastructure
{
    interface ICustomPrincipal : IPrincipal
    {
        int UserId { get; set; }
        string FullName { get; set; }
        string EmailAddress { get; set; } 
    }
}