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

namespace Presentation.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
 
        public UsersController()
        {
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser([FromQuery]string? name, [FromQuery]string? email, [FromQuery]string? address, [FromQuery]string? phone, [FromQuery]string? userType, [FromQuery]string? money)
        {
            var errors = "";
            ValidateErrors(name, email, address, phone, ref errors);

            if (errors != null && errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };
			else
			{
                UserLogic.CreateUserLogic(name, email, address, phone, userType, money);
			}
            return null;
        }

        //Validate errors
        private void ValidateErrors(string name, string email, string address, string phone, ref string errors)
        {
            if (name == null)
                //Validate if Name is null
                errors = "The name is required";
            if (email == null)
                //Validate if Email is null
                errors = errors + " The email is required";
            if (address == null)
                //Validate if Address is null
                errors = errors + " The address is required";
            if (phone == null)
                //Validate if Phone is null
                errors = errors + " The phone is required";
        }
    }
}
