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
            var tempRelatedPlaces = newPlace.RelatedPlaces != null? newPlace.RelatedPlaces : new List<Place>();
            var tempArticles = newPlace.Articles != null ? newPlace.Articles : new List<Article>();
            var tempSlideShowPics = newPlace.SlideshowPictures != null ? newPlace.SlideshowPictures : new List<Picture>();
            newPlace.RelatedPlaces = new List<Place>();
            newPlace.Articles = new List<Article>();
            newPlace.SlideshowPictures = new List<Picture>();

            try
            {
                newPlace = _uOW.PlaceRepo.Insert(newPlace);
                _uOW.Save();
                foreach (Place place in tempRelatedPlaces)
                {
                    var tempPlace = _uOW.PlaceRepo.GetByID(place.PlaceId);
                    newPlace.RelatedPlaces.Add(tempPlace);
                }
                foreach (Article article in tempArticles)
                {
                    var tempArticle = _uOW.ArticleRepo.GetByID(article.ArticleId);
                    newPlace.Articles.Add(tempArticle);
                }
                foreach (Picture picture in tempSlideShowPics)
                {
                    var tempPicture = _uOW.PictureRepo.GetByID(picture.PictureId);
                    newPlace.SlideshowPictures.Add(tempPicture);
                }
                _uOW.Save();
            }
            catch (Exception ex)
            {
                return response.ReturnFailResponse(new[] { ex.Message }
                       , "There is an error trying to create a new article."
                       , null);
            }

            if (newPlace.PlaceId > 0)
            {
                return response.ReturnSuccessResponse(newPlace
                        , new[] { "New article has been successfully created." }
                        , "New article has been successfully created.");
            }
            else
            {
                return response.ReturnFailResponse(new[] { "Error occur while trying to create new article" }
                       , "There is an error trying to save data"
                       , null);
            }
        }

        public DomainResponse<BooleanResult> EditPlace(Place newPlace)
        {
            var response = new DomainResponse<BooleanResult>();
            try
            {
                var placeData = _uOW.PlaceRepo.Get(filter: p => p.PlaceId == newPlace.PlaceId, includeProperties: "RelatedPlaces,Articles").FirstOrDefault();
                placeData.PlaceName = newPlace.PlaceName ?? placeData.PlaceName;
                placeData.Description = newPlace.Description ?? placeData.Description;
                placeData.InternalRanking = newPlace.InternalRanking > -1 ? newPlace.InternalRanking : placeData.InternalRanking;
                placeData.PlaceTypeId = newPlace.PlaceTypeId > 0 ? newPlace.PlaceTypeId : placeData.PlaceTypeId;
                placeData.PlaceType = newPlace.PlaceType != null ? newPlace.PlaceType : placeData.PlaceType;

                UpdateRelatedPlaces(newPlace, placeData);
                UpdateRelatedArticles(newPlace, placeData);
                UpdateRelatedSlideshowPictures(newPlace, placeData);
                _uOW.PlaceRepo.Update(placeData);
                _uOW.Save();
            }

            catch (Exception ex)
            {
                return response.ReturnFailResponse(new[] { ex.Message }
                       , "There is an error trying to update data"
                       , new BooleanResult { Success = false });
            }

            return response.ReturnSuccessResponse(new BooleanResult { Success = true }
                    , new[] { "Admin data has been successfully updated." }
                    , "Admin data has been successfully updated.");
        }

        private void UpdateRelatedSlideshowPictures(Place newPlace, Place placeToUpdate)
        {
            var pictures = _uOW.PictureRepo.Get();
            var selectedIdsAry = newPlace.SlideshowPictures != null ? newPlace.SlideshowPictures.Select(x => x.PictureId).ToArray() : new int[]{};
            var existingIdsAry = placeToUpdate.SlideshowPictures != null ? placeToUpdate.SlideshowPictures.Select(x => x.PictureId).ToArray() : new int[] { };

            //TODO: make performance testing for this logic
            foreach (Picture picture in pictures)
            {
                if (selectedIdsAry.Contains(picture.PictureId))
                {
                    if (!existingIdsAry.Contains(picture.PictureId))
                        placeToUpdate.SlideshowPictures.Add(picture);
                }
                else
                {
                    if (existingIdsAry.Contains(picture.PictureId))
                        placeToUpdate.SlideshowPictures.Remove(picture);
                }
            }
        }

        private void UpdateRelatedPlaces(Place newPlace, Place placeToUpdate)
        {
            var places = _uOW.PlaceRepo.Get();
            var selectedIdsAry = newPlace.RelatedPlaces != null ? newPlace.RelatedPlaces.Select(x => x.PlaceId).ToArray() : new int[]{};
            var existingIdsAry = placeToUpdate.RelatedPlaces != null ? placeToUpdate.RelatedPlaces.Select(x => x.PlaceId).ToArray() : new int[]{};
            foreach (Place place in places)
            {
                if (selectedIdsAry.Contains(place.PlaceId))
                {
                    if (!existingIdsAry.Contains(place.PlaceId))
                        placeToUpdate.RelatedPlaces.Add(place);
                }
                else
                {
                    if (existingIdsAry.Contains(place.PlaceId))
                        placeToUpdate.RelatedPlaces.Remove(place);
                }
            }
        }

        private void UpdateRelatedArticles(Place newPlace, Place placeToUpdate)
        {
            var articles = _uOW.ArticleRepo.Get();
            var selectedIdsAry = newPlace.Articles != null ? newPlace.Articles.Select(x => x.ArticleId).ToArray() : new int[]{};
            var existingIdsAry = placeToUpdate.Articles != null ? placeToUpdate.Articles.Select(x => x.ArticleId).ToArray() : new int[]{};
            foreach (Article article in articles)
            {
                if (selectedIdsAry.Contains(article.ArticleId))
                {
                    if (!existingIdsAry.Contains(article.ArticleId))
                        placeToUpdate.Articles.Add(article);
                }
                else
                {
                    if (existingIdsAry.Contains(article.ArticleId))
                        placeToUpdate.Articles.Remove(article);
                }
            }
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
            var response = new DomainResponse<Place>();
            try
            {
                response.Result = _uOW.PlaceRepo.GetPlaceById(id);
            }
            catch (Exception ex)
            {
                return response.ReturnFailResponse(new[] { ex.Message }
                       , "There is an error trying to retrieve data", null);
            }

            if (response.Result != null)
                return response.ReturnSuccessResponse(response.Result, null, null);
            else
                return response.ReturnFailResponse(new[] { string.Format("Error occur whilte retrieving data for admingId {0}", id) }
                    , "There is an error trying to retrieve data", null);
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
