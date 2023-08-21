using BusinessLayerInterfaces.RockHallServices;
using DALInterfaces.Repositories;
using GamerShop.Models;
using GamerShop.Models.RockHall;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RockHallController : ControllerBase
    {

        IRockMemberServices _rockMemberServices;

        public RockHallController(IRockMemberServices rockMemberServices)
        {
            _rockMemberServices = rockMemberServices;
        }

        public List<InfoMemberViewModel> GetRockMemberViewModel()
        {
            var viewModels = _rockMemberServices
                .GetAll()
                .Select(dbMember => new InfoMemberViewModel
                {
                    Id = dbMember.Id,
                    FullName = dbMember.FullName,
                    Genre = dbMember.Genre,
                    YearOfBirth = dbMember.YearOfBirth,
                    EntryYear = dbMember.EntryYear
                }).ToList();

            return viewModels;
        }
    }
}
