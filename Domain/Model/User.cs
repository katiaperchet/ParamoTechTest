using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
	public class User
	{
		public User()
		{
		}

		public User(string name, string email, string address, string phone, string userType, decimal money)
		{
			Name = name;
			Email = email;
			Address = address;
			Phone = phone;
			UserType = userType;
			Money = money;
		}

		public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }

		public override string ToString()
		{
			return Name + ","+Email+","+Phone+","+Address+","+UserType+","+ Money.ToString();
		}
	}
}
