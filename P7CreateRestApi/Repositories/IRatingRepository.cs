using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IRatingRepository
    {
        public List<Rating> List();
        public void Create(Rating rating);
        public Rating? Get(int id);
        public Rating? Update(Rating rating);
        public Rating? Delete(int id);
    }
}
