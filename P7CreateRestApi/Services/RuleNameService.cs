using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class RuleNameService : IRuleNameService
    {
        private readonly IRuleNameRepository _ruleNameRepository;
        public RuleNameService(IRuleNameRepository ruleNameRepository)
        {
            _ruleNameRepository = ruleNameRepository;
        }
        /// <summary>Rule Service Create method. 
        /// Call CRUD method in the Rule Repository with Rule POCO object to create. 
        /// Store created record into DTO object and returns POCO output model object.</summary>  
        /// <param name="inputModel">Rule POCO input model object.</param>
        /// <return>Rule POCO output model object.</return> 
        /// <remarks></remarks>
        public RuleNameOutputModel? Create(RuleNameInputModel inputModel)
        {
            var ruleName = new RuleName
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                Json = inputModel.Json,
                Template = inputModel.Template,
                SqlStr = inputModel.SqlStr,
                SqlPart = inputModel.SqlPart,
            };
            _ruleNameRepository.Create(ruleName);
            return ToOutputModel(ruleName);
        }
        /// <summary>Rule Service Delete method. 
        /// Call CRUD method in the Rule Repository with Rule id tot delete. 
        /// Store deleted record into DTO object and returns POCO object if found or null</summary>  
        /// <param name="id">Id of the Rule record to delete.</param>
        /// <return>Rule POCO object or null.</return> 
        /// <remarks></remarks>
        public RuleNameOutputModel? Delete(int id)
        {
            var ruleName = _ruleNameRepository.Delete(id);
            if (ruleName is not null)
            {
                return ToOutputModel(ruleName);
            }
            return null;
        }
        /// <summary>Rule Service Get method. 
        /// Call Get method in the Rule Repository with Rule id to get. 
        /// Store record into DTO object and returns POCO output model object if found or null. </summary>  
        /// <param name="id">Id of the Rule record to get.</param>
        /// <return>Rule POCO output model object or null.</return> 
        /// <remarks></remarks>
        public RuleNameOutputModel? Get(int id)
        {
            var ruleName = _ruleNameRepository.Get(id);
            if (ruleName is not null)
            {
                return ToOutputModel(ruleName);
            }
            return null;
        }
        /// <summary>Rule Service List method. 
        /// Call List method in the Rule Repository. 
        /// Get DTO objects list and returns POCO output model objects list.</summary>          
        /// <return>Rule POCO output model object list.</return> 
        /// <remarks></remarks>
        public List<RuleNameOutputModel> List()
        {
            var list = new List<RuleNameOutputModel>();
            var ruleNames = _ruleNameRepository.List();
            foreach (var ruleName in ruleNames)
            {
                list.Add(ToOutputModel(ruleName));
            }
            return list;
        }
        /// <summary>Rule Service Update method. 
        /// Call CRUD method in the Rule Repository with Rule id to update 
        /// and BidList POCO object to update. 
        /// Store updated record into DTO object and returns POCO output model object if found or null.</summary>  
        /// <param name="id">Id of the Rule record to get.</param>
        /// <param name="inputModel">Rule POCO input model object.</param>
        /// <return>Rule POCO output model object or null.</return> 
        /// <remarks></remarks>
        public RuleNameOutputModel? Update(int id, RuleNameInputModel inputModel)
        {
            var ruleName = _ruleNameRepository.Update(new RuleName
            {
                Id = id,
                Name = inputModel.Name,
                Description = inputModel.Description,
                Json = inputModel.Json,
                Template = inputModel.Template,
                SqlStr = inputModel.SqlStr,
                SqlPart = inputModel.SqlPart,
            });
            if (ruleName is not null)
            {
                return ToOutputModel(ruleName);
            }
            return null;
        }
        /// <summary>Rule Service ToOutputModel method. 
        /// Load Rule DTO object properties into POCO uutput model object.</summary>  
        /// <param name="ruleName">Rule DTO output model object.</param>
        /// <remarks></remarks>
        private RuleNameOutputModel ToOutputModel(RuleName ruleName) => new RuleNameOutputModel
            {
                Id = ruleName.Id,
                Name = ruleName.Name,
                Description = ruleName.Description,
                Json = ruleName.Json,
                Template = ruleName.Template,
                SqlStr = ruleName.SqlStr,
                SqlPart = ruleName.SqlPart
            };
    }
}
