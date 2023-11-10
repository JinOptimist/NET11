using ChatApi.DatabaseStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.DatabaseStuff
{
    public class ChatApiContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public ChatApiContext(DbContextOptions<ChatApiContext> options) : base(options) { }
    }
}
