﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Persistence;

namespace Application
{
    public class UserLogic
	{
        
        public static Result CreateUserLogic(string name, string email, string address, string phone, string userType, string money)
		{
            List<User> _users = new List<User>();
            User newUser = new User(name, email, address, phone, userType, decimal.Parse(money));
            decimal percentageAdd=0;

            if (newUser.UserType == "Normal")
            {
                 //If new user is normal and has more than USD100
                 percentageAdd = newUser.Money > 100 ? Convert.ToDecimal(0.12) : newUser.Money > 10 ? Convert.ToDecimal(0.8) : 0 ;
                
            }
            else if (newUser.UserType == "SuperUser" && newUser.Money > 100)
            {
                percentageAdd = Convert.ToDecimal(0.20);
                
            }
            else if (newUser.UserType == "Premium" && newUser.Money > 100)
            {
                percentageAdd = Convert.ToDecimal(2);        
            }
            var gif = newUser.Money * percentageAdd;
            newUser.Money = newUser.Money + gif;

            using (StreamReader reader = UserPersistence.ReadUsersFromFile())
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
                   }               
                }

                if (!isDuplicated)
                {
                    UserPersistence.SaveUserToFile(newUser.ToString());
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
