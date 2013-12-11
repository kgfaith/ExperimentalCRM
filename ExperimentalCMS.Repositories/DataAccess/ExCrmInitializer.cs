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
                                     new PlaceType{ PlaceTypeName = "Tourist Attraction"},
                                     new PlaceType{ PlaceTypeName = "State"},
                                     new PlaceType{ PlaceTypeName = "City/Town"}
                                 };

            placeTypes.ForEach(s => context.PlaceTypes.Add(s));
            context.SaveChanges();


            var places = new List<Place>
                             {
                                 new Place{ PlaceName = "Bagan", Description = "Description of bagan", PlaceType = placeTypes[0], PlaceId = placeTypes[0].PlaceTypeId, InternalRanking = 1, },
                                 new Place{ PlaceName = "Mandalay", Description = "Description of mandalay", PlaceType = placeTypes[0], PlaceId = placeTypes[0].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "Taungyi", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "Ngapali", Description = "Description of ngapali", PlaceType = placeTypes[0], PlaceId = placeTypes[0].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "Shan state", Description = "Description of Shan state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "Yangon state", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "Yangon", Description = "Description of Yangon city", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1}

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
                                         new PictureSource{ SourceName = "Normal"},
                                         new PictureSource{ SourceName = "Flickr"},
                                     };
            pictureSources.ForEach(s => context.PictureSources.Add(s));
            context.SaveChanges();

            var pictures = new List<Picture>
                               {
                                   new Picture{ FileName = "1c3e2fcb-25ba-4695-a3e3-a4cb2eb5ffdd.jpg", OwnerName = "Ko Kyaw Gyi", Title = "Bagan Kalaw photo", Description = "Description Kalaw of bagan photo", PictureSource = pictureSources[0], ImageUrl = "/Content/Upload/1dcf528b-cec4-476b-959e-55e2892c051c.jpg"}, 
                                   new Picture{ FileName = "1dcf528b-cec4-476b-959e-55e2892c051c.jpg", OwnerName = "SuperKg", Title = "Mandalay Kalaw photo", Description = "Description Kalaw of mandalay photo", PictureSource = pictureSources[0], ImageUrl = "/Content/Upload/1dcf528b-cec4-476b-959e-55e2892c051c.jpg"},
                                   new Picture{ FileName = "7430026648", OwnerName = "Cool kg", Title = "Taungyi Bagan photo", Description = "Description of taungyi Kalaw photo", PictureSource = pictureSources[1], ImageUrl = "http://farm6.staticflickr.com/5071/7430026378_6068a6fb77.jpg"},
                                   new Picture{ FileName = "8966469", OwnerName = "SuperCool Kyaw Gyi", Title = "Ngapali photo", Description = "Description of ngapali photo", PictureSource = pictureSources[1], ImageUrl = "http://farm1.staticflickr.com/4/8966469_3ce6afca40.jpg"},
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

