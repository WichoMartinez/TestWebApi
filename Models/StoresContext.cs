using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StoreApi.Models
{
    public class StoresContext : DbContext
    {
      

        public StoresContext(DbContextOptions<StoresContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Place> Place{ get; set; }
        public DbSet<PlaceCategory> PlaceCategory { get; set; }
        public DbSet<VwPlacesCategory> VwPlacesCategory { get; set; }

    }

}
