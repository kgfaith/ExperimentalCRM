﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using ExperimentalCMS.Repositories.DataAccess;
using ExperimentalCMS.Web.BackEnd.App_Start;
using WebMatrix.WebData;
using System.Linq;
using System;
using System.Web;
using System.Web.Security;
using System.Web.Script.Serialization;
using ExperimentalCMS.ViewModels;
using ExperimentalCMS.Web.BackEnd.Infrastructure;

namespace ExperimentalCMS.Web.BackEnd
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            Database.SetInitializer<ExCMSContext>(new ExCrmInitializer());
            //ExCMSContext db = new ExCMSContext();
            //var article = db.Articles.ToList();
            //db.Dispose();
            //WebSecurity.InitializeDatabaseConnection("ExperimentalCMS", "Admin", "AdminId", "UserName", autoCreateTables: true);

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                newUser.UserId = serializeModel.UserId;
                newUser.FullName = serializeModel.FullName;
                newUser.EmailAddress = serializeModel.EmailAddress;

                HttpContext.Current.User = newUser;
            }
        }
    }
}