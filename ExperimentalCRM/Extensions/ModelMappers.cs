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
    }
}