using DALInterfaces.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.DataModels.Books
{
    public class ShortBookDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ShortAuthorDataModel> Authors { get; set; }
    }
}
