using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Presentation.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void CreateUser_SuccesfulResult()
        {
           //Arrange
           var userController = new UsersController();
           //Act
           var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");
           //Assert
           Assert.True(result.IsSuccess);
           Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void CreateUser_DuplicatedField_FailedResult()
        {
            //Arrange
            var userController = new UsersController();
            //Act
            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");
            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }
    }
}
