using Dot.Net.WebApi.Domain;
using Moq;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Tests
{
    public class CurvePointServiceTests
    {
        private readonly CurvePointService _curvePointService;
        private readonly Mock<ICurvePointRepository> _curvePointRepositoryMock = new();

        public CurvePointServiceTests()
        {
            _curvePointService = new CurvePointService(_curvePointRepositoryMock.Object);
        }

        /// <summary>CurvePoint test unit for Create method. 
        /// Check if created CurvePoint has an Output Model correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void CreateCurvePoint_ShouldHaveCurvePointOutputModelReturned()
        {
            // Arrange
            var inputModel = new CurvePointInputModel
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                Term = 1.1,
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.Create(It.IsAny<CurvePoint>()));

            // Act
            var outputModel = _curvePointService.Create(inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.CurveId, outputModel.CurveId);
            Assert.Equal(inputModel.AsOfDate, outputModel.AsOfDate);
            Assert.Equal(inputModel.CurvePointValue, outputModel.CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.Create(It.IsAny<CurvePoint>()), Times.Once);
        }
        /// <summary>CurvePoint test unit for Delete method.
        /// Check if deleted CurvePoint has an OutputModel correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteCurvePoint_ShouldHaveCurvePointOutputModelReturned()
        {
            // Arrange
            var curvePointExcepted = new CurvePoint()
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.Delete(1)).Returns(curvePointExcepted);

            // Act
            var outputModel = _curvePointService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(curvePointExcepted.CurveId, outputModel.CurveId);
            Assert.Equal(curvePointExcepted.AsOfDate, outputModel.AsOfDate);
            Assert.Equal(curvePointExcepted.CurvePointValue, outputModel.CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }
        /// <summary>CurvePoint test unit for Delete method.
        /// Check if deleted CurvePoint does'nt return Output Model (null).</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteCurvePointThatDoesntExist_ShouldReturnsNulll()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _curvePointService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            _curvePointRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }
        /// <summary>CurvePoint test unit for Get method.
        /// Check if CurvePoint OutputModel item properties sent back from Get method 
        /// is identical to requested item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetCurvePoint__ShouldHaveCurvePointOutputModelReturnedl()
        {
            // Arrange
            var curvePointExcepted = new CurvePoint()
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.Get(1)).Returns(curvePointExcepted);

            // Act
            var outputModel = _curvePointService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(curvePointExcepted.CurveId, outputModel.CurveId);
            Assert.Equal(curvePointExcepted.AsOfDate, outputModel.AsOfDate);
            Assert.Equal(curvePointExcepted.CurvePointValue, outputModel.CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }
        /// <summary>CurvePoint test unit for Get method.
        /// Check if not existing CurvePoint item with Get method send 
        /// back null result.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetCurvePointThatDoesntExist_ShouldReturnsNulll()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _curvePointService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _curvePointRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }
        /// <summary>CurvePoint test unit for List method.
        /// Check if List method send back correct CurvePoint item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListCurvePointWithOneCurvePoint_ShouldHaveOneCurvePointInListReturned()
        {
            // Arrange
            var curvePointExcepted = new CurvePoint()
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.List()).Returns(new List<CurvePoint> { curvePointExcepted });

            // Act
            var list = _curvePointService.List();

            // Assert
            Assert.NotEmpty(list);
            Assert.Single(list);
            Assert.Equal(curvePointExcepted.CurveId, list[0].CurveId);
            Assert.Equal(curvePointExcepted.AsOfDate, list[0].AsOfDate);
            Assert.Equal(curvePointExcepted.CurvePointValue, list[0].CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.List(), Times.Once);
        }
        /// <summary>CurvePoint test unit for List method.
        /// Check if List method send back CurvePoint list with no items 
        /// when there are no CurvePoint items.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListCurvePointEmpty_ShouldHaveEmptyListReturned()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(m => m.List()).Returns(new List<CurvePoint>());

            // Act
            var list = _curvePointService.List();

            // Assert
            Assert.Empty(list);
            _curvePointRepositoryMock.Verify(m => m.List(), Times.Once);
        }
        /// <summary>CurvePoint test unit for Update method.
        /// Check if Update method send back
        /// correct CurvePoint item properties updated as expected.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void UpdateCurvePoint_ShouldHaveUpdateCurvePointReturned()
        {
            // Arrange
            var curvePointExcepted = new CurvePoint()
            {
                CurveId = 1,
                AsOfDate = new DateTime(2024, 1, 1),
                Term = 1.1,
                CurvePointValue = 1.1
            };
            var inputModel = new CurvePointInputModel()
            {
                CurveId = 1,
                AsOfDate = new DateTime(2024, 1, 1),
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.Update(It.IsAny<CurvePoint>())).Returns(curvePointExcepted);

            // Act
            var outputModel = _curvePointService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(curvePointExcepted.CurveId, outputModel.CurveId);
            Assert.Equal(curvePointExcepted.AsOfDate, outputModel.AsOfDate);
            Assert.Equal(curvePointExcepted.CurvePointValue, outputModel.CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.Update(It.IsAny<CurvePoint>()), Times.Once);
        }
        /// <summary>CurvePoint test unit for Update method.
        /// Check if Update method for a not existing item 
        /// send back null result.</summary> 
        /// <remarks></remarks> 
        [Fact]
        public void UpdateCurvePointDoesntExist_ShouldReturnsNull()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(m => m.Update(It.IsAny<CurvePoint>()));

            // Act
            var outputModel = _curvePointService.Update(1, new CurvePointInputModel
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                Term = 1.1,
                CurvePointValue = 1.1
            });

            // Assert
            Assert.Null(outputModel);
            _curvePointRepositoryMock.Verify(m => m.Update(It.IsAny<CurvePoint>()), Times.Once);
        }
    }
}
