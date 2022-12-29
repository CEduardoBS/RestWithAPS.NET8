﻿using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithASPNETudemy.Model;
using RestWithASPNETudemy.Model.Context;
using System;

namespace RestWithASPNETudemy.Service.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            List<Person> Peoples = new List<Person>();

            return _context.People.ToList();
        }


        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public Person Update(Person person)
            {
                if (!Exists(person.Id)) return new Person();
            
                var result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));

                if (result != null) 
                {
                    try
                    {
                        _context.Entry(result).CurrentValues.SetValues(person);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

                return person;
            }

        public void Delete(long id)
        {
            var result = _context.People.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        private bool Exists(long id)
        {
            return _context.People.Any(p => p.Id.Equals(id));
        }
    }
}
