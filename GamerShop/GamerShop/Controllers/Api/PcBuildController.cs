using BusinessLayerInterfaces.UserServices;
using GamerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PcBuildController : ControllerBase
    {
        private IPcComponentServices _pcComponentServices;

        public PcBuildController(IPcComponentServices pcComponentServices)
        {
            _pcComponentServices = pcComponentServices;
        }

        public List<PcComponentViewModel> GetPcComponentViewModels()
        {
            var viewModel = _pcComponentServices
                .GetAllPcComponents()
                .Select(component => new PcComponentViewModel()
                {
                    Id = component.Id,
                    Category = component.Category,
                    Price = component.Price,
                    Title = component.Title
                })
                .ToList();
            return viewModel;
        }
    }
}
