using System.Web.Mvc;
using AutoMapper;
using ExperimentalCMS.Model;
using ExperimentalCMS.Web.BackEnd.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Controllers.BaseController
{
    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            Mapper.CreateMap<ArticleCreateViewModel, Article>();
        }
    }
}
