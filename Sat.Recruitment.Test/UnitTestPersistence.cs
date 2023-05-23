using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
	public class UnitTestPersistence
	{
        [Fact]
        public void ReadUsersFromFile_ReturnsStreamReader()
        {
            // Arrange
            var expectedFileName = "/Files/Users.txt";
            var expectedPath = Path.Combine(Directory.GetCurrentDirectory(), "/Files/Users.txt");
            // Act
            var result = UserPersistence.ReadUsersFromFile(expectedFileName);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<StreamReader>(result);
        }
        
        [Fact]
        public void SaveUserToFile_ValidUser_Sucess()
        {
            // Arrange
            var user = "Juan,Juan@gmail.com,+549115412,Paraguay 2464,Normal,1234";
            // Act
            var result = UserPersistence.SaveUserToFile(user, "/Files/UsersTest2.txt");
            // Assert
            Assert.True(result);
            File.Delete(Directory.GetCurrentDirectory()+"/Files/UsersTest2.txt");
        }


    }
}
