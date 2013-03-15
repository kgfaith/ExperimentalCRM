using System.Web.Mvc;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;

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

        public LoginToken Token
        {
            get
            {
                if (Session["Token"] != null)
                {
                    return Session["Token"] as LoginToken;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
