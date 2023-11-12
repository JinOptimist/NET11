using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.BookServices
{
    public interface IAuthorServices 
    {
        IEnumerable<AuthorBlm> GetAll();

        void Save(AuthorBlm authorBlm);

        void Remove(int id);
    }
}
