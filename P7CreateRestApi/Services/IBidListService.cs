using P7CreateRestApi.Models.InputModels;
using P7CreateRestApi.Models.OutputModel;

namespace P7CreateRestApi.Services
{
    public interface IBidListService
    {
        public List<BidListOutputModel> List();
        public BidListOutputModel? Create(BidListInputModel inputModel);
        public BidListOutputModel? Get(int id);
        public BidListOutputModel? Update(int id, BidListInputModel inputModel);
        public BidListOutputModel? Delete(int id);
    }
}
