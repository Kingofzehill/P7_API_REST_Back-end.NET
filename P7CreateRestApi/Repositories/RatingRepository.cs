using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Data;

namespace P7CreateRestApi.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly LocalDbContext _dbContext;
        public RatingRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Rating Repository Create method.</summary>  
        /// <param name="rating">Rating DTO object</param>
        /// <return></return> 
        /// <remarks></remarks>
        public void Create(Rating rating)
        {
            _dbContext.Ratings.Add(rating);
            _dbContext.SaveChanges();
        }
        /// <summary>Rating Repository delete method.</summary>      
        /// <return>Updated Rating.</return> 
        /// <param name="id">Rating id to delete.</param>
        /// <remarks></remarks>
        public Rating? Delete(int id)
        {
            var rating = _dbContext.Ratings.FirstOrDefault(r => r.Id == id);
            if (rating is not null)
            {
                _dbContext.Ratings.Remove(rating);
                _dbContext.SaveChanges();
            }
            return rating;
        }
        /// <summary>Rating Repository Get method.</summary>      
        /// <return></return> 
        /// <param name="id">Rating id to get.</param>
        /// <remarks></remarks>
        public Rating? Get(int id) => _dbContext.Ratings.FirstOrDefault(r => r.Id == id);
        /// <summary>Rating Repository List method.</summary>      
        /// <return>List of Rating DTO objects.</return> 
        /// <remarks></remarks>
        public List<Rating> List() => _dbContext.Ratings.ToList();
        /// <summary>Rating Repository Update method.</summary>      
        /// <return>Updated Rating.</return> 
        /// <param name="rating">Rating DTO object.</param>
        /// <remarks></remarks>
        public Rating? Update(Rating rating)
        {
            var ratingAModifier = _dbContext.Ratings.FirstOrDefault(r => r.Id == rating.Id);
            if (ratingAModifier is not null)
            {
                ratingAModifier.MoodysRating = rating.MoodysRating;
                ratingAModifier.SandPRating = rating.SandPRating;
                ratingAModifier.FitchRating = rating.FitchRating;
                ratingAModifier.OrderNumber = rating.OrderNumber;
                _dbContext.SaveChanges();
            }
            return ratingAModifier;
        }
    }
}
