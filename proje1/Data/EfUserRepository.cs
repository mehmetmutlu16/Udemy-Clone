using proje1.Data.Abstract;
using proje1.Data;

namespace proje1.Data{
    public class EfUserRepository: IUserRepository{

        private DataContext _context;

        public EfUserRepository(DataContext context){
            _context = context;
        }

        public IQueryable<Ogrenci> Users=> _context.Ogrenciler;

        public void CreateUser(Ogrenci user){
            _context.Ogrenciler.Add(user);
            _context.SaveChanges();
        }

        




    }
}

