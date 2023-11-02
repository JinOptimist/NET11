using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerInterfaces.BusinessModels.BG;

namespace BusinessLayerInterfaces.BgServices
{
    public interface IBgServices
    {
        IEnumerable<BaldursGateBml> GetAllHero();

        void Remove(int id);
        void Save (BaldursGateBml BgBml);

        public AllAtributeForAddingBml GetAllAtribute();
        void CreateNewHero(NewBGBml  NewBGBml);
        CharacterListBml GetCharacterListBml(int page,int perPage);

        

    }
}
