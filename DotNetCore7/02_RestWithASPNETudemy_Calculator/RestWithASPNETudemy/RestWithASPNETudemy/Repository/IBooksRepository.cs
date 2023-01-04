using RestWithASPNETudemy.Model;

namespace RestWithASPNETudemy.Repository
{
    public interface IBooksRepository
    {
        Books create(Books books);

        Books FindById(long id);

        List<Books> FindAll();

        Books Update(Books books);

        void delete(long id);

        bool Exists(long id);

    }
}
