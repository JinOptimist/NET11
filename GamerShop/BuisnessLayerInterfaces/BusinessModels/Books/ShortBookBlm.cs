using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.BusinessModels.Books
{
    public class ShortBookBlm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ShortAuthorBlm> Authors { get; set; }
    }
}
