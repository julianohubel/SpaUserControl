using SpaUserControlDataContex.domain.Model;
using SpaUserControlDataContex.Infrastructure.Data.Map;
using System.Data.Entity;

namespace SpaUserControlDataContex.Infrastructure.Data
{
    public class SpaUserControlDataContext : DbContext
    {
        public SpaUserControlDataContext():base("SpaUserControlDataContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }


    }
}
