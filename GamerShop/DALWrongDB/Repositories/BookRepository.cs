using DALInterfaces.Models;
using DALInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWrongDB.Repositories
{
    public class BookRepository: IBookRepository
    {
        private static List<Book> _Books = new List<Book>();

        public IEnumerable<Book> GetAll()
        {
            return _Books;
        }

        public void Save(Book book)
        {
            _Books.Add(book);
        }
    }
}
