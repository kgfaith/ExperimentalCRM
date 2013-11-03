using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;
using ExperimentalCMS.Web.BackEnd.Mappers;

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

        public ActionResult JsonAddNewPhoto(PhotoViewModel newPhoto)
        {
            var result = _photoManager.AddNewPhoto(new PhotoViewModelMapper().Map(newPhoto));
            return Json(new PhotoViewModelMapper().Map(result), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file,int id)
        {
            UploadFile(file);
            return Content(file.FileName);
        }

        public void UploadFile(HttpPostedFileBase file)
        {
            System.IO.File.WriteAllBytes(Server.MapPath("~/Content/upload/" + file.FileName), ReadData(file.InputStream));
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

    }
}
