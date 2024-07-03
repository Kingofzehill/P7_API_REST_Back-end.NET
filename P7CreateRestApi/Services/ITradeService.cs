using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;

namespace P7CreateRestApi.Services
{
    public interface ITradeService
    {
        public List<TradeOutputModel> List();
        public TradeOutputModel? Create(TradeInputModel inputModel);
        public TradeOutputModel? Get(int id);
        public TradeOutputModel? Update(int id, TradeInputModel inputModel);
        public TradeOutputModel? Delete(int id);
    }
}
