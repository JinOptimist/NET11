using BusinessLayer.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerTests.UserServices
{
    public class HomeServicesTest
    {
        private Mock<IUserRepository> _userRepository;
        private HomeServices _homeServices;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _homeServices = new HomeServices(_userRepository.Object);
        }

        [TestCase(1, "Admin")]
        [TestCase(42, "Smile")]
        [TestCase(1024, "Bot")]
        [TestCase(7, "---")]
        public void GetUserById_GetExistUser(int userId, string name)
        {
            // Preparation
            var defaultUser = new User
            {
                Id = userId,
                Name = name
            };
            _userRepository
                .Setup(x => x.Get(userId))
                .Returns(defaultUser);

            // Action
            var userBlm = _homeServices.GetUserById(userId);

            // Assert
            Assert.NotNull(userBlm);
            Assert.AreEqual(userId, userBlm.Id);
            Assert.AreEqual(name, userBlm.Name);
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(30)]
        public void GetUserById_FailOnTryingGetUnexistUser(int userId)
        {
            //Preparation

            //Act

            //Assert
            Assert.Throws<NullReferenceException>(
                () => _homeServices.GetUserById(userId));
        }
    }
}
