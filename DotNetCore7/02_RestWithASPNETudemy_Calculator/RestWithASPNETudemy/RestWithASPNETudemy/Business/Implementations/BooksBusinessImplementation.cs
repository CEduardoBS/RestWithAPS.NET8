using RestWithASPNETudemy.Model;
using RestWithASPNETudemy.Repository;

namespace RestWithASPNETudemy.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IBooksRepository _repository;
        
        public BooksBusinessImplementation(IBooksRepository repository)
        {
            _repository = repository;
        }
        public List<Books> FindAll()
        {
            List<Books> Library = new List<Books>();

            return _repository.FindAll();
        }
        public Books FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Books create(Books books)
        {
            return _repository.create(books);
        }
        public Books Update(Books books)
        {
            return _repository.Update(books);
        }

        public void Delete(long id)
        {
            _repository.delete(id);
        }

    }
}
