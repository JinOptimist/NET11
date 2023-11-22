using DALInterfaces.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.Models.Books
{
    public class Author : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public int? YearOfDeath { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
