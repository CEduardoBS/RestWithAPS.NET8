using Microsoft.AspNetCore.Http.HttpResults;
using RestWithASPNETudemy.Business;
using RestWithASPNETudemy.Model;
using RestWithASPNETudemy.Model.Context;
using System;

namespace RestWithASPNETudemy.Repository.Implementations
{
    public class BooksRepositoryImplemantation : IBooksRepository
    {
        private MySQLContext _context;

        public BooksRepositoryImplemantation(MySQLContext context)
        {
            _context = context;
        }
        
        public List<Books> FindAll()
        {
            List<Books> Libraries = new List<Books>();

            return _context.Library.ToList();
        }
        public Books FindById(long id)
        {
            return _context.Library.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Books create(Books books)
        {
            try
            {
                _context.Add(books);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return books;
        }

        public Books Update(Books books)
        {
            if (!Exists(books.Id)) return null;

            var result = _context.Library.SingleOrDefault(p => p.Id.Equals(books.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(books);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return books;
        }
        public void delete(long id)
        {
            var result = _context.Library.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                _context.Library.Remove(result);
                _context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Exists(long id)
        { 
            return _context.Library.Any(p => p.Id.Equals(id)); 
        }
    }
}
