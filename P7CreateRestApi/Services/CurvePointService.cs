using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class CurvePointService : ICurvePointService
    {
        private readonly ICurvePointRepository _curvePointRepository;
        public CurvePointService(ICurvePointRepository curvePointRepository)
        {
            _curvePointRepository = curvePointRepository;
        }

        /// <summary>CurvePoint Service List method. 
        /// Call List method in the CurvePoint Repository. 
        /// Get DTO objects list and returns POCO output model objects list.</summary>          
        /// <return>CurvePoint POCO output model object list.</return> 
        /// <remarks></remarks>
        public List<CurvePointOutputModel> List()
        {
            var list = new List<CurvePointOutputModel>();
            var curvePoints = _curvePointRepository.List();
            foreach (var curvePoint in curvePoints)
            {
                list.Add(ToOutputModel(curvePoint));
            }
            return list;
        }
        /// <summary>CurvePoint Service Create method. 
        /// Call CRUD method in the CurvePoint Repository with CurvePoint POCO object to create. 
        /// Store created record into DTO object and returns POCO output model object.</summary>  
        /// <param name="inputModel">CurvePoint POCO input model object.</param>
        /// <return>CurvePoint POCO output model object.</return> 
        /// <remarks></remarks>
        public CurvePointOutputModel? Create(CurvePointInputModel inputModel)
        {
            var curvePoint = new CurvePoint
            {
                CurveId = inputModel.CurveId,
                AsOfDate = inputModel.AsOfDate,
                Term = inputModel.Term,
                CurvePointValue = inputModel.CurvePointValue,
                CreationDate = DateTime.Now
            };
            _curvePointRepository.Create(curvePoint);
            return ToOutputModel(curvePoint);
        }
        /// <summary>CurvePoint Service Get method. 
        /// Call Get method in the CurvePoint Repository with CurvePoint id to get. 
        /// Store record into DTO object and returns POCO output model object if found or null. </summary>  
        /// <param name="id">Id of the CurvePoint record to get.</param>
        /// <return>CurvePoint POCO output model object or null.</return> 
        /// <remarks></remarks>
        public CurvePointOutputModel? Get(int id)
        {
            var curvePoint = _curvePointRepository.Get(id);
            if (curvePoint is not null)
            {
                return ToOutputModel(curvePoint);
            }
            return null;
        }
        /// <summary>CurvePoint Service Update method. 
        /// Call CRUD method in the CurvePoint Repository with CurvePoint id to update 
        /// and BidList POCO object to update. 
        /// Store updated record into DTO object and returns POCO output model object if found or null.</summary>  
        /// <param name="id">Id of the CurvePoint record to get.</param>
        /// <param name="inputModel">CurvePoint POCO input model object.</param>
        /// <return>CurvePoint POCO output model object or null.</return> 
        /// <remarks></remarks>
        public CurvePointOutputModel? Update(int id, CurvePointInputModel inputModel)
        {
            var curvePoint = _curvePointRepository.Update(new CurvePoint
            {
                Id = id,
                CurveId = inputModel.CurveId,
                AsOfDate = inputModel.AsOfDate,
                Term = inputModel.Term,
                CurvePointValue = inputModel.CurvePointValue,
                CreationDate = DateTime.Now
            });
            if (curvePoint is not null)
            {
                return ToOutputModel(curvePoint);
            }
            return null;
        }
        /// <summary>CurvePoint Service Delete method. 
        /// Call CRUD method in the CurvePoint Repository with CurvePoint id tot delete. 
        /// Store deleted record into DTO object and returns POCO object if found or null</summary>  
        /// <param name="id">Id of the CurvePoint record to delete.</param>
        /// <return>CurvePoint POCO object or null.</return> 
        /// <remarks></remarks>
        public CurvePointOutputModel? Delete(int id)
        {
            var curvePoint = _curvePointRepository.Delete(id);
            if (curvePoint is not null)
            {
                return ToOutputModel(curvePoint);
            }
            return null;
        }
        /// <summary>CurvePoint Service ToOutputModel method. 
        /// Load CurvePoint DTO object properties into POCO uutput model object.</summary>  
        /// <param name="curvePoint">CurvePoint DTO output model object.</param>
        /// <remarks></remarks>
        private CurvePointOutputModel ToOutputModel(CurvePoint curvePoint) =>
            new CurvePointOutputModel
            {
                Id = curvePoint.Id,
                CurveId = curvePoint.CurveId,
                AsOfDate = curvePoint.AsOfDate,
                CurvePointValue = curvePoint.CurvePointValue,
                Term = curvePoint.Term,
                CreationDate = curvePoint.CreationDate
            };
    }
}
