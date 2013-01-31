using System;



namespace Model
{
    public class Article 
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
