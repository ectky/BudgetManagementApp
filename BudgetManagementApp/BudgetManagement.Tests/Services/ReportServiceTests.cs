using BudgetManagement.Data.Entities;
using BudgetManagement.Services;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using Moq;
using NUnit.Framework;


namespace BudgetManagement.Test.Service
{
    public class ReportServiceTests
    {
        private readonly Mock<IReportRepository> _reportRepositoryMock = new Mock<IReportRepository>();
        private readonly IReportService _service;

        public ReportServiceTests()
        {
            _service = new ReportsService(_reportRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var reportDto = new ReportDto()
            {

                Name = "кражба",
                Description = "краде се"
                


            };

            //Act
            await _service.SaveAsync(reportDto);

            //Asert
            _reportRepositoryMock.Verify(x => x.SaveAsync(reportDto), Times.Once());


        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _reportRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _reportRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidReportId_ThenReturnUser(int reportId)
        {
            //Arrange
            var reportDto = new ReportDto()
            {

                Name = "кражба",
                Description = "краде се"

            };
            _reportRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(reportId))))
                .ReturnsAsync(reportDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(reportId);

            //Assert
            _reportRepositoryMock.Verify(x => x.GetByIdAsync(reportId), Times.Once);
            Assert.That(userResult == reportDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidReportId_ThenReturnDefault(int reportId)
        {
            var report = (ReportDto)default;
            _reportRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(reportId))))
                .ReturnsAsync(report);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(reportId);

            //Assert
            _reportRepositoryMock.Verify(x => x.GetByIdAsync(reportId), Times.Once);
            Assert.That(userResult == report);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var reportDto = new ReportDto
            {
                Name = "кражба",
                Description = "краде се"


            };
            _reportRepositoryMock.Setup(s => s.SaveAsync(It.Is<ReportDto>(x => x.Equals(reportDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(reportDto);

            //Assert
            _reportRepositoryMock.Verify(x => x.SaveAsync(reportDto), Times.Once);
        }

    }
}

