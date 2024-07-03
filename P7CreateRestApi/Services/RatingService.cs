using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        /// <summary>Rating Service Create method. 
        /// Call CRUD method in the Rating Repository with Rating POCO object to create. 
        /// Store created record into DTO object and returns POCO output model object.</summary>  
        /// <param name="inputModel">Rating POCO input model object.</param>
        /// <return>Rating POCO output model object.</return> 
        /// <remarks></remarks>
        public RatingOutputModel? Create(RatingInputModel inputModel)
        {
            var rating = new Rating
            {
                MoodysRating = inputModel.MoodysRating,
                SandPRating = inputModel.SandPRating,
                FitchRating = inputModel.FitchRating,
                OrderNumber = inputModel.OrderNumber
            };
            _ratingRepository.Create(rating);
            return ToOutputModel(rating);
        }

        /// <summary>Rating Service Delete method. 
        /// Call CRUD method in the Rating Repository with Rating id tot delete. 
        /// Store deleted record into DTO object and returns POCO object if found or null</summary>  
        /// <param name="id">Id of the Rating record to delete.</param>
        /// <return>Rating POCO object or null.</return> 
        /// <remarks></remarks>
        public RatingOutputModel? Delete(int id)
        {
            var rating = _ratingRepository.Delete(id);
            if (rating is not null)
            {
                return ToOutputModel(rating);
            }
            return null;
        }
        /// <summary>Rating Service Get method. 
        /// Call Get method in the Rating Repository with Rating id to get. 
        /// Store record into DTO object and returns POCO output model object if found or null. </summary>  
        /// <param name="id">Id of the Rating record to get.</param>
        /// <return>Rating POCO output model object or null.</return> 
        /// <remarks></remarks>
        public RatingOutputModel? Get(int id)
        {
            var rating = _ratingRepository.Get(id);
            if (rating is not null)
            {
                return ToOutputModel(rating);
            }
            return null;
        }
        /// <summary>Rating Service List method. 
        /// Call List method in the Rating Repository. 
        /// Get DTO objects list and returns POCO output model objects list.</summary>          
        /// <return>Rating POCO output model object list.</return> 
        /// <remarks></remarks>
        public List<RatingOutputModel> List()
        {
            var list = new List<RatingOutputModel>();
            var ratings = _ratingRepository.List();
            foreach (var rating in ratings)
            {
                list.Add(ToOutputModel(rating));
            }
            return list;
        }
        /// <summary>Rating Service Update method. 
        /// Call CRUD method in the Rating Repository with Rating id to update 
        /// and BidList POCO object to update. 
        /// Store updated record into DTO object and returns POCO output model object if found or null.</summary>  
        /// <param name="id">Id of the Rating record to get.</param>
        /// <param name="inputModel">Rating POCO input model object.</param>
        /// <return>Rating POCO output model object or null.</return> 
        /// <remarks></remarks>
        public RatingOutputModel? Update(int id, RatingInputModel inputModel)
        {
            var rating = _ratingRepository.Update(new Rating
            {
                Id = id,
                MoodysRating = inputModel.MoodysRating,
                SandPRating = inputModel.SandPRating,
                FitchRating = inputModel.FitchRating,
                OrderNumber = inputModel.OrderNumber,
            });
            if (rating is not null)
            {
                return ToOutputModel(rating);
            }
            return null;
        }

        /// <summary>Rating Service ToOutputModel method. 
        /// Load Rating DTO object properties into POCO uutput model object.</summary>  
        /// <param name="rating">Rating DTO output model object.</param>
        /// <remarks></remarks>
        private RatingOutputModel ToOutputModel(Rating rating) => new RatingOutputModel
        {
            Id = rating.Id,
            MoodysRating = rating.MoodysRating,
            SandPRating = rating.SandPRating,
            FitchRating = rating.FitchRating,
            OrderNumber = rating.OrderNumber
        };
    }
}
