using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Models.InputModels;
using P7CreateRestApi.Models.OutputModel;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class BidListService : IBidListService
    {
        private readonly IBidListRepository _bidListRepository;
        public BidListService(IBidListRepository bidListRepository)
        {
            _bidListRepository = bidListRepository;
        }

        /// <summary>BidList Create. 
        /// Call CRUD method in the BidList Repository with BidList POCO object to create. 
        /// Store created record into DTO object and returns POCO output model object.</summary>  
        /// <param name="bidList">BidList POCO input model object.</param>
        /// <return>BidList POCO output model object.</return> 
        /// <remarks></remarks>
        public BidListOutputModel? Create(BidListInputModel inputModel)
        {
            var bidList = new BidList
            {
                Account = inputModel.Account,
                BidType = inputModel.BidType,
                BidQuantity = inputModel.BidQuantity,
                AskQuantity = inputModel.AskQuantity,
                Bid = inputModel.Bid,
                Ask = inputModel.Ask,
                Benchmark = inputModel.Benchmark,
                BidListDate = inputModel.BidListDate,
                Commentary = inputModel.Commentary,
                BidSecurity = inputModel.BidSecurity,
                BidStatus = inputModel.BidStatus,
                Trader = inputModel.Trader,
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
            _bidListRepository.Create(bidList);
            return ToOutputModel(bidList);
        }

        /// <summary>BidList Delete. 
        /// Call CRUD method in the BidList Repository with BidList id tot delete. 
        /// Store deleted record into DTO object and returns POCO object if found or null</summary>  
        /// <param name="id">Id of the BidList record to delete.</param>
        /// <return>BidList POCO object or null.</return> 
        /// <remarks></remarks>
        public BidListOutputModel? Delete(int id)
        {
            var bidList = _bidListRepository.Delete(id);
            if (bidList is not null)
            {
                return ToOutputModel(bidList);
            }
            return null;
        }

        /// <summary>BidList Get. 
        /// Call Get method in the BidList Repository with BidList id to get. 
        /// Store record into DTO object and returns POCO output model object if found or null. </summary>  
        /// <param name="id">Id of the BidList record to get.</param>
        /// <return>BidList POCO output model object or null.</return> 
        /// <remarks></remarks>
        public BidListOutputModel? Get(int id)
        {
            var bidList = _bidListRepository.Get(id);
            if (bidList is not null)
            {
                return ToOutputModel(bidList);
            }
            return null;
        }

        /// <summary>BidList List. 
        /// Call List method in the BidList Repository. 
        /// Get DTO objects list and returns POCO output model objects list.</summary>          
        /// <return>BidList POCO output model object list.</return> 
        /// <remarks></remarks>
        public List<BidListOutputModel> List()
        {
            var list = new List<BidListOutputModel>();
            var bidLists = _bidListRepository.List();
            foreach (var bidList in bidLists)
            {
                list.Add(ToOutputModel(bidList));
            }
            return list;
        }

        /// <summary>BidList Update. 
        /// Call CRUD method in the BidList Repository with BidList id to update 
        /// and BidList POCO object to update. 
        /// Store updated record into DTO object and returns POCO output model object if found or null.</summary>  
        /// <param name="id">Id of the BidList record to get.</param>
        /// <return>BidList POCO output model object or null.</return> 
        /// <remarks></remarks>
        public BidListOutputModel? Update(int id, BidListInputModel inputModel)
        {
            var bidList = _bidListRepository.Update(new BidList
            {
                BidListId = id,
                Account = inputModel.Account,
                BidType = inputModel.BidType,
                BidQuantity = inputModel.BidQuantity,
                AskQuantity = inputModel.AskQuantity,
                Bid = inputModel.Bid,
                Ask = inputModel.Ask,
                Benchmark = inputModel.Benchmark,
                BidListDate = inputModel.BidListDate,
                Commentary = inputModel.Commentary,
                BidSecurity = inputModel.BidSecurity,
                BidStatus = inputModel.BidStatus,
                Trader = inputModel.Trader,
                Book = inputModel.Book,
                CreationName = inputModel.CreationName,
                RevisionName = inputModel.RevisionName,
                RevisionDate = inputModel.RevisionDate,
                DealName = inputModel.DealName,
                DealType = inputModel.DealType,
                SourceListId = inputModel.SourceListId,
                Side = inputModel.Side
            });
            if (bidList is not null)
            {
                return ToOutputModel(bidList);
            }
            return null;
        }

        /// <summary>BidList ToOutputModel method. 
        /// Load Bidlist DTO object properties into POCO uutput model object.</summary>  
        /// <param name="bidList">Bidlist DTO output model object.</param>
        /// <remarks></remarks>
        private BidListOutputModel ToOutputModel(BidList bidList) => new BidListOutputModel
        {
            BidListId = bidList.BidListId,
            Account = bidList.Account,
            BidType = bidList.BidType,
            BidQuantity = bidList.BidQuantity,
            AskQuantity = bidList.AskQuantity,
            Bid = bidList.Bid,
            Ask = bidList.Ask,
            Benchmark = bidList.Benchmark,
            BidListDate = bidList.BidListDate,
            Commentary = bidList.Commentary,
            BidSecurity = bidList.BidSecurity,
            BidStatus = bidList.BidStatus,
            Trader = bidList.Trader,
            Book = bidList.Book,
            CreationName = bidList.CreationName,
            CreationDate = bidList.CreationDate,
            RevisionName = bidList.RevisionName,
            RevisionDate = bidList.RevisionDate,
            DealName = bidList.DealName,
            DealType = bidList.DealType,
            SourceListId = bidList.SourceListId,
            Side = bidList.Side
        };
    }
}
