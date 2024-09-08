using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;

namespace Dot.Net.WebApi.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _repository;

        public TradeService(ITradeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TradeModel>> GetAllAsync()
        {
            var trades = await _repository.GetAllAsync();
            return trades.Select(t => new TradeModel
            {
                TradeId = t.TradeId,
                Account = t.Account,
                AccountType = t.AccountType,
                BuyQuantity = t.BuyQuantity ?? 0.0,
                SellQuantity = t.SellQuantity ?? 0.0,
                BuyPrice = t.BuyPrice ?? 0.0,
                SellPrice = t.SellPrice ?? 0.0,
                TradeDate = t.TradeDate ?? DateTime.MinValue,
                TradeSecurity = t.TradeSecurity,
                TradeStatus = t.TradeStatus,
                Trader = t.Trader,
                Benchmark = t.Benchmark,
                CreationDate = t.CreationDate ?? DateTime.MinValue,
                RevisionName = t.RevisionName,
                RevisionDate = t.RevisionDate ?? DateTime.MinValue,
                DealName = t.DealName,
                DealType = t.DealType,
                SourceListId = t.SourceListId,
                Side = t.Side
            });
        }

        public async Task<TradeModel> GetByIdAsync(int id)
        {
            var trade = await _repository.GetByIdAsync(id);
            if (trade == null) return null!;

            return new TradeModel
            {
                TradeId = trade.TradeId,
                Account = trade.Account,
                AccountType = trade.AccountType,
                BuyQuantity = trade.BuyQuantity ?? 0.0,
                SellQuantity = trade.SellQuantity ?? 0.0,
                BuyPrice = trade.BuyPrice ?? 0.0,
                SellPrice = trade.SellPrice ?? 0.0,
                TradeDate = trade.TradeDate ?? DateTime.MinValue,
                TradeSecurity = trade.TradeSecurity,
                TradeStatus = trade.TradeStatus,
                Trader = trade.Trader,
                Benchmark = trade.Benchmark,
                CreationDate = trade.CreationDate ?? DateTime.MinValue,
                RevisionName = trade.RevisionName,
                RevisionDate = trade.RevisionDate ?? DateTime.MinValue,
                DealName = trade.DealName,
                DealType = trade.DealType,
                SourceListId = trade.SourceListId,
                Side = trade.Side
            };
        }

        public async Task<IEnumerable<TradeModel>> GetTradesByUserIdAsync(string userId)
        {
            var trades = await _repository.GetTradesByUserIdAsync(userId);
            return trades.Select(t => new TradeModel
            {
                TradeId = t.TradeId,
                Account = t.Account,
                BuyQuantity = t.BuyQuantity,
                SellQuantity = t.SellQuantity,
                BuyPrice = t.BuyPrice ?? 0.0,
                SellPrice = t.SellPrice ?? 0.0,
                TradeDate = t.TradeDate ?? DateTime.MinValue,
                TradeSecurity = t.TradeSecurity,
                TradeStatus = t.TradeStatus,
                Trader = t.Trader,
                Benchmark = t.Benchmark,
                CreationDate = t.CreationDate ?? DateTime.MinValue,
                RevisionName = t.RevisionName,
                RevisionDate = t.RevisionDate ?? DateTime.MinValue,
                DealName = t.DealName,
                DealType = t.DealType,
                SourceListId = t.SourceListId,
                Side = t.Side
            });
        }

        public async Task<TradeModel> AddAsync(TradeModel dto)
        {
            var trade = new Trade
            {
                Account = dto.Account,
                AccountType = dto.AccountType,
                BuyQuantity = dto.BuyQuantity,
                SellQuantity = dto.SellQuantity,
                BuyPrice = dto.BuyPrice,
                SellPrice = dto.SellPrice,
                TradeDate = dto.TradeDate,
                TradeSecurity = dto.TradeSecurity,
                TradeStatus = dto.TradeStatus,
                Trader = dto.Trader,
                Benchmark = dto.Benchmark,
                CreationDate = dto.CreationDate,
                RevisionName = dto.RevisionName,
                RevisionDate = dto.RevisionDate,
                DealName = dto.DealName,
                DealType = dto.DealType,
                SourceListId = dto.SourceListId,
                Side = dto.Side
            };

            await _repository.AddAsync(trade);
            dto.TradeId = trade.TradeId;
            return dto;
        }

        public async Task<TradeModel> UpdateAsync(int id, TradeModel dto)
        {
            var trade = await _repository.GetByIdAsync(id);
            if (trade == null) return null!;

            trade.Account = dto.Account;
            trade.AccountType = dto.AccountType;
            trade.BuyQuantity = dto.BuyQuantity;
            trade.SellQuantity = dto.SellQuantity;
            trade.BuyPrice = dto.BuyPrice;
            trade.SellPrice = dto.SellPrice;
            trade.TradeDate = dto.TradeDate;
            trade.TradeSecurity = dto.TradeSecurity;
            trade.TradeStatus = dto.TradeStatus;
            trade.Trader = dto.Trader;
            trade.Benchmark = dto.Benchmark;
            trade.CreationDate = dto.CreationDate;
            trade.RevisionName = dto.RevisionName;
            trade.RevisionDate = dto.RevisionDate;
            trade.DealName = dto.DealName;
            trade.DealType = dto.DealType;
            trade.SourceListId = dto.SourceListId;
            trade.Side = dto.Side;

            await _repository.UpdateAsync(trade);
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
