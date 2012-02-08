using System;

namespace Contacts
{
	public class Contact
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string CreditCard { get; set; }
		public string PinNumber { get; set; }
		public string Account { get; set; }
	}
}