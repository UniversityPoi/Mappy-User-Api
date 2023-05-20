using System.Linq;
using MappyUserApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MappyUserApi.Repos
{
    public class UserDbContext : DbContext
    {
        //=============================================================================================
        public DbSet<UserModel> Users { get; set; }
        
        
        //=============================================================================================
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }
    }
}