using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface ITradeRepository
    {
        public List<Trade> List();
        public void Create(Trade trade);
        public Trade? Get(int id);
        public Trade? Update(Trade trade);
        public Trade? Delete(int id);
    }
}
