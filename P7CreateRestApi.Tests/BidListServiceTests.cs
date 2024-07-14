using Dot.Net.WebApi.Domain;
using Moq;
using P7CreateRestApi.Models.InputModels;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Tests
{
    public class BidListServiceTests
    {
        private readonly BidListService _bidListService;
        private readonly Mock<IBidListRepository> _bidListRepositoryMock = new();
        public BidListServiceTests()
        {
            _bidListService = new BidListService(_bidListRepositoryMock.Object);
        }
        /// <summary>BidList test unit for Create method. 
        /// Check if created BidList has an Output Model correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void CreateBidList_ShouldHaveBidListOutputModelReturned()
        {
            // Arrange
            var inputModel = new BidListInputModel()
            {
                Account = "Account",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationDate = DateTime.Now,
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            // Setup of Repositor Create method mock.
            _bidListRepositoryMock.Setup(m => m.Create(It.IsAny<BidList>()));

            // Act
            var outputModel = _bidListService.Create(inputModel);

            // Assert
            // Various assert checks if OutputModel returned properties
            // are equals to InputModel properties.
            Assert.NotNull(outputModel);
            // check if returned values (Output Model) ​​conform to input values (Input Model).
            Assert.Equal(inputModel.Account, outputModel.Account);
            Assert.Equal(inputModel.Ask, outputModel.Ask);
            Assert.Equal(inputModel.AskQuantity, outputModel.AskQuantity);
            Assert.Equal(inputModel.Benchmark, outputModel.Benchmark);
            Assert.Equal(inputModel.Bid, outputModel.Bid);
            Assert.Equal(inputModel.BidListDate, outputModel.BidListDate);
            Assert.Equal(inputModel.BidQuantity, outputModel.BidQuantity);
            Assert.Equal(inputModel.BidSecurity, outputModel.BidSecurity);
            Assert.Equal(inputModel.BidStatus, outputModel.BidStatus);
            Assert.Equal(inputModel.BidType, outputModel.BidType);
            Assert.Equal(inputModel.Book, outputModel.Book);
            Assert.Equal(inputModel.Commentary, outputModel.Commentary);
            Assert.Equal(inputModel.CreationName, outputModel.CreationName);
            Assert.Equal(inputModel.DealName, outputModel.DealName);
            Assert.Equal(inputModel.DealType, outputModel.DealType);
            Assert.Equal(inputModel.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(inputModel.RevisionName, outputModel.RevisionName);
            Assert.Equal(inputModel.Side, outputModel.Side);
            Assert.Equal(inputModel.SourceListId, outputModel.SourceListId);
            Assert.Equal(inputModel.Trader, outputModel.Trader);
            // Create method should has been called once.
            _bidListRepositoryMock.Verify(repo => repo.Create(It.IsAny<BidList>()), Times.Once);
        }
        /// <summary>BidList test unit for Delete method.
        /// Check if deleted BidList has an OutputModel correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteBidList_ShouldHaveBidListOutputModelReturned()
        {
            // Arrange
            var bidListExcepted = new BidList()
            {
                BidListId = 1,
                Account = "Account",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationDate = DateTime.Now,
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            // Setup of Repository delete method mock and defines object to return.
            _bidListRepositoryMock.Setup(m => m.Delete(1)).Returns(bidListExcepted);

            // Act
            var outputModel = _bidListService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            // check if returned values (Output Model) ​​are the same as input values.
            Assert.Equal(bidListExcepted.BidListId, outputModel.BidListId);
            Assert.Equal(bidListExcepted.Account, outputModel.Account);
            Assert.Equal(bidListExcepted.Ask, outputModel.Ask);
            Assert.Equal(bidListExcepted.AskQuantity, outputModel.AskQuantity);
            Assert.Equal(bidListExcepted.Benchmark, outputModel.Benchmark);
            Assert.Equal(bidListExcepted.Bid, outputModel.Bid);
            Assert.Equal(bidListExcepted.BidListDate, outputModel.BidListDate);
            Assert.Equal(bidListExcepted.BidQuantity, outputModel.BidQuantity);
            Assert.Equal(bidListExcepted.BidSecurity, outputModel.BidSecurity);
            Assert.Equal(bidListExcepted.BidStatus, outputModel.BidStatus);
            Assert.Equal(bidListExcepted.BidType, outputModel.BidType);
            Assert.Equal(bidListExcepted.Book, outputModel.Book);
            Assert.Equal(bidListExcepted.Commentary, outputModel.Commentary);
            Assert.Equal(bidListExcepted.CreationDate, outputModel.CreationDate);
            Assert.Equal(bidListExcepted.CreationName, outputModel.CreationName);
            Assert.Equal(bidListExcepted.DealName, outputModel.DealName);
            Assert.Equal(bidListExcepted.DealType, outputModel.DealType);
            Assert.Equal(bidListExcepted.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(bidListExcepted.RevisionName, outputModel.RevisionName);
            Assert.Equal(bidListExcepted.Side, outputModel.Side);
            Assert.Equal(bidListExcepted.SourceListId, outputModel.SourceListId);
            Assert.Equal(bidListExcepted.Trader, outputModel.Trader);
            // Delete method should have been called once.
            _bidListRepositoryMock.Verify(repo => repo.Delete(1), Times.Once);
        }
        /// <summary>BidList test unit for Delete method.
        /// Check if deleted BidList does'nt return Output Model (null).</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteBidListThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            // Setup of Repository Delete method mock.
            _bidListRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _bidListService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            // Delete method should have been called once.
            _bidListRepositoryMock.Verify(repo => repo.Delete(1), Times.Once);
        }
        /// <summary>BidList test unit for Get method.
        /// Check if BidList OutputModel item properties sent back from Get method
        /// is identical to requested item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetExistingBidList_ShouldHaveBidListOutputModelReturned()
        {
            // Arrange
            var bidListExcepted = new BidList()
            {
                BidListId = 1,
                Account = "Account",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationDate = DateTime.Now,
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            // Setup of Repository Get method mock and defines object to return.
            _bidListRepositoryMock.Setup(m => m.Get(1)).Returns(bidListExcepted);

            // Act
            var outputModel = _bidListService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            // check if returned values (Output Model) ​​are the same as input values.
            Assert.Equal(bidListExcepted.BidListId, outputModel.BidListId);
            Assert.Equal(bidListExcepted.Account, outputModel.Account);
            Assert.Equal(bidListExcepted.Ask, outputModel.Ask);
            Assert.Equal(bidListExcepted.AskQuantity, outputModel.AskQuantity);
            Assert.Equal(bidListExcepted.Benchmark, outputModel.Benchmark);
            Assert.Equal(bidListExcepted.Bid, outputModel.Bid);
            Assert.Equal(bidListExcepted.BidListDate, outputModel.BidListDate);
            Assert.Equal(bidListExcepted.BidQuantity, outputModel.BidQuantity);
            Assert.Equal(bidListExcepted.BidSecurity, outputModel.BidSecurity);
            Assert.Equal(bidListExcepted.BidStatus, outputModel.BidStatus);
            Assert.Equal(bidListExcepted.BidType, outputModel.BidType);
            Assert.Equal(bidListExcepted.Book, outputModel.Book);
            Assert.Equal(bidListExcepted.Commentary, outputModel.Commentary);
            Assert.Equal(bidListExcepted.CreationDate, outputModel.CreationDate);
            Assert.Equal(bidListExcepted.CreationName, outputModel.CreationName);
            Assert.Equal(bidListExcepted.DealName, outputModel.DealName);
            Assert.Equal(bidListExcepted.DealType, outputModel.DealType);
            Assert.Equal(bidListExcepted.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(bidListExcepted.RevisionName, outputModel.RevisionName);
            Assert.Equal(bidListExcepted.Side, outputModel.Side);
            Assert.Equal(bidListExcepted.SourceListId, outputModel.SourceListId);
            Assert.Equal(bidListExcepted.Trader, outputModel.Trader);
            // Delete method should have been called once.
            _bidListRepositoryMock.Verify(repo => repo.Get(1), Times.Once);
        }

        /// <summary>BidList test unit for Get method.
        /// Check if not existing BidList item with Get method send 
        /// back null result.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetBidListThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            // Setup of Repository Get method mock.
            _bidListRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _bidListService.Get(1);

            // Assert
            Assert.Null(outputModel);
            // Get method should have been called once.
            _bidListRepositoryMock.Verify(repo => repo.Get(1), Times.Once);
        }

        /// <summary>BidList test unit for List method.
        /// Check if List method send back correct BidList item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListBidListWithOneBidList_ShouldHaveOneBidListInListReturned()
        {
            // Arrange
            var bidListExcepted = new BidList()
            {
                BidListId = 1,
                Account = "Account",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationDate = DateTime.Now,
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            // Setup of Repository List method mock and defines object to return.
            _bidListRepositoryMock.Setup(m => m.List()).Returns(new List<BidList> { bidListExcepted });

            // Act
            var list = _bidListService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Single(list);
            // check if returned values ​​are the same as input values.
            Assert.Equal(bidListExcepted.BidListId, list[0].BidListId);
            Assert.Equal(bidListExcepted.Account, list[0].Account);
            Assert.Equal(bidListExcepted.Ask, list[0].Ask);
            Assert.Equal(bidListExcepted.AskQuantity, list[0].AskQuantity);
            Assert.Equal(bidListExcepted.Benchmark, list[0].Benchmark);
            Assert.Equal(bidListExcepted.Bid, list[0].Bid);
            Assert.Equal(bidListExcepted.BidListDate, list[0].BidListDate);
            Assert.Equal(bidListExcepted.BidQuantity, list[0].BidQuantity);
            Assert.Equal(bidListExcepted.BidSecurity, list[0].BidSecurity);
            Assert.Equal(bidListExcepted.BidStatus, list[0].BidStatus);
            Assert.Equal(bidListExcepted.BidType, list[0].BidType);
            Assert.Equal(bidListExcepted.Book, list[0].Book);
            Assert.Equal(bidListExcepted.Commentary, list[0].Commentary);
            Assert.Equal(bidListExcepted.CreationDate, list[0].CreationDate);
            Assert.Equal(bidListExcepted.CreationName, list[0].CreationName);
            Assert.Equal(bidListExcepted.DealName, list[0].DealName);
            Assert.Equal(bidListExcepted.DealType, list[0].DealType);
            Assert.Equal(bidListExcepted.RevisionDate, list[0].RevisionDate);
            Assert.Equal(bidListExcepted.RevisionName, list[0].RevisionName);
            Assert.Equal(bidListExcepted.Side, list[0].Side);
            Assert.Equal(bidListExcepted.SourceListId, list[0].SourceListId);
            Assert.Equal(bidListExcepted.Trader, list[0].Trader);
            // List method should have been called once.
            _bidListRepositoryMock.Verify(repo => repo.List(), Times.Once);
        }
        /// <summary>BidList test unit for List method.
        /// Check if List method send back BidList with no items 
        /// if there are no BidList items.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListBidListEmpty_ShouldHaveEmptyListReturned()
        {
            // Arrange
            // Setup of Repository List method mock and defines value to return.
            _bidListRepositoryMock.Setup(m => m.List()).Returns(new List<BidList>());

            // Act
            var list = _bidListService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Empty(list);
            // List method should have been called once.
            _bidListRepositoryMock.Verify(repo => repo.List(), Times.Once);
        }
        /// <summary>BidList test unit for Update method.
        /// Check if Update method send back
        /// correct BidList item properties updated as expected.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void BidListUpdate_ShouldHaveUpdateBidListReturned()
        {
            // Arrange
            var bidListExpected = new BidList()
            {
                BidListId = 1,
                Account = "AccountUpdated",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = new DateTime(2024, 1, 1),
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationDate = DateTime.Now,
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = new DateTime(2024, 1, 1),
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            var inputModel = new BidListInputModel()
            {
                Account = "AccountUpdated",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = new DateTime(2024, 1, 1),
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationDate = DateTime.Now,
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = new DateTime(2024, 1, 1),
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            // Setup of Repository Update method mock and defines object to return.
            _bidListRepositoryMock.Setup(repo => repo.Update(It.IsAny<BidList>())).Returns(bidListExpected);

            // Act
            var outputModel = _bidListService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            // check if returned values (Output Model) ​​are the same as input values.
            Assert.Equal(bidListExpected.BidListId, outputModel.BidListId);
            Assert.Equal(bidListExpected.Account, outputModel.Account);
            Assert.Equal(bidListExpected.Ask, outputModel.Ask);
            Assert.Equal(bidListExpected.AskQuantity, outputModel.AskQuantity);
            Assert.Equal(bidListExpected.Benchmark, outputModel.Benchmark);
            Assert.Equal(bidListExpected.Bid, outputModel.Bid);
            Assert.Equal(bidListExpected.BidListDate, outputModel.BidListDate);
            Assert.Equal(bidListExpected.BidQuantity, outputModel.BidQuantity);
            Assert.Equal(bidListExpected.BidSecurity, outputModel.BidSecurity);
            Assert.Equal(bidListExpected.BidStatus, outputModel.BidStatus);
            Assert.Equal(bidListExpected.BidType, outputModel.BidType);
            Assert.Equal(bidListExpected.Book, outputModel.Book);
            Assert.Equal(bidListExpected.Commentary, outputModel.Commentary);
            Assert.Equal(bidListExpected.CreationDate, outputModel.CreationDate);
            Assert.Equal(bidListExpected.CreationName, outputModel.CreationName);
            Assert.Equal(bidListExpected.DealName, outputModel.DealName);
            Assert.Equal(bidListExpected.DealType, outputModel.DealType);
            Assert.Equal(bidListExpected.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(bidListExpected.RevisionName, outputModel.RevisionName);
            Assert.Equal(bidListExpected.Side, outputModel.Side);
            Assert.Equal(bidListExpected.SourceListId, outputModel.SourceListId);
            Assert.Equal(bidListExpected.Trader, outputModel.Trader);
            // Update method should have been called once.
            _bidListRepositoryMock.Verify(repo => repo.Update(It.IsAny<BidList>()), Times.Once);
        }
        /// <summary>BidList test unit for Update method.
        /// Check if Update method for a not existing item 
        /// send back null result.</summary> 
        /// <remarks></remarks>        
        [Fact]
        public void UpdateBidListThatDoesntExist_ShouldReturnsNull()
        {
            // Arrange
            // Setup of Repository Update method mock.
            _bidListRepositoryMock.Setup(repo => repo.Update(It.IsAny<BidList>()));

            // Act
            var outputModel = _bidListService.Update(1, new BidListInputModel
            {
                Account = "AccountUpdated",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationDate = DateTime.Now,
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            });

            // Assert
            Assert.Null(outputModel);
            // Update method should have been called once.
            _bidListRepositoryMock.Verify(repo => repo.Update(It.IsAny<BidList>()), Times.Once);
        }
    }
}