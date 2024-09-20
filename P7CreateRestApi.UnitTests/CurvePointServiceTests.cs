using Moq;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using P7CreateRestApi.Models.DTOs;
using Dot.Net.WebApi.Repositories;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.UnitTests
{
    public class CurvePointServiceTests
    {
        private readonly Mock<ICurvePointRepository> _mockRepository;
        private readonly CurvePointService _service;

        public CurvePointServiceTests()
        {
            // Création d'un Mock pour ICurvePointRepository
            _mockRepository = new Mock<ICurvePointRepository>();

            // Initialisation du service avec le Mock
            _service = new CurvePointService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfCurvePoints()
        {
            // Arrange
            // Création d'une liste fictive de CurvePoints
            var curvePoints = new List<CurvePoint>
            {
                new CurvePoint { Id = 1, CurveId = 100, Term = 1.0, CurvePointValue = 2.0 },
                new CurvePoint { Id = 2, CurveId = 200, Term = 1.5, CurvePointValue = 2.5 }
            };

            // Configuration du mock pour retourner cette liste lorsque GetAllAsync est appelé
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(curvePoints);

            // Act
            // Appel de la méthode GetAllAsync du service
            var result = await _service.GetAllAsync();

            // Assert
            // Vérification que le résultat contient bien les CurvePoints attendus
            result.Should().HaveCount(2);
            result.Should().Contain(cp => cp.Id == 1 && cp.CurveId == 100);
            result.Should().Contain(cp => cp.Id == 2 && cp.CurveId == 200);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCurvePoint_WhenExists()
        {
            // Arrange
            // Création d'un CurvePoint fictif
            var curvePoint = new CurvePoint { Id = 1, CurveId = 100, Term = 1.0, CurvePointValue = 2.0 };

            // Configuration du mock pour retourner ce CurvePoint lorsque GetByIdAsync est appelé avec l'ID 1
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(curvePoint);

            // Act
            // Appel de la méthode GetByIdAsync du service
            var result = await _service.GetByIdAsync(1);

            // Assert
            // Vérification que le CurvePoint retourné correspond à celui attendu
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.CurveId.Should().Be(100);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenCurvePointDoesNotExist()
        {
            // Arrange
            // Configuration du mock pour retourner null lorsque GetByIdAsync est appelé avec un ID inexistant
            _mockRepository.Setup(repo => repo.GetByIdAsync(999)).ReturnsAsync((CurvePoint)null);

            // Act
            // Appel de la méthode GetByIdAsync du service avec un ID inexistant
            var result = await _service.GetByIdAsync(999);

            // Assert
            // Vérification que le résultat est null
            result.Should().BeNull();
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNewCurvePoint_WhenAddedSuccessfully()
        {
            // Arrange
            // Création d'un DTO fictif à ajouter
            var curvePointDto = new CurvePointDto { CurveId = 100, Term = 1.0, CurvePointValue = 2.0 };

            // Configuration du mock pour simuler l'ajout et retourner un CurvePoint avec un ID généré
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<CurvePoint>()))
                .Callback<CurvePoint>(cp => cp.Id = 1)  // Simule l'ajout en générant un ID
                .Returns(Task.CompletedTask);

            // Act
            // Appel de la méthode AddAsync du service
            var result = await _service.AddAsync(curvePointDto);

            // Assert
            // Vérification que le CurvePoint ajouté contient l'ID généré
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.CurveId.Should().Be(100);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedCurvePoint_WhenUpdateIsSuccessful()
        {
            // Arrange
            // Création d'un CurvePoint fictif existant
            var existingCurvePoint = new CurvePoint { Id = 1, CurveId = 100, Term = 1.0, CurvePointValue = 2.0 };

            // Configuration du mock pour retourner ce CurvePoint existant
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingCurvePoint);
            _mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<CurvePoint>())).Returns(Task.CompletedTask);

            // Création du DTO de mise à jour
            var updatedCurvePointDto = new CurvePointDto { CurveId = 200, Term = 2.0, CurvePointValue = 3.0 };

            // Act
            // Appel de la méthode UpdateAsync du service
            var result = await _service.UpdateAsync(1, updatedCurvePointDto);

            // Assert
            // Vérification que le CurvePoint a bien été mis à jour
            result.Should().NotBeNull();
            result.CurveId.Should().Be(200);
            result.Term.Should().Be(2.0);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteCurvePoint_WhenExists()
        {
            // Arrange
            // Configuration du mock pour simuler l'existence d'un CurvePoint à supprimer
            _mockRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            // Appel de la méthode DeleteAsync du service
            await _service.DeleteAsync(1);

            // Assert
            // Vérification que la méthode DeleteAsync du repository a été appelée une fois
            _mockRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }
    }
}
