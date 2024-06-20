using BudgetManagement.Data.Entities;
using BudgetManagement.Data.Repos;
using BudgetManagement.Services;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using Moq;
using NUnit.Framework;



namespace BudgetManagement.Test.Service
{
    public class BudgetServiceTests
    {
        private readonly Mock<IBudgetRepository> _budgetRepositoryMock = new Mock<IBudgetRepository>();
        private readonly IBudgetService _service;

        public BudgetServiceTests()
        {
            _service = new BudgetsService(_budgetRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidDate_ThenSaveAsync()
        {
            //Arrange
            var budgetDto = new BudgetDto
            {
                UserId = 1,
                BudgetCategoryId = 1,
            };
            //Act
            await _service.SaveAsync(budgetDto);
            //Assert
            _budgetRepositoryMock.Verify(x => x.SaveAsync(budgetDto), Times.Once());
        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _budgetRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _budgetRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }
        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBudgetId_ThenReturnUser(int budgetId)
        {
            //Arrange
            var budgetDto = new BudgetDto
            {
                UserId = 1,
                BudgetCategoryId = 1,
            };


            _budgetRepositoryMock.Setup(x => x.GetByIdAsync(It.Is<int>(x => x.Equals(budgetId))))
                .ReturnsAsync(budgetDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(budgetId);
            //Assert
            _budgetRepositoryMock.Verify(x => x.GetByIdAsync(budgetId), Times.Once());
            Assert.That(userResult == budgetDto);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidBudgetId_ThenReturnDefault(int budgetId)
        {
            //Arrange
            var budget = (BudgetDto)default;
            _budgetRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(budgetId))))
            .ReturnsAsync(budget);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(budgetId);

            //Assert
            _budgetRepositoryMock.Verify(x => x.GetByIdAsync(budgetId), Times.Once());
            Assert.That(userResult == budget);
        }
        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var budgetDto = new BudgetDto
            {
                UserId = 1,
                BudgetCategoryId = 1,

            };
            _budgetRepositoryMock.Setup(s => s.SaveAsync(It.Is<BudgetDto>(x => x.Equals(budgetDto))))
                .Verifiable();
            //Act
            await _service.SaveAsync(budgetDto);
            //Assert
            _budgetRepositoryMock.Verify(x => x.SaveAsync(budgetDto), Times.Once());
        }

        [Test]
        public async Task AddBudgetToReport_Should_Call_Repository_With_Correct_Parameters()
        {
            // Arrange
            int budgetId = 1;
            int reportId = 2;
            _budgetRepositoryMock.Setup(repo => repo.AddBudgetToReport(budgetId, reportId)).Returns(Task.CompletedTask);
            // Act
            await _service.AddBudgetToReport(budgetId, reportId);
            // Assert
            _budgetRepositoryMock.Verify(repo => repo.AddBudgetToReport(budgetId, reportId), Times.Once);
        }
        [Test]
        public async Task Transfer_Should_Call_Repository_With_Correct_Parameters()
        {
            // Arrange
            int budgetAmountId = 3;
            int budgetId = 4;
            _budgetRepositoryMock.Setup(repo => repo.Transfer(budgetAmountId, budgetId)).Returns(Task.CompletedTask);
            // Act
            await _service.Transfer(budgetAmountId, budgetId);
            // Assert
            _budgetRepositoryMock.Verify(repo => repo.Transfer(budgetAmountId, budgetId), Times.Once);


        }
    }
}



