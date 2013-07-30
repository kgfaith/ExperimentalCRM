using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExperimentalCMS.Web.BackEnd.Infrastructure;

namespace ExperimentalCMS.Web.BackEnd.Extensions
{
    //public class CustomWebViewPage
    //{
    //}

    public abstract class CustomWebViewPage : WebViewPage
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }

    public abstract class CustomWebViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}