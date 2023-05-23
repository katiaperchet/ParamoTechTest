using System;
using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

using Presentation.Controllers;
using Application.Interfaces;
using Application;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTestController
    {
        [Fact]
        public void CreateUser_SuccesfulResult()
        {
            //Arrange
            IFileName fileName = new FileNameProvider("/Files/Users.txt");
            var userController = new UsersController(fileName);
           //Act
           var result = userController.CreateUser("John", "john@example.com", "Av. John G", "+349 123455", "Normal", "1243");
           //Assert
           Assert.True(result.IsSuccess);
           Assert.Equal("User Created", result.Errors);
           File.Delete(Directory.GetCurrentDirectory()+"/Files/UsersTest3.txt");
        }

        [Fact]
        public void CreateUser_DuplicatedField_FailedResult()
        {
            //Arrange
            IFileName fileName = new FileNameProvider("/Files/UsersTest.txt");
            var userController = new UsersController(fileName);
            //Act
            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");
            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void CreateUser_BlankField_FailedResult()
        {
            //Arrange
            IFileName fileName = new FileNameProvider("/Files/UsersTest.txt");
            var userController = new UsersController(fileName);
            //Act
            var result = userController.CreateUser("", "", "", "", "", "");
            //Assert
            Assert.False(result.IsSuccess);
            Assert.NotEmpty(result.Errors);
        }
    }
}
