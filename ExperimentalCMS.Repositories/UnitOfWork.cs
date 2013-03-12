using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.DataAccess;
using ExperimentalCMS.Repositories.Contracts;
using ExperimentalCMS.Repositories.Repositories;

namespace ExperimentalCMS.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ExCMSContext context = new ExCMSContext();
        private IAdminRepository adminRepo;
        private IArticleRepository articleRepo;
        private IPictureRepository pictureRepo;
        private IPictureSourceRepository pictureSourceRepo;
        private IPlaceRepository placeRepo;
        private IPlaceTypeRepository placeTypeRepo;

        public IAdminRepository AdminRepo
        {
            get
            {
                if (this.adminRepo == null)
                    this.adminRepo = new AdminRepository(context);

                return adminRepo;
            }
        }

        public IArticleRepository ArticleRepo
        {
            get
            {
                if (this.articleRepo == null)
                    this.articleRepo = new ArticleRepository(context);

                return articleRepo;
            }
        }

        public IPictureRepository PictureRepo
        {
            get
            {
                if (this.pictureRepo == null)
                    this.pictureRepo = new PictureRepository(context);

                return pictureRepo;
            }
        }

        public IPictureSourceRepository PictureSourceRepo
        {
            get
            {
                if (this.pictureSourceRepo == null)
                    this.pictureSourceRepo = new PictureSourceRepository(context);

                return pictureSourceRepo;
            }
        }

        public IPlaceRepository PlaceRepo
        {
            get
            {
                if (this.placeRepo == null)
                    this.placeRepo = new PlaceRepository(context);

                return placeRepo;
            }
        }

        public IPlaceTypeRepository PlaceTypeRepo
        {
            get
            {
                if (this.placeTypeRepo == null)
                    this.placeTypeRepo = new PlaceTypeRepository(context);

                return placeTypeRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
