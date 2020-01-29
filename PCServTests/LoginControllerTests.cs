using NUnit.Framework;
using Moq;
using PCServ.Services;
using PCServ.Models.Login;
using PCServ.DTO;
using PCServ.Models.User;
using PCServ.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCServTests
{
    [TestFixture]
    public class LoginControllerTests
    {
        private LoginForm _loginForm;
        private User _user;
        private UserDTO _userDto;
        private Mock<IUserService> _userServiceMock;
        private LoginController _loginController;

        [SetUp]
        public void Setup()
        {
            // Arrange START
            _loginForm = new LoginForm() { Login = "ankow", Password = "PiesBurek" };
            _user = new User("Andrzej", "Kowalski", "ankow", "somehash123123!@#!@#", "and@kow.pl") { Token = "somejettoken123!" };
            _userDto = new UserDTO(_user);

            _userServiceMock = new Mock<IUserService>();

            _userServiceMock.Setup(
                s => s.LoginUser(
                    It.Is<LoginForm>(
                        lf => lf.Login == _loginForm.Login
                        && lf.Password == _loginForm.Password
                    )
                )
            ).Returns(
                Task.FromResult(_user)
            );

            _userServiceMock.Setup(
                s => s.LoginUser(
                    It.Is<LoginForm>(
                        lf => lf.Login != _loginForm.Login
                        || lf.Password != _loginForm.Password
                    )
                )
            ).Returns(
                Task.FromResult<User>(null)
            );

            _loginController = new LoginController(_userServiceMock.Object);
            // Arrange STOP
        }

        [Test]
        public async Task Authenticate_PassValidLoginForm_ReturnsOkObjectResult()
        {
            // Act
            var result = await _loginController.Authenticate(_loginForm);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public async Task Authenticate_PassValidLoginForm_ReturnsOkWithValidUserDTO()
        {
            // Act
            OkObjectResult result = (OkObjectResult) await _loginController.Authenticate(_loginForm);

            var actual = (UserDTO) result.Value;

            // Assert
            Assert.True(CheckUserDtoEquality(_userDto, actual));
        }

        [Test]
        public async Task Authenticate_PassValidLoginForm_CallsSerivceMethod()
        {
            // Act
            var result = await _loginController.Authenticate(_loginForm);

            // Assert
            _userServiceMock.Verify(s => s.LoginUser(_loginForm), Times.Once);
        }

        [Test]
        public async Task Authenticate_PassInvalidLoginForm_ReturnsBadRequestObjectResult()
        {
            // Act
            var result = await _loginController.Authenticate(new LoginForm() { Login = "x", Password = "z" });

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task Authenticate_PassInvalidLoginForm_ReturnsBadRequestWithSecifiedMessage()
        {
            // Arrange
            string expectedMessage = "Bad login credentials";

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult) await _loginController.Authenticate(new LoginForm() { Login = "x", Password = "z" });

            // Assert
            var actualMessage = DynamicObiectPropertyExtractor(result.Value, "message").ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public async Task Authenticate_PassInvalidLoginForm_CallsSerivceMethod()
        {
            // Arrage
            var invalidLoginForm = new LoginForm() { Login = "x", Password = "y" };

            // Act
            var result = await _loginController.Authenticate(invalidLoginForm);

            // Assert
            _userServiceMock.Verify(s => s.LoginUser(invalidLoginForm), Times.Once);
        }

        private object DynamicObiectPropertyExtractor(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        private bool CheckUserDtoEquality(UserDTO DTO1, UserDTO DTO2) =>
            DTO1.FirstName == DTO2.FirstName &&
            DTO1.LastName == DTO2.LastName &&
            DTO1.Role == DTO2.Role &&
            DTO1.Token == DTO2.Token;
    }
}