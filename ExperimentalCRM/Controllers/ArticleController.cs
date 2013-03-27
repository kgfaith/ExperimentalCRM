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
//using ExperimentalCMS.Web.BackEnd.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    [Authorize]
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
                var articleModel = article.TransformToArticle();
                articleModel.LastUpdatedDate = DateTime.Now;
                db.Articles.Add(articleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        public ActionResult Edit(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
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

            var searchResults = _placeManager.SearchPlace(searchParams.Term, idsToExclude);
            return Json(searchResults, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}