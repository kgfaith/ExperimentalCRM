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
            var response = new DomainResponse<Place>();
            var tempRelatedPlaces = newPlace.RelatedPlaces;
            newPlace.RelatedPlaces = new List<Place>();
            return null;
            //newPlace.LastUpdatedDate = DateTime.Now;
            //try
            //{
            //    newArticle = _uOW.ArticleRepo.Insert(newArticle);
            //    _uOW.Save();
            //    foreach (Place place in tempRelatedPlaces)
            //    {
            //        var tempPlace = _uOW.PlaceRepo.GetByID(place.PlaceId);
            //        newArticle.Places.Add(tempPlace);
            //    }
            //    _uOW.Save();
            //}
            //catch (Exception ex)
            //{
            //    return response.ReturnFailResponse(new[] { ex.Message }
            //           , "There is an error trying to create a new article."
            //           , null);
            //}

            //if (newArticle.ArticleId > 0)
            //{

            //    return response.ReturnSuccessResponse(newArticle
            //            , new[] { "New article has been successfully created." }
            //            , "New article has been successfully created.");
            //}
            //else
            //{
            //    return response.ReturnFailResponse(new[] { "Error occur while trying to create new article" }
            //           , "There is an error trying to save data"
            //           , null);
            //}
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
