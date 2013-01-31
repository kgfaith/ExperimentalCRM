using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Model.DataAccess
{
    public class ExCrmInitializer : DropCreateDatabaseIfModelChanges<ExCrmContext>
    {
        protected override void Seed(ExCrmContext context)
        {
            var students = new List<Article>
            {
                new Article { Title = "Bagan",   Content = "Bagan is beautiful place", CreatedDate = DateTime.Now.AddDays(-10), LastUpdatedDate = DateTime.Now, PublishDate = DateTime.Now},
                new Article { Title = "Mandalay",   Content = "Mandalay is beautiful place", CreatedDate = DateTime.Now.AddDays(-10), LastUpdatedDate = DateTime.Now, PublishDate = DateTime.Now},
                new Article { Title = "Taungyi",   Content = "Taungyi is beautiful place", CreatedDate = DateTime.Now.AddDays(-10), LastUpdatedDate = DateTime.Now, PublishDate = DateTime.Now},
                new Article { Title = "Ngapali",   Content = "Ngapali is beautiful place", CreatedDate = DateTime.Now.AddDays(-10), LastUpdatedDate = DateTime.Now, PublishDate = DateTime.Now},
            };
            students.ForEach(s => context.Articles.Add(s));
            context.SaveChanges();
        }
    }
}

