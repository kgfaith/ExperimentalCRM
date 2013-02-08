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
            var articles = new List<Article>
                            {
                                new Article { ArticleName = "Bagan" ,Title = "Bagan",   Content = "Bagan is beautiful place", CreatedDate = DateTime.Now.AddDays(-10), LastUpdatedDate = DateTime.Now, PublishDate = DateTime.Now},
                                new Article { ArticleName = "Mandalay" ,Title = "Mandalay",   Content = "Mandalay is beautiful place", CreatedDate = DateTime.Now.AddDays(-10), LastUpdatedDate = DateTime.Now, PublishDate = DateTime.Now},
                                new Article { ArticleName = "Taungyi" ,Title = "Taungyi",   Content = "Taungyi is beautiful place", CreatedDate = DateTime.Now.AddDays(-10), LastUpdatedDate = DateTime.Now, PublishDate = DateTime.Now},
                                new Article { ArticleName = "Ngapali" ,Title = "Ngapali",   Content = "Ngapali is beautiful place", CreatedDate = DateTime.Now.AddDays(-10), LastUpdatedDate = DateTime.Now, PublishDate = DateTime.Now},
                            };
            articles.ForEach(s => context.Articles.Add(s));
            context.SaveChanges();

            var placeTypes = new List<PlaceType>
                                 {
                                     new PlaceType{ PlaceTypeName = "Tourist Attraction"}
                                 };

            placeTypes.ForEach(s => context.PlaceTypes.Add(s));
            context.SaveChanges();


            var places = new List<Place>
                             {
                                 new Place{ PlaceName = "Bagan", Description = "Description of bagan", PlaceType = placeTypes[0]},
                                 new Place{ PlaceName = "Mandalay", Description = "Description of mandalay", PlaceType = placeTypes[0]},
                                 new Place{ PlaceName = "Taungyi", Description = "Description of taungyi", PlaceType = placeTypes[0]},
                                 new Place{ PlaceName = "Ngapali", Description = "Description of ngapali", PlaceType = placeTypes[0]},
                             };

            places.ForEach(s => context.Places.Add(s));
            context.SaveChanges();

            articles[0].Places.Add(places[0]);
            articles[1].Places.Add(places[1]);
            articles[2].Places.Add(places[2]);
            articles[3].Places.Add(places[3]);
            context.SaveChanges();

            var pictureSources = new List<PictureSource>
                                     {
                                         new PictureSource{ SourceName = "Flickr"},
                                         new PictureSource{ SourceName = "Instagram"},
                                     };
            pictureSources.ForEach(s => context.PictureSources.Add(s));
            context.SaveChanges();

            var pictures = new List<Picture>
                               {
                                   new Picture{ FileName = "BaganFile", OwnerName = "Ko Kyaw Gyi", Title = "Bagan photo", Description = "Description of bagan photo", PictureSource = pictureSources[0]},
                                   new Picture{ FileName = "Mandalay", OwnerName = "SuperKg", Title = "Mandalay photo", Description = "Description of mandalay photo", PictureSource = pictureSources[0]},
                                   new Picture{ FileName = "Taungyi", OwnerName = "Cool kg", Title = "Taungyi photo", Description = "Description of taungyi photo", PictureSource = pictureSources[1]},
                                   new Picture{ FileName = "Ngapali", OwnerName = "SuperCool Kyaw Gyi", Title = "Ngapali photo", Description = "Description of ngapali photo", PictureSource = pictureSources[1]},
                               };
            pictures.ForEach(s => context.Pictures.Add(s));
            context.SaveChanges();

            pictures[0].Places.Add(places[0]);
            pictures[1].Places.Add(places[1]);
            pictures[2].Places.Add(places[2]);
            pictures[3].Places.Add(places[3]);
            context.SaveChanges();



            string something = "this is something to test and let's see what happen";
            string putSomething = something;
        }
    }
}

