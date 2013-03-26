using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Repositories.Contracts;

namespace ExperimentalCMS.Repositories
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
        IAdminRepository AdminRepo { get;  }
        IArticleRepository ArticleRepo { get;  }
        IPictureRepository PictureRepo { get;  }
        IPictureSourceRepository PictureSourceRepo { get; }
        IPlaceRepository PlaceRepo { get; }
        IPlaceTypeRepository PlaceTypeRepo { get; }
    }
}
