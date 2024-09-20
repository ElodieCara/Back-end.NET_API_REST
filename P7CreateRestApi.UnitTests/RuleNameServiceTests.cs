using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Repositories;
using P7CreateRestApi.Models.DTOs;
using Xunit;

namespace P7CreateRestApi.UnitTests
{
    // Cette classe contient des tests unitaires pour le service RuleNameService.
    public class RuleNameServiceTests
    {
        private readonly RuleNameService _ruleNameService;
        private readonly Mock<IRuleNameRepository> _mockRuleNameRepository;

        // Le constructeur initialise les objets simulés (Mock) et l'instance de RuleNameService.
        public RuleNameServiceTests()
        {
            _mockRuleNameRepository = new Mock<IRuleNameRepository>();
            _ruleNameService = new RuleNameService(_mockRuleNameRepository.Object);
        }

        // Test de la méthode GetAllAsync pour s'assurer qu'elle renvoie une liste de RuleNames.
        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfRuleNames()
        {
            // Arrange : préparation des données simulées.
            var ruleNames = new List<RuleName>
            {
                new RuleName { Id = 1, Name = "Rule1", Description = "Description1" },
                new RuleName { Id = 2, Name = "Rule2", Description = "Description2" }
            };
            _mockRuleNameRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(ruleNames);

            // Act : exécution de la méthode à tester.
            var result = await _ruleNameService.GetAllAsync();

            // Assert : vérification que les résultats sont corrects.
            result.Should().HaveCount(2); // Il doit y avoir deux éléments dans la liste.
            result.Should().Contain(r => r.Id == 1 && r.Name == "Rule1"); // Le premier élément doit avoir ces propriétés.
            result.Should().Contain(r => r.Id == 2 && r.Name == "Rule2"); // Le second élément doit avoir ces propriétés.
        }

        // Test de la méthode GetByIdAsync pour vérifier qu'un RuleName est renvoyé lorsque l'ID existe.
        [Fact]
        public async Task GetByIdAsync_ShouldReturnRuleName_WhenExists()
        {
            // Arrange : configuration de la réponse simulée pour un ID donné.
            var ruleName = new RuleName { Id = 1, Name = "Rule1", Description = "Description1" };
            _mockRuleNameRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(ruleName);

            // Act : exécution de la méthode à tester.
            var result = await _ruleNameService.GetByIdAsync(1);

            // Assert : vérification que le résultat n'est pas nul et que les propriétés sont correctes.
            result.Should().NotBeNull();
            result.Id.Should().Be(1); // L'ID doit être 1.
            result.Name.Should().Be("Rule1"); // Le nom doit être "Rule1".
        }

        // Test de la méthode GetByIdAsync pour s'assurer que null est renvoyé lorsque l'ID n'existe pas.
        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange : simulation d'une réponse null pour un ID donné.
            _mockRuleNameRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((RuleName)null);

            // Act : exécution de la méthode à tester.
            var result = await _ruleNameService.GetByIdAsync(1);

            // Assert : vérification que le résultat est bien null lorsque l'ID n'est pas trouvé.
            result.Should().BeNull();
        }

        // Test de la méthode AddAsync pour vérifier qu'un nouveau RuleName est ajouté avec succès.
        [Fact]
        public async Task AddAsync_ShouldReturnNewRuleName_WhenAddedSuccessfully()
        {
            // Arrange : préparation des données d'entrée.
            var newRuleNameDto = new RuleNameDto { Name = "NewRule", Description = "NewDescription" };

            // Simulation de l'ajout du RuleName avec un ID généré.
            _mockRuleNameRepository.Setup(repo => repo.AddAsync(It.IsAny<RuleName>()))
                .Callback<RuleName>(rule => rule.Id = 1)  // Simule l'ajout avec l'ID généré.
                .Returns(Task.CompletedTask);

            // Act : exécution de la méthode à tester.
            var result = await _ruleNameService.AddAsync(newRuleNameDto);

            // Assert : vérification que le résultat est correct après l'ajout.
            result.Should().NotBeNull();
            result.Id.Should().Be(1);  // Vérifie que l'ID a bien été généré (simulé dans Callback).
            result.Name.Should().Be("NewRule"); // Vérifie que le nom est bien celui ajouté.
        }

        // Test de la méthode UpdateAsync pour vérifier qu'un RuleName est mis à jour avec succès.
        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedRuleName_WhenUpdateIsSuccessful()
        {
            // Arrange : préparation des données existantes.
            var updatedRuleName = new RuleName { Id = 1, Name = "UpdatedRule", Description = "UpdatedDescription" };
            _mockRuleNameRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(updatedRuleName);

            // Simulation de la mise à jour sans erreurs.
            _mockRuleNameRepository.Setup(repo => repo.UpdateAsync(It.IsAny<RuleName>())).Returns(Task.CompletedTask);

            // Données d'entrée pour la mise à jour.
            var ruleNameDto = new RuleNameDto { Name = "UpdatedRule", Description = "UpdatedDescription" };

            // Act : exécution de la méthode à tester.
            var result = await _ruleNameService.UpdateAsync(1, ruleNameDto);

            // Assert : vérification que les données mises à jour sont correctes.
            result.Should().NotBeNull();
            result.Name.Should().Be("UpdatedRule"); // Le nom doit correspondre aux nouvelles valeurs.
        }

        // Test de la méthode DeleteAsync pour vérifier qu'un RuleName est supprimé avec succès.
        [Fact]
        public async Task DeleteAsync_ShouldComplete_WhenDeleteIsSuccessful()
        {
            // Arrange : simulation de la suppression réussie.
            _mockRuleNameRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act : exécution de la méthode à tester.
            await _ruleNameService.DeleteAsync(1);

            // Assert : vérification que la méthode DeleteAsync a été appelée une fois.
            _mockRuleNameRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }
    }
}
