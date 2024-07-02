using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;

namespace P7CreateRestApi.Services
{
    public interface ICurvePointService
    {
        public List<CurvePointOutputModel> List();
        public CurvePointOutputModel? Create(CurvePointInputModel inputModel);
        public CurvePointOutputModel? Get(int id);
        public CurvePointOutputModel? Update(int id, CurvePointInputModel inputModel);
        public CurvePointOutputModel? Delete(int id);
    }
}
