using Microsoft.AspNetCore.Mvc;
using Moq;
using Rodriguez_Camani_Feresin_Backend;
using Rodriguez_Camani_Feresin_Backend.Models;
using Xunit;
namespace Rodriguez_Camani_Tests
{
    public class RodriguezCamaniTests
    {
        private readonly UserController _usercontroller;
        private readonly Mock<IUserService> _userserviceMock;

        public RodriguezCamaniTests()
        {
            _userserviceMock = new Mock<IUserService>();
            _usercontroller = new UserController(_userserviceMock.Object);
        }

        [Fact]
        public void Get_Ok()
        {

            _userserviceMock.Setup(service => service.GetAllUsers()).Returns(new List<User>());


            var result = _usercontroller.GetUsers();


            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.IsType<List<User>>(okResult.Value);
        }

        [Fact]
        public void Get_UserById()
        {
            int id = 1;
            _userserviceMock.Setup(service => service.GetUserById(id)).Returns(new Client());
            var result = _usercontroller.GetUserById(id);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}