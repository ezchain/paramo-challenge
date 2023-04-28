using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Request;
using Sat.Recruitment.Domain.Exceptions;
using Sat.Recruitment.Domain.Interfaces.Services;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTest
    {
        [Fact]
        public void Create_User_Creates_Correctly()
        {
            var userService = new Mock<IUserService>();
            var userController = new UsersController(userService.Object);

           var request = new CreateUserRequest()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Phone = "+349 1122354215",
                Address = "Av. Juan G",
                Money = 124

            };
            userService.Setup(s=>s.Create(request)).Returns(request);

            var result = userController.Create(request).Result;


            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Message);
            Assert.NotNull(result.Body);
        }

        [Fact]
        public void Create_User_Fails()
        {
            var userService = new Mock<IUserService>();
            var userController = new UsersController(userService.Object);

            var request = new CreateUserRequest()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                Money = 124
            };
            userService.Setup(s => s.Create(request)).Throws(new DuplicatedUserException());
            var result = userController.Create(request).Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("User is duplicated", result.Message);
            Assert.Null(result.Body);
        }
    }
}
