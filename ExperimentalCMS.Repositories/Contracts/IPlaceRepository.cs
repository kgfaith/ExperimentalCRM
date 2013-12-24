using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Repositories.Contracts
{
    public interface IPlaceRepository : IGenericRepository<Place>
    {
        Place GetPlaceById(int id);
        IEnumerable<Place> GetPagedPlaces(int skip, int take, int placeTypeId,
                                          Expression<Func<Place, object>> expression, bool isDesending = false);
    }
}
