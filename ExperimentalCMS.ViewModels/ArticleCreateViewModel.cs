using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.ViewModels
{
    public class ArticleCreateViewModel
    {
        public int ArticleId { get; set; }

        [Display(Name = "Article Name")]
        [MaxLength(50, ErrorMessage = "Article name cannot be more than {0} string length")]
        public string ArticleName { get; set; }

        [MaxLength(200, ErrorMessage = "Article title cannot be more than {0} string length")]
        public string Title { get; set; }

        [MaxLength(25000)]
        [AllowHtml]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        public ICollection<Place> Places { get; set; }

        public Article TransformToArticle()
        {
            Article articleObj = new Article();
            articleObj.ArticleId = ArticleId;
            articleObj.ArticleName = ArticleName;
            articleObj.Title = Title;
            articleObj.Content = Content;
            articleObj.CreatedDate = CreatedDate;
            articleObj.LastUpdatedDate = LastUpdatedDate;
            articleObj.PublishDate = PublishDate;
            articleObj.Places = Places;
            return articleObj;
        }
    }
}