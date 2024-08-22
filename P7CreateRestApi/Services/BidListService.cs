using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using System;


namespace Dot.Net.WebApi.Services
{
        public class BidListService : IBidListService
        {
            private readonly IBidListRepository _bidListRepository;

            public BidListService(IBidListRepository bidListRepository)
            {
                _bidListRepository = bidListRepository;
            }

            // Méthode pour récupérer un BidList par son ID
            public async Task<BidList> GetBidByIdAsync(int id)
            {
                var bid = await _bidListRepository.GetByIdAsync(id);
                if (bid == null)
                {
                    throw new KeyNotFoundException($"Bid with ID {id} not found.");
                }
                return bid;
            }

            // Méthode pour récupérer tous les BidLists
            public async Task<IEnumerable<BidList>> GetAllBidsAsync()
            {
                return await _bidListRepository.GetAllAsync();
            }

            // Méthode pour ajouter un nouveau BidList
            public async Task AddBidAsync(BidList bidList)
            {
                if (bidList == null)
                {
                    throw new ArgumentNullException(nameof(bidList), "BidList cannot be null.");
                }

                // Ajout d'une validation basique
                ValidateBid(bidList);

                await _bidListRepository.AddAsync(bidList);
            }

            // Méthode pour mettre à jour un BidList existant
            public async Task UpdateBidAsync(int id, BidList bidList)
            {
                if (bidList == null)
                {
                    throw new ArgumentNullException(nameof(bidList), "BidList cannot be null.");
                }

                var existingBid = await _bidListRepository.GetByIdAsync(id);
                if (existingBid == null)
                {
                    throw new KeyNotFoundException($"Bid with ID {id} not found.");
                }

                // Mise à jour des propriétés de l'entité existante
                existingBid.Account = bidList.Account ?? existingBid.Account;
                existingBid.BidType = bidList.BidType ?? existingBid.BidType;
                existingBid.BidQuantity = bidList.BidQuantity ?? existingBid.BidQuantity;
                existingBid.AskQuantity = bidList.AskQuantity ?? existingBid.AskQuantity;
                existingBid.Bid = bidList.Bid ?? existingBid.Bid;
                existingBid.Ask = bidList.Ask ?? existingBid.Ask;
                existingBid.Benchmark = bidList.Benchmark ?? existingBid.Benchmark;
                existingBid.BidListDate = bidList.BidListDate ?? existingBid.BidListDate;
                existingBid.Commentary = bidList.Commentary ?? existingBid.Commentary;
                existingBid.BidSecurity = bidList.BidSecurity ?? existingBid.BidSecurity;
                existingBid.BidStatus = bidList.BidStatus ?? existingBid.BidStatus;
                existingBid.Trader = bidList.Trader ?? existingBid.Trader;
                existingBid.Book = bidList.Book ?? existingBid.Book;
                existingBid.CreationName = bidList.CreationName ?? existingBid.CreationName;
                existingBid.CreationDate = bidList.CreationDate ?? existingBid.CreationDate;
                existingBid.RevisionName = bidList.RevisionName ?? existingBid.RevisionName;
                existingBid.RevisionDate = bidList.RevisionDate ?? existingBid.RevisionDate;
                existingBid.DealName = bidList.DealName ?? existingBid.DealName;
                existingBid.DealType = bidList.DealType ?? existingBid.DealType;
                existingBid.SourceListId = bidList.SourceListId ?? existingBid.SourceListId;
                existingBid.Side = bidList.Side ?? existingBid.Side;

                // Ajout d'une validation basique
                ValidateBid(existingBid);

                await _bidListRepository.UpdateAsync(existingBid);
            }

            // Méthode pour supprimer un BidList par son ID
            public async Task DeleteBidAsync(int id)
            {
                var existingBid = await _bidListRepository.GetByIdAsync(id);
                if (existingBid == null)
                {
                    throw new KeyNotFoundException($"Bid with ID {id} not found.");
                }

                await _bidListRepository.DeleteAsync(id);
            }

            // Méthode pour valider un BidList avant l'ajout ou la mise à jour
            public async Task ValidateBidAsync(BidList bidList)
            {
                ValidateBid(bidList);
                await Task.CompletedTask;
        }

            // Validation de base pour un BidList
            private void ValidateBid(BidList bidList)
            {
            if (string.IsNullOrWhiteSpace(bidList.Account))
            {
                throw new ArgumentException("Account cannot be empty.", nameof(bidList));
            }

            if (string.IsNullOrWhiteSpace(bidList.BidType))
            {
                throw new ArgumentException("BidType cannot be empty.", nameof(bidList));
            }
            // Ajouter d'autres règles de validation selon les besoins
        }
    }
}
