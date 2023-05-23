using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Persistence;
using Application;
using Application.Interfaces;

namespace Presentation.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly UserLogic logic;
        public UsersController(IFileName fileName)
        {
            logic = new UserLogic(fileName);
        }

		[HttpPost]
		[Route("/create-user")]
		public Result CreateUser(string name, string email, string address, string phone, string userType, string money)
		{
			var errors = "";
			ValidateErrors(name, email, address, phone, ref errors);

            if (!string.IsNullOrEmpty(errors))
            {
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };
            }
            else
            {
                return logic.CreateUserLogic(name, email, address, phone, userType, money);
            }
			
		}

        //Validate errors
        private void ValidateErrors(string name, string email, string address, string phone, ref string errors)
        {
            if (string.IsNullOrEmpty(name))
                errors += "The name is required-";
            if (string.IsNullOrEmpty(email))
                errors += " The email is required-";
            if (string.IsNullOrEmpty(address))
                errors += " The address is required-";
            if (string.IsNullOrEmpty(phone))
                errors += " The phone is required-";
        }
    }
}
