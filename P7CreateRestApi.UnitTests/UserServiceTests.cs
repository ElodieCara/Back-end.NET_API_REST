using Moq;
using Dot.Net.WebApi.Services;
using Microsoft.AspNetCore.Identity;
using Dot.Net.WebApi.Domain;
using FluentAssertions;
using Dot.Net.WebApi.Models;
using Microsoft.Extensions.Logging;

public class UserServiceTests
{
    private readonly Mock<UserManager<User>> _mockUserManager;
    private Mock<ILogger<UserService>> _mockLogger;
    private readonly UserService _userService;

    // Initialisation des mocks et du UserService avant chaque test
    public UserServiceTests()
    {
        var store = new Mock<IUserStore<User>>();
        _mockUserManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
        _mockLogger = new Mock<ILogger<UserService>>();
        _userService = new UserService(_mockUserManager.Object, _mockLogger.Object);
    }

    // Test pour vérifier si GetAllAsync renvoie la liste des utilisateurs
    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfUsers()
    {
        // Arrange: Configurer une liste d'utilisateurs simulée
        var users = new List<User>
        {
            new User { Id = "1", UserName = "User1", Fullname = "Full User 1", Role = "Admin" },
            new User { Id = "2", UserName = "User2", Fullname = "Full User 2", Role = "User" }
        };

        // Simuler la méthode Users du UserManager pour renvoyer cette liste
        _mockUserManager.Setup(um => um.Users).Returns(users.AsQueryable());

        // Act: Appel de la méthode GetAllAsync
        var result = await _userService.GetAllAsync();

        // Assert: Vérification que le résultat contient bien les utilisateurs attendus
        result.Should().HaveCount(2);
        result.Should().Contain(u => u.Username == "User1" && u.Role == "Admin");
        result.Should().Contain(u => u.Username == "User2" && u.Role == "User");
    }

    // Test pour vérifier si LoginAsync retourne l'utilisateur lorsque les identifiants sont valides
    [Fact]
    public async Task LoginAsync_ShouldReturnUser_WhenCredentialsAreValid()
    {
        // Arrange: Simuler un utilisateur et un mot de passe valide
        var user = new User { Id = "1", UserName = "User1", Fullname = "Full User 1", Role = "Admin" };
        _mockUserManager.Setup(um => um.FindByNameAsync("User1")).ReturnsAsync(user);
        _mockUserManager.Setup(um => um.CheckPasswordAsync(user, "Password123")).ReturnsAsync(true);

        // Act: Appel de la méthode LoginAsync avec des identifiants valides
        var result = await _userService.LoginAsync("User1", "Password123");

        // Assert: Vérification que l'utilisateur est bien renvoyé
        result.Should().NotBeNull();
        result.Username.Should().Be("User1");
        result.Role.Should().Be("Admin");
    }

    // Test pour vérifier que LoginAsync retourne null lorsque les identifiants sont invalides
    [Fact]
    public async Task LoginAsync_ShouldReturnNull_WhenCredentialsAreInvalid()
    {
        // Arrange: Simuler un utilisateur non trouvé (mauvais identifiants)
        _mockUserManager.Setup(um => um.FindByNameAsync("User1")).ReturnsAsync((User)null);

        // Act: Appel de la méthode LoginAsync avec des identifiants incorrects
        var result = await _userService.LoginAsync("User1", "WrongPassword");

        // Assert: Vérification que le résultat est null
        result.Should().BeNull();
    }

    // Test pour vérifier si AddAsync crée un nouvel utilisateur
    [Fact]
    public async Task AddAsync_ShouldReturnNewUser_WhenUserIsCreated()
    {
        // Arrange: Simuler les données du nouvel utilisateur
        var userModel = new UserModel
        {
            Username = "NewUser",
            Fullname = "Full New User",
            Password = "Password123",
            Role = "User"
        };

        // Simuler la création réussie de l'utilisateur par le UserManager
        _mockUserManager.Setup(um => um.CreateAsync(It.IsAny<User>(), "Password123"))
            .ReturnsAsync(IdentityResult.Success);

        // Act: Appel de la méthode AddAsync
        var result = await _userService.AddAsync(userModel, "Password123");

        // Assert: Vérification que l'utilisateur a bien été créé et que les informations sont correctes
        result.Should().NotBeNull();
        result.Username.Should().Be("NewUser");
        result.Role.Should().Be("User");
    }

    // Test pour vérifier si GetByIdAsync renvoie un utilisateur lorsque celui-ci existe
    [Fact]
    public async Task GetByIdAsync_ShouldReturnUser_WhenExists()
    {
        // Arrange: Simuler un utilisateur existant
        var user = new User { Id = "1", UserName = "User1", Fullname = "Full User 1", Role = "Admin" };
        _mockUserManager.Setup(um => um.FindByIdAsync("1")).ReturnsAsync(user);

        // Act: Appel de la méthode GetByIdAsync
        var result = await _userService.GetByIdAsync("1");

        // Assert: Vérification que l'utilisateur renvoyé correspond
        result.Should().NotBeNull();
        result.Username.Should().Be("User1");
    }

    // Test pour vérifier si UpdateAsync met à jour l'utilisateur
    [Fact]
    public async Task UpdateAsync_ShouldUpdateUser_WhenExists()
    {
        // Arrange: Simuler un utilisateur existant
        var user = new User { Id = "1", UserName = "User1", Fullname = "Full User 1", Role = "Admin" };
        _mockUserManager.Setup(um => um.FindByIdAsync("1")).ReturnsAsync(user);
        _mockUserManager.Setup(um => um.UpdateAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);

        // Définir les nouvelles informations utilisateur
        var userModel = new UserModel
        {
            Username = "UpdatedUser",
            Fullname = "Updated Fullname",
            Role = "User"
        };

        // Act: Appel de la méthode UpdateAsync
        var result = await _userService.UpdateAsync("1", userModel);

        // Assert: Vérification que l'utilisateur a bien été mis à jour
        result.Should().NotBeNull();
        result.Username.Should().Be("UpdatedUser");
        result.Fullname.Should().Be("Updated Fullname");
    }

    // Test pour vérifier si DeleteAsync supprime un utilisateur existant
    [Fact]
    public async Task DeleteAsync_ShouldDeleteUser_WhenExists()
    {
        // Arrange: Simuler un utilisateur existant
        var user = new User { Id = "1", UserName = "User1" };
        _mockUserManager.Setup(um => um.FindByIdAsync("1")).ReturnsAsync(user);
        _mockUserManager.Setup(um => um.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

        // Act: Appel de la méthode DeleteAsync
        await _userService.DeleteAsync("1");

        // Assert: Vérification que l'utilisateur a bien été supprimé
        _mockUserManager.Verify(um => um.DeleteAsync(user), Times.Once);
    }
}
