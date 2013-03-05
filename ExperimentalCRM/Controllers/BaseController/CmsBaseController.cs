using System.Web.Mvc;
using AutoMapper;
using ExperimentalCMS.Model;
using ExperimentalCMS.Web.BackEnd.ViewModels;

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
            Mapper.CreateMap<ArticleCreateViewModel, Article>();
        }
    }
}
