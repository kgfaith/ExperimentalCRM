using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories.DataAccess;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {
        private ExCMSContext db = new ExCMSContext();

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
            ViewBag.PlaceTypeId = new SelectList(db.PlaceTypes, "PlaceTypeId", "PlaceTypeName");
            return View();
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
        public ActionResult Edit(Place place)
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