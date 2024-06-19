using BudgetManagement.Data.Entities;
using BudgetManagement.Services;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using Moq;
using NUnit.Framework;


namespace BudgetManagement.Test.Service
{
    public class BudgetCategoryServiceTests
    {
        private readonly Mock<IBudgetCategoryRepository> _budgetCategoryRepositoryMock = new Mock<IBudgetCategoryRepository>();
        private readonly IBudgetCategoryService _service;

        public BudgetCategoryServiceTests()
        {
            _service = new BudgetCategoriesService(_budgetCategoryRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidDate_ThenSaveAsync()
        {
            //Arrange
            var budgetCategoryDto = new BudgetCategoryDto
            {
                Name = "Test"
            };
            //Act
            await _service.SaveAsync(budgetCategoryDto);
            //Assert
            _budgetCategoryRepositoryMock.Verify(x => x.SaveAsync(budgetCategoryDto), Times.Once());
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _budgetCategoryRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _budgetCategoryRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }
        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidLocationId_ThenReturnUser(int budgetCategoryId)
        {
            //Arrange
            var budgetCategoryDto = new BudgetCategoryDto
            {
                Name = "Test"
            };


            _budgetCategoryRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(budgetCategoryId))))
                .ReturnsAsync(budgetCategoryDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(budgetCategoryId);
            //Assert
            _budgetCategoryRepositoryMock.Verify(x => x.GetByIdAsync(budgetCategoryId), Times.Once());
            Assert.That(userResult == budgetCategoryDto);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidLocationId_ThenReturnDefault(int budgetCategoryId)
        {
            //Arrange
            var budgetCategory = (BudgetCategoryDto)default;
            _budgetCategoryRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(budgetCategoryId))))
            .ReturnsAsync(budgetCategory);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(budgetCategoryId);

            //Assert
            _budgetCategoryRepositoryMock.Verify(x => x.GetByIdAsync(budgetCategoryId), Times.Once());
            Assert.That(userResult == budgetCategory);
        }
        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var budgetCategoryDto = new BudgetCategoryDto
            {
                Name = "Test"
            };
            _budgetCategoryRepositoryMock.Setup(s => s.SaveAsync(It.Is<BudgetCategoryDto>(x => x.Equals(budgetCategoryDto))))
                .Verifiable();
            //Act
            await _service.SaveAsync(budgetCategoryDto);
            //Assert
            _budgetCategoryRepositoryMock.Verify(x => x.SaveAsync(budgetCategoryDto), Times.Once());
        }

    }
}