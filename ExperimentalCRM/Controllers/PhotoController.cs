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

        public ActionResult JsonQuickSearchPictures(AjaxSearchParams searchParams)
        {
            List<int> idsToExclude = new List<int>();
            if (searchParams.Excludes != null)
                idsToExclude.AddRange(searchParams.Excludes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(artistIDToExclude => int.Parse(artistIDToExclude)));

            var modelMapper = new PhotoViewModelMapper();
            var searchResults = _photoManager.SearchPictures(searchParams.Term, idsToExclude).Result.Take(10).Select(x => modelMapper.Map(x, Url));
            return Json(searchResults, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult JsonAddNewNormalPhoto(PhotoViewModel newPhoto)
        {

            var uploadResult = UploadFiles();
            if (uploadResult.Count > 0)
            {
                newPhoto.FileName = uploadResult[0].name;
                newPhoto.ImageUrl = uploadResult[0].url;
                var result = _photoManager.AddNewPhoto(new PhotoViewModelMapper().Map(newPhoto));
                if (result.PictureId > 0)
                    uploadResult[0].createdPicture = result;
            }
            return Json(uploadResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult JsonAddNewFlickrPhoto(PhotoViewModel newPhoto)
        {
            var result = _photoManager.AddNewPhoto(new PhotoViewModelMapper().Map(newPhoto));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        private List<ViewDataUploadFilesResult> UploadFiles()
        {
            var r = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files)
            {
                var statuses = new List<ViewDataUploadFilesResult>();
                var headers = Request.Headers;

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(Request, statuses);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], Request, statuses);
                }

                return statuses;
            }
            return r;

        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        //Credit to i-e-b and his ASP.Net uploader for the bulk of the upload helper methods - https://github.com/i-e-b/jQueryFileUpload.Net
        private void UploadPartialFile(string fileName, HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var file = request.Files[0];
            var inputStream = file.InputStream;

            var fullName = Path.Combine(Server.MapPath("~/Content/Upload/"), Path.GetFileName(fileName));

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new ViewDataUploadFilesResult()
            {
                name = fileName,
                size = file.ContentLength,
                type = file.ContentType,
                url = "~/Content/Upload/" + fileName,
                delete_url = "/Photo/Delete/" + fileName,
                thumbnail_url = @"data:image/png;base64," + EncodeFile(fullName),
                delete_type = "GET",
            });
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        //Credit to i-e-b and his ASP.Net uploader for the bulk of the upload helper methods - https://github.com/i-e-b/jQueryFileUpload.Net
        private void UploadWholeFile(HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];

                var fileExtension = System.IO.Path.GetExtension(file.FileName);
                var guidFileName = Guid.NewGuid() + fileExtension;
                var fullPath = Path.Combine(Server.MapPath("~/Content/Upload/"), guidFileName);

                file.SaveAs(fullPath);

                statuses.Add(new ViewDataUploadFilesResult()
                {
                    name = guidFileName,
                    size = file.ContentLength,
                    type = file.ContentType,
                    url = Url.Content("~/Content/Upload/" + guidFileName),
                    delete_url = "/Photo/Delete/" + file.FileName,
                    thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath),
                    delete_type = "GET",
                });
            }
        }
    }

    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string delete_url { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_type { get; set; }
        public Picture createdPicture { get; set; }
    }
}
        /*[HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file, PhotoViewModel newPhoto)
        {
            UploadFile(file);
            ContentResult cr = Content(file.FileName);
            return cr;
        }

        public void UploadFile(HttpPostedFileBase file)
        {
            System.IO.File.WriteAllBytes(Server.MapPath("~/Content/Upload/" + Guid.NewGuid()), ReadData(file.InputStream));
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
        }*/

    

