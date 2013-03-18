using System.Web.Mvc;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;
using ExperimentalCMS.Web.BackEnd.Infrastructure;

namespace ExperimentalCMS.Web.BackEnd.Controllers.BaseController
{
    public class CmsBaseController : Controller
    {
        public CmsBaseController() :base()
        {
            
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        //public CustomPrincipalSerializeModel Token
        //{
        //    get
        //    {
        //        if (Session["Token"] != null)
        //        {
        //            return Session["Token"] as CustomPrincipalSerializeModel;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
}
