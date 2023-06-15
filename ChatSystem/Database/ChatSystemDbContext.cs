using ChatSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ChatSystem.Data
{
    public class ChatSystemDbContext : DbContext
    {
        public ChatSystemDbContext(DbContextOptions<ChatSystemDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
}
