using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.Domain.Contracts
{
    public interface IPhotoManager
    {
        void GetOnePhotoInfoFromFlickr();
        //void ValidatePhotoByPhotoId(string photoId);
        //void SearchPhotoByTagNames(string tags);
    }
}
