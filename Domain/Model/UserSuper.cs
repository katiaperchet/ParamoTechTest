using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
	public class UserSuper : User, IStrategy
	{
		public UserSuper(string name, string email, string address, string phone, string userType, decimal money) : base(name, email, address, phone, userType, money)
		{
			this.Name = name;
			this.Email = email;
			this.Address = address;
			this.Phone = phone;
			this.UserType = userType;
			this.Money = defineGiftUserType(money) * money + money;
		}

		public decimal defineGiftUserType(decimal money)
		{
			return money > 100 ? Convert.ToDecimal(0.20) : 0;
		}
	}
}
