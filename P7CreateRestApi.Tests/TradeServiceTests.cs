using Dot.Net.WebApi.Domain;
using Moq;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Tests
{
    public class TradeServiceTests
    {
        private readonly TradeService _tradeService;
        private readonly Mock<ITradeRepository> _tradeRepositoryMock = new();

        public TradeServiceTests()
        {
            _tradeService = new TradeService(_tradeRepositoryMock.Object);
        }
        /// <summary>Trade test unit for Create method. 
        /// Check if created Trade has an Output Model correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void CreateTrade_ShouldHaveTradeOutputModelReturned()
        {
            // Arrange
            var inputModel = new TradeInputModel
            {
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.Create(It.IsAny<Trade>()));

            // Act
            var outputModel = _tradeService.Create(inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.Account, outputModel.Account);
            Assert.Equal(inputModel.AccountType, outputModel.AccountType);
            Assert.Equal(inputModel.BuyQuantity, outputModel.BuyQuantity);
            Assert.Equal(inputModel.SellQuantity, outputModel.SellQuantity);
            Assert.Equal(inputModel.BuyPrice, outputModel.BuyPrice);
            Assert.Equal(inputModel.SellPrice, outputModel.SellPrice);
            Assert.Equal(inputModel.Benchmark, outputModel.Benchmark);
            Assert.Equal(inputModel.TradeDate, outputModel.TradeDate);
            Assert.Equal(inputModel.TradeSecurity, outputModel.TradeSecurity);
            Assert.Equal(inputModel.TradeStatus, outputModel.TradeStatus);
            Assert.Equal(inputModel.Trader, outputModel.Trader);
            Assert.Equal(inputModel.Book, outputModel.Book);
            Assert.Equal(inputModel.CreationName, outputModel.CreationName);
            Assert.Equal(inputModel.RevisionName, outputModel.RevisionName);
            Assert.Equal(inputModel.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(inputModel.DealName, outputModel.DealName);
            Assert.Equal(inputModel.DealType, outputModel.DealType);
            Assert.Equal(inputModel.SourceListId, outputModel.SourceListId);
            Assert.Equal(inputModel.Side, outputModel.Side);
            _tradeRepositoryMock.Verify(m => m.Create(It.IsAny<Trade>()), Times.Once);
        }
        /// <summary>Trade test unit for Delete method.
        /// Check if deleted Trade has an OutputModel correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteTrade_ShouldHaveTradeOutputModelReturned()
        {
            // Arrange
            var tradeExcepted = new Trade()
            {
                TradeId = 1,
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                CreationDate = new DateTime(2024, 1, 1),
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.Delete(1)).Returns(tradeExcepted);

            // Act
            var outputModel = _tradeService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(tradeExcepted.TradeId, outputModel.TradeId);
            Assert.Equal(tradeExcepted.Account, outputModel.Account);
            Assert.Equal(tradeExcepted.AccountType, outputModel.AccountType);
            Assert.Equal(tradeExcepted.BuyQuantity, outputModel.BuyQuantity);
            Assert.Equal(tradeExcepted.SellQuantity, outputModel.SellQuantity);
            Assert.Equal(tradeExcepted.BuyPrice, outputModel.BuyPrice);
            Assert.Equal(tradeExcepted.SellPrice, outputModel.SellPrice);
            Assert.Equal(tradeExcepted.Benchmark, outputModel.Benchmark);
            Assert.Equal(tradeExcepted.TradeDate, outputModel.TradeDate);
            Assert.Equal(tradeExcepted.TradeSecurity, outputModel.TradeSecurity);
            Assert.Equal(tradeExcepted.TradeStatus, outputModel.TradeStatus);
            Assert.Equal(tradeExcepted.Trader, outputModel.Trader);
            Assert.Equal(tradeExcepted.Book, outputModel.Book);
            Assert.Equal(tradeExcepted.CreationName, outputModel.CreationName);
            Assert.Equal(tradeExcepted.CreationDate, outputModel.CreationDate);
            Assert.Equal(tradeExcepted.RevisionName, outputModel.RevisionName);
            Assert.Equal(tradeExcepted.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(tradeExcepted.DealName, outputModel.DealName);
            Assert.Equal(tradeExcepted.DealType, outputModel.DealType);
            Assert.Equal(tradeExcepted.SourceListId, outputModel.SourceListId);
            Assert.Equal(tradeExcepted.Side, outputModel.Side);
            _tradeRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }
        /// <summary>Trade test unit for Delete method.
        /// Check if deleted Trade does'nt return Output Model (null).</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteTradethatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _tradeRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _tradeService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            _tradeRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }
        /// <summary>Trade test unit for Get method.
        /// Check if Trade OutputModel item properties sent back from Get method
        /// is identical to requested item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetExistingTrade_ShouldHaveTradeOutputModelReturned()
        {
            // Arrange
            var tradeExcepted = new Trade()
            {
                TradeId = 1,
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                CreationDate = new DateTime(2024, 1, 1),
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.Get(1)).Returns(tradeExcepted);

            // Act
            var outputModel = _tradeService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(tradeExcepted.TradeId, outputModel.TradeId);
            Assert.Equal(tradeExcepted.Account, outputModel.Account);
            Assert.Equal(tradeExcepted.AccountType, outputModel.AccountType);
            Assert.Equal(tradeExcepted.BuyQuantity, outputModel.BuyQuantity);
            Assert.Equal(tradeExcepted.SellQuantity, outputModel.SellQuantity);
            Assert.Equal(tradeExcepted.BuyPrice, outputModel.BuyPrice);
            Assert.Equal(tradeExcepted.SellPrice, outputModel.SellPrice);
            Assert.Equal(tradeExcepted.Benchmark, outputModel.Benchmark);
            Assert.Equal(tradeExcepted.TradeDate, outputModel.TradeDate);
            Assert.Equal(tradeExcepted.TradeSecurity, outputModel.TradeSecurity);
            Assert.Equal(tradeExcepted.TradeStatus, outputModel.TradeStatus);
            Assert.Equal(tradeExcepted.Trader, outputModel.Trader);
            Assert.Equal(tradeExcepted.Book, outputModel.Book);
            Assert.Equal(tradeExcepted.CreationName, outputModel.CreationName);
            Assert.Equal(tradeExcepted.CreationDate, outputModel.CreationDate);
            Assert.Equal(tradeExcepted.RevisionName, outputModel.RevisionName);
            Assert.Equal(tradeExcepted.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(tradeExcepted.DealName, outputModel.DealName);
            Assert.Equal(tradeExcepted.DealType, outputModel.DealType);
            Assert.Equal(tradeExcepted.SourceListId, outputModel.SourceListId);
            Assert.Equal(tradeExcepted.Side, outputModel.Side);
            _tradeRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }
        /// <summary>Trade test unit for Get method.
        /// Check if not existing Trade item with Get method send 
        /// back null result.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetTradeThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _tradeRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _tradeService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _tradeRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }
        /// <summary>Trade test unit for List method.
        /// Check if List method send back correct Trade item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListTradeWithOneTrade_ShouldHaveOneTradeInListReturned()
        {
            // Arrange
            var tradeExcepted = new Trade()
            {
                TradeId = 1,
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                CreationDate = new DateTime(2024, 1, 1),
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.List()).Returns(new List<Trade> { tradeExcepted });

            // Act
            var list = _tradeService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Single(list);
            Assert.Equal(tradeExcepted.TradeId, list[0].TradeId);
            Assert.Equal(tradeExcepted.Account, list[0].Account);
            Assert.Equal(tradeExcepted.AccountType, list[0].AccountType);
            Assert.Equal(tradeExcepted.BuyQuantity, list[0].BuyQuantity);
            Assert.Equal(tradeExcepted.SellQuantity, list[0].SellQuantity);
            Assert.Equal(tradeExcepted.BuyPrice, list[0].BuyPrice);
            Assert.Equal(tradeExcepted.SellPrice, list[0].SellPrice);
            Assert.Equal(tradeExcepted.Benchmark, list[0].Benchmark);
            Assert.Equal(tradeExcepted.TradeDate, list[0].TradeDate);
            Assert.Equal(tradeExcepted.TradeSecurity, list[0].TradeSecurity);
            Assert.Equal(tradeExcepted.TradeStatus, list[0].TradeStatus);
            Assert.Equal(tradeExcepted.Trader, list[0].Trader);
            Assert.Equal(tradeExcepted.Book, list[0].Book);
            Assert.Equal(tradeExcepted.CreationName, list[0].CreationName);
            Assert.Equal(tradeExcepted.CreationDate, list[0].CreationDate);
            Assert.Equal(tradeExcepted.RevisionName, list[0].RevisionName);
            Assert.Equal(tradeExcepted.RevisionDate, list[0].RevisionDate);
            Assert.Equal(tradeExcepted.DealName, list[0].DealName);
            Assert.Equal(tradeExcepted.DealType, list[0].DealType);
            Assert.Equal(tradeExcepted.SourceListId, list[0].SourceListId);
            Assert.Equal(tradeExcepted.Side, list[0].Side);
            _tradeRepositoryMock.Verify(m => m.List(), Times.Once);
        }
        /// <summary>Trade test unit for List method.
        /// Check if List method send back Trade with no items 
        /// if there are no Trade items.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListTradeEmpty_ShouldHaveEmptyListReturned()
        {
            // Arrange
            _tradeRepositoryMock.Setup(m => m.List()).Returns(new List<Trade>());

            // Act
            var list = _tradeService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Empty(list);
            _tradeRepositoryMock.Verify(m => m.List(), Times.Once);
        }
        /// <summary>Trade test unit for Update method.
        /// Check if Update method send back
        /// correct Trade item properties updated as expected.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void UpdateTrade_ShouldHaveUpdateTradeReturned()
        {
            // Arrange
            var tradeExcepted = new Trade()
            {
                TradeId = 1,
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                CreationDate = new DateTime(2024, 1, 1),
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            var inputModel = new TradeInputModel
            {
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.Update(It.IsAny<Trade>())).Returns(tradeExcepted);

            // Act
            var outputModel = _tradeService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(tradeExcepted.Account, outputModel.Account);
            Assert.Equal(tradeExcepted.AccountType, outputModel.AccountType);
            Assert.Equal(tradeExcepted.BuyQuantity, outputModel.BuyQuantity);
            Assert.Equal(tradeExcepted.SellQuantity, outputModel.SellQuantity);
            Assert.Equal(tradeExcepted.BuyPrice, outputModel.BuyPrice);
            Assert.Equal(tradeExcepted.SellPrice, outputModel.SellPrice);
            Assert.Equal(tradeExcepted.Benchmark, outputModel.Benchmark);
            Assert.Equal(tradeExcepted.TradeDate, outputModel.TradeDate);
            Assert.Equal(tradeExcepted.TradeSecurity, outputModel.TradeSecurity);
            Assert.Equal(tradeExcepted.TradeStatus, outputModel.TradeStatus);
            Assert.Equal(tradeExcepted.Trader, outputModel.Trader);
            Assert.Equal(tradeExcepted.Book, outputModel.Book);
            Assert.Equal(tradeExcepted.CreationName, outputModel.CreationName);
            Assert.Equal(tradeExcepted.CreationDate, outputModel.CreationDate);
            Assert.Equal(tradeExcepted.RevisionName, outputModel.RevisionName);
            Assert.Equal(tradeExcepted.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(tradeExcepted.DealName, outputModel.DealName);
            Assert.Equal(tradeExcepted.DealType, outputModel.DealType);
            Assert.Equal(tradeExcepted.SourceListId, outputModel.SourceListId);
            Assert.Equal(tradeExcepted.Side, outputModel.Side);
            _tradeRepositoryMock.Verify(m => m.Update(It.IsAny<Trade>()), Times.Once);
        }
        /// <summary>Trade test unit for Update method.
        /// Check if Update method for a not existing item 
        /// send back null result.</summary> 
        /// <remarks></remarks>  
        [Fact]
        public void UpdateTradeThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _tradeRepositoryMock.Setup(m => m.Update(It.IsAny<Trade>()));

            // Act
            var outputModel = _tradeService.Update(1, new TradeInputModel
            {
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            });

            // Assert
            Assert.Null(outputModel);
            _tradeRepositoryMock.Verify(m => m.Update(It.IsAny<Trade>()), Times.Once);
        }
    }
}
