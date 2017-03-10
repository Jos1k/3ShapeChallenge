using DataAccess.DataContext.Default;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Default;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DA.Tests.Repositories
{
    public class RepositoryBaseTests
    {
        private readonly IRepository<User> _repositoryBase;
        public RepositoryBaseTests()
        {
            Mock<JsonDataContext> jsonDataContextMock = new Mock<JsonDataContext>(MockBehavior.Strict, new object[] { string.Empty, new Lazy<JArray>() });
            Mock<JsonDataContextFactory<User>> jsonDataContextFactoryMock = new Mock<JsonDataContextFactory<User>>();

            jsonDataContextMock.Setup(x => x.SaveChanges());
            jsonDataContextFactoryMock.Setup(x => x.Create()).Returns(jsonDataContextMock.Object);

            _repositoryBase = new JsonRepositoryBase<User>(jsonDataContextFactoryMock.Object);
        }

        [Fact]
        public void AddNewItem_ItemAdded()
        {
            User testUser = _repositoryBase.Create(CreateTestUser("test"));

            Assert.NotNull(testUser.Id);
            Assert.NotEmpty(_repositoryBase.GetAll());
        }

        [Fact]
        public void AddTwoUsersWithSameEmail_ExceptionOccur()
        {
            User testUser = CreateTestUser("test");

            _repositoryBase.Create(testUser);
            Assert.Throws(typeof(ArgumentException), () => _repositoryBase.Create(testUser));
        }

        [Fact]
        public void GetById_EmptyInputParameter()
        {
            Assert.Throws(typeof(ArgumentNullException), () => _repositoryBase.GetById(string.Empty));
        }

        [Fact]
        public void GetById_ItemReceived()
        {
            User testUser = _repositoryBase.Create(CreateTestUser("test"));
            User resultUser = _repositoryBase.GetById(testUser.Id);
            Assert.NotNull(resultUser);
        }

        [Fact]
        public void GetAll_AddedTwoItems()
        {

            _repositoryBase.Create(CreateTestUser("test1"));
            _repositoryBase.Create(CreateTestUser("test2"));

            ICollection<User> resultUsers =  new List<User>(_repositoryBase.GetAll());
            Assert.Equal(resultUsers.Count , 2);
        }

        private User CreateTestUser(string name)
        {
            return new User()
            {
                Birthday = DateTime.Now,
                Email = name + "@test.com",
                Name = name
            };
        }
    }
}