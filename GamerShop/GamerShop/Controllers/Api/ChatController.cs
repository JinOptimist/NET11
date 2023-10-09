using DALInterfaces.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : Controller
    {
        public List<ChatMessageDataModel> GetLastMessages()
        {
            var list = new List<ChatMessageDataModel>()
            {
                new ChatMessageDataModel
                {
                    UserName= "Admin",
                    Message = "Hi"
                },
                new ChatMessageDataModel
                {
                    UserName= "User",
                    Message = "I'm leave"
                },
            };

            //TODO Get real message from DB
            return list;
        }
    }
}
