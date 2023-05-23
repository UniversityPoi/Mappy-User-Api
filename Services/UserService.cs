using System;
using System.Threading.Tasks;
using MappyUserApi.Models;
using MappyUserApi.Repos;
using Microsoft.EntityFrameworkCore;

namespace MappyUserApi.Services
{
  public class UserService
  {
    private readonly UserDbContext _db;


    public UserService(UserDbContext dbContext)
    {
      _db = dbContext;
    }


    public async Task<bool> AddAsync(UserModel user)
    {
      await _db.Users.AddAsync(user);

      var changedEntries = await _db.SaveChangesAsync();

      return changedEntries > 0;
    }


    public async Task<UserModel?> GetAsync(Guid id)
    {
      return await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
    }


    public async Task<UserModel?> GetAsync(string email)
    {
      return await _db.Users.FirstOrDefaultAsync(user => user.Email == email);
    }


    public async Task<bool> ExistByEmail(string email)
    {
      return await _db.Users.AnyAsync(user => user.Email == email);
    }
  }
}