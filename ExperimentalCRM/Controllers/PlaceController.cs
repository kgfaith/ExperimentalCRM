using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories.DataAccess;
using ExperimentalCMS.ViewModels;

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

        public ActionResult Index()
        {
            var places = db.Places.Include(p => p.PlaceType);
            return View(places.ToList());
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

        //
        // GET: /Place/Create

        public ActionResult Create()
        {
            ViewBag.PlaceTypeId = PopulatePlaceTypesSelectList();

            return View();
        }

        private SelectList PopulatePlaceTypesSelectList()
        {
            var placeTypeList = _placeManager.GetPlaceTypeList();
            if (placeTypeList.Success && placeTypeList.Result.Count() > 0)
                return new SelectList(placeTypeList.Result.Select(x => new SelectListItem { Text = x.PlaceTypeName, Value = x.PlaceTypeId.ToString() }), "Value", "Text");

            return null;
        }

        //
        // POST: /Place/Create

        [HttpPost]
        public ActionResult Create(Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceTypeId = new SelectList(db.PlaceTypes, "PlaceTypeId", "PlaceTypeName", place.PlaceTypeId);
            return View(place);
        }

        //
        // GET: /Place/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceTypeId = new SelectList(db.PlaceTypes, "PlaceTypeId", "PlaceTypeName", place.PlaceTypeId);
            return View(place);
        }

        //
        // POST: /Place/Edit/5

        [HttpPost]
        public ActionResult Edit(PlaceViewModel place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceTypeId = new SelectList(db.PlaceTypes, "PlaceTypeId", "PlaceTypeName", place.PlaceTypeId);
            return View(place);
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}