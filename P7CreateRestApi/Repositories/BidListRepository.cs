using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class BidListRepository : IBidListRepository
    {
        private readonly LocalDbContext _dbContext;
        public BidListRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>BidList create.</summary>  
        /// <param name="bidList">BidList DTO object (BidList class from ../Domain)</param>
        /// <return></return> 
        /// <remarks></remarks>

        public void Create(BidList bidList)
        {
            _dbContext.Bids.Add(bidList);
            _dbContext.SaveChanges();
        }

        /// <summary>BidList delete.</summary>      
        /// <return>Updated bidList.</return> 
        /// <param name="id">Bid id to delete.</param>
        /// <remarks></remarks>

        public BidList? Delete(int id)
        {
            var bidList = _dbContext.Bids.FirstOrDefault(b => b.BidListId == id);
            if (bidList is not null)
            {
                _dbContext.Bids.Remove(bidList);
                _dbContext.SaveChanges();
            }
            return bidList;
        }

        /// <summary>BidList Get.</summary>      
        /// <return></return> 
        /// <param name="id">Bid id to get.</param>
        /// <remarks></remarks>
        public BidList? Get(int id) => _dbContext.Bids.FirstOrDefault(b => b.BidListId == id);

        /// <summary>BidList List.</summary>      
        /// <return>List of BidList DTO objects.</return> 
        /// <remarks></remarks>
        public List<BidList> List() => _dbContext.Bids.ToList();

        /// <summary>BidList Update.</summary>      
        /// <return>Updated BidList.</return> 
        /// <param name="bidList">BidList DTO object (BidList class from ../Domain)</param>
        /// <remarks></remarks>
        public BidList? Update(BidList bidList)
        {
            var bidListAModifier = _dbContext.Bids.FirstOrDefault(b => b.BidListId == bidList.BidListId);
            if (bidListAModifier is not null)
            {
                bidListAModifier.Account = bidList.Account;
                bidListAModifier.BidType = bidList.BidType;
                bidListAModifier.BidQuantity = bidList.BidQuantity;
                bidListAModifier.AskQuantity = bidList.AskQuantity;
                bidListAModifier.Bid = bidList.Bid;
                bidListAModifier.Ask = bidList.Ask;
                bidListAModifier.Benchmark = bidList.Benchmark;
                bidListAModifier.BidListDate = bidList.BidListDate;
                bidListAModifier.Commentary = bidList.Commentary;
                bidListAModifier.BidSecurity = bidList.BidSecurity;
                bidListAModifier.BidStatus = bidList.BidStatus;
                bidListAModifier.Trader = bidList.Trader;
                bidListAModifier.Book = bidList.Book;
                bidListAModifier.CreationName = bidList.CreationName;
                bidListAModifier.RevisionName = bidList.RevisionName;
                bidListAModifier.RevisionDate = bidList.RevisionDate;
                bidListAModifier.DealName = bidList.DealName;
                bidListAModifier.DealType = bidList.DealType;
                bidListAModifier.SourceListId = bidList.SourceListId;
                bidListAModifier.Side = bidList.Side;
                _dbContext.SaveChanges();
            }
            return bidListAModifier;
        }
    }
}
