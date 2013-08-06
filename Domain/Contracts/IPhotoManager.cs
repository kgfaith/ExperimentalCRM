using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Contracts
{
    public interface IPhotoManager
    {
        FlickrPhoto GetOnePhotoInfoFromFlickr(string photoId);
        //void ValidatePhotoByPhotoId(string photoId);
        //void SearchPhotoByTagNames(string tags);
    }
}
