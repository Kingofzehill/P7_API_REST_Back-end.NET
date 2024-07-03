using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;

namespace P7CreateRestApi.Services
{
    public interface IRatingService
    {
        public List<RatingOutputModel> List();
        public RatingOutputModel? Create(RatingInputModel inputModel);
        public RatingOutputModel? Get(int id);
        public RatingOutputModel? Update(int id, RatingInputModel inputModel);
        public RatingOutputModel? Delete(int id);
    }
}
