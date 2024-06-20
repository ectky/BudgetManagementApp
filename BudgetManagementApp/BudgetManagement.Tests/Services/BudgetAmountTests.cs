using BudgetManagement.Data.Entities;
using BudgetManagement.Services;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Tests.Services
{
    public class BudgetAmountServiceTests
    {
        private readonly Mock<IBudgetAmountRepository> _budgetAmountRepositoryMock = new Mock<IBudgetAmountRepository>();
        private readonly IBudgetAmountService _service;

        public BudgetAmountServiceTests()
        {
            _service = new BudgetAmountsService(_budgetAmountRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var budgetAmountDto = new BudgetAmountDto()
            {
                Name = "приход",
                BudgetId = 1

            };

            //Act
            await _service.SaveAsync(budgetAmountDto);

            //Asert
            _budgetAmountRepositoryMock.Verify(x => x.SaveAsync(budgetAmountDto), Times.Once());


        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _budgetAmountRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _budgetAmountRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBudgetAmount_ThenReturnUser(int budgetAmountId)
        {
            //Arrange
            var budgetAmountDto = new BudgetAmountDto()
            {
                Name = "приход",
                BudgetId = 1
            };
            _budgetAmountRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(budgetAmountId))))
                .ReturnsAsync(budgetAmountDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(budgetAmountId);

            //Assert
            _budgetAmountRepositoryMock.Verify(x => x.GetByIdAsync(budgetAmountId), Times.Once);
            Assert.That(userResult == budgetAmountDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBudgetAmountId_ThenReturnDefault(int budgetAmountId)
        {
            //Arrange
            var budgetAmountDto = new BudgetAmountDto()
            {
                Name = "приход",
                BudgetId = 1
            };
            _budgetAmountRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(budgetAmountId))))
                .ReturnsAsync(budgetAmountDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(budgetAmountId);

            //Assert
            _budgetAmountRepositoryMock.Verify(x => x.GetByIdAsync(budgetAmountId), Times.Once);
            Assert.That(userResult == budgetAmountDto);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var budgetAmountDto = new BudgetAmountDto
            {
                Name = "приход",
                BudgetId = 1

            };
            _budgetAmountRepositoryMock.Setup(s => s.SaveAsync(It.Is<BudgetAmountDto>(x => x.Equals(budgetAmountDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(budgetAmountDto);

            //Assert
            _budgetAmountRepositoryMock.Verify(x => x.SaveAsync(budgetAmountDto), Times.Once);
        }

    }
}
