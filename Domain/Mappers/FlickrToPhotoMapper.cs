using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Mappers
{
    public static class FlickrToPhotoMapper
    {
        public static Picture Map(FlickrPhoto flickrPhoto)
        {
            return new Picture
                        {
                            FileName = flickrPhoto.PictureId,
                            OwnerName = flickrPhoto.OwnerName,
                            Title = flickrPhoto.Title,
                            Description = flickrPhoto.Description,
                            PictureSourceId = 2
                        };
        }
    }
}