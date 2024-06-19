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
    public class BudgetReportServiceTests
    {
        private readonly Mock<IBudgetReportRepository> _budgetReportRepositoryMock = new Mock<IBudgetReportRepository>();
        private readonly IBudgetReportService _service;

        public BudgetReportServiceTests()
        {
            _service = new BudgetReportService(_budgetReportRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var budgetReportDto = new BudgetReportDto()
            {
                BudgetId = 1,
                ReportId = 1
            };

            //Act
            await _service.SaveAsync(budgetReportDto);

            //Asert
            _budgetReportRepositoryMock.Verify(x => x.SaveAsync(budgetReportDto), Times.Once());


        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _budgetReportRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _budgetReportRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithInvalidBudgetReportId_ThenReturnDefault(int budgetReportId)
        {
            //Arrange
            var budgetReportDto = new BudgetReportDto()
            {
                BudgetId = 1,
                ReportId = 1
            };
            _budgetReportRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(budgetReportId))))
                .ReturnsAsync(budgetReportDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(budgetReportId);

            //Assert
            _budgetReportRepositoryMock.Verify(x => x.GetByIdAsync(budgetReportId), Times.Once);
            Assert.That(userResult == budgetReportDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBudgetReportId_ThenReturnDefault(int budgetReportId)
        {
            var budgetReport = (BudgetReportDto)default;
            _budgetReportRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(budgetReportId))))
                .ReturnsAsync(budgetReport);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(budgetReportId);

            //Assert
            _budgetReportRepositoryMock.Verify(x => x.GetByIdAsync(budgetReportId), Times.Once);
            Assert.That(userResult == budgetReport);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var budgetReportDto = new BudgetReportDto
            {
                BudgetId = 1,
                ReportId = 1

            };
            _budgetReportRepositoryMock.Setup(s => s.SaveAsync(It.Is<BudgetReportDto>(x => x.Equals(budgetReportDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(budgetReportDto);

            //Assert
            _budgetReportRepositoryMock.Verify(x => x.SaveAsync(budgetReportDto), Times.Once);
        }

    }
}


