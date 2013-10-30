using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories;
using FlickrNet;
using FlickrNet.Exceptions;

namespace ExperimentalCMS.Domain.Managers
{
    public class PhotoManager : IPhotoManager
    {
        private readonly string _apiKey;
        private readonly string _secret; 
        private IUnitOfWork _uOW;

        public PhotoManager(IUnitOfWork uow, string apiKey, string secret)
        {
            _uOW = uow;
            _apiKey = apiKey;
            _secret = secret;
        }

        public FlickrPhoto GetOnePhotoInfoFromFlickr(string photoId)
        {
            Flickr flickr = new Flickr(_apiKey, _secret);
            flickr.InstanceCacheDisabled = true;
            PhotoInfo photoInfo = new PhotoInfo();
            FlickrPhoto flickrPhoto = new FlickrPhoto();
            try
            {
                photoInfo = flickr.PhotosGetInfo(photoId);
                flickrPhoto.PictureId = photoInfo.PhotoId; 
                flickrPhoto.OwnerName = !string.IsNullOrWhiteSpace(photoInfo.OwnerRealName) ? photoInfo.OwnerRealName : photoInfo.OwnerUserName;
                flickrPhoto.Title = photoInfo.Title;
                flickrPhoto.Description = photoInfo.Description;
                flickrPhoto.AvailablePublic = photoInfo.IsPublic;
                flickrPhoto.SmallImageUrl = photoInfo.Small320Url;
            }
            catch (Exception ex)
            {
                if (ex is PhotoNotFoundException)
                {
                    flickrPhoto.AvailablePublic = false;
                }
            }
            return flickrPhoto;
        }

        public Picture AddNewPhoto(Picture photo)
        {
            try
            {
                photo = _uOW.PictureRepo.Insert(photo);
                _uOW.Save();
            }
            catch (Exception ex)
            {
                return photo;
            }
            return photo;
        }
    }
}