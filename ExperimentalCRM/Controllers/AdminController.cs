using System.Data;
using System.Linq;
using System.Web.Mvc;
using ExperimentalCMS.Model;
using ExperimentalCMS.Domain.DataAccess;
using ExperimentalCMS.ViewModels;
using System.Web.Security;
using WebMatrix.WebData;
using ExperimentalCMS.Repositories;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    public class AdminController : Controller
    {
        private ExCMSContext db = new ExCMSContext();
        private UnitOfWork uOW = new UnitOfWork();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(AdminCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var adminModel = model.TransformToAdmin();
                    adminModel = uOW.AdminRepo.Insert(adminModel);
                    return RedirectToAction("Index");
                }

                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            return View(model);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                id = WebSecurity.GetUserId(User.Identity.Name);
            }

            Admin admin = db.Admins.Find(id);
           
            if (admin == null)
            {
                return HttpNotFound();
            } 

            var model = new AdminEditViewModel();
            model.TransformFromAdmin(admin);
            return View(model);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(AdminEditViewModel model)
        {
            if (ModelState.IsValid )
            {
                Admin admin = db.Admins.Find(model.AdminId);
                
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();

                bool changePasswordSucceeded;
                MembershipUser currentUser = Membership.GetUser(model.AdminId, userIsOnline: false);
                changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}