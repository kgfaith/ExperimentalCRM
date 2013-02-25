using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExperimentalCMS.Model.DataAccess
{
    public class ExCrmContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PictureSource> PictureSources { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceType> PlaceTypes { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public ExCrmContext() : base("ExperimentalCrm")
        {
            
        }

        public ExCrmContext(string nameOrConnectionString)
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
            modelBuilder.Entity<Picture>()
                .HasMany(c => c.Places).WithMany(i => i.Pictures)
                .Map(t => t.MapLeftKey("PictureId")
                    .MapRightKey("PlaceId")
                    .ToTable("PicturePlace"));
        }
    }
}
