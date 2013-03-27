using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Utility;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Domain.Contracts
{
    public interface IPlaceManager
    {
        DomainResponse<Place> CreateNewPlace(Place newPlace);
        DomainResponse<BooleanResult> EditPlace(Place place);
        IEnumerable<Place> GetAllPlaceList();
        DomainResponse<Place> GetPlaceById(int id);
        bool DeletPlaceById(int id);
        DomainResponse<IEnumerable<Place>> SearchPlace(string searchTerm, IEnumerable<int> placeIdsToExclude);
        void Dispose();
    }
}
