
namespace proje1.Data.Abstract{
    public interface IUserRepository{
        IQueryable<Ogrenci> Users{get; }
        void CreateUser(Ogrenci user);

    }
}