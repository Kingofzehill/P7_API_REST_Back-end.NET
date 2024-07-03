using P7CreateRestApi.Models.InputModels;
using P7CreateRestApi.Models.OutputModels;

namespace P7CreateRestApi.Services
{
    public interface IRuleNameService
    {
        public List<RuleNameOutputModel> List();
        public RuleNameOutputModel? Create(RuleNameInputModel inputModel);
        public RuleNameOutputModel? Get(int id);
        public RuleNameOutputModel? Update(int id, RuleNameInputModel inputModel);
        public RuleNameOutputModel? Delete(int id);
    }
}
