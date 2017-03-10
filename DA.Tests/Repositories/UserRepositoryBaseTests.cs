using DataAccess.DataContext.Default;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Common;
using DataAccess.Repositories.Default;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DA.Tests.Repositories
{
    public class UserRepositoryBaseTests
    {
        private readonly IUserRepository _userRepository;
        public UserRepositoryBaseTests()
        {
            Mock<JsonDataContext> jsonDataContextMock = new Mock<JsonDataContext>(MockBehavior.Strict, new object[] { string.Empty, new Lazy<JArray>() });
            Mock<JsonDataContextFactory<User>> jsonDataContextFactoryMock = new Mock<JsonDataContextFactory<User>>();

            jsonDataContextMock.Setup(x => x.SaveChanges());
            jsonDataContextFactoryMock.Setup(x => x.Create()).Returns(jsonDataContextMock.Object);

            _userRepository = new UserJsonRepository(jsonDataContextFactoryMock.Object);
            FillRepoByUsers();
        }

        [Fact]
        public void GetBy_EmptyInpuParam()
        {
            Assert.Throws(typeof(ArgumentNullException), () => _userRepository.GetBy(null));
        }

        [Theory]
        [MemberData(nameof(GetByFilterData))]
        public void GetBy_DifferentFilters(UserFilterModel filter, int resultCount)
        {
            ICollection<User> resultUsers = new List<User>( _userRepository.GetBy(filter));
            Assert.Equal(resultCount, resultUsers.Count);
        }

        [Fact]
        public void GetBy_FilterById()
        {
            User testUser = _userRepository.Create(CreateTestUser("test10", DateTime.Parse("09-25-1992")));
            ICollection<User> resultUsers = new List<User>(_userRepository.GetBy(new UserFilterModel() { Id = testUser.Id}));
            Assert.NotEmpty(resultUsers);
        }

        public static IEnumerable<object[]> GetByFilterData {
            get {
                return new[]
                {
                    new object[] { new UserFilterModel() { Email  = "test1@mail.com" }, 1 },
                    new object[] { new UserFilterModel() { ToDate  = DateTime.Parse("01-01-2000") }, 3 },
                    new object[] { new UserFilterModel() , 0 }
                };
            }
        }

        private void FillRepoByUsers()
        {
            _userRepository.Create(CreateTestUser("test1", DateTime.Parse("09-25-1992")));
            _userRepository.Create(CreateTestUser("test2", DateTime.Parse("05-30-1995")));
            _userRepository.Create(CreateTestUser("test3", DateTime.Parse("08-01-1999")));
            _userRepository.Create(CreateTestUser("test4", DateTime.Parse("01-01-2001")));
            _userRepository.Create(CreateTestUser("test5", DateTime.Parse("10-23-2005")));
        }

        private User CreateTestUser(string name, DateTime birthday)
        {
            return new User()
            {
                Birthday = birthday,
                Email = name + "@mail.com",
                Name = name
            };
        }
    }
}