using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class CurvePointRepository : ICurvePointRepository
    {
        private readonly LocalDbContext _dbContext;

        public CurvePointRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>CurvePoint Repository List method.</summary>      
        /// <return>List of CurvePoint DTO objects.</return> 
        /// <remarks></remarks>
        public List<CurvePoint> List() => _dbContext.CurvePoints.ToList();

        /// <summary>CurvePoint Repository Create method.</summary>  
        /// <param name="curvePoint">CurvePoint DTO object</param>
        /// <return></return> 
        /// <remarks></remarks>
        public void Create(CurvePoint curvePoint)
        {
            _dbContext.CurvePoints.Add(curvePoint);
            _dbContext.SaveChanges();
        }

        /// <summary>CurvePoint Repository Get method.</summary>      
        /// <return></return> 
        /// <param name="id">CurvePoint id to get.</param>
        /// <remarks></remarks>
        public CurvePoint? Get(int id) => _dbContext.CurvePoints.FirstOrDefault(c => c.Id == id);

        /// <summary>CurvePoint Repository Update method.</summary>      
        /// <return>Updated CurvePoint.</return> 
        /// <param name="curvePoint">CurvePoint DTO object.</param>
        /// <remarks></remarks>
        public CurvePoint? Update(CurvePoint curvePoint)
        {
            var curvePointAModifier = _dbContext.CurvePoints.FirstOrDefault(c => c.Id == curvePoint.Id);
            if (curvePointAModifier is not null)
            {
                curvePointAModifier.CurveId = curvePoint.CurveId;
                curvePointAModifier.AsOfDate = curvePoint.AsOfDate;
                curvePointAModifier.CurvePointValue = curvePoint.CurvePointValue;
                _dbContext.SaveChanges();
            }
            return curvePointAModifier;
        }
        /// <summary>CurvePoint Repository delete method.</summary>      
        /// <return>Updated CurvePoint.</return> 
        /// <param name="id">CurvePoint id to delete.</param>
        /// <remarks></remarks>
        public CurvePoint? Delete(int id)
        {
            var curvePoint = _dbContext.CurvePoints.FirstOrDefault(c => c.Id == id);
            if (curvePoint is not null)
            {
                _dbContext.CurvePoints.Remove(curvePoint);
                _dbContext.SaveChanges();
            }
            return curvePoint;
        }
    }
}
