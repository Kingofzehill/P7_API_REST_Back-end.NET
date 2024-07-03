using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dot.Net.WebApi.Repositories
{
    public class UserRepository
    {
        private readonly LocalDbContext _dbContext;
        
        public UserRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>User Repository FindByUserName method.</summary>  
        /// <param name="username">Username to find.</param>
        /// <return>DTO User class object.</return> 
        /// <remarks></remarks>
        public User? FindByUserName(string username) => _dbContext.Users.FirstOrDefault(user => user.UserName == username);
        /// <summary>User Repository FindAll method.</summary>          
        /// <return>List of all users.</return> 
        /// <remarks></remarks>
        public async Task<List<User>> FindAll()
        {
            return await _dbContext.Users.ToListAsync();
        }
        /// <summary>User Repository Add method. Add a new user and save it.</summary>          
        /// <param name="user">DTO User class object to add.</param>
        /// <return></return> 
        /// <remarks></remarks>
        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        /// <summary>User Repository FindById method.</summary>          
        /// <param name="id">Id of the user to find.</param>
        /// <return>DTO User class object.</return> 
        /// <remarks></remarks>
        public User? FindById(int id) => _dbContext.Users.FirstOrDefault(user => user.Id == id);
    }
}