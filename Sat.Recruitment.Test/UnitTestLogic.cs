using Application;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
	public class UnitTestLogic
	{
        [Fact]
        public void CreateUserLogic_NormalUser_LessThan10()
        {
            // Arrange
            IFileName fileName = new FileNameProvider();
            fileName.setFileName("/Files/UsersTest1.txt");
            var logic = new UserLogic(fileName);
            string name = "Juan";
            string email = "Juan@hotmail.com";
            string address = "123 Calle";
            string phone = "+1234567890";
            string userType = "Normal";
            string money = "5";

            // Act
            var result = logic.CreateUserLogic(name, email, address, phone, userType, money);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
            File.Delete(Directory.GetCurrentDirectory() + "/Files/UsersTest1.txt");
        }

        [Fact]
        public void CreateUserLogic_NormalUser_Between10And100()
        {
            // Arrange
            IFileName fileName = new FileNameProvider();
            fileName.setFileName("/Files/UsersTest2.txt");
            var logic = new UserLogic(fileName);
            string name = "Juana";
            string email = "juana@hotmail.com";
            string address = "456 Calle";
            string phone = "+1176543210";
            string userType = "Normal";
            string money = "50";

            // Act
            var result = logic.CreateUserLogic(name, email, address, phone, userType, money);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
            File.Delete(Directory.GetCurrentDirectory() + "/Files/UsersTest2.txt");
        }

        [Fact]
        public void CreateUserLogic_NormalUser_MoreThan100()
        {
            // Arrange
            IFileName fileName = new FileNameProvider();
            fileName.setFileName("/Files/UsersTest3.txt");
            var logic = new UserLogic(fileName);
            string name = "Nicolas";
            string email = "nico@gmail.com";
            string address = "789 Calle";
            string phone = "+55223455";
            string userType = "Normal";
            string money = "150";

            // Act
            var result = logic.CreateUserLogic(name, email, address, phone, userType, money);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
            File.Delete(Directory.GetCurrentDirectory() + "/Files/UsersTest3.txt");
        }
        
        [Fact]
        public void CreateUserLogic_SuperUser_MoreThan100()
        {
            // Arrange
            IFileName fileName = new FileNameProvider();
            fileName.setFileName("/Files/UsersTest4.txt");
            var logic = new UserLogic(fileName);
            string name = "Sam";
            string email = "sam@gmail.com";
            string address = "321 Calle";
            string phone = "+999966666";
            string userType = "SuperUser";
            string money = "200";

            // Act
            var result = logic.CreateUserLogic(name, email, address, phone, userType, money);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
            File.Delete(Directory.GetCurrentDirectory() + "/Files/UsersTest4.txt");
        }

        [Fact]
        public void CreateUserLogic_PremiumUser_MoreThan100()
        {
            // Arrange
            IFileName fileName = new FileNameProvider();
            fileName.setFileName("/Files/UsersTest5.txt");
            var logic = new UserLogic(fileName);
            string name = "Maria";
            string email = "maria@hotmail.com";
            string address = "987 Maria B";
            string phone = "+11111567111";
            string userType = "Premium";
            string money = "500";

            // Act
            var result = logic.CreateUserLogic(name, email, address, phone, userType, money);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
            File.Delete(Directory.GetCurrentDirectory() + "/Files/UsersTest5.txt");
        }

        [Fact]
        public void CreateUserLogic_DuplicateUser()
        {
            // Arrange
            IFileName fileName = new FileNameProvider();
            fileName.setFileName("/Files/UsersTest.txt");
            var logic = new UserLogic(fileName);
            string name = "Agustina";
            string email = "Agustina@gmail.com";
            string address = "Av. Juan G";
            string phone = "+349 1122354215";
            string userType = "Normal";
            string money = "124";

            // Act & Assert
            var result =logic.CreateUserLogic(name, email, address, phone, userType, money);

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }





    }
}
