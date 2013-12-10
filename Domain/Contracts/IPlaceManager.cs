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
        DomainResponse<IEnumerable<PlaceType>> GetPlaceTypeList();
        DomainResponse<Place> GetPlaceById(int id);
        bool DeletPlaceById(int id);
        DomainResponse<IEnumerable<Place>> SearchPlace(string searchTerm, IEnumerable<int> placeIdsToExclude);
        DomainResponse<IEnumerable<Place>> GetStateList();
        DomainResponse<IEnumerable<Place>> GetCityTownList();
        DomainResponse<IEnumerable<Place>> GetAttractionList();
        void Dispose();
    }
}
