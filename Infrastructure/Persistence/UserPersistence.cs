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
        public static StreamReader ReadUsersFromFile(string filePath)
        {
            var path = Directory.GetCurrentDirectory() + filePath;

            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
        public static bool SaveUserToFile(string user, string filePath)
        {
            var path = Directory.GetCurrentDirectory() +filePath;

			try
			{
                FileStream fileStream = new FileStream(path, FileMode.Append);
                using(StreamWriter writer = new StreamWriter(fileStream))
				{
                    writer.WriteLine(user);                
				}
                return true;
            }
			catch (Exception ex)
			{
                var m = ex.Message; 
                return false;
			}
        }
    }
}
