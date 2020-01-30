using NUnit.Framework;
using Moq;
using PCServ.Services;
using PCServ.Models.Login;
using PCServ.DTO;
using PCServ.Models.User;
using PCServ.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCServ.Models.Register;

namespace PCServTests
{
    [TestFixture]
    public class RegisterControllerTests
    {
        private RegisterForm _validRegisterForm;
        private RegisterForm _invalidRegisterForm;
        private RegisterForm _fakeZeroReturningRegisterForm; // proper to validate but important test to simulating database error
        private Mock<IUserService> _userServiceMock;
        private RegisterController _registerController;

        [SetUp]
        public void Setup()
        {
            // Arrange START
            _validRegisterForm = new RegisterForm()
            {
                FirstName = "Jan", 
                LastName = "Kowalski", 
                EMail = "jan.kowalski@gmail.com", 
                Login = "janjanek1", 
                Password = "ITakWycieknieZMorele"
            };

            _invalidRegisterForm = new RegisterForm();

            _fakeZeroReturningRegisterForm = new RegisterForm()
            {
                FirstName = "Fake",
                LastName = "Fake",
                EMail = "fake@gmail.com",
                Login = "fake",
                Password = "FakeFakeFakeFake"
            };

            _userServiceMock = new Mock<IUserService>();

            _userServiceMock.Setup(
                s => s.RegisterUser(
                    It.Is<RegisterForm>(rf => rf.Equals(_fakeZeroReturningRegisterForm))
                )
            ).Returns(
                Task.FromResult(0)
            );

            _userServiceMock.Setup(
                s => s.RegisterUser(
                    It.Is<RegisterForm>(rf => rf.Equals(_validRegisterForm))
                )
            ).Returns(
                Task.FromResult(1)
            );

            _registerController = new RegisterController(_userServiceMock.Object);
            // Arrange STOP
        }

        [Test]
        public async Task NewAccount_PassValidRegisterForm_ReturnsOkResult()
        {
            // Act
            var result = await _registerController.NewAccount(_validRegisterForm);

            // Assert
            Assert.That(result, Is.TypeOf<OkResult>());
        }

        [Test]
        public async Task NewAccount_PassValidRegisterForm_CallsServiceMethod()
        {
            // Act
            var result = await _registerController.NewAccount(_validRegisterForm);

            // Assert
            _userServiceMock.Verify(s => s.RegisterUser(_validRegisterForm), Times.Once);
        }

        [Test]
        public async Task NewAccount_PassInvalidRegisterForm_ReturnsBadRequestObjectResult()
        {
            // Arrange
            _registerController.ModelState.AddModelError("SomeErrorName", "SomeErrorMessage");

            // Act
            var result = await _registerController.NewAccount(_invalidRegisterForm);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task NewAccount_PassInvalidRegisterForm_ReturnsBadRequestWithSecifiedMessage()
        {
            // Arrange
            _registerController.ModelState.AddModelError("SomeErrorName", "SomeErrorMessage");
            string expectedMessage = "Validation Failed";

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult)await _registerController.NewAccount(_invalidRegisterForm);

            // Assert
            var actualMessage = DynamicObiectPropertyExtractor(result.Value, "message").ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public async Task NewAccount_PassInvalidRegisterForm_DoesNotCallServiceMethod()
        {
            // Arrange
            _registerController.ModelState.AddModelError("SomeErrorName", "SomeErrorMessage");

            // Act
            var result = await _registerController.NewAccount(_invalidRegisterForm);

            // Assert
            _userServiceMock.Verify(s => s.RegisterUser(_validRegisterForm), Times.Never);
        }

        [Test]
        public async Task NewAccount_PassZeroReturningRegisterForm_ReturnsBadRequestObjectResult()
        {
            // Act
            var result = await _registerController.NewAccount(_fakeZeroReturningRegisterForm);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task NewAccount_PassZeroReturningRegisterForm_ReturnsBadRequestWithSpecifiedMessage()
        {
            // Arrange
            string expectedMessage = "Adding to database failed";

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult)await _registerController.NewAccount(_fakeZeroReturningRegisterForm);

            // Assert
            var actualMessage = DynamicObiectPropertyExtractor(result.Value, "message").ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public async Task NewAccount_PassZeroReturningRegisterForm_CallsServiceMethod()
        {
            // Act
            var result = await _registerController.NewAccount(_fakeZeroReturningRegisterForm);

            // Assert
            _userServiceMock.Verify(s => s.RegisterUser(_fakeZeroReturningRegisterForm), Times.Once);
        }

        private object DynamicObiectPropertyExtractor(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}