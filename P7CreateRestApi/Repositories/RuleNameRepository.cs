using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{    
    public class RuleNameRepository : IRuleNameRepository
    {        
        private readonly LocalDbContext _dbContext;
        public RuleNameRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>Rule Repository Create method.</summary>  
        /// <param name="ruleName">Rule DTO object</param>
        /// <return></return> 
        /// <remarks></remarks>
        public void Create(RuleName ruleName)
        {
            _dbContext.Rules.Add(ruleName);
            _dbContext.SaveChanges();
        }
        /// <summary>Rule Repository delete method.</summary>      
        /// <return>Updated Rule.</return> 
        /// <param name="id">Rule id to delete.</param>
        /// <remarks></remarks>
        public RuleName? Delete(int id)
        {
            var ruleName = _dbContext.Rules.FirstOrDefault(r => r.Id == id);
            if (ruleName is not null)
            {
                _dbContext.Rules.Remove(ruleName);
                _dbContext.SaveChanges();
            }
            return ruleName;
        }
        /// <summary>Rule Repository Get method.</summary>      
        /// <return></return> 
        /// <param name="id">Rule id to get.</param>
        /// <remarks></remarks>
        public RuleName? Get(int id) => _dbContext.Rules.FirstOrDefault(r => r.Id == id);
        /// <summary>Rule Repository List method.</summary>      
        /// <return>List of Rule DTO objects.</return> 
        /// <remarks></remarks>
        public List<RuleName> List() => _dbContext.Rules.ToList();
        /// <summary>Rule Repository Update method.</summary>      
        /// <return>Updated Rule.</return> 
        /// <param name="ruleName">Rule DTO object.</param>
        /// <remarks></remarks>
        public RuleName? Update(RuleName ruleName)
        {
            var ruleNameAModifier = _dbContext.Rules.FirstOrDefault(r => r.Id == ruleName.Id);
            if (ruleNameAModifier is not null)
            {
                ruleNameAModifier.Name = ruleName.Name;
                ruleNameAModifier.Description = ruleName.Description;
                ruleNameAModifier.Json = ruleName.Json;
                ruleNameAModifier.Template = ruleName.Template;
                ruleNameAModifier.SqlStr = ruleName.SqlStr;
                ruleNameAModifier.SqlPart = ruleName.SqlPart;
                _dbContext.SaveChanges();
            }
            return ruleNameAModifier;
        }
    }
}

