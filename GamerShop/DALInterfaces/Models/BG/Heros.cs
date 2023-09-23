using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.Models.BG
{
    public class Heros : BaseModel
    {

        public string Name { get; set; }
        public int Bone { get; set; }

        public virtual Race Race { get; set; }
        public virtual Subrace? Subrace { get; set; }
        public virtual Class  Class{ get; set; }
        public virtual Оrigin Оrigin { get; set; }
        public virtual User UserCreator { get; set; }

    }
}
