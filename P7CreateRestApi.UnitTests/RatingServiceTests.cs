using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentAssertions;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Repositories;
using P7CreateRestApi.Models.DTOs;
using Dot.Net.WebApi.Models;

namespace P7CreateRestApi.UnitTests
{
    public class RatingServiceTests
    {
        // On crée des mocks pour simuler le comportement du repository
        private readonly Mock<IRatingRepository> _mockRatingRepository;
        private readonly RatingService _ratingService;

        // Le constructeur initialise les mocks et le service avec ces mocks
        public RatingServiceTests()
        {
            _mockRatingRepository = new Mock<IRatingRepository>();
            _ratingService = new RatingService(_mockRatingRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfRatings()
        {
            // Arrange: Préparation du test, ici on simule une liste de ratings dans le repository
            var ratings = new List<Rating>
            {
                new Rating { Id = 1, MoodysRating = "Aa1", SandPRating = "AA+", FitchRating = "A+" },
                new Rating { Id = 2, MoodysRating = "Aa2", SandPRating = "AA", FitchRating = "A" }
            };
            _mockRatingRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(ratings);

            // Act: On appelle la méthode à tester, ici GetAllAsync
            var result = await _ratingService.GetAllAsync();

            // Assert: On vérifie que le résultat contient bien les éléments attendus
            result.Should().HaveCount(2); // Vérifie que la liste contient 2 éléments
            result.Should().Contain(r => r.Id == 1 && r.MoodysRating == "Aa1"); // Vérifie le premier élément
            result.Should().Contain(r => r.Id == 2 && r.MoodysRating == "Aa2"); // Vérifie le deuxième élément
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnRating_WhenExists()
        {
            // Arrange: On prépare un rating simulé avec l'ID 1
            var rating = new Rating { Id = 1, MoodysRating = "Aa1", SandPRating = "AA+", FitchRating = "A+" };
            _mockRatingRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(rating);

            // Act: On appelle la méthode GetByIdAsync avec l'ID 1
            var result = await _ratingService.GetByIdAsync(1);

            // Assert: On vérifie que le résultat est correct
            result.Should().NotBeNull(); // Vérifie que le résultat n'est pas null
            result.Id.Should().Be(1); // Vérifie que l'ID est bien 1
            result.MoodysRating.Should().Be("Aa1"); // Vérifie que la note Moody's est correcte
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange: Simule le comportement quand le rating n'est pas trouvé
            _mockRatingRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Rating)null);

            // Act: Appelle la méthode GetByIdAsync avec un ID qui n'existe pas
            var result = await _ratingService.GetByIdAsync(1);

            // Assert: Le résultat doit être null
            result.Should().BeNull(); // Vérifie que le résultat est bien null
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNewRating_WhenAddedSuccessfully()
        {
            // Arrange: Prépare le modèle DTO du rating à ajouter
            var newRatingDto = new RatingModel { MoodysRating = "Aa1", SandPRating = "AA+", FitchRating = "A+" };

            // Simule le comportement du repository lors de l'ajout d'un rating
            _mockRatingRepository.Setup(repo => repo.AddAsync(It.IsAny<Rating>())).Returns(Task.CompletedTask);

            // Act: Appelle la méthode AddAsync pour ajouter un nouveau rating
            var result = await _ratingService.AddAsync(newRatingDto);

            // Assert: Vérifie que le rating est correctement retourné après ajout
            result.Should().NotBeNull(); // Vérifie que le résultat n'est pas null
            result.MoodysRating.Should().Be("Aa1"); // Vérifie que la note Moody's est correcte
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedRating_WhenUpdateIsSuccessful()
        {
            // Arrange: Prépare un rating existant et un modèle DTO pour la mise à jour
            var ratingToUpdate = new Rating { Id = 1, MoodysRating = "Aa1", SandPRating = "AA+", FitchRating = "A+" };
            _mockRatingRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(ratingToUpdate); // Simule la récupération du rating
            _mockRatingRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Rating>())).Returns(Task.CompletedTask); // Simule la mise à jour

            // Prépare le modèle DTO mis à jour
            var ratingModel = new RatingModel { MoodysRating = "Aa2", SandPRating = "AA", FitchRating = "A" };

            // Act: Appelle la méthode UpdateAsync pour mettre à jour le rating
            var result = await _ratingService.UpdateAsync(1, ratingModel);

            // Assert: Vérifie que le rating est correctement mis à jour
            result.Should().NotBeNull(); // Vérifie que le résultat n'est pas null
            result.MoodysRating.Should().Be("Aa2"); // Vérifie que la note Moody's a été mise à jour
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnCompletedTask_WhenDeleteIsSuccessful()
        {
            // Arrange: Simule la suppression du rating avec l'ID 1
            _mockRatingRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act: Appelle la méthode DeleteAsync pour supprimer le rating
            await _ratingService.DeleteAsync(1);

            // Assert: Vérifie que la méthode DeleteAsync a été appelée une fois
            _mockRatingRepository.Verify(repo => repo.DeleteAsync(1), Times.Once); // Vérifie que la méthode a été appelée une seule fois
        }
    }
}
