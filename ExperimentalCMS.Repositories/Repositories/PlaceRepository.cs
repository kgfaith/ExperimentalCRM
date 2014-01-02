using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Repositories.DataAccess;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories.Contracts;

namespace ExperimentalCMS.Repositories.Repositories
{
    public class PlaceRepository : GenericRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(ExCMSContext context)
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

        public Place GetPlaceById(int id)
        {
            var obj = Get(x => x.PlaceId == id, null, "Articles");
            return obj.FirstOrDefault();
        }

        public IEnumerable<Place> GetPagedPlaces(out int totalPages, int skip, int take, int placeTypeId, Expression<Func<Place, object>> expression, bool isDesending = false)
        {
            totalPages = 1;        
            var query = _context.Places.Where(p => p.PlaceTypeId == placeTypeId);

            query = isDesending ? query.OrderByDescending(expression) : query.OrderBy(expression);
            if(query.Any())
                totalPages = (int) Math.Ceiling((double) query.Count() / take);
            return query.Skip(skip).Take(take).ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

