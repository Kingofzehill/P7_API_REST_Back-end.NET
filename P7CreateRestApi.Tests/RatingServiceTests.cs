using Dot.Net.WebApi.Domain;
using Moq;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Tests
{
    public class RatingServiceTests
    {
        private readonly RatingService _ratingService;
        private readonly Mock<IRatingRepository> _ratingRepositoryMock = new();
        public RatingServiceTests()
        {
            _ratingService = new RatingService(_ratingRepositoryMock.Object);
        }
        /// <summary>Rating test unit for Create method. 
        /// Check if created Rating has an Output Model correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void CreateRating_ShouldHaveRatingOutputModelReturned()
        {
            // Arrange
            var inputModel = new RatingInputModel
            {
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.Create(It.IsAny<Rating>()));

            // Act
            var outputModel = _ratingService.Create(inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.MoodysRating, outputModel.MoodysRating);
            Assert.Equal(inputModel.SandPRating, outputModel.SandPRating);
            Assert.Equal(inputModel.FitchRating, outputModel.FitchRating);
            Assert.Equal(inputModel.OrderNumber, outputModel.OrderNumber);
            _ratingRepositoryMock.Verify(m => m.Create(It.IsAny<Rating>()), Times.Once);
        }
        /// <summary>Rating test unit for Delete method.
        /// Check if deleted Rating has an OutputModel correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteRating_ShouldHaveRatingOutputModelReturned()
        {
            // Arrange
            var ratingExcepted = new Rating()
            {
                Id = 1,
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.Delete(1)).Returns(ratingExcepted);

            // Act
            var outputModel = _ratingService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(ratingExcepted.Id, outputModel.Id);
            Assert.Equal(ratingExcepted.MoodysRating, outputModel.MoodysRating);
            Assert.Equal(ratingExcepted.SandPRating, outputModel.SandPRating);
            Assert.Equal(ratingExcepted.FitchRating, outputModel.FitchRating);
            Assert.Equal(ratingExcepted.OrderNumber, outputModel.OrderNumber);
            _ratingRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }
        /// <summary>Rating test unit for Delete method.
        /// Check if deleted Rating does'nt return Output Model (null).</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteRatingThatDoesntExist_ShouldReturnNulll()
        {
            // Arrange
            _ratingRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _ratingService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            _ratingRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }
        /// <summary>Rating test unit for Get method.
        /// Check if Rating OutputModel item properties sent back from Get method
        /// is identical to requested item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetExistingRating_ShouldHaveRatingOutputModelReturned()
        {
            // Arrange
            var ratingExcepted = new Rating()
            {
                Id = 1,
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.Get(1)).Returns(ratingExcepted);

            // Act
            var outputModel = _ratingService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(ratingExcepted.MoodysRating, outputModel.MoodysRating);
            Assert.Equal(ratingExcepted.SandPRating, outputModel.SandPRating);
            Assert.Equal(ratingExcepted.FitchRating, outputModel.FitchRating);
            Assert.Equal(ratingExcepted.OrderNumber, outputModel.OrderNumber);
        }
        /// <summary>Rating test unit for Get method.
        /// Check if not existing Rating item with Get method send 
        /// back null result.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetRatingThatDoesntExist_ShoulReturnNull()
        {
            // Arrange
            _ratingRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _ratingService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _ratingRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }
        /// <summary>Rating test unit for Update method.
        /// Check if Update method send back
        /// correct Rating item properties updated as expected.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void RatingUpdate_ShouldHaveUpdateRatingReturned()
        {
            // Arrange
            var ratingExcepted = new Rating()
            {
                Id = 1,
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            var inputModel = new RatingInputModel()
            {
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.Update(It.IsAny<Rating>())).Returns(ratingExcepted);

            // Act
            var outputModel = _ratingService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(ratingExcepted.Id, outputModel.Id);
            Assert.Equal(ratingExcepted.MoodysRating, outputModel.MoodysRating);
            Assert.Equal(ratingExcepted.SandPRating, outputModel.SandPRating);
            Assert.Equal(ratingExcepted.FitchRating, outputModel.FitchRating);
            Assert.Equal(ratingExcepted.OrderNumber, outputModel.OrderNumber);
            _ratingRepositoryMock.Verify(m => m.Update(It.IsAny<Rating>()), Times.Once);
        }
        /// <summary>Rating test unit for Update method.
        /// Check if Update method for a not existing item 
        /// send back null result.</summary> 
        /// <remarks></remarks>    
        [Fact]
        public void UpdateRatingThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _ratingRepositoryMock.Setup(m => m.Update(It.IsAny<Rating>()));

            // Act
            var outputModel = _ratingService.Update(1, new RatingInputModel
            {
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            });

            // Assert
            Assert.Null(outputModel);
            _ratingRepositoryMock.Verify(m => m.Update(It.IsAny<Rating>()), Times.Once);
        }
        /// <summary>Rating test unit for List method.
        /// Check if List method send back correct Rating item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListRatingWithOneRating_ShouldHaveOneRatingInListReturned()
        {
            // Arrange
            var ratingExcepted = new Rating()
            {
                Id = 1,
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.List()).Returns(new List<Rating> { ratingExcepted });

            // Act
            var list = _ratingService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Single(list);
            Assert.Equal(ratingExcepted.Id, list[0].Id);
            Assert.Equal(ratingExcepted.MoodysRating, list[0].MoodysRating);
            Assert.Equal(ratingExcepted.SandPRating, list[0].SandPRating);
            Assert.Equal(ratingExcepted.FitchRating, list[0].FitchRating);
            Assert.Equal(ratingExcepted.OrderNumber, list[0].OrderNumber);
            _ratingRepositoryMock.Verify(m => m.List(), Times.Once);
        }
        /// <summary>Rating test unit for List method.
        /// Check if List method send back BidList with no items 
        /// if there are no BidList items.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void RatingListEmpty_ShouldHaveEmptyRatingListReturned()
        {
            // Arrange
            _ratingRepositoryMock.Setup(m => m.List()).Returns(new List<Rating>());

            // Act
            var list = _ratingService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Empty(list);
            _ratingRepositoryMock.Verify(repo => repo.List(), Times.Once);
        }
    }
}
