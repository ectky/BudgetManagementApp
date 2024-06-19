using BudgetManagement.Services;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using Moq;
using NUnit.Framework;


namespace BudgetManagement.Test.Service
{
    public class RoleServiceTests
    {
        private readonly Mock<IRoleRepository> _roleRepositoryMock = new Mock<IRoleRepository>();
        private readonly IRoleService _service;

        public RoleServiceTests()
        {
            _service = new RolesService(_roleRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var roleDto = new RoleDto()
            {

                Name = "God",


            };

            //Act
            await _service.SaveAsync(roleDto);

            //Asert
            _roleRepositoryMock.Verify(x => x.SaveAsync(roleDto), Times.Once());


        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _roleRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCallDeleteAsyncInRepository(int id)
        {
            //Arrange

            //Act
            await _service.DeleteAsync(id);

            //Assert
            _roleRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidRoleId_ThenReturnUser(int roleId)
        {
            //Arrange
            var roleDto = new RoleDto()
            {

                Name = "Boy",
            };
            _roleRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(roleId))))
                .ReturnsAsync(roleDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(roleId);

            //Assert
            _roleRepositoryMock.Verify(x => x.GetByIdAsync(roleId), Times.Once);
            Assert.That(userResult == roleDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidRoleId_ThenReturnDefault(int roleId)
        {
            var role = (RoleDto)default;
            _roleRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(roleId))))
                .ReturnsAsync(role);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(roleId);

            //Assert
            _roleRepositoryMock.Verify(x => x.GetByIdAsync(roleId), Times.Once);
            Assert.That(userResult == role);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var roleDto = new RoleDto
            {
                Name = "Hap",

            };
            _roleRepositoryMock.Setup(s => s.SaveAsync(It.Is<RoleDto>(x => x.Equals(roleDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(roleDto);

            //Assert
            _roleRepositoryMock.Verify(x => x.SaveAsync(roleDto), Times.Once);
        }

    }
}

