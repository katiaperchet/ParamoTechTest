using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Model;
using Infrastructure.Persistence;


namespace Application
{
    public class UserLogic 
	{
        private readonly IFileName provider;
        public UserLogic(IFileName fileName)
		{
            provider = fileName;
		}

		public Result CreateUserLogic(string name, string email, string address, string phone, string userType, string money)
		{
            List<User> _users = new List<User>();
            User newUser = null;
            //decimal percentageAdd=0;

            if (userType == "Normal")
            {
                newUser = new UserNormal(name, email, address, phone, userType, decimal.Parse(money)); 
                //If new user is normal and has more than USD100
                 //percentageAdd = newUser.Money > 100 ? Convert.ToDecimal(0.12) : newUser.Money > 10 ? Convert.ToDecimal(0.8) : 0 ;
                
            }
            else if (userType == "SuperUser")
            {
                newUser = new UserSuper(name, email, address, phone, userType, decimal.Parse(money));

            }
            else if (userType == "Premium")
            {
                newUser = new UserPremium(name, email, address, phone, userType, decimal.Parse(money));

            }
            

            using (StreamReader reader = UserPersistence.ReadUsersFromFile(provider.GetFileName()))
            {
                //Normalize email
                var emailParts = newUser.Email.Split('@');
                var atIndex = emailParts[0].IndexOf("+");
                emailParts[0] = atIndex < 0 ? emailParts[0].Replace(".", "") : emailParts[0].Replace(".", "").Remove(atIndex);
                newUser.Email = string.Join("@", emailParts);

                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString()),
                    };
                    _users.Add(user);
                }
            }
            try
            {
                var isDuplicated = false;
                foreach (var user in _users)
                {
                   if (_users.Exists(x=>x.Email == newUser.Email && x.Phone== newUser.Phone || x.Name == newUser.Name && x.Address == newUser.Address))
                   {
                       isDuplicated = true;
                        break;
                   }               
                }

                if (!isDuplicated)
                {
                    UserPersistence.SaveUserToFile(newUser.ToString(), provider.GetFileName() );
                    return new Result()
                    {
                        IsSuccess = true,
                        Errors = "User Created"
                    };
                }
                else
                {
                    throw new Exception("The user is duplicated");
                }
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }

        }

	}
}
