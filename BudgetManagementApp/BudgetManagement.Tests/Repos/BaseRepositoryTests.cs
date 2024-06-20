using AutoMapper;
using BudgetManagement.Data;
using BudgetManagement.Data.Entities;
using BudgetManagement.Data.Repos;
using BudgetManagement.Shared;
using BudgetManagement.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShelter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Tests.Repos
{
    public class BaseRepositoryTests<TRepository,T,TModel>
        where TRepository : BaseRepository<T,TModel>
        where T : class , IBaseEntity
        where TModel : BaseModel
    {
        private Mock<BudgetManagementDbContext> mockContext;
        private Mock<DbSet<T>> mockDbSet;
        private Mock<IMapper> mockMapper;
        private TRepository repository;
        [SetUp]
        public void Setup()
        {
            mockContext = new Mock<BudgetManagementDbContext>();
            mockDbSet= new Mock<DbSet<T>>();
            mockMapper = new Mock<IMapper>();
            repository = new Mock<TRepository>(mockContext.Object, mockMapper.Object)
            { CallBase = true }.Object;
        }
        [Test]
        public void MapToModel_ValidEntity_ReturnsMappedModel()
        {
            //arange
            var entity = new Mock<T>();
            var model = new Mock<TModel>();
            mockMapper.Setup(m => m.Map<TModel>(entity.Object)).Returns(model.Object);
            var result=repository.MapToModel(entity.Object);
            Assert.That(result, Is.EqualTo(model.Object));
        }
    }

}
