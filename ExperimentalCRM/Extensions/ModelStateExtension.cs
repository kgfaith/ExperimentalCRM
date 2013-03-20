using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExperimentalCMS.Web.BackEnd.Extensions
{
    public static class ModelStateExtension
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, string key, List<string> errorMessages)
        {
            foreach (var msg in errorMessages)
                modelState.AddModelError(key, msg);
        }
    }
}