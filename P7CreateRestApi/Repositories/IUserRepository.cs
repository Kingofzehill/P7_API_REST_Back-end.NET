using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IUserRepository
    {
        public User? FindByUserName(string username);
        public Task<List<User>> FindAll();
        public void Add(User user);
        public User? FindById(int id);
    }
}
