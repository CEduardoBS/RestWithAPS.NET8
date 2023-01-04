using RestWithASPNETudemy.Model;

namespace RestWithASPNETudemy.Business
{
    public interface IBooksBusiness
    {
        Books create(Books books);

        Books FindById(long id);

        List<Books> FindAll();

        Books Update(Books books);

        void Delete(long id);

    }
}
