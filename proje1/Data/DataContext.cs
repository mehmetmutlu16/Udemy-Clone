using Microsoft.EntityFrameworkCore;

namespace proje1.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        }

        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();
        public DbSet<Resimler> Resimler => Set<Resimler>();
        public DbSet<Videolar> Videolar => Set<Videolar>();



    }

}