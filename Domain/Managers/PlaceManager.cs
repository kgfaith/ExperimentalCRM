using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Domain.Utility;
using ExperimentalCMS.Model;
using ExperimentalCMS.Repositories;

namespace ExperimentalCMS.Domain.Managers
{
    public class PlaceManager : IPlaceManager
    {
        private IUnitOfWork _uOW;

        public PlaceManager(IUnitOfWork uow)
        {
            _uOW = uow;
        }

        public DomainResponse<Place> CreateNewPlace(Place newPlace)
        {
            throw new NotImplementedException();
        }

        public DomainResponse<BooleanResult> EditPlace(Place place)
        {
            throw new NotImplementedException();
        }

        public DomainResponse<IEnumerable<PlaceType>> GetPlaceTypeList()
        {
            var response = new DomainResponse<IEnumerable<PlaceType>>();
            try
            {
                response.Result = _uOW.PlaceTypeRepo.Get().ToArray();
            }
            catch (Exception ex)
            {
                return response.ReturnFailResponse(new[] { ex.Message }
                       , "There is an error trying to retrieve data", null);
            }

            return response.ReturnSuccessResponse(response.Result, null, null);
        }

        public IEnumerable<Place> GetAllPlaceList()
        {
            throw new NotImplementedException();
        }

        public DomainResponse<Place> GetPlaceById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeletPlaceById(int id)
        {
            throw new NotImplementedException();
        }

        public DomainResponse<IEnumerable<Place>> SearchPlace(string searchTerm, IEnumerable<int> placeIdsToExclude)
        {
            var response = new DomainResponse<IEnumerable<Place>>();
            try
            {
                var places = _uOW.PlaceRepo.Get(p => !placeIdsToExclude.Contains(p.PlaceId) && p.PlaceName.Contains(searchTerm));
                response.Result = places.ToArray();
            }
            catch (Exception ex)
            {
                return response.ReturnFailResponse(new[] { ex.Message }
                       , "There is an error trying to retrieve data", null);
            }

            return response.ReturnSuccessResponse(response.Result, null, null);
        }

        public void Dispose()
        {
            _uOW.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
