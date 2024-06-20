using BudgetManagement.Data.Entities;
using BudgetManagement.Services;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using Moq;
using NUnit.Framework;


namespace BudgetManagement.Test.Service
{
    public class FinanceGoalServiceTests
    {
        private readonly Mock<IFinanceGoalRepository> _financeGoalRepositoryMock = new Mock<IFinanceGoalRepository>();
        private readonly IFinanceGoalService _service;

        public FinanceGoalServiceTests()
        {
            _service = new FinanceGoalsService(_financeGoalRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var financeGoalDto = new FinanceGoalDto()
            {
               UserId = 21,
               BudgetId = 122

            };

            //Act
            await _service.SaveAsync(financeGoalDto);

            //Asert
            _financeGoalRepositoryMock.Verify(x => x.SaveAsync(financeGoalDto), Times.Once());


        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _financeGoalRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _financeGoalRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidfinanceGoalId_ThenReturnUser(int financeGoalId)
        {
            //Arrange
            var financeGoalDto = new FinanceGoalDto()
            {
                UserId = 21,
                BudgetId = 122
            };
            _financeGoalRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(financeGoalId))))
                .ReturnsAsync(financeGoalDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(financeGoalId);

            //Assert
            _financeGoalRepositoryMock.Verify(x => x.GetByIdAsync(financeGoalId), Times.Once);
            Assert.That(userResult == financeGoalDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidfinanceGoalId_ThenReturnDefault(int financeGoalId)
        {
            var financeGoal = (FinanceGoalDto)default;
            _financeGoalRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(financeGoalId))))
                .ReturnsAsync(financeGoal);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(financeGoalId);

            //Assert
            _financeGoalRepositoryMock.Verify(x => x.GetByIdAsync(financeGoalId), Times.Once);
            Assert.That(userResult == financeGoal);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var financeGoalDto = new FinanceGoalDto
            {
                UserId = 21,
                BudgetId = 122

            };
            _financeGoalRepositoryMock.Setup(s => s.SaveAsync(It.Is<FinanceGoalDto>(x => x.Equals(financeGoalDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(financeGoalDto);

            //Assert
            _financeGoalRepositoryMock.Verify(x => x.SaveAsync(financeGoalDto), Times.Once);
        }

    }
}

