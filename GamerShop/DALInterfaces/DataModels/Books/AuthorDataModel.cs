using DALInterfaces.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.DataModels.Books
{
    public class AuthorDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfIssue { get; set; }
        public virtual ICollection<ShortBookDataModel> Books { get; set; }
    }
}
