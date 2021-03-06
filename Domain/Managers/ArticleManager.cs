﻿using System;
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
    public class ArticleManager : IArticleManager
    {
        private IUnitOfWork _uOW;

        public ArticleManager(IUnitOfWork uow)
        {
            _uOW = uow;
        }

        public DomainResponse<Article> CreateNewArticle(Article newArticle)
        {
            var response = new DomainResponse<Article>();
            var tempRelatedPlaces = newArticle.Places;
            newArticle.Places = new List<Place>();
            newArticle.LastUpdatedDate = DateTime.Now;
            try
            {
                newArticle = _uOW.ArticleRepo.Insert(newArticle);
                _uOW.Save();
                foreach (Place place in tempRelatedPlaces)
                {
                    var tempPlace = _uOW.PlaceRepo.GetByID(place.PlaceId);
                    newArticle.Places.Add(tempPlace);
                }
                _uOW.Save();
            }
            catch (Exception ex)
            {
                return response.ReturnFailResponse(new[] { ex.Message }
                       , "There is an error trying to create a new article."
                       , null);
            }

            if (newArticle.ArticleId > 0)
            {

                return response.ReturnSuccessResponse(newArticle
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

        public DomainResponse<BooleanResult> EditArticle(Article article)
        {
            var response = new DomainResponse<BooleanResult>();
            try
            {
                var articleData = _uOW.ArticleRepo.Get(filter: ai => ai.ArticleId == article.ArticleId, includeProperties: "Places").FirstOrDefault();
                articleData.ArticleName = article.ArticleName ?? articleData.ArticleName;
                articleData.Title = article.Title ?? articleData.Title;
                articleData.CreatedDate = article.PublishDate != DateTime.MinValue ? article.PublishDate : articleData.CreatedDate;
                articleData.LastUpdatedDate = article.LastUpdatedDate != DateTime.MinValue ? article.LastUpdatedDate : articleData.LastUpdatedDate;
                articleData.PublishDate = article.PublishDate != DateTime.MinValue ? article.PublishDate : articleData.PublishDate;
                articleData.Content = article.Content;
                UpdateArticlePlaces(article, articleData);
                _uOW.ArticleRepo.Update(articleData);
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

        private void UpdateArticlePlaces(Article newArticle, Article articaleToUpdate)
        {
            var places = _uOW.PlaceRepo.Get();
            var selectedIdsAry = newArticle.Places.Select(x => x.PlaceId).ToArray();
            var existingIdsAry = articaleToUpdate.Places.Select(x => x.PlaceId).ToArray();
            foreach (Place place in places)
            {
                if (selectedIdsAry.Contains(place.PlaceId))
                {
                    if(!existingIdsAry.Contains(place.PlaceId))
                        articaleToUpdate.Places.Add(place);
                }
                else
                {
                    if (existingIdsAry.Contains(place.PlaceId))
                        articaleToUpdate.Places.Remove(place);
                }
            }
        }

        public IEnumerable<Article> GetAllArticleList()
        {
            throw new NotImplementedException();
        }

        public DomainResponse<Article> GetArticleById(int id)
        {
            var response = new DomainResponse<Article>();
            try
            {
                response.Result = _uOW.ArticleRepo.GetArticleById(id);
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

        public bool DeleteArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public DomainResponse<IEnumerable<Article>> SearchArticls(string searchTerm, IEnumerable<int> articleIdsToExclude)
        {
            var response = new DomainResponse<IEnumerable<Article>>();
            try
            {
                var articles = _uOW.ArticleRepo.Get(p => !articleIdsToExclude.Contains(p.ArticleId) && p.ArticleName.Contains(searchTerm));
                response.Result = articles.ToArray();
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
            throw new NotImplementedException();
        }
    }
}
