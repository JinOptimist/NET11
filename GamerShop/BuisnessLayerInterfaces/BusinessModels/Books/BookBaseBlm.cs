using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayerInterfaces.BusinessModels.Books
{
    public class BookBaseBlm
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
    }
}
