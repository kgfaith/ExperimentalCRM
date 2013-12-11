using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories.DataAccess;
using ExperimentalCMS.Web.BackEnd.Extensions;
using ExperimentalCMS.ViewModels;
using ExperimentalCMS.Web.BackEnd.Utility;
using System.Web;
using System.IO;
using ExperimentalCMS.Domain.Utility;
using ExperimentalCMS.Web.BackEnd.Domain;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {
        private ExCMSContext db = new ExCMSContext();

        private IArticleManager _articleManager;
        private IPlaceManager _placeManager;

        public PlaceController(IArticleManager articleManager, IPlaceManager placeManager)
        {
            _articleManager = articleManager;
            _placeManager = placeManager;
        }

        //
        // GET: /Place/

        public ActionResult Index(int pageSize = 10, int pageNumber = 1, string sortOrder = "PlaceName", bool sortAscending = true, int placeType = 1)
        {
            var placeListViewModel = new PlaceListViewModel();
            var places = db.Places.Include(p => p.PlaceType);
            ViewBag.PlaceTypeId = PopulatePlaceTypesSelectList(placeType);
            ViewBag.PageSize = Pagination.CreatePageSizeSelectListUsing(pageSize);
            return View(placeListViewModel);
        }

        //
        // GET: /Place/Details/5

        public ActionResult Details(int id = 0)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

      
        private SelectList PopulatePlaceTypesSelectList(object selectedValue = null)
        {
            var placeTypeList = _placeManager.GetPlaceTypeList();
            return new SelectList(placeTypeList.Result.Select(x => new SelectListItem { Text = x.PlaceTypeName, Value = x.PlaceTypeId.ToString() }), "Value", "Text", selectedValue);
        }

        private SelectList PopulateParentStateSelectList(object selectedValue = null)
        {
            var stateList = _placeManager.GetStateList();
            return new SelectList(stateList.Result.Select(x => new SelectListItem { Text = x.PlaceName, Value = x.PlaceId.ToString() }), "Value", "Text", selectedValue);
        }

        private SelectList PopulateParentCityTownSelectList(object selectedValue = null)
        {
            var placeTypeList = _placeManager.GetCityTownList();
            return new SelectList(placeTypeList.Result.Select(x => new SelectListItem { Text = x.PlaceName, Value = x.PlaceId.ToString() }), "Value", "Text", selectedValue);
        }

        private SelectList PopulateParentAttractionSelectList(object selectedValue = null)
        {
            var placeTypeList = _placeManager.GetAttractionList();
            return new SelectList(placeTypeList.Result.Select(x => new SelectListItem { Text = x.PlaceName, Value = x.PlaceId.ToString() }), "Value", "Text", selectedValue);
        }

        //
        // GET: /Place/Create

        public ActionResult Create()
        {
            ViewBag.PlaceTypeId = PopulatePlaceTypesSelectList();
            ViewBag.ParentStateId = PopulateParentStateSelectList();
            ViewBag.ParentCityTownId = PopulateParentCityTownSelectList();
            ViewBag.ParentAttractionId = PopulateParentAttractionSelectList();
            return View();
        }

        //
        // POST: /Place/Create

        [HttpPost]
        public ActionResult Create(PlaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var placeObj = PreparePlaceViewModelToUpdate(model);
                var response = _placeManager.CreateNewPlace(placeObj);
                if (response.Success && response.Result.PlaceId > 0)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelErrors("", response.Messages);
            }
            ViewBag.PlaceTypeId = PopulatePlaceTypesSelectList();
            ViewBag.ParentStateId = PopulateParentStateSelectList();
            ViewBag.ParentCityTownId = PopulateParentCityTownSelectList();
            ViewBag.ParentAttractionId = PopulateParentAttractionSelectList();
            return View(model);
        }

        private Place PreparePlaceViewModelToUpdate(PlaceViewModel viewModel)
        {
            var articleIds = !string.IsNullOrEmpty(viewModel.RelatedArticleIds) ? viewModel.RelatedArticleIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : new string[]{};
            var placeIds = !string.IsNullOrEmpty(viewModel.RelatedPlaceIds) ? viewModel.RelatedPlaceIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : new string[] { };
            var slideShowPicIds = !string.IsNullOrEmpty(viewModel.RelatedSlideShowPictureIds) ? viewModel.RelatedSlideShowPictureIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : new string[] { };

            var placeObj = viewModel.TransformToPlaceObject();
            foreach (var id in articleIds)
            {
                var article = new Article { ArticleId = int.Parse(id) };
                if (placeObj.Articles == null)
                    placeObj.Articles = new List<Article>();
                placeObj.Articles.Add(article);
            }
            /*foreach (var id in placeIds)
            {
                var place = new Place { PlaceId = int.Parse(id) };
                if (placeObj.RelatedPlaces == null)
                    placeObj.RelatedPlaces = new List<Place>();
                placeObj.RelatedPlaces.Add(place);
            }*/

            foreach (var id in slideShowPicIds)
            {
                var picture = new Picture { PictureId = int.Parse(id) };
                if (placeObj.SlideshowPictures == null)
                    placeObj.SlideshowPictures = new List<Picture>();
                placeObj.SlideshowPictures.Add(picture);
            }

            
            return placeObj;
        }

        //
        // GET: /Place/Edit/5

        public ActionResult Edit(int id = 0)
        {
            string errorMessage;
            Place place = GetPlaceById(id, out errorMessage);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceTypeId = PopulatePlaceTypesSelectList(place.PlaceTypeId);
            ViewBag.ParentStateId = PopulateParentStateSelectList(place.ParentStateId);
            ViewBag.ParentCityTownId = PopulateParentCityTownSelectList(place.ParentTownCityId);
            ViewBag.ParentAttractionId = PopulateParentAttractionSelectList(place.ParentAttractionId);
            return View(place.MapToPlaceViewModel());
        }

        //
        // POST: /Place/Edit/5

        [HttpPost]
        public ActionResult Edit(PlaceViewModel place)
        {
            if (ModelState.IsValid)
            {
                var placeObj = PreparePlaceViewModelToUpdate(place);
                var response = _placeManager.EditPlace(placeObj);

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
            ViewBag.PlaceTypeId = PopulatePlaceTypesSelectList(place.PlaceTypeId);
            ViewBag.ParentStateId = PopulateParentStateSelectList(place.ParentStateId);
            ViewBag.ParentCityTownId = PopulateParentCityTownSelectList(place.ParentCityTownId);
            ViewBag.ParentAttractionId = PopulateParentAttractionSelectList(place.ParentAttractionId);
            return RedirectToAction("Edit");
        }

        //
        // GET: /Place/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        //
        // POST: /Place/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private Place GetPlaceById(int id, out string errorMessage)
        {
            errorMessage = string.Empty;

            var domainResponse = _placeManager.GetPlaceById(id);

            if (!domainResponse.Success)
            {
                errorMessage = domainResponse.Messages.FirstOrDefault();
                return null;
            }

            return domainResponse.Result;
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            UploadFile(file);
            return Content(file.FileName);
        }

        public void UploadFile(HttpPostedFileBase file)
        {
            System.IO.File.WriteAllBytes(Server.MapPath("~/Content/Pictures/" + file.FileName), ReadData(file.InputStream));
        }

        private byte[] ReadData(Stream stream)
        {
            var buffer = new byte[16 * 1024];

            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}