using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentAssertions;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Repositories;
using P7CreateRestApi.Models.DTOs;

namespace P7CreateRestApi.UnitTests
{
    public class TradeServiceTests
    {
        // Création d'un mock du TradeRepository pour simuler les interactions avec la base de données
        private readonly Mock<ITradeRepository> _mockTradeRepository;
        // Instance du TradeService à tester
        private readonly TradeService _tradeService;

        public TradeServiceTests()
        {
            // Initialisation du mock TradeRepository
            _mockTradeRepository = new Mock<ITradeRepository>();
            // Création d'une instance de TradeService utilisant le mock TradeRepository
            _tradeService = new TradeService(_mockTradeRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfTrades()
        {
            // Arrange
            // Préparation des données simulées : deux trades fictifs
            var trades = new List<Trade>
            {
                new Trade { TradeId = 1, Account = "Account1", BuyQuantity = 10.0 },
                new Trade { TradeId = 2, Account = "Account2", BuyQuantity = 20.0 }
            };
            // Configuration du mock pour que GetAllAsync renvoie la liste de trades simulée
            _mockTradeRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(trades);

            // Act
            // Appel de la méthode à tester
            var result = await _tradeService.GetAllAsync();

            // Assert
            // Vérification que le résultat contient bien deux éléments et que les propriétés sont correctes
            result.Should().HaveCount(2);
            result.Should().Contain(t => t.TradeId == 1 && t.Account == "Account1");
            result.Should().Contain(t => t.TradeId == 2 && t.Account == "Account2");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTrade_WhenExists()
        {
            // Arrange
            // Préparation d'un trade fictif avec TradeId = 1
            var trade = new Trade { TradeId = 1, Account = "Account1", BuyQuantity = 10.0 };
            // Configuration du mock pour que GetByIdAsync renvoie le trade simulé
            _mockTradeRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(trade);

            // Act
            // Appel de la méthode à tester
            var result = await _tradeService.GetByIdAsync(1);

            // Assert
            // Vérification que le résultat n'est pas null et que les propriétés sont correctes
            result.Should().NotBeNull();
            result.TradeId.Should().Be(1);
            result.Account.Should().Be("Account1");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            // Configuration du mock pour que GetByIdAsync renvoie null (aucun trade trouvé)
            _mockTradeRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Trade)null);

            // Act
            // Appel de la méthode à tester
            var result = await _tradeService.GetByIdAsync(1);

            // Assert
            // Vérification que le résultat est null (aucun trade trouvé)
            result.Should().BeNull();
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNewTrade_WhenAddedSuccessfully()
        {
            // Arrange
            // Préparation d'un TradeDto pour l'ajout d'un nouveau trade
            var newTradeDto = new TradeDto { Account = "NewAccount", BuyQuantity = 15.0 };
            // Configuration du mock pour simuler l'ajout du trade
            _mockTradeRepository.Setup(repo => repo.AddAsync(It.IsAny<Trade>())).Returns(Task.CompletedTask);

            // Act
            // Appel de la méthode à tester
            var result = await _tradeService.AddAsync(newTradeDto);

            // Assert
            // Vérification que le nouveau trade a bien été ajouté et que ses propriétés sont correctes
            result.Should().NotBeNull();
            result.Account.Should().Be("NewAccount");
            result.BuyQuantity.Should().Be(15.0);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedTrade_WhenUpdateIsSuccessful()
        {
            // Arrange
            // Préparation d'un trade fictif avec TradeId = 1
            var tradeToUpdate = new Trade { TradeId = 1, Account = "OldAccount", BuyQuantity = 10.0 };
            // Configuration du mock pour que GetByIdAsync renvoie le trade à mettre à jour
            _mockTradeRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(tradeToUpdate);
            // Configuration du mock pour simuler la mise à jour du trade
            _mockTradeRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Trade>())).Returns(Task.CompletedTask);

            // Préparation d'un TradeDto avec les nouvelles valeurs pour la mise à jour
            var tradeDto = new TradeDto { Account = "UpdatedAccount", BuyQuantity = 20.0 };

            // Act
            // Appel de la méthode à tester
            var result = await _tradeService.UpdateAsync(1, tradeDto);

            // Assert
            // Vérification que le trade a bien été mis à jour et que les propriétés sont correctes
            result.Should().NotBeNull();
            result.Account.Should().Be("UpdatedAccount");
            result.BuyQuantity.Should().Be(20.0);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnCompletedTask_WhenDeleteIsSuccessful()
        {
            // Arrange
            // Configuration du mock pour simuler la suppression du trade
            _mockTradeRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            // Appel de la méthode à tester
            await _tradeService.DeleteAsync(1);

            // Assert
            // Vérification que la méthode DeleteAsync du repository a été appelée une fois
            _mockTradeRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }
    }
}
