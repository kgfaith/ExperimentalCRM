using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    public class PhotoController : Controller
    {
        private IPhotoManager _photoManager;

        public PhotoController(IPhotoManager photoManager)
        {
            _photoManager = photoManager;
        }

        public ActionResult JsonGetFlickrPhotoInfo(string photoId)
        {
            var photoInfo = _photoManager.GetOnePhotoInfoFromFlickr(photoId);
            return Json(photoInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonAddNewPhoto(PhotoViewModel newFlickrPhoto)
        {
            //var photoInfo = _photoManager.GetOnePhotoInfoFromFlickr(photoId);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

    }
}
