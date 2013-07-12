using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories.DataAccess;
using ExperimentalCMS.ViewModels;
using ExperimentalCMS.Web.BackEnd.Controllers.BaseController;
using ExperimentalCMS.Web.BackEnd.Extensions;
using ExperimentalCMS.Web.BackEnd.Utility;
using MvcContrib.Filters;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    [Authorize]
    [ModelStateToTempData]
    public class ArticleController : CmsBaseController
    {
        private ExCMSContext db = new ExCMSContext();
        private IArticleManager _articleManager;
        private IPlaceManager _placeManager;


        public ArticleController(IArticleManager articleManager, IPlaceManager placeManager)
        {
            _articleManager = articleManager;
            _placeManager = placeManager;
        }

        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(ArticleCreateViewModel article)
        {
            if (ModelState.IsValid)
            {
                var response = _articleManager.CreateNewArticle(article.TransformToArticle());
                if(response.Success && response.Result.ArticleId > 0)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelErrors("", response.Messages);
            }

            return View(article);
        }

        public ActionResult Edit(int id = 0)
        {
            string errorMessage;
            Article article = GetArticleById(id, out errorMessage);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article.MapToArticleCreateViewModel());
        }

        [HttpPost]
        public ActionResult Edit(ArticleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _articleManager.EditArticle(model.TransformToArticle());

                if (response.Success)
                {
                    TempData[Constants.TempdataKeys.EditArticleSuccessKey] = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelErrors("", response.Messages);
                }
            }
            return RedirectToAction("Edit");
        }

        public ActionResult Delete(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult QuickSearchPlace(AjaxSearchParams searchParams)
        {
            List<int> idsToExclude = new List<int>();
            if (searchParams.Excludes != null)
                idsToExclude.AddRange(searchParams.Excludes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(artistIDToExclude => int.Parse(artistIDToExclude)));

            var searchResults = _placeManager.SearchPlace(searchParams.Term, idsToExclude).Result.Take(10).Select(p => new { label = p.PlaceName, value = p.PlaceId }); ;
            return Json(searchResults, JsonRequestBehavior.AllowGet);
        }

        private Article GetArticleById(int id, out string errorMessage)
        {
            errorMessage = string.Empty;

            var domainResponse = _articleManager.GetArticleById(id);

            if (!domainResponse.Success)
            {
                errorMessage = domainResponse.Messages.FirstOrDefault();
                return null;
            }

            return domainResponse.Result;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}