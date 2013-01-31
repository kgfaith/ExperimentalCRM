using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

namespace Model.DataAccess
{
    public class ExCrmContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ExCrmContext() : base("ExperimentalCrm")
        {
            
        }

        public ExCrmContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<ExCrmContext>(null);
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Article>().ToTable("Article");
        }
    }
}
