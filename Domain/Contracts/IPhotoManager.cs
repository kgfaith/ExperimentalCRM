using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Utility;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Contracts
{
    public interface IPhotoManager
    {
        Picture AddNewPhoto(Picture photo);
        FlickrPhoto GetOnePhotoInfoFromFlickr(string photoId);
        DomainResponse<IEnumerable<Picture>> SearchPictures(string searchTerm, IEnumerable<int> articleIdsToExclude);
        //void ValidatePhotoByPhotoId(string photoId);
        //void SearchPhotoByTagNames(string tags);

    }
}
