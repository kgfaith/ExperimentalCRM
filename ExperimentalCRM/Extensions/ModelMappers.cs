using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;

namespace ExperimentalCMS.Web.BackEnd.Extensions
{
    public static class ModelMappers
    {
        public static ArticleCreateViewModel MapToArticleCreateViewModel(this Article article)
        {
            var obj = new ArticleCreateViewModel
                        {
                            ArticleId = article.ArticleId,
                            ArticleName = article.ArticleName,
                            Title = article.Title,
                            Content = article.Content,
                            CreatedDate = article.CreatedDate,
                            LastUpdatedDate = article.LastUpdatedDate.Value,
                            PublishDate = article.PublishDate,
                            Places = article.Places                     
                        };
            string str = string.Empty;
            foreach (var place in article.Places)
            {
                str += place.PlaceId.ToString() + ',';
            }
            obj.PlacesIdsString = str;
            return obj;
        }

        public static PlaceViewModel MapToPlaceViewModel(this Place place)
        {
            var obj = new PlaceViewModel
            {
                 PlaceId = place.PlaceId, 
            PlaceName = place.PlaceName,
            Description = place.Description,
            InternalRanking = place.InternalRanking, 
            PlaceTypeId = place.PlaceTypeId,
            RelatedPlaces = place.RelatedPlaces,
            Articles = place.Articles
            };
            string str = string.Empty;
            foreach (var p in place.RelatedPlaces)
            {
                str += p.PlaceId.ToString() + ',';
            }
            obj.RelatedPlaceIds = str;
            str = string.Empty;
            foreach (var a in place.Articles)
            {
                str += a.ArticleId.ToString() + ',';
            }
            obj.RelatedArticleIds = str;
            return obj;
        }
    }
}