﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExperimentalCMS.Model
{
    public class Article 
    {
        public Article()
        {
            LastUpdatedDate = DateTime.Now;
        }
        
        public int ArticleId { get; set; }

        [Display(Name = "Article Name")]
        [MaxLength(50, ErrorMessage = "Article name cannot be more than {0} string length")]
        public string ArticleName { get; set; }

        [MaxLength(200, ErrorMessage = "Article title cannot be more than {0} string length")]
        public string Title { get; set; }

        [MaxLength(25001)]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDate { get; set; }
       

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
