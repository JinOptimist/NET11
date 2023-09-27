using BusinessLayerInterfaces.UserServices;
using GamerShop.Services;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;

namespace GamerShopTests.Services
{
    public class AuthServiceTest
    {
        private Mock<IHomeServices> _homeServicesMock;
        private Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private AuthService _authService;

        [SetUp]
        public void Setup()
        {
            _homeServicesMock = new Mock<IHomeServices>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _authService = new AuthService(_homeServicesMock.Object, _httpContextAccessorMock.Object);
        }

        [TestCase(1, "/img/avatars/1.jpg")]
        [TestCase(13, "/img/avatars/13.jpg")]
        [TestCase(42, "/img/avatars/42.jpg")]
        public void GetAvatar_ForLoginUser(int userId, string avatarUrlExpected)
        {
            //Preparation
            var claimsForId = new Claim("Id", userId.ToString());
            var claims = new List<Claim> { claimsForId };
            _httpContextAccessorMock
                .Setup(x => x.HttpContext
                    .User
                    .Claims)
                .Returns(claims);

            //Act
            var avatarUrl = _authService.GetAvatar();

            //Assert
            Assert.AreEqual(avatarUrlExpected, avatarUrl);
        }

        [Test]
        public void GetAvatar_ForGuess()
        {
            //Preparation
            var emptyList = new List<Claim>();
            _httpContextAccessorMock
                .Setup(x => x.HttpContext
                    .User
                    .Claims)
                .Returns(emptyList);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(
                    () => _authService.GetAvatar()
                );
        }
    }
}
