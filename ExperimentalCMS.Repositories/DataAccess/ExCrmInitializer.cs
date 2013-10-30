using System;
using System.Collections.Generic;
using System.Data.Entity;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Repositories.DataAccess
{
    public class ExCrmInitializer : DropCreateDatabaseIfModelChanges<ExCMSContext>
    {
        protected override void Seed(ExCMSContext context)
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
                                 new Place{ PlaceName = "Bagan", Description = "Description of bagan", PlaceType = placeTypes[0], PlaceId = placeTypes[0].PlaceTypeId, InternalRanking = 1, },
                                 new Place{ PlaceName = "Mandalay", Description = "Description of mandalay", PlaceType = placeTypes[0], PlaceId = placeTypes[0].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "Taungyi", Description = "Description of taungyi", PlaceType = placeTypes[0], PlaceId = placeTypes[0].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "Ngapali", Description = "Description of ngapali", PlaceType = placeTypes[0], PlaceId = placeTypes[0].PlaceTypeId, InternalRanking = 1},
                             };

            places.ForEach(s => context.Places.Add(s));
            context.SaveChanges();

            articles[0].Places = new List<Place>{ places[0]};
            articles[1].Places = new List<Place> { places[1]};
            articles[2].Places = new List<Place> { places[2] };
            articles[3].Places = new List<Place> { places[3] };
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

            var admins = new List<Admin>
                            {
                                new Admin { FirstName = "Ahboo", LastName = "Admin", Email = "kg.faith@gmail.com", UserName = "SuperCoolKg" ,DateCreated = DateTime.Parse("2011-02-03"), Activated = true, Password = "Test1234"},
                                new Admin { FirstName = "BabyLay", LastName = "Nge", Email = "babylay@gmail.com", UserName = "BabyLay" ,DateCreated = DateTime.Parse("2011-02-12"), Activated = true, Password = "Test1234"},
                                new Admin { FirstName = "Lao", LastName = "Nan", Email = "lao@gmail.com", UserName = "Lao" ,DateCreated = DateTime.Parse("2011-05-23"), Activated = true, Password = "Test1234"}
                            };
            admins.ForEach(u => context.Admins.Add(u));
            context.SaveChanges();
        }
    }
}

