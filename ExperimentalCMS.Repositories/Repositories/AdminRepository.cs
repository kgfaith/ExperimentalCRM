using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.DataAccess;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories.Contracts;

namespace ExperimentalCMS.Repositories.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ExCMSContext context)
            : base(context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
