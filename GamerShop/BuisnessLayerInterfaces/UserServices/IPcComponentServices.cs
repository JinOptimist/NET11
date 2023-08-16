using BusinessLayerInterfaces.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.UserServices
{
    public interface IPcComponentServices
    {
        IEnumerable<PcComponentBlm> GetAllPcComponents();

        void Remove(int id);
        void Save(PcComponentBlm pcComponentBlm);
    }
}
