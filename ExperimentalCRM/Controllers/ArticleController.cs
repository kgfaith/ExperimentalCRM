﻿using System;
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
                var articleObj = PrepareArticleViewModelToUpdate(article);
                var response = _articleManager.CreateNewArticle(articleObj);
                if(response.Success && response.Result.ArticleId > 0)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelErrors("", response.Messages);
            }

            return View(article);
        }

        private Article PrepareArticleViewModelToUpdate(ArticleCreateViewModel viewModel)
        {
            var articleIds = !string.IsNullOrEmpty(viewModel.PlacesIdsString) ? viewModel.PlacesIdsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : null;
            var articleObj = viewModel.TransformToArticle();
            foreach (var id in articleIds)
            {
                var place = new Place { PlaceId = int.Parse(id) };
                if(articleObj.Places == null)
                    articleObj.Places = new List<Place>();
                articleObj.Places.Add(place);
            }
            return articleObj;
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
                var articleIds = !string.IsNullOrEmpty(model.PlacesIdsString) ? model.PlacesIdsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : null;
                var articleObj = model.TransformToArticle();
                foreach (var id in articleIds)
                {
                    var place = new Place { PlaceId = int.Parse(id) };
                    if (articleObj.Places == null)
                        articleObj.Places = new List<Place>();
                    articleObj.Places.Add(place);
                }

                var response = _articleManager.EditArticle(articleObj);

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

            var searchResults = _placeManager.SearchPlace(searchParams.Term, idsToExclude).Result.Take(10).Select(p => new { label = p.PlaceName, value = p.PlaceId });
            return Json(searchResults, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonQuickSearchArticle(AjaxSearchParams searchParams)
        {
            List<int> idsToExclude = new List<int>();
            if (searchParams.Excludes != null)
                idsToExclude.AddRange(searchParams.Excludes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(artistIDToExclude => int.Parse(artistIDToExclude)));

            var searchResults = _articleManager.SearchArticls(searchParams.Term, idsToExclude).Result.Take(10).Select(a => new { label = a.ArticleName , value = a.ArticleId });
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