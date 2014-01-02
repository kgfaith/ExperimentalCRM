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
                                 new Place{ PlaceName = "Yangon", Description = "Description of Yangon city", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state1", Description = "Description of Shan state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state2", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state3", Description = "Description of Shan state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state4", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state5", Description = "Description of Shan state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state6", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state7", Description = "Description of Shan state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state8", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state9", Description = "Description of Shan state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state10", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state11", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state12", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state13", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "state14", Description = "Description of Yangon state", PlaceType = placeTypes[1], PlaceId = placeTypes[1].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown1", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown2", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown3", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown4", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown5", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown6", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown7", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown8", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown9", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown10", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown11", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown12", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown13", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown14", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown15", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown16", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown17", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown18", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown19", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown20", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown21", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown22", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown23", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown24", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown25", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown26", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown27", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown28", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown29", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown30", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown31", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown32", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown33", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown34", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown35", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown36", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown37", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown38", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown39", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown40", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown41", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown42", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown43", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown44", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown45", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown46", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown47", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},
                                 new Place{ PlaceName = "CityTown48", Description = "Description of taungyi", PlaceType = placeTypes[2], PlaceId = placeTypes[2].PlaceTypeId, InternalRanking = 1},


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

