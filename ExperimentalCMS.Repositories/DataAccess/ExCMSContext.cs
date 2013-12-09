using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ExperimentalCMS.Model;

namespace ExperimentalCMS.Repositories.DataAccess
{
    public class ExCMSContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PictureSource> PictureSources { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceType> PlaceTypes { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public ExCMSContext() : base("ExperimentalCMS")
        {
            
        }

        public ExCMSContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<Place>()
                .HasMany(c => c.Articles).WithMany(i => i.Places)
                .Map(t => t.MapLeftKey("PlaceId")
                    .MapRightKey("ArticleId")
                    .ToTable("PlaceArticle"));

            modelBuilder.Entity<Place>()
                .HasMany(u => u.PictureGallery)
                .WithMany(t => t.GalleryPlaces)
                .Map(x =>
                {
                    x.MapLeftKey("PlaceId");
                    x.MapRightKey("PictureId");
                    x.ToTable("PlacesGalleries");
                });

            modelBuilder.Entity<Place>()
                .HasMany(u => u.SlideshowPictures)
                .WithMany(t => t.SlideShowPlaces)
                .Map(x =>
                {
                    x.MapLeftKey("PlaceId");
                    x.MapRightKey("PictureId");
                    x.ToTable("PlacesSlideshows");
                });

            modelBuilder.Entity<Place>()
                .HasOptional(p => p.ParentState)
                    .WithMany(u => u.StateChilds)
                    .HasForeignKey(u => u.ParentStateId);

            modelBuilder.Entity<Place>()
                .HasOptional(p => p.ParentTownCity)
                    .WithMany(u => u.TownCityChilds)
                    .HasForeignKey(u => u.ParentTownCityId);

            modelBuilder.Entity<Place>()
                .HasOptional(p => p.ParentAttraction)
                    .WithMany(u => u.AttractionChilds)
                    .HasForeignKey(u => u.ParentAttractionId);
            
        }
    }
}
