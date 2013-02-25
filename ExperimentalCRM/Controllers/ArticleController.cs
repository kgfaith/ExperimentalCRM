﻿using System.Data;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ExperimentalCMS.Model;
using ExperimentalCMS.Model.DataAccess;
using ExperimentalCMS.Web.BackEnd.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    public class ArticleController : Controller
    {
        private ExCrmContext db = new ExCrmContext();

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
                var articleModel = Mapper.Map<ArticleCreateViewModel, Article>(article);
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}