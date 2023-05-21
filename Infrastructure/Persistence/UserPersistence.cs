using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class UserPersistence
    {
        public static StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
        public static bool SaveUserToFile(string user)
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

			try
			{
                FileStream fileStream = new FileStream(path, FileMode.Append);
                using(StreamWriter writer = new StreamWriter(fileStream))
				{
                    writer.WriteLine(user);                
				}
                return true;
            }
			catch (Exception)
			{
                return false;
			}
        }
    }
}
