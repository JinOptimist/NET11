using GamerShop.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GamerShop.Hubs
{
    public class ChatHub : Hub
    {
        private IAuthService _authService;

        public ChatHub(IAuthService authService)
        {
            _authService = authService;
        }

        public void AddNewMessage(string message)
        {
            // TODO: Add to DB
            // _chatRepository.Save(message);

            // Notify all users about update
            var userName = _authService.GetCurrentUser().Name;
            Clients.All.SendAsync("SomeOneAddNewMessage", userName, message);
        }
    }
}
