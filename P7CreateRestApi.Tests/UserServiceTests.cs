using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Tests
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        // Mock Asp.Net Identity User Manager.
        private readonly Mock<UserManager<User>> _userManagerMock;

        public UserServiceTests()
        {
            // Mock all User objects used.
            var userStoreMock = new Mock<IUserStore<User>>();
            var optionsMock = new Mock<IOptions<IdentityOptions>>();
            var passwordHasherMock = new Mock<IPasswordHasher<User>>();
            var userValidators = new List<IUserValidator<User>>();
            var passwordValidators = new List<IPasswordValidator<User>>();
            var keyNormalizerMock = new Mock<ILookupNormalizer>();
            var errorsMock = new Mock<IdentityErrorDescriber>();
            var serviceProviderMock = new Mock<IServiceProvider>();
            var loggerMock = new Mock<ILogger<UserManager<User>>>();
            _userManagerMock = new(
                userStoreMock.Object,
                optionsMock.Object,
                passwordHasherMock.Object,
                userValidators,
                passwordValidators,
                keyNormalizerMock.Object,
                errorsMock.Object,
                serviceProviderMock.Object,
                loggerMock.Object);
            _userService = new UserService(_userRepositoryMock.Object, _userManagerMock.Object);
        }
        /// <summary>User test unit for Create method. 
        /// Check if created User has an Output Model correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void CreateUser_ShouldHaveUserOutputModelReturned()
        {
            // Arrange
            var inputModel = new UserInputModel
            {
                UserName = "UserName",
                FullName = "FullName",
                Role = "Admin",
                Password = "SuperP4ssw0rd!"
            };
            var user = new User
            {
                UserName = inputModel.UserName,
                FullName = inputModel.FullName,
                Role = inputModel.Role
            };
            _userManagerMock.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(m => m.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            // Act
            var outputModel = _userService.Create(inputModel).Result;

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.UserName, outputModel.UserName);
            Assert.Equal(inputModel.FullName, outputModel.FullName);
            Assert.Equal(inputModel.Role, outputModel.Role);
            _userManagerMock.Verify(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Once);
            _userManagerMock.Verify(m => m.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Once);
        }
        /// <summary>User test unit for Delete method.
        /// Check if deleted User has an OutputModel correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteUser_ShouldHaveUserOutputModelReturned()
        {
            // Arrange
            var userExcepted = new User()
            {
                Id = 1,
                UserName = "UserName",
                FullName = "FullName",
                Role = "Admin"
            };
            _userRepositoryMock.Setup(m => m.FindById(1)).Returns(userExcepted);
            _userManagerMock.Setup(m => m.DeleteAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);

            // Act
            var outputModel = _userService.Delete(1).Result;

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(userExcepted.Id, outputModel.Id);
            Assert.Equal(userExcepted.UserName, outputModel.UserName);
            Assert.Equal(userExcepted.FullName, outputModel.FullName);
            Assert.Equal(userExcepted.Role, outputModel.Role);
        }
        /// <summary>User test unit for Delete method.
        /// Check if deleted User does'nt return Output Model (null).</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteUserThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _userRepositoryMock.Setup(m => m.FindById(1));

            // Act
            var outputModel = _userService.Delete(1).Result;

            // Assert
            Assert.Null(outputModel);
        }
        /// <summary>User test unit for Get method.
        /// Check if User OutputModel item properties sent back from Get method
        /// is identical to requested item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetexistingUser_ShouldHaveUserOutputModelReturned()
        {
            // Arrange
            var userExcepted = new User()
            {
                Id = 1,
                UserName = "UserName",
                FullName = "FullName",
                Role = "Admin"
            };
            _userRepositoryMock.Setup(m => m.FindById(1)).Returns(userExcepted);

            // Act
            var outputModel = _userService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(userExcepted.Id, outputModel.Id);
            Assert.Equal(userExcepted.UserName, outputModel.UserName);
            Assert.Equal(userExcepted.FullName, outputModel.FullName);
            Assert.Equal(userExcepted.Role, outputModel.Role);
            _userRepositoryMock.Verify(m => m.FindById(1), Times.Once);
        }
        /// <summary>User test unit for Get method.
        /// Check if not existing User item with Get method send 
        /// back null result.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetUserthatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _userRepositoryMock.Setup(m => m.FindById(1));

            // Act
            var outputModel = _userService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _userRepositoryMock.Verify(m => m.FindById(1), Times.Once);
        }
        /// <summary>User test unit for List method.
        /// Check if List method send back correct User item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListUserWithUsers_ShouldHaveUsersInListReturned()
        {
            // Arrange
            var usersExcepted = new List<User>
            {
                new User
                {
                    Id = 1,
                    UserName = "UserName1",
                    FullName = "FullName1",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    UserName = "UserName2",
                    FullName = "FullName2",
                    Role = "User"
                }
            };
            _userRepositoryMock.Setup(m => m.FindAll()).ReturnsAsync(usersExcepted);

            // Act
            var list = _userService.List().Result;

            // Assert
            Assert.NotNull(list);
            Assert.Equal(usersExcepted.Count, list.Count);
            for (var i = 0; i < usersExcepted.Count; i++)
            {
                Assert.Equal(usersExcepted[i].Id, list[i].Id);
                Assert.Equal(usersExcepted[i].UserName, list[i].UserName);
                Assert.Equal(usersExcepted[i].FullName, list[i].FullName);
                Assert.Equal(usersExcepted[i].Role, list[i].Role);
            }
            _userRepositoryMock.Verify(m => m.FindAll(), Times.Once);
        }
        /// <summary>User test unit for List method.
        /// Check if List method send back User with no items 
        /// if there are no BidList items.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListUserEmpty_ShouldHaveEmptyListReturned()
        {
            // Arrange
            _userRepositoryMock.Setup(m => m.FindAll()).ReturnsAsync(new List<User>());

            // Act
            var list = _userService.List().Result;

            // Assert
            Assert.NotNull(list);
            Assert.Empty(list);
            _userRepositoryMock.Verify(m => m.FindAll(), Times.Once);
        }
        /// <summary>User test unit for Update method.
        /// Check if Update method send back
        /// correct User item properties updated as expected.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void UpdateUser_ShouldHaveUserUpdatedReturned()
        {
            // Arrange
            var userExcepted = new User()
            {
                Id = 1,
                UserName = "UserName",
                FullName = "FullName",
                Role = "Admin"
            };
            var inputModel = new UserInputModel
            {
                UserName = "UserName",
                FullName = "FullName",
                Role = "Admin",
                Password = "SuperP4ssw0rd!"
            };
            _userRepositoryMock.Setup(m => m.FindById(1)).Returns(userExcepted);
            _userManagerMock.Setup(m => m.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(false);
            _userManagerMock.Setup(m => m.GeneratePasswordResetTokenAsync(It.IsAny<User>())).ReturnsAsync("Token");
            _userManagerMock.Setup(m => m.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(m => m.UpdateAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);

            // Act
            var outputModel = _userService.Update(1, inputModel).Result;

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(userExcepted.Id, outputModel.Id);
            Assert.Equal(userExcepted.UserName, outputModel.UserName);
            Assert.Equal(userExcepted.FullName, outputModel.FullName);
            Assert.Equal(userExcepted.Role, outputModel.Role);
            _userManagerMock.Verify(m => m.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Once);
            _userManagerMock.Verify(m => m.GeneratePasswordResetTokenAsync(It.IsAny<User>()), Times.Once);
            _userManagerMock.Verify(m => m.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _userManagerMock.Verify(m => m.UpdateAsync(It.IsAny<User>()), Times.Never);
        }
        /// <summary>User test unit for Update method.
        /// Check if Update method for a not existing item 
        /// send back null result.</summary> 
        /// <remarks></remarks>    
        [Fact]
        public void UpdateUserThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _userRepositoryMock.Setup(m => m.FindById(1));

            // Act
            var outputModel = _userService.Update(1, new UserInputModel
            {
                UserName = "UserName",
                FullName = "FullName",
                Role = "Admin",
                Password = "SuperP4ssw0rd!"
            }).Result;

            // Assert
            Assert.Null(outputModel);
        }
    }
}
