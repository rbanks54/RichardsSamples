using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
	public class ContactRepository
	{
		private List<Contact> contacts = new List<Contact>();

		public ContactRepository()
		{
			//http://en.wikipedia.org/wiki/List_of_Characters_in_the_Hunger_Games_trilogy
			contacts.Add(new Contact()
			{
				Id = new Guid(),
				Name = "Katniss Everdeen",
				Account = "88702091",
				Address = "District 12",
				CreditCard = "1234567890123456",
				PinNumber = "1234"
			});
			contacts.Add(new Contact()
			{
				Id = new Guid(),
				Name = "President Snow",
				Account = "23492218",
				Address = "Capitol",
				CreditCard = "2345678901234561",
				PinNumber = "1111"
			});
			contacts.Add(new Contact()
			{
				Id = new Guid(),
				Name = "Finnick Odair",
				Account = "30902724",
				Address = "District 4",
				CreditCard = "3456789012345612",
				PinNumber = "2222"
			});
			contacts.Add(new Contact()
			{
				Id = new Guid(),
				Name = "Peeta Mellark",
				Account = "98375922",
				Address = "District 12",
				CreditCard = "4567890123456123",
				PinNumber = "4321"
			});
		}

		public IQueryable<Contact> Contacts
		{
			get { return contacts.AsQueryable(); }
		}

		public void Add(Contact contact)
		{
			contacts.Add(contact);
		}
	}
}
