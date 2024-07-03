using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }
        /// <summary>Trade Service Create method. 
        /// Call CRUD method in the Trade Repository with Trade POCO object to create. 
        /// Store created record into DTO object and returns POCO output model object.</summary>  
        /// <param name="inputModel">Trade POCO input model object.</param>
        /// <return>Trade POCO output model object.</return> 
        /// <remarks></remarks>
        public TradeOutputModel? Create(TradeInputModel inputModel)
        {
            var trade = new Trade
            {
                Account = inputModel.Account,
                AccountType = inputModel.AccountType,
                BuyQuantity = inputModel.BuyQuantity,
                SellQuantity = inputModel.SellQuantity,
                BuyPrice = inputModel.BuyPrice,
                SellPrice = inputModel.SellPrice,
                TradeDate = inputModel.TradeDate,
                TradeSecurity = inputModel.TradeSecurity,
                TradeStatus = inputModel.TradeStatus,
                Trader = inputModel.Trader,
                Benchmark = inputModel.Benchmark,
                Book = inputModel.Book,
                CreationName = inputModel.CreationName,
                CreationDate = DateTime.Now,
                RevisionName = inputModel.RevisionName,
                RevisionDate = inputModel.RevisionDate,
                DealName = inputModel.DealName,
                DealType = inputModel.DealType,
                SourceListId = inputModel.SourceListId,
                Side = inputModel.Side
            };
            _tradeRepository.Create(trade);
            return ToOutputModel(trade);
        }
        /// <summary>Trade Service Delete method. 
        /// Call CRUD method in the Trade Repository with Trade id tot delete. 
        /// Store deleted record into DTO object and returns POCO object if found or null</summary>  
        /// <param name="id">Id of the Trade record to delete.</param>
        /// <return>Trade POCO object or null.</return> 
        /// <remarks></remarks>
        public TradeOutputModel? Delete(int id)
        {
            var trade = _tradeRepository.Delete(id);
            if (trade is not null)
            {
                return ToOutputModel(trade);
            }
            return null;
        }
        /// <summary>Trade Service Get method. 
        /// Call Get method in the Trade Repository with Trade id to get. 
        /// Store record into DTO object and returns POCO output model object if found or null. </summary>  
        /// <param name="id">Id of the Trade record to get.</param>
        /// <return>Trade POCO output model object or null.</return> 
        /// <remarks></remarks>
        public TradeOutputModel? Get(int id)
        {
            var trade = _tradeRepository.Get(id);
            if (trade is not null)
            {
                return ToOutputModel(trade);
            }
            return null;
        }
        /// <summary>Trade Service List method. 
        /// Call List method in the Trade Repository. 
        /// Get DTO objects list and returns POCO output model objects list.</summary>          
        /// <return>Trade POCO output model object list.</return> 
        /// <remarks></remarks>
        public List<TradeOutputModel> List()
        {
            var list = new List<TradeOutputModel>();
            var trades = _tradeRepository.List();
            foreach (var trade in trades)
            {
                list.Add(ToOutputModel(trade));
            }
            return list;
        }
        /// <summary>Trade Service Update method. 
        /// Call CRUD method in the Trade Repository with Trade id to update 
        /// and BidList POCO object to update. 
        /// Store updated record into DTO object and returns POCO output model object if found or null.</summary>  
        /// <param name="id">Id of the Trade record to get.</param>
        /// <param name="inputModel">Trade POCO input model object.</param>
        /// <return>Trade POCO output model object or null.</return> 
        /// <remarks></remarks>
        public TradeOutputModel? Update(int id, TradeInputModel inputModel)
        {
            var trade = _tradeRepository.Update(new Trade
            {
                TradeId = id,
                Account = inputModel.Account,
                AccountType = inputModel.AccountType,
                BuyQuantity = inputModel.BuyQuantity,
                SellQuantity = inputModel.SellQuantity,
                BuyPrice = inputModel.BuyPrice,
                SellPrice = inputModel.SellPrice,
                TradeDate = inputModel.TradeDate,
                TradeSecurity = inputModel.TradeSecurity,
                TradeStatus = inputModel.TradeStatus,
                Trader = inputModel.Trader,
                Benchmark = inputModel.Benchmark,
                Book = inputModel.Book,
                CreationName = inputModel.CreationName,
                RevisionName = inputModel.RevisionName,
                RevisionDate = inputModel.RevisionDate,
                DealName = inputModel.DealName,
                DealType = inputModel.DealType,
                SourceListId = inputModel.SourceListId,
                Side = inputModel.Side
            });
            if (trade is not null)
            {
                return ToOutputModel(trade);
            }
            return null;
        }
        /// <summary>Trade Service ToOutputModel method. 
        /// Load Trade DTO object properties into POCO uutput model object.</summary>  
        /// <param name="rating">Trade DTO output model object.</param>
        /// <remarks></remarks>
        private TradeOutputModel ToOutputModel(Trade trade) => new TradeOutputModel
        {
            TradeId = trade.TradeId,
            Account = trade.Account,
            AccountType = trade.AccountType,
            BuyQuantity = trade.BuyQuantity,
            SellQuantity = trade.SellQuantity,
            BuyPrice = trade.BuyPrice,
            SellPrice = trade.SellPrice,
            TradeDate = trade.TradeDate,
            TradeSecurity = trade.TradeSecurity,
            TradeStatus = trade.TradeStatus,
            Trader = trade.Trader,
            Benchmark = trade.Benchmark,
            Book = trade.Book,
            CreationName = trade.CreationName,
            CreationDate = trade.CreationDate,
            RevisionName = trade.RevisionName,
            RevisionDate = trade.RevisionDate,
            DealName = trade.DealName,
            DealType = trade.DealType,
            SourceListId = trade.SourceListId,
            Side = trade.Side
        };
    }
}
