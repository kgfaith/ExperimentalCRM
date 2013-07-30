using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Repositories;
using FlickrNet;

namespace ExperimentalCMS.Domain.Managers
{
    public class PhotoManager : IPhotoManager
    {
        private IUnitOfWork _uOW;

        public PhotoManager(IUnitOfWork uow)
        {
            _uOW = uow;
        }

        public void GetOnePhotoInfoFromFlickr()
        {
            string apikey = "8adf99bc3e2ed3349369c24a094b6563";
            string secret = "8eb5af964c3881b5";
            Flickr flickr = new Flickr(apikey,secret);
            flickr.InstanceCacheDisabled = true;
            PhotoSearchOptions searchOptions = new PhotoSearchOptions();
            searchOptions.Tags = "myanmar,bagan";
            PhotoCollection microsoftPhotos = flickr.PhotosSearch(searchOptions);
        }
    }
}
