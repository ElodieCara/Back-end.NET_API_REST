using Moq;
using Xunit;
using FluentAssertions;
using Dot.Net.WebApi.Repositories;
using Dot.Net.WebApi.Services;
using P7CreateRestApi.Models.DTOs; // Assurez-vous d'utiliser les DTOs corrects
using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.UnitTests
{
    public class BidListServiceTests
    {
        private readonly Mock<IBidListRepository> _mockRepository; // Mock du dépôt pour simuler les opérations sur les données
        private readonly BidListService _bidListService; // Service que nous allons tester

        public BidListServiceTests()
        {
            // Initialisation du mock et du service
            _mockRepository = new Mock<IBidListRepository>();
            _bidListService = new BidListService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfBidLists()
        {
            // Arrange: Préparer les données simulées
            var bidLists = new List<BidList>
            {
                new BidList { BidListId = 1, Account = "Account1", BidType = "Type1" },
                new BidList { BidListId = 2, Account = "Account2", BidType = "Type2" }
            };
            // Simuler la méthode GetAllAsync du dépôt pour retourner la liste bidLists
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(bidLists);

            // Act: Appeler la méthode du service
            var result = await _bidListService.GetAllAsync();

            // Assert: Vérifier les résultats
            result.Should().HaveCount(2); // Vérifie qu'il y a bien 2 éléments dans la liste
            result.Should().Contain(b => b.BidListId == 1 && b.Account == "Account1"); // Vérifie que le premier élément est correct
            result.Should().Contain(b => b.BidListId == 2 && b.Account == "Account2"); // Vérifie que le second élément est correct
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnBidList_WhenExists()
        {
            // Arrange: Préparer un élément BidList simulé
            var bidList = new BidList { BidListId = 1, Account = "Account1", BidType = "Type1" };
            // Simuler la méthode GetByIdAsync pour retourner cet élément lorsqu'on appelle l'ID 1
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(bidList);

            // Act: Appeler la méthode du service pour récupérer le BidList avec l'ID 1
            var result = await _bidListService.GetByIdAsync(1);

            // Assert: Vérifier les résultats
            result.Should().NotBeNull(); // L'élément ne doit pas être null
            result.BidListId.Should().Be(1); // L'ID de l'élément doit être 1
            result.Account.Should().Be("Account1"); // Le compte de l'élément doit être "Account1"
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange: Simuler un retour null lorsque l'ID 1 n'existe pas dans le dépôt
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((BidList)null);

            // Act: Appeler la méthode du service
            var result = await _bidListService.GetByIdAsync(1);

            // Assert: Vérifier que le résultat est bien null
            result.Should().BeNull();
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNewBidList_WhenAddedSuccessfully()
        {
            // Arrange: Créer un DTO pour un nouveau BidList
            var newBidListDto = new BidListDto { Account = "NewAccount", BidType = "NewType" };
            // Simuler l'ajout avec un callback qui ajoute un ID au BidList et retourne Task.CompletedTask
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<BidList>()))
                .Callback<BidList>(bidList => bidList.BidListId = 1) // Simule l'ajout avec génération d'un ID
                .Returns(Task.CompletedTask);

            // Act: Appeler la méthode AddAsync du service
            var result = await _bidListService.AddAsync(newBidListDto);

            // Assert: Vérifier que l'ajout a bien réussi
            result.Should().NotBeNull(); // Le résultat ne doit pas être null
            result.BidListId.Should().Be(1); // L'ID généré doit être 1
            result.Account.Should().Be("NewAccount"); // Le compte doit correspondre à celui fourni dans le DTO
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedBidList_WhenUpdateIsSuccessful()
        {
            // Arrange: Créer un BidList existant à mettre à jour
            var updatedBidList = new BidList { BidListId = 1, Account = "UpdatedAccount", BidType = "UpdatedType" };
            // Simuler que le dépôt retourne cet élément lorsqu'on appelle GetByIdAsync
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(updatedBidList);
            // Simuler la méthode UpdateAsync
            _mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<BidList>())).Returns(Task.CompletedTask);

            // Créer un DTO pour les nouvelles valeurs
            var bidListDto = new BidListDto { Account = "UpdatedAccount", BidType = "UpdatedType" };

            // Act: Appeler la méthode UpdateAsync du service
            var result = await _bidListService.UpdateAsync(1, bidListDto);

            // Assert: Vérifier que la mise à jour a bien été effectuée
            result.Should().NotBeNull(); // Le résultat ne doit pas être null
            result.Account.Should().Be("UpdatedAccount"); // Le compte doit correspondre aux nouvelles valeurs
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnCompletedTask_WhenDeleteIsSuccessful()
        {
            // Arrange: Simuler la suppression d'un élément avec l'ID 1
            _mockRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act: Appeler la méthode DeleteAsync du service
            await _bidListService.DeleteAsync(1);

            // Assert: Vérifier que la méthode du dépôt a bien été appelée
            _mockRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }
    }
}
