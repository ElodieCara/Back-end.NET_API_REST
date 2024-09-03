using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;

namespace Dot.Net.WebApi.Services
{
    public class BidListService : IBidListService
    {
        private readonly IBidListRepository _repository;

        public BidListService(IBidListRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BidListModel>> GetAllAsync()
        {
            var bidLists = await _repository.GetAllAsync();
            return bidLists.Select(b => new BidListModel
            {
                BidListId = b.BidListId,
                Account = b.Account,
                BidType = b.BidType,
                BidQuantity = b.BidQuantity,
                AskQuantity = b.AskQuantity,
                Bid = b.Bid,
                Ask = b.Ask,
                Benchmark = b.Benchmark,
                BidListDate = b.BidListDate,
                Commentary = b.Commentary,
                BidSecurity = b.BidSecurity,
                BidStatus = b.BidStatus,
                Trader = b.Trader,
                Book = b.Book,
                CreationName = b.CreationName,
                CreationDate = b.CreationDate,
                RevisionName = b.RevisionName,
                RevisionDate = b.RevisionDate,
                DealName = b.DealName,
                DealType = b.DealType,
                SourceListId = b.SourceListId,
                Side = b.Side
            });
        }

        public async Task<BidListModel> GetByIdAsync(int id)
        {
            var bidList = await _repository.GetByIdAsync(id);
            if (bidList == null)
            {
                return null;
            }
            return new BidListModel
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

        public async Task<BidListModel> AddAsync(BidListModel dto)
        {
            var bidList = new BidList
            {
                Account = dto.Account,
                BidType = dto.BidType,
                BidQuantity = dto.BidQuantity,
                AskQuantity = dto.AskQuantity,
                Bid = dto.Bid,
                Ask = dto.Ask,
                Benchmark = dto.Benchmark,
                BidListDate = dto.BidListDate,
                Commentary = dto.Commentary,
                BidSecurity = dto.BidSecurity,
                BidStatus = dto.BidStatus,
                Trader = dto.Trader,
                Book = dto.Book,
                CreationName = dto.CreationName,
                CreationDate = dto.CreationDate,
                RevisionName = dto.RevisionName,
                RevisionDate = dto.RevisionDate,
                DealName = dto.DealName,
                DealType = dto.DealType,
                SourceListId = dto.SourceListId,
                Side = dto.Side
            };
            await _repository.AddAsync(bidList);
            dto.BidListId = bidList.BidListId;
            return dto;
        }

        public async Task<BidListModel> UpdateAsync(int id, BidListModel dto)
        {
            var bidList = await _repository.GetByIdAsync(id);
            if (bidList == null)
            {
                return null;
            }

            bidList.Account = dto.Account;
            bidList.BidType = dto.BidType;
            bidList.BidQuantity = dto.BidQuantity;
            bidList.AskQuantity = dto.AskQuantity;
            bidList.Bid = dto.Bid;
            bidList.Ask = dto.Ask;
            bidList.Benchmark = dto.Benchmark;
            bidList.BidListDate = dto.BidListDate;
            bidList.Commentary = dto.Commentary;
            bidList.BidSecurity = dto.BidSecurity;
            bidList.BidStatus = dto.BidStatus;
            bidList.Trader = dto.Trader;
            bidList.Book = dto.Book;
            bidList.CreationName = dto.CreationName;
            bidList.CreationDate = dto.CreationDate;
            bidList.RevisionName = dto.RevisionName;
            bidList.RevisionDate = dto.RevisionDate;
            bidList.DealName = dto.DealName;
            bidList.DealType = dto.DealType;
            bidList.SourceListId = dto.SourceListId;
            bidList.Side = dto.Side;

            await _repository.UpdateAsync(bidList);

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
