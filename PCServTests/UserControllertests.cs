using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PCServ.Models.User;
using PCServ.Controllers;
using PCServ.DTO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace PCServTests
{
    [TestFixture]
    class UserControllertests
    {
        private Mock<IUserRepository> _userRepo;
        private User _existingUser;
        private User _exsistingUser2;
        private UserController _userController;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _existingUser = new User("Jan", "Nowak", "jn01", "fajne", "jan.nowak");
            _existingUser.Id = 1;

            _exsistingUser2 = new User("Jan", "Kwiatkowski", "jk02", "faj", "jan.kwiatkowski");
            _exsistingUser2.Id = 2;
            _user = new User("Pior", "Grońko", "pg03", "dfs", "piotr.gronko");

            _userRepo = new Mock<IUserRepository>();
            _userRepo.Setup(r => r.GetUserAsync(1)).ReturnsAsync(_existingUser);
            _userRepo.Setup(r => r.GetUserAsync(2)).ReturnsAsync(_exsistingUser2);
            _userRepo.Setup(r => r.GetUserAsync("jn01")).ReturnsAsync(_existingUser);
            _userRepo.Setup(r => r.GetUserAsync("jk02")).ReturnsAsync(_exsistingUser2);
            _userRepo.Setup(r =>
            r.Contains(
                It.Is<User>(
                    lf => lf.Login == _existingUser.Login
                    && lf.EMail == _existingUser.EMail
                    && lf.Login == _exsistingUser2.Login
                    && lf.EMail == _exsistingUser2.EMail
                    )
                )
            ).ReturnsAsync(true);

            _userRepo.Setup(r =>
            r.Contains(
                It.Is<User>(
                    lf => lf.Login != _existingUser.Login
                    && lf.EMail != _existingUser.EMail
                    && lf.Login != _exsistingUser2.Login
                    && lf.EMail != _exsistingUser2.EMail
                    )
                )
            ).ReturnsAsync(false);
            _userRepo.Setup(r => r.AddUser(It.IsAny<User>()));

            _userController = new UserController(_userRepo.Object);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task GetUser_ReturnuserJsonResult(int id)
        {
            var result = await _userController.Get(id);

            Assert.That(result, Is.TypeOf<JsonResult>());
        }
        [Test]
        [TestCase("jn01")]
        [TestCase("jk02")]
        public async Task Search_ReturnuserJsonResult(string login)
        {
            var result = await _userController.Search(login);

            Assert.That(result, Is.TypeOf<JsonResult>());
        }
        [Test]
        public async Task Create_ReturnOkObject()
        {
            var result = await _userController.Create(_user);
            Assert.That(result, Is.TypeOf<OkResult>());
        }

    }
}
